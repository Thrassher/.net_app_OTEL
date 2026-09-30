#!/bin/bash

BASE_URL="http://localhost:8088"

echo "Starting load test..."
echo "Target: $BASE_URL"

while true
do
    curl -s "$BASE_URL/" > /dev/null
    curl -s "$BASE_URL/health" > /dev/null
    curl -s "$BASE_URL/slow" > /dev/null
    curl -s "$BASE_URL/outbound" > /dev/null
    curl -s "$BASE_URL/error" > /dev/null

    sleep 0.2
done
