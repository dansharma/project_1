import HtmlWebpackPlugin from 'html-webpack-plugin';
import MiniCssExtractPlugin from 'mini-css-extract-plugin';
import path from 'path';
import { fileURLToPath } from 'url';

const isProduction = process.env.NODE_ENV == "production";
const __filename = fileURLToPath(import.meta.url);
const __dirname = path.dirname(__filename);

const stylesHandler = MiniCssExtractPlugin.loader;

const config = {
 
  entry: './src/client/app/main.js',

 
  output: {
    path: path.resolve(__dirname, 'dist'),
    filename: 'js/[name].[contenthash].js',
    clean: true,
  },

  
  devServer: {
    open: true,
    host: 'localhost',
    port: 3000,
    historyApiFallback: true, 
    static: {
      directory: path.resolve(__dirname, 'dist'),
    },
  },

  // Plugins configuration
  plugins: [
    
    new HtmlWebpackPlugin({
      template: './src/client/app/pages/home/home.ejs',
      filename: 'index.html', // Output HTML file name
      inject: 'body', 
      minify: isProduction, 
    }),
    
    new MiniCssExtractPlugin({
      filename: 'css/[name].[contenthash].css', 
    }),
  ],

  // Module rules for processing different types of files
  module: {
    rules: [
      // Process JavaScript files using Babel
      {
        test: /\.(js|jsx)$/i,
        loader: 'babel-loader',
        exclude: /node_modules/,
      },
      // Process CSS files using MiniCssExtractPlugin and css-loader
      {
        test: /\.css$/i,
        use: [stylesHandler, 'css-loader'],
      },
      // Process EJS templates using ejs-compiled-loader
      {
        test: /\.ejs$/,
        use: {
          loader: 'ejs-compiled-loader',
          options: {
            htmlmin: true,
            htmlminOptions: {
              removeComments: true,
            },
          },
        },
      },
      
      {
        test: /\.(png|jpg|gif|webp|avif)$/i,
        type: 'asset/resource',
        generator: {
          filename: 'img/[name][ext]', 
        },
      },
      {
        test: /\.(eot|svg|ttf|woff|woff2)$/i,
        type: 'asset/resource',
        generator: {
          filename: 'fonts/[name][ext]', 
        },
      },
    ],
  },

  mode: isProduction ? 'production' : 'development',
};

export default config;
