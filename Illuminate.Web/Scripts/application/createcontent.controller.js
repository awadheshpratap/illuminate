var myApp = angular.module('content', []);
var baseUrl = 'http://localhost:8181';
 
myApp.controller('CreateContentCtrl', function ($scope, $http) {

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
            "Description": $scope.description,
            "Author": $scope.Author
        };

        $http({
            url: baseUrl + '/contribute/content/null',
            method: "POST",
            data: JSON.stringify($scope.content),
            headers: {'Content-Type': 'application/json'}
        }).success(function (data, status, headers, config) {
             
        }).error(function (data, status, headers, config) {
            $scope.status = status + ' ' + headers;
        });
    }; 

});
