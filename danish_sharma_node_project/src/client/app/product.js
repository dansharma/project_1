// Product.js
function Product(name, price, stock, description) {
    this.name = name;
    this.price = price;
    this.stock = stock;
    this.description = description;
}

Product.prototype.toString = function() {
    return `${this.name}: $${this.price}, Stock: ${this.stock}, Description: ${this.description}`;
}

export default Product;
