NgCookingIngredientCat.service('IngredientCategoryService', function ($http) {

    //Create new
    this.post = function (IngredientCategory) {
        var request = $http({
            method: "post",
            url: "http://localhost:51371/api/IngredientCategory",
            data: IngredientCategory,
        });
        return request;
    }
    //Get Single 
    this.get = function (Id) {
        return $http.get("http://localhost:51371/api/IngredientCategory/" + Id);
    }

    //Get All
    this.getIngredientCategories = function () {
        return $http.get("http://localhost:51371/api/IngredientCategory");
    }
});