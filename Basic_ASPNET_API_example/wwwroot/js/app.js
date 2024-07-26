'use strict';
angular.module('petshopApp', ['ngRoute'])
.config(['$routeProvider', '$httpProvider', function ($routeProvider, $httpProvider) {

    // disable IE ajax request caching
    if (!$httpProvider.defaults.headers.get) {
        $httpProvider.defaults.headers.get = {};
    }
    $httpProvider.defaults.headers.get['If-Modified-Since'] = '0';

    $routeProvider.when("/PetshopList", {
        controller: "petshopListCtrl",
        templateUrl: "../views/PetshopList.cshtml",
    }).otherwise({ redirectTo: "/swagger" });

    }]);