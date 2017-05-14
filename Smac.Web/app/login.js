/// <reference path="Assets/admin/libs/angular/angular.js" />
(function () {
    'use strict';
    var app = angular.module('smacshop',[])
    app.config(configAuthentication);

    function configAuthentication($httpProvider) {
        $httpProvider.interceptors.push(function ($q, $location) {
            return {
                request: function (config) {

                    return config;
                },
                requestError: function (rejection) {

                    return $q.reject(rejection);
                },
                response: function (response) {
                    if (response.status == "401") {
                        $location.path('/login');
                        //alert("401");
                        //window.location = "http://localhost:56579/Admin/Login";
                    }
                    //the same response/modified/or a new one need to be returned.
                    return response;
                },
                responseError: function (rejection) {

                    if (rejection.status == "401") {
                        $location.path('/login');
                        //alert("401");
                    }
                    return $q.reject(rejection);
                }
            };
        });
    }

    //app.config(['$qProvider', function ($qProvider) {
    //    $qProvider.errorOnUnhandledRejections(false);
    //}]);

    //config.$inject = ["$stateProvider", "$urlRouterProvider"]

    //function config($stateProvider, $urlRouterProvider) {

    //    $stateProvider
    //        .state('home', {
    //            url: "/admin",
    //            //parent: 'base',
    //            templateUrl: "/app/components/home/homeView.html",
    //            controller: "homeController"
    //        });
    //    $urlRouterProvider.otherwise('/admin');
    //}
})();