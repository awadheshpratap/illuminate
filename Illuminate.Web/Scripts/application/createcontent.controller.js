

var myApp = angular.module('content', []);
var baseUrl = 'http://localhost:8181';
 
myApp.directive('fileUpload', function () {
    return {
        scope: true,        //create a new scope
        link: function (scope, el, attrs) {
            el.bind('change', function (event) {
                var files = event.target.files;
                //iterate files since 'multiple' may be specified on the element
                for (var i = 0; i < files.length; i++) {
                    //emit event upward
                    scope.$emit("fileSelected", { file: files[i] });
                }
            });
        }
    };
});

myApp.controller('CreateContentCtrl', function ($scope, $http) {

    $scope.area = "";
    $scope.topic = "";
    $scope.author = "";
    $scope.title = "";
    $scope.description = "";
    $scope.fileName = "";

    $scope.files = [];


    //listen for the file selected event
    $scope.$on("fileSelected", function (event, args) {
        $scope.$apply(function () {
            //add the file object to the scope's files collection
            $scope.files.push(args.file);
        });
    });


    $scope.publish = function () {

        $scope.content = {
            "Id":-1, 
            "Title": $scope.title,
            "CategoryId": 1,
            "Description": $scope.description,
            "Author": $scope.Author
        };

     

        $http({
            method: 'POST',
            url: baseUrl + '/contribute/content/null',
            headers: { 'Content-Type': false },
            //This method will allow us to change how the data is sent up to the server
            // for which we'll need to encapsulate the model data in 'FormData'
            transformRequest: function (data) {
                var formData = new FormData();
                //need to convert our json object to a string version of json otherwise
                // the browser will do a 'toString()' on the object which will result 
                // in the value '[Object object]' on the server.
                formData.append("model", angular.toJson(data.model));
                //alert(data.files.length);
                //now add all of the assigned files
                for (var i = 0; i < data.files.length; i++) {
                    //add each file to the form data and iteratively name them
                    formData.append("file" + i, data.files[i]);
                }
                return formData;
            },
            //Create an object that contains the model and files which will be transformed
            // in the above transformRequest method
            data: { model: $scope.content, files: $scope.files }
            //data: JSON.stringify($scope.content),
            //headers: {'Content-Type': 'application/json'}
        }).success(function (data, status, headers, config) {
             
        }).error(function (data, status, headers, config) {
            $scope.status = status + ' ' + headers;
        });
    }; 

});
