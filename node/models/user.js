const model = require('../utils/model');

module.exports = model.createFrom(
    {
        username: "",
        email: "",
        password: "",
        characters: ["priest", "ogre"],
        que: false,
        queId: "",
        roomId: 0
    }
);