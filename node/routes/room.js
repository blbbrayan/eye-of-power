const data = require('../utils/data');

module.exports = {
    init: (app, status) => {
        app.route('/room')
            .post((req, res) => {
                const
                    request = req.body,
                    accountId = request.accountId;


                console.log('req', req.body);

                data.get(path, key, data => {
                    console.log(data);
                    status(res, true, data);
                })
            });
    }
};