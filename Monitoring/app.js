'use strict';

var redis = require('redis');
var log = require('single-line-log').stdout;

var client = redis.createClient(6379, '127.0.0.1');

client.on('connect', function () {
    console.log('[REDIS] client connected');
});

function loop() {           
    setTimeout(function () {    
        client.get('counter', function (err, reply) {
            log(`[REDIS] Current counter: ${reply}`);
            loop();
        });          
        ;                        
    }, 100)
}

loop(); 
