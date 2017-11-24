const
    auth = require('../utils/auth'),
    User = require('../models/user');

module.exports = {
    init: (app, status) => {
        app.route('/account/signup')
            .post((req, res) => {
                const request = req.body;

                const user = {
                    email: request.email,
                    password: request.password
                };

                auth.create(
                    new User(user),
                    error => { //onFail
                        status(res, false, error)
                    },
                    (userRecord, uid) => { //onSuccess
                        console.log('userRecord', userRecord);
                        status(res, true, userRecord)
                    }
                )
            });
        app.route('/account/login')
            .post((req, res) => {
                const request = req.body;

                const user = {
                    email: request.email,
                    password: request.password
                };

                auth.read(
                    new User(user),
                    error => { //onFail
                        status(res, false, error)
                    },
                    (userRecord, uid) => { //onSuccess
                        console.log('userRecord', userRecord);
                        status(res, true, userRecord)
                    }
                )
            });
    }
};