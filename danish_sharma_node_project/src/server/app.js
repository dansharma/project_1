// app.js
import express from 'express';
import mongoose from 'mongoose';
import router from './routes/router.js'; 
import path from 'path';
import { fileURLToPath } from 'url';
import { LoggingMiddleware } from './middleware/logging.js';
import { ErrorHandlingMiddleware } from './middleware/errorHandling.js';
import cors from 'cors';

const app = express();
const __filename = fileURLToPath(import.meta.url);
const __dirname = path.dirname(__filename);

app.use(cors());  
app.use(express.json());
app.use(LoggingMiddleware);
app.use(router);
app.use(express.static(path.join(__dirname, '../client')));
app.use("/node_modules", express.static(path.join(__dirname, '../../node_modules')));
app.use(ErrorHandlingMiddleware);
app.options('*', cors()); 


export default app;
