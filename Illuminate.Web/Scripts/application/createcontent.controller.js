var myApp = angular.module('content',[]);
 
myApp.controller('CreateContentCtrl', function ($scope, $http) {
    var baseUrl = 'http://localhost:8081';

    $scope.area = "";
    $scope.topic = "";
    $scope.author = "";
    $scope.title = "";
    $scope.description = "";
    $scope.fileName = "";

    $scope.publish = function () {

        $scope.content = {
            "Id":-1, 
            "Title": $scope.title,
            "CategoryId": 1,
            "Description": $scope.description
        };

        $http({
            url: baseUrl + '/contribute/content/-1',
            method: "POST",
            data: JSON.stringify($scope.content),
            headers: {'Content-Type': 'application/json'}
        }).success(function (data, status, headers, config) {
             
        }).error(function (data, status, headers, config) {
            $scope.status = status + ' ' + headers;
        });
    }; 

});
