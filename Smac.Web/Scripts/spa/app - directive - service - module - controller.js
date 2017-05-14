var app;
(function () {
    'use strict';
    app = angular.module('myApp', []);
    app.controller("myController", myController);
    app.service('Validator', Validator);
    app.directive("smacDirective", function () {
        return {
            restrict:"A",
            template:"<h1>thanh-dep-tra-chim-to</h1>"
        }
    });
    myController.$inject = ['$scope', 'Validator'];
    function myController($scope, Validator) {
        $scope.CheckNumber = function () {
            $scope.message = Validator.checkNumber($scope.inputNumber);
        }
    };
    
    function Validator($window) {
        return {
            //Public : Nội bộ
            checkNumber: checkNumber
        }
        function checkNumber(input) {
            if (input % 2 == 0) {
                return "Đây là số chắn";
            }
            else {
                return "Đây là số lẽ";
            }
        }
    };
})();