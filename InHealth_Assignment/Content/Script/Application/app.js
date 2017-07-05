'use strict';


//Declare app level module which depends on filters, and services
var inHealthAssignmentApp = angular.module('inHealthAssignmentApp',
    ['ngRoute', 'ui.bootstrap', 'ngResource', 'trNgGrid',
        function () {
            
        }]);

inHealthAssignmentApp.factory('httpRequestInterceptor', function () {
    return {
        request: function (config) {
            config.headers['Security'] = "Key";
            return config;
        }
    };
});