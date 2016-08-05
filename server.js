// Подключаем модули
var express = require('express'),
    bodyParser = require('body-parser'),
    http = require('http'),
    mysql = require('mysql'),
    cluster = require('cluster'),
    os = require('os'),

    config = require('./config'),

    app = express(); // приложение

var pool = null; // переменная для пула коннеткионов к БД

if (cluster.isMaster) {
    for (var i = 0; i < config.process; i += 1) {
        pool = mysql.createPool(config.db); // для того, чтобы был общий пул коннектионов к БД для всех процессов
        cluster.fork();
    }

    // когда процесс умер, нужно перезапустить
    cluster.on('exit', function () {
        pool = mysql.createPool(config.db); // для того, чтобы был общий пул коннектионов к БД для всех процессов
        cluster.fork();
    });

    return;
} else {

    pool = mysql.createPool(config.db); // необходимо инициализировать в пулл конектионов к БД

    // Для парсинга тела запроса
    app.use(bodyParser.urlencoded({extended: true}));
    app.use(bodyParser.json());

    // маршрут запроса
    app.post('/', function (req, res) {
        if (req.body.data == undefined || req.body.data.trim() == '') {
            res.status(404).send('Error');
        } else {

            // принятые данные
            var respondData = JSON.parse(req.body.data),
                data = {};

            var newDate = new Date().getTime();
            data['_Added'] = newDate;
            data['_Saved'] = newDate;

            data.PacketNum = respondData.PacketNum;
            data.Receiver = respondData.Receiver ? respondData.Receiver : -1;
            data.Channel = respondData.Channel ? respondData.Channel : -1;
            data.Level = respondData.Level ? respondData.Level : 0;
            data.DataHex = respondData.DataHex;
            data.Station = respondData.Station ? respondData.Station : '';
            data.StationHubIP = respondData.StationHubIP ? respondData.StationHubIP : '';
            data.CatcherIP = req.ip ? req.ip : '';

            // формируем подготовленный запрос
            var sql = 'INSERT INTO `UDPData` (_Added, _Saved,' +
                'PacketNum, Receiver, Channel, Level, DataHex, Station, StationHubIP, CatcherIP) ' +
                'VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)';

            sql = mysql.format(sql, [data._Added, data._Saved, data.PacketNum, data.Receiver, data.Channel,
                data.Level, data.DataHex, data.Station, data.StationHubIP, data.CatcherIP]);

            // получаем соединение с БД
            pool.getConnection(function (err, connection) {
                if (err) {
                    res.status(404).send('Error');
                    console.log('Не удалось соединиться в БД');
                } else {
                    connection.beginTransaction(function (err) {
                        if (err) {
                            return connection.rollback(function () {
                                connection.release();
                                console.log('Не удалось начать транзакцию');
                                res.status(404).send('Error');
                            });
                        }

                        connection.query(sql, function (err, result) { // выполняем запрос
                            if (err) {
                                connection.rollback(function () {
                                    connection.release(); // !!! возврат соединения
                                    console.log('Не удалось вставить данные')
                                    res.status(404).send('Error');
                                });
                            } else {
                                connection.commit(function (err) {
                                    if (err) {
                                        connection.rollback(function () {
                                            connection.release(); // !!! возврат соединения
                                            console.log('Не удалось вставить данные')
                                            res.status(404).send('Error');
                                        });
                                    }

                                    connection.release(); // !!! возврат соединения
                                    res.status(200).send('OK');
                                });
                            }
                        });
                    });
                }
            });
        }
    });

    // Обработка ошибок в приложении
    app.use(function (err, req, res, next) {
        if (err.status && err.status < 500) {
            return res.status(404).send('Error');
        }

        console.log(err.message);

        req.destroy();
    });

    http.createServer(app).listen(config.appPort, function () {
        console.log('Сервер запущен на порту ' + config.appPort);
    });
}
