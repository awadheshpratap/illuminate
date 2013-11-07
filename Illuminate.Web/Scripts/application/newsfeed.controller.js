var myApp = angular.module('content', []);

myApp.controller('NewsFeedCtrl', function ($scope, $http) {
    var baseUrl = 'http://localhost:8081';

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
