var myApp = angular.module('signin',[]);
var baseUrl = 'http://localhost:8181';

myApp.controller('SignInCtrl', function ($scope, $http, $q, $location) {

    $scope.userid = "";
    $scope.password = "";

    $scope.signIn = function () {

            $http({
                url: baseUrl + '/api/userprofile/' + $scope.userid,
                method: "GET",
            }).success(function (data, status, headers, config) {
                
                if (data != null && data.UserId == $scope.userid) {
                    // direct to main page. This is a page redirect, not a partial view load
                    // so cannot use ajax get on mvc.
                    window.location.href = '/Home?userid='+$scope.userid;
                    /*jQuery.ajax({
                        //url: '@Url.Action("Home","Index")',
                        url: '/Home?invoke&action=Index',
                        //headers: {'x-mvc-action': action},
                        type: 'GET',
                        dataType : 'html',
                        success: function (data) { }

                    });*/
                }


            }).error(function (data, status, headers, config) {
                $scope.status += status + ' ' + headers;
            });
    }
});
