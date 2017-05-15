(function (app) {
    app.controller('rootController', rootController);

    rootController.$inject = ['$state', 'authData', 'loginService', '$scope', 'authenticationService', 'apiService',];

    function rootController($state, authData, loginService, $scope, authenticationService, apiService) {
        $scope.Mods = [];
        $scope.logOut = function () {
            loginService.logOut();
            $state.go('login');
        }

        $scope.authentication = authData.authenticationData;
        apiService.get('/api/admod/getmod', {},
            function (result) {
                console.log(result);
            },
            function (result) {
                console.log(result);
            }
        )
        
    }
})(angular.module('smacshop'));