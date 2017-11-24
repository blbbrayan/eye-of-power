const admin = require('firebase-admin');

function auth() {
    return admin.auth()
}

function createUser(user, fail, success) {
    auth()
        .createUser(user)
        .then(userRecord => success(userRecord, userRecord.uid))
        .catch(error => fail(error))
}

function getUser(uid, fail, success) {
    auth()
        .getUser(uid)
        .then(userRecord => success(userRecord, userRecord.uid))
        .catch(error => fail(error))
}

function updateUser(uid, user, fail, success) {
    auth()
        .updateUser(uid, user)
        .then(userRecord => success(userRecord, userRecord.uid))
        .catch(error => fail(error))
}

module.exports = {
    create: createUser,
    read: getUser,
    update: updateUser
};