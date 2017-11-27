const data = require('../utils/data'),
    Que = require('../models/que'),
    User = require('../models/user');

function _toUser(r) {
    return new User({
        email: r.email,
        password: r.password,
        username: r.username,
        characters: r.characters
    });
}

function _pushUser(user, selectedCharacter, que) {
    que.users.push({
        username: user.username,
        character: selectedCharacter
    });
    return que;
}

function _createQue(user, selectedCharacter) {
    const que = new Que({
        users: [{username: user.username, character: selectedCharacter}]
    });
    user.queId = data.add('que', que); // add que to queList
    data.set('user', user.username, user); // save user
    return user;
}

function _joinQue(user, selectedCharacter, que) {
    que = _pushUser(user, selectedCharacter, que);
    user.queId = que.id;
    data.set('user', user.username, user); // save user
    data.set('que', que.id, que); // save que
    return user;
}

function _startGame(user, selectedCharacter, que) {
    data.remove('que', que.id);
    que = _pushUser(user, selectedCharacter, que);

    //todo: create game with que here
    const roomId = "";//todo: roomId

    data.database('user').orderByChild('queId').equalTo(que.id).once('value').then(snapshot => {
        const users = [user].concat(snapshot.val());
        users.forEach(queUser => {
            queUser.queId = "";
            queUser.roomId = roomId;
            queUser.que = false;
            data.set('user', queUser.username, queUser);
        });
        user.que = false;
        user.roomId = roomId;
        return user;
    });
}

module.exports = {
    init: (app, status) => {
        app.route('/que')
            .post((req, res) => {
                const
                    user = _toUser(req.body),
                    selectedCharacter = req.body.selectedCharacter;

                console.log('user', user);
                console.log('selectedCharacter', selectedCharacter);

                data.get('user', user.username, userData => {
                    console.log('passwords', user.password === userData.password, user.password, userData.password);
                    if (user.password === userData.password) { // check if user is authenticated
                        user.que = true;
                        data.get('que', '', queList => {
                            queList = queList || [];
                            const _run = fn => fn(user, selectedCharacter, queList[0]),
                                updatedUser = _run( queList.length > 0 // if queList has room open
                                        ? queList[0].length + 1 < 6 ? _joinQue : _startGame // if queList is not full once you joined
                                        : _createQue); // create que
                            status(res, true, updatedUser);
                        })
                    } else
                        status(res, false, {code: 'invalid-user', error: 'Please re-log in with account to continue'});
                });
            });
    }
};