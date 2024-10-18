import { validationResult } from 'express-validator';
import Product from '../../models/Product.js';

export const createProduct = async (req, res, next) => {
    const errors = validationResult(req);
    if (!errors.isEmpty()) {
        return res.status(400).json({ errors: errors.array() });
    }

    const { name, price, stock, description } = req.body;
    try {
        const newProduct = new Product({ name, price, stock, description });
        await newProduct.save();
        res.status(201).json(newProduct);
    } catch (error) {
        next(error);
    }
};
