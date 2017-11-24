const Status = require('../models/status');

module.exports = (res, successful, result) => res.send(
    new Status({
        successful: successful,
        result: result
    })
);