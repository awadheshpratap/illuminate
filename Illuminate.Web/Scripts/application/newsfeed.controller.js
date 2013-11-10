var myApp = angular.module('content', []);
var baseUrl = 'http://localhost:8181';

myApp.controller('NewsFeedCtrl', function ($scope, $http, $q) {

    $scope.newsFeed = [];

    $scope.getNews = function () {

        var latestContent = [];
        
        var promise1 = getContent();
        promise1.then(function (content) {
            latestContent = content;

            var promise2 = getComments();
            promise2.then(function(comments) {
                // optimise if needed : use javascript for instead of jquery.each since it is slower in comparision
                $.each(latestContent, function (index, item) {
                    // get comments
                    var commentOnIt = Enumerable.From(comments).
                       Where("x => x.ContentId == " + item.Id).ToArray();
                    
                    // set in content
                    latestContent[index].comments = commentOnIt;
                });
            });

            var promise3 = getLikes();
            promise3.then(function (likes) {
                $.each(latestContent, function (index, item) {
                    // get likes
                    var likesOnIt = Enumerable.From(likes).
                        Where("x => x.ContentId == " + item.Id);
                    // set in content
                    latestContent[index].likes = likesOnIt;
                });

                $scope.newsFeed = latestContent;
            });
        });
    };

    $scope.commentOnContent = function(contentId) {

        $http({
            url: baseUrl + '/collaborate/contentcomment/' + contentId,
            method: "POST",
            data: JSON.stringify($scope.comment),
            headers: {'Content-Type': 'application/json'}
        }).success(function (data, status, headers, config) {
            
        }).error(function (data, status, headers, config) {
            $scope.status = status + ' ' + headers;
        });

    }

    $scope.likeContent = function(contentId) {

        $http( {
            url: baseUrl + '/collaborate/contentlike' + contentId,
            method: 'POST',
            data : JSON.stringify($scope.like),
            headers: {'Content-Type': 'application/json'}

        }).success(function (data, status, headers, config) {


        }).error(function (data, status, headers, config) {
            $scope.status = status + ' ' + headers;
        });

    }

    var getContent = function () {

        var deferred = $q.defer();

        $http({
            url: baseUrl + '/consume/content/',
            method: "GET",
        }).success(function (data, status, headers, config) {
            deferred.resolve(data);
        }).error(function (data, status, headers, config) {
            $scope.status += status + ' ' + headers;
            deferred.reject(null);
        });

        return deferred.promise;
    }

    var getComments = function () {
        
        var deferred = $q.defer();

        $http({
            url: baseUrl + '/collaborate/contentcomment/',
            method: "GET",
        }).success(function (data, status, headers, config) {
            deferred.resolve(data);
        }).error(function (data, status, headers, config) {
            $scope.status += status + ' ' + headers;
            deferred.reject(null);
        });

        return deferred.promise;
    }

    var getLikes = function () {

        var deferred = $q.defer();

        $http({
            url: baseUrl + '/collaborate/contentlike/',
            method: "GET",
        }).success(function (data, status, headers, config) {
            deferred.resolve(data);
        }).error(function (data, status, headers, config) {
            $scope.status += status + ' ' + headers;
            deferred.reject(null);
        });

        return deferred.promise;
    }

});
