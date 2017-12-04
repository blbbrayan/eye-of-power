const
    auth = require('../utils/auth'),
    User = require('../models/user');
    accounts = ([1, 2, 3, 4, 5, 6].map(i => {
        return {username: `admin${i}`, email: `admin${i}@tls.com`, password: `admin`}
    }))
;

module.exports = {
    init: (app, status) => {
        app.route('/test/account')
            .get((req, res) => {
                accounts.forEach(user => {
                    console.log('user', new User(user));
                    auth.create(
                        new User(user),
                        error => console.log('error', error),
                        user => console.log('new user', user)
                    )
                });
                res.send('done');
            });
        app.route('/test/que')
            .get((req, res) => {

                let accountData = [];
                accounts.forEach(user => {
                    auth.read(
                        user,
                        error => console.log('error', error),
                        user => {console.log('user', user); accountData.push(user)}
                    )
                });

                let listener = setInterval(()=>{
                    if(accountData.length === 6){
                        clearInterval(listener);
                        res.send(accountData);
                    }
                }, 100);
            })
    }
};