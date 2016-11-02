angular.module('ngRoute').service('RecipeService', function ($http) {

    //Create new
    this.post = function (Recipe) {
        var request = $http({
            method: "post",
            url: "http://localhost:51371/api/Recipe",
            data: Recipe,
        });
        return request;
    }

    //Create new comment
    this.postRate = function (RecipeRate) {
        var request = $http({
            method: "post",
            url: "http://localhost:51371/api/RecipeRate",
            data: RecipeRate,
        });
        return request;
    }

    //Get Single 
    this.get = function (Id) {
        return $http.get("http://localhost:51371/api/Recipe/" + Id);
    }

    //Get All
    this.getRecipes = function () {
        return $http.get("http://localhost:51371/api/Recipe");
    }
});