// Подключаем модули
const express = require('express');
const bodyParser = require('body-parser');
const http = require('http');
const mysql = require('mysql');
const cluster = require('cluster');
const os = require('os');

const config = require('./config'),

const app = express(); // приложение

let pool = null; // переменная для пула коннеткионов к БД

if (cluster.isMaster) {
    for (let i = 0; i < config.process; i += 1) {
        pool = mysql.createPool(config.db); // для того, чтобы был общий пул коннектионов к БД для всех процессов
        cluster.fork();
    }

    // когда процесс умер, нужно перезапустить
    cluster.on('exit', () => {
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
    app.post('/', (req, res) => {
        if (req.body.data == undefined || req.body.data.trim() == '') {
            res.status(404).send('Error');
        } else {
            // принятые данные
            const respondData = JSON.parse(req.body.data);
            const data = {};

            const newDate = new Date().getTime();
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
            let sql = 'INSERT INTO `UDPData` (_Added, _Saved,' +
                'PacketNum, Receiver, Channel, Level, DataHex, Station, StationHubIP, CatcherIP) ' +
                'VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)';

            sql = mysql.format(sql, [data._Added, data._Saved, data.PacketNum, data.Receiver, data.Channel,
                data.Level, data.DataHex, data.Station, data.StationHubIP, data.CatcherIP]);

            // получаем соединение с БД
            pool.getConnection((err, connection) => {
                if (err) {
                    res.status(404).send('Error');
                    console.log('Не удалось соединиться в БД');
                } else {
                    connection.beginTransaction(err => {
                        if (err) {
                            return connection.rollback(() => {
                                connection.release();
                                console.log('Не удалось начать транзакцию');
                                res.status(404).send('Error');
                            });
                        }

                        connection.query(sql, (err, result) => { // выполняем запрос
                            if (err) {
                                connection.rollback(() => {
                                    connection.release(); // !!! возврат соединения
                                    console.log('Не удалось вставить данные')
                                    res.status(404).send('Error');
                                });
                            } else {
                                connection.commit(err => {
                                    if (err) {
                                        connection.rollback(() => {
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
    app.use((err, req, res, next) => {
        if (err.status && err.status < 500) {
            return res.status(404).send('Error');
        }

        console.log(err.message);

        req.destroy();
    });

    http
        .createServer(app)
        .listen(config.appPort, () => {
            console.log('Сервер запущен на порту ' + config.appPort);
        });
    };
