var myApp = angular.module('content', []);
var baseUrl = 'http://localhost:8181';

myApp.controller('NewsFeedCtrl', function ($scope, $http) {

    $scope.newsFeed = [];

    $scope.getNews = function () {

        $http({
            url: baseUrl + '/consume/content/',
            method: "GET",
        }).success(function (data, status, headers, config) {
            $scope.newsFeed = data;
        }).error(function (data, status, headers, config) {
            $scope.status = status + ' ' + headers;
        });

    };

});
