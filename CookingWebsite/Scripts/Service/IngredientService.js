NgCookingIngredient.service('IngredientService', function ($http) {

    //Create new
    this.post = function (Ingredient) {
        var request = $http({
            method: "post",
            url: "http://localhost:51371/api/Ingredient",
            data: Ingredient,
        });
        return request;
    }
    //Get Single 
    this.get = function (Id) {
        return $http.get("http://localhost:51371/api/Ingredient/" + Id);
    }

    //Get All
    this.getIngredients = function () {
        return $http.get("http://localhost:51371/api/Ingredient");
    }
});