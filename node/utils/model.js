module.exports = {
    createFrom: (template) => {
        return class {
            constructor(obj){
                for(let e in template)
                    this[e] = obj[e] ? obj[e] : template[e];
            }
        };
    }
};