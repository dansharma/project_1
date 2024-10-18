
import app from './app.js'; 
import mongoose from 'mongoose';

const PORT = process.env.PORT || 3000;

const startServer = async () => {
    try {
        await mongoose.connect('mongodb://localhost:27017/inft2202', {
            useNewUrlParser: true,
            useUnifiedTopology: true
        });
        console.log('Connected to the database!');
        app.listen(PORT, () => {
            console.log(`Server running on port ${PORT}`);
        });
    } catch (error) {
        console.error('Failed to connect to MongoDB:', error);
        process.exit(1);
    }
};

startServer();
