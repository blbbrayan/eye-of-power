const data = require('../utils/data');

module.exports = {
    init: (app, status) => {
        app.route('/packet')
            .post((req, res) => {
                const
                    request = req.body,
                    accountId = request.accountId;

                //todo: build game packet based on account status
            });
    }
};