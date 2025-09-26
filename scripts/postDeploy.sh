#!/bin/bash

ENV=$1

# Make the curl request
curl "http://webapi-app-apps-$ENV.apps.pminkows.95az.p1.openshiftapps.com/api/version"