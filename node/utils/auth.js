const data = require('./data');
const passwordHash = require('password-hash');

function createUser(user, fail, success) {
    const create = () => {
        user.password = passwordHash.generate(user.password);
        data.set('user', user.username, user);
        success(user);
    };
    data.get('user', user.username, userData =>
        userData.username === undefined
            ? data.database('user').orderByChild('email').equalTo(user.email).once('value').then(snapshot =>
                snapshot.val() !== null ? fail({code: 'email-taken', error: `email "${user.email}" taken`}) : create()
            )
            : fail({code: 'username-taken', error: `username "${user.username}" taken`})
    )
}

function getUser(user, fail, success) {
    data.get('user', user.username, userData => {
        if (userData === null)
            return fail({code: 'username-not-found', error: `username "${user.username}" not found`});
        if(!passwordHash.verify(user.password, userData.password))
            return fail({code: 'incorrect-password', error: 'incorrect password'});
        success(userData);
    });
}

function updateUser(user, fail, success) {
    data.get('user', user.username, userData => {
        if(user.password === userData.password){

        } else{

        }
    })
}

module.exports = {
    create: createUser,
    read: getUser,
    update: updateUser
};