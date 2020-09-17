var path = require('path');
var MiniCssExtractPlugin = require("mini-css-extract-plugin");
var { CleanWebpackPlugin } = require('clean-webpack-plugin');
var ImageminPlugin = require('imagemin-webpack-plugin').default;
var imageminMozjpeg = require('imagemin-mozjpeg');

var outputDir = "wwwroot/assets";

module.exports = (env, argv) => {
    return {
        mode: argv.mode === "production" ? "production" : "development",
        entry: './src/js/main.js',
        output: {
            filename: '[name].bundle.js',
            chunkFilename: '[name].bundle.js',
            path: path.resolve(__dirname, outputDir),
            publicPath: '/assets/',
            libraryTarget: 'var',
            library: 'myModule'
        },
        module: {
            rules: [
                {
                    test: /\.[s]?[ac]ss$/,
                    use: [
                        MiniCssExtractPlugin.loader,
                        'css-loader',
                        {
                            loader: 'postcss-loader',
                            options: {
                                config: {
                                    ctx: {
                                        env: argv.mode
                                    }
                                }
                            }
                        },
                        'sass-loader'
                    ]
                },
                {
                    test: /\.(png|jpeg|jpg|svg)$/,
                    loader: 'file-loader',
                    options: {
                        name: '[name].[ext]',
                        outputPath: 'img/',
                        relativePath: true,
                        publicPath:'../img/'
                    }
                },
                { test: /\.js$/, exclude: /node_modules/, loader: "babel-loader" }
            ]
        },
        plugins: [
            new CleanWebpackPlugin(),
            new MiniCssExtractPlugin({
                filename: '/css/bundle.css'
            }),
            new ImageminPlugin({
                disable: argv.mode !== 'production',
                pngquant: {
                    quality: '75-90'
                },
                jpegtran: {
                    progressive: false
                },
                plugins: [
                    imageminMozjpeg({
                        quality:70
                    })
                ]
            })
        ]
    }
}