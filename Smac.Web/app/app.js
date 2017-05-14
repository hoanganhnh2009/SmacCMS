(function () {
    'use strict';
    var app = angular.module('smacshop',
        ['smacshop.products',
            'smacshop.product_categories',
           'smacshop.application_groups',
         'smacshop.application_roles',
         'smacshop.application_users',
            'smacshop.common'])
    .config(config)
    .config(configAuthentication);

    app.config(['$qProvider', function ($qProvider) {
        $qProvider.errorOnUnhandledRejections(false);
    }]);

    config.$inject = ["$stateProvider", "$urlRouterProvider"]

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider
           .state('login', {
               url: "/login",
               templateUrl: "/app/components/login/loginView.html",
               controller: "loginController"
           })
            .state('home', {
                url: "/admin",
                templateUrl: "/app/components/home/homeView.html",
                controller: "homeController"
            })
        $urlRouterProvider.otherwise('/admin');
    }

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
                    }
                    //the same response/modified/or a new one need to be returned.
                    return response;
                },
                responseError: function (rejection) {

                    if (rejection.status == "401") {
                        $location.path('/login');
                    }
                    return $q.reject(rejection);
                }
            };
        });
    }

})();