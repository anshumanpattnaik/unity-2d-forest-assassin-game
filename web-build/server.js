var express = require('express');
var compression = require('compression');
var cors = require('cors');

var app = express();

app.use(compression());
app.use(express.static(__dirname + '/public/'));

app.listen(8000, function () {
    console.log('app listening on port 8000!');
});
