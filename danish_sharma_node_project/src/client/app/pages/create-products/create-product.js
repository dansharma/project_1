import tmplCreateProduct from './create-product.ejs';
import ProductService from './product.service.js';

const productService = new ProductService('http://localhost:3000');

export default async () => {
    const initData = await onInit(); 
    const strCreateProduct = tmplCreateProduct(initData); 
    document.getElementById('app').insertAdjacentHTML('beforeend', strCreateProduct);

    onRender();  
}

export const onInit = async () => {
    const urlParams = new URLSearchParams(window.location.search);
    const productId = urlParams.get('id');
    let product = null;

    if (productId) {
        try {
            product = await productService.findProduct(productId);
            return { product }; // Return product data to populate the form
        } catch (error) {
            console.error('Error finding product:', error);
        }
    }

    return { product }; 
};

export const onRender = () => {
    const { product } = onInit();

    if (product) {
        document.getElementById('productName').value = product.name;
        document.getElementById('productDescription').value = product.description;
        document.getElementById('productStock').value = product.stock;
        document.getElementById('productPrice').value = product.price;
        document.getElementById('formHeading').innerText = 'Edit Product'; 

        
        document.getElementById('productName').disabled = true;
    }

    const form = document.getElementById('productForm');
    form.addEventListener('submit', async (event) => {
        event.preventDefault();

        if (!validateForm(form)) {
            return;
        }

        const productName = document.getElementById('productName').value;
        const productDescription = document.getElementById('productDescription').value;
        const productStock = parseInt(document.getElementById('productStock').value, 10);
        const productPrice = parseFloat(document.getElementById('productPrice').value);

        try {
            if (!product) {
                const exists = await productExists(productName);
                if (exists) {
                    showMessage('Product already exists', 'danger');
                    return;
                }
            }

            const productData = {
                name: productName,
                description: productDescription,
                stock: productStock,
                price: productPrice
            };

            if (product) {
                const result = await productService.updateProduct(product._id, productData);
                console.log('Product updated:', result);
                showMessage('Product edited successfully', 'success');
            } else {
                const result = await productService.addProduct(productData);
                console.log('Product added:', result);
                showMessage('Product added successfully', 'success');
            }

            window.location.href = 'list.html';
        } catch (error) {
            console.error(`Error ${product ? 'updating' : 'adding'} product:`, error);
            showMessage(`Error ${product ? 'updating' : 'adding'} product`, 'danger');
        }
    });
}

const validateForm = (form) => {
    let isValid = true;
    form.querySelectorAll('input, textarea').forEach((input) => {
        if (!input.checkValidity()) {
            isValid = false;
            input.classList.add('is-invalid');
        } else {
            input.classList.remove('is-invalid');
        }
    });
    return isValid;
}

const productExists = async (name) => {
    try {
        const products = await productService.listProducts(1, 1000);
        return products.some(product => product.name.toLowerCase() === name.toLowerCase());
    } catch (error) {
        console.error('Error checking if product exists:', error);
        return false;
    }
}

const showMessage = (message, type) => {
    const messageDiv = document.getElementById('message');
    messageDiv.textContent = message;
    messageDiv.className = `alert alert-${type}`;
    messageDiv.style.display = 'block';
}
