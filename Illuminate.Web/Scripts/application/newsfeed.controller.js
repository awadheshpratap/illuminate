var myApp = angular.module('content', []);
var baseUrl = 'http://localhost:8181';

myApp.controller('NewsFeedCtrl', function ($scope, $http, $q, $location) {

    $scope.newsFeed = [];

    $scope.getNews = function () {

        var latestContent = [];
        
        var promise1 = getChannels();
        promise1.then(function (categories) {

            var promise2 = getContent();
            promise2.then(function (content) {
                latestContent = content;

                var promise3 = getComments();
                promise3.then(function (comments) {
                    // optimise if needed : use javascript for instead of jquery.each since it is slower in comparision
                    $.each(latestContent, function (index, item) {
                        // expand category
                        latestContent[index].Channel = Enumerable.From(categories).
                           Where("x => x.CategoryId == " + latestContent[index].CategoryId).First().Name;

                        // get comments
                        var commentOnIt = Enumerable.From(comments).
                           Where("x => x.ContentId == " + item.Id).ToArray();

                        // set in content
                        latestContent[index].comments = commentOnIt;
                        latestContent[index].commentplaceholder = "";
                    });
                });

                var promise4 = getLikes();
                promise4.then(function (likes) {
                    $.each(latestContent, function (index, item) {
                        // get likes
                        var likesOnIt = Enumerable.From(likes).
                            Where("x => x.contentid == " + item.Id).ToArray();
                        // set in content
                        latestContent[index].likesCount = likesOnIt.length;
                    });

                    $scope.newsFeed = latestContent;
                });
            });
        });
    };

    $scope.commentOnContent = function (contentId) {

        var item = Enumerable.From($scope.newsFeed).
                       Where("x => x.Id == " + contentId).First();

        var comment = {
            "Id": -1,
            "ContentId": contentId,
            "CommentedBy": "loggeduser", //TODO:
            "Comments": item.commentplaceholder
        };

        $http({
            url: baseUrl + '/collaborate/contentcomment/' + contentId,
            method: "POST",
            data: JSON.stringify(comment),
            headers: {'Content-Type': 'application/json'}
        }).success(function (data, status, headers, config) {
            $location.reload(); // hack, doesn't work ? partial refresh
        }).error(function (data, status, headers, config) {
            $scope.status = status + ' ' + headers;
        });

    }

    $scope.likeContent = function(contentId) {

        var like = {
            "Id": -1,
            "contentid": contentId,
            "userid": "loggeduser", //TODO:
            "likestatus": true
        };

        $http( {
            url: baseUrl + '/collaborate/contentlike/' + contentId,
            method: 'POST',
            data : JSON.stringify(like),
            headers: {'Content-Type': 'application/json'}

        }).success(function (data, status, headers, config) {


        }).error(function (data, status, headers, config) {
            $scope.status = status + ' ' + headers;
        });

    }

    getChannels = function () {

        var deferred = $q.defer();

        $http({
            url: baseUrl + '/contribute/category/',
            method: "GET",
        }).success(function (data, status, headers, config) {
            deferred.resolve(data);
        }).error(function (data, status, headers, config) {
            $scope.status += status + ' ' + headers;
            deferred.reject(null);
        });

        return deferred.promise;

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
