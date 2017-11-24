const data = require('../utils/data');

module.exports = {
    init: (app, status) => {
        app.route('/data/get')
            .post((req, res) => {
                const request = req.body,
                    path = request.path || "",
                    key = request.key || undefined;

                console.log('req', req.body);

                data.get(path, key, data => {
                    console.log('get', data);
                    status(res, true, data);
                })
            });
        app.route('/data/set')
            .post((req, res) => {
                const request = req.body,
                    path = request.path || "",
                    key = request.key || undefined;

                let obj = request;
                delete obj.path;
                delete obj.key;

                data.set(path, key, obj);
                status(res, true);
            })
    }
};