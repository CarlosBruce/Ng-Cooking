NgCookingRecipeCat.service('RecipeCategoryService', function ($http) {

    //Create new
    this.post = function (RecipeCategory) {
        var request = $http({
            method: "post",
            url: "http://localhost:51371/api/RecipeCategory",
            data: RecipeCategory,
        });
        return request;
    }
    //Get Single 
    this.get = function (Id) {
        return $http.get("http://localhost:51371/api/RecipeCategory/" + Id);
    }

    //Get All
    this.getRecipeCategories = function () {
        return $http.get("http://localhost:51371/api/RecipeCategory");
    }
});