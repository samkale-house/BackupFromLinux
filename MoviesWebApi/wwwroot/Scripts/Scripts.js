var app = angular
    .module("myModule", [])
    .controller("myController", function ($scope, $http, $log) {
        $http({
            method: 'GET',
            url: 'https://localhost:44364/movies'
        })
            .then(function (response) {
                var movies;
                movies = response.data;
                $scope.movies = movies;
                //$scope.movies = response.data;
                $log.info(response);
            }, function (reason) {
                $scope.error = reason.data;
                $log.info(reason);
            }
        )
    })
