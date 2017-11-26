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
                    password: request.password,
                    username: request.username
                };

                auth.create(
                    new User(user),
                    error => status(res, false, error),
                    user => { //onSuccess
                        delete user.password;
                        status(res, true, user)
                    }
                )
            });
        app.route('/account/login')
            .post((req, res) => {
                const request = req.body;

                const user = {
                    username: request.username,
                    password: request.password
                };

                console.log('user', user);

                auth.read(
                    new User(user),
                    error => status(res, false, error),
                    user => { //onSuccess
                        delete user.password;
                        status(res, true, user)
                    }
                )
            });
    }
};