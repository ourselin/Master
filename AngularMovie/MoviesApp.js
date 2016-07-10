var app = angular.module("MoviesApp", []);

app.controller("MovieController", function ($scope, $http) {

    /*var movies = [
        { title: "Avatar", rating: "PG-12", year: 2009, plot: "fdeokfdekfek fkezkfezkf fkzefkezkf" },
        { title: "star wars", rating: "PG-12", year: 2009, plot: "fdeokfdekfek fkezkfezkf fkzefkezkf" },
        { title: "The Shawshank Redemption", rating: "PG-12", year: 2009, plot: "fdeokfdekfek fkezkfezkf fkzefkezkf" },
        { title: "The GodFather", rating: "PG-12", year: 2009, plot: "fdeokfdekfek fkezkfezkf fkzefkezkf" }
    ];*/

    

    $scope.searchMovies = function()
    {
        var title = $scope.searchTitle;
        $http.jsonp("http://www.myapifilms.com/imdb/idIMDB?title=" + title + "&token=d6650b7b-79df-436d-a11e-3ac3fa0e57e3&format=json&language=en-us&aka=0&business=0&seasons=0&seasonYear=0&technical=0&filter=2&exactFilter=0&limit=10&forceYear=0&trailers=0&movieTrivia=0&awards=0&moviePhotos=0&movieVideos=0&actors=0&biography=0&uniqueName=0&filmography=0&bornAndDead=0&starSign=0&actorActress=0&actorTrivia=0&similarMovies=0&adultSearch=0&goofs=0&quotes=0&fullSize=0&companyCredits=0&callback=JSON_CALLBACK")
        .success(function (response) {
            $scope.movies = response.data.movies;
        })
    }

    $scope.removeMovie = function (movie)
    {
        var index = $scope.movies.indexOf(movie);
        $scope.movies.splice(index, 1);
    }

    $scope.saveMovie = function()
    {
        $scope.movies[$scope.selectedMovie] = $scope.movie;
        $scope.movie = null;
    }

    $scope.selectMovie = function (movie) {
        var newMovie = {
            title: movie.title,
            year: movie.year,
            rating: movie.rating,
            plot: movie.plot
        };
        $scope.movie = newMovie;
        $scope.selectedMovie = $scope.movies.indexOf(movie);
    }

    $scope.addMovie = function () {
        var newMovie = {
            title: $scope.movie.title,
            year: $scope.movie.year,
            rating: $scope.movie.rating,
            plot: $scope.movie.plot
        };
        
        $scope.movies.push(newMovie);
    }

});