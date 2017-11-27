const data = require('../utils/data'),
    User = require('../models/user');

module.exports = {
    init: (app, status) => {
        app.route('/room')
            .post((req, res) => {
                const r = req.body;

                const user = new User({
                    email: r.email,
                    password: r.password,
                    username: r.username,
                    characters: r.characters
                });

                const selcetedCharacter = r.selectedCharacter;


                console.log('req', req.body);

                data.get(path, key, data => {
                    console.log(data);
                    status(res, true, data);
                })
            });
    }
};