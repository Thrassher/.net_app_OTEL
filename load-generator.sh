#!/bin/bash

while true
do
    curl -s http://localhost:8088/ > /dev/null
    curl -s http://localhost:8088/health > /dev/null
    curl -s http://localhost:8088/slow > /dev/null
    curl -s http://localhost:8088/outbound > /dev/null
    curl -s http://localhost:8088/error > /dev/null

    sleep 1
done
