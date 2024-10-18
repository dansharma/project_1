import tmplListProduct from './list-product.ejs';
import ProductService from './product.service.js';

const productService = new ProductService('http://localhost:3000');

export default async () => {
    const initData = await onInit(); 
    const strListProduct = tmplListProduct(initData); 
    document.getElementById('app').insertAdjacentHTML('beforeend', strListProduct);

    
    onRender();
}

export const onInit = async () => {
    let currentPage = 1;
    let perPage = 10;

    try {
        const products = await productService.listProducts(currentPage, perPage);
        return { products, currentPage, perPage }; 
    } catch (error) {
        console.error('Error loading products:', error);
        return { products: [], currentPage, perPage }; 
    }
};

export const onRender = () => {
  
    let productIdToDelete = '';
    const { products, currentPage, perPage } = onInit();

    const productList = document.getElementById('productList');
    const spinner = document.getElementById('spinner');

    if (spinner) spinner.style.display = 'block';
    if (productList) productList.style.display = 'none';

    try {
        if (products.length === 0) {
            productList.innerHTML = '<div class="col-12"><p class="text-white bg-dark">The shop is currently closed.</p></div>';
        } else {
            products.forEach(product => {
                const col = document.createElement('div');
                col.className = 'col-md-4 mb-4';
                const card = `
                    <div class="card shadow-lg bg-black text-white" style="width: 20rem;">
                        <img src="./img/Thumb_450_b7.avif" class="card-img-top" alt="Product Image" style="height: 250px; object-fit: cover;">
                        <div class="card-body">
                            <h5 class="card-title text-white">${product.name}</h5>
                            <p class="card-text text-white">Price: $${product.price.toFixed(2)}</p>
                            <p class="card-text text-white">Quantity: ${product.stock}</p>
                            <p class="card-text text-white">Description: ${product.description}</p>
                            <div class="d-flex justify-content-between align-items-center mt-3">
                                <button class="btn btn-success add-to-cart-btn" data-id="${product._id}">Add to cart</button>
                                <button class="btn btn-primary edit-btn" data-id="${product._id}">Edit</button>
                                <button class="btn btn-danger delete-btn" data-bs-toggle="modal" data-bs-target="#deleteConfirmationModal" data-id="${product._id}">Delete</button>
                            </div>
                        </div>
                    </div>`;
                col.innerHTML = card;
                productList.appendChild(col);
            });
        }
    } catch (error) {
        console.error('Error loading products:', error);
    } finally {
        if (spinner) spinner.style.display = 'none';
        if (productList) productList.style.display = 'flex';
    }

    document.getElementById('confirmDeleteBtn').addEventListener('click', async function () {
        try {
            await productService.deleteProduct(productIdToDelete);
            onRender(); 
            console.log('Product deleted successfully');
        } catch (error) {
            console.error('Failed to delete product:', error);
        }
        const deleteModal = bootstrap.Modal.getInstance(document.getElementById('deleteConfirmationModal'));
        deleteModal.hide();
    });

    document.getElementById('perPage').addEventListener('change', function () {
        perPage = parseInt(this.value, 10);
        onRender(); 
    });

    document.getElementById('productList').addEventListener('click', function (event) {
        if (event.target.matches('.delete-btn')) {
            productIdToDelete = event.target.getAttribute('data-id');
        }
        if (event.target.matches('.edit-btn')) {
            const productId = event.target.getAttribute('data-id');
            window.location.href = `add.html?id=${encodeURIComponent(productId)}`;
        }
    });

   
    onRender();
}
