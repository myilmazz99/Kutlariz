module.exports = ({ options }) => {
    var plugins = [];
    if (options.env === 'production') {
        plugins.push(require('autoprefixer'));
        plugins.push(require('cssnano'));
    }

    return {
        plugins
    }
}