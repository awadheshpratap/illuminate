var myApp = angular.module('signin', []);
var baseUrl = 'http://localhost:8181';

myApp.controller('SignInCtrl', function ($scope, $http, $q, $location) {

    $scope.username = "";
    $scope.password = "";

    $scope.signIn = function () {

            $http({
                url: baseUrl + '/api/userprofile/' + $scope.username,
                method: "GET",
            }).success(function (data, status, headers, config) {
                
                if (data) {
                    // for test purpose only
                    // TODO: use angular routes configuration
                    window.location.href='http://...'
                }


            }).error(function (data, status, headers, config) {
                $scope.status += status + ' ' + headers;
            });
    }
});