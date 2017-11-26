module.exports = {
    createFrom: (template) => {
        return class {
            constructor(obj){
                Object.keys(Object.assign({}, obj, template)).forEach(e => this[e] = obj[e] !== undefined ? obj[e] : template[e]);
            }
        };
    }
};