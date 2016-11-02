//angular.module('ngRoute').controller('IngredientController', function ($scope, $location, $routeParams, IngredientService, IngredientCategoryService) {
angular.module(['ngRoute']).controller('RecipeController', function ($scope, RecipeService, RecipeCategoryService, UserService, IngredientCategoryService, $location,$sce) {
    $scope.IsNew = 1;
    $scope.IngredientList = [];
    $scope.Ingredients = [];
    $scope.calories = 0;
    $scope.SelectedIngredient = "";
    $scope.Rate = 0;
    $scope.rateValue = 0;

    $scope.$on('rateEvent', function (event, myData) { alert(myData); })

    var urlarray = $location.absUrl().split("/")
    if (urlarray.length > 0) {
        var idRecipe = urlarray[urlarray.length - 1] || "Unknown";
        if (idRecipe > 0)
            get(idRecipe);
        else
            getData();
    }

    getIngredientCategories();
    getRecipeCategories();
    getUsers();

    $scope.ingredientsFilter = function (itemRecipe) {
        var arrayIngredients = $scope.SelectedIngredient.split(';');

        if (arrayIngredients.length > 0) {
            for (var i = 0; i < itemRecipe.Ingredients.length; i++) {
                for (var i2 = 0; i2 < arrayIngredients.length; i2++) {
                    if (itemRecipe.Ingredients[i].Name.toLowerCase().includes(arrayIngredients[i2]))
                        return true;
                }
            }
        }
        return false;
    }


    //Data used to populate the dropdown list
    $scope.RecipeFilterOptions = [
       { "Description": "Ordre alphabétique (A->A)", "Value": "-Login" },
       { "Description": "Ordre alphabétique (Z->A)", "Value": "+Login" },
       { "Description": "Les plus récentes d'abord", "Value": "-CreationDate" },
       { "Description": "Les plus anciennes d'abord", "Value": "+CreationDate" },
       { "Description": "Les mieux notés d'abord", "Value": "-AverageRate" },
       { "Description": "Les moins bien notés d'abord", "Value": "+AverageRate" },
       { "Description": "Du plus calorique au moins calorique", "Value": "-calories" },
       { "Description": "Du moins calorique au plus calorique", "Value": "+calories" }];


    $scope.byRange = function (fieldName, minValue, maxValue) {
        if (minValue === undefined) minValue = 0;
        if (maxValue === undefined) maxValue = 150000;

        return function predicateFunc(item) {
            var keys = fieldName.split('.');
            var val = item;
            for (var i = 0; i < keys.length; i++) {
                val = val[keys[i]];
            }

            return minValue <= val && val <= maxValue;
        };
    };

    function getUsers() {
        if ($scope.Users === undefined || $scope.Users.length === 0) {
            var promiseGet = UserService.getUsers();
            promiseGet.then(function (t) {
                $scope.Users = t.data
            },
                function (errorT) {
                    console.log('Chargement des utilisateurs', errorT);
                });
        }
    }

    $scope.GetSelectedIngredientCategory = function () {
        for (var i = 0; i < $scope.IngredientCategories.length; i++) {
            if ($scope.IngredientCategories[i].IdIngredientCategory == $scope.IngredientCategory)
                $scope.IngredientList = $scope.IngredientCategories[i];
        }

    }

    function getRecipeCategories() {
        if ($scope.RecipeCategories === undefined || $scope.RecipeCategories.length === 0) {
            var promiseGet = RecipeCategoryService.getRecipeCategories();
            promiseGet.then(function (t) {
                $scope.RecipeCategories = t.data
            },
                function (errorT) {
                    console.log('Chargement des categories de recettes impossible', errorT);
                });
        }
    }


    function getIngredientCategories() {
        if ($scope.IngredientCategories === undefined || $scope.IngredientCategories.length === 0) {
            var promiseGet = IngredientCategoryService.getIngredientCategories();
            promiseGet.then(function (t) {
                $scope.IngredientCategories = t.data
            },
                function (errorT) {
                    console.log('Chargement des ingredients impossible', errorT);
                });
        }
    }

    // Load all recipes
    function getData() {
        var promiseGet = RecipeService.getRecipes();

        promiseGet.then(function (t) {
            $scope.Recipes = t.data;
            for (var i = 0; i < $scope.Recipes.length; i++) {
                $scope.Recipes[i].calories = 0;
                $scope.Recipes[i].AverageRate = 0;

                for (var i2 = 0; i2 < $scope.Recipes[i].RecipeRates.length; i2++) {
                    $scope.Recipes[i].AverageRate += $scope.Recipes[i].RecipeRates[i2].Rate;
                }
                $scope.Recipes[i].AverageRate = Math.round($scope.Recipes[i].AverageRate / $scope.Recipes[i].RecipeRates.length);
                for (var i2 = 0; i2 < $scope.Recipes[i].Ingredients.length; i2++) {
                    $scope.Recipes[i].calories += $scope.Recipes[i].Ingredients[i2].Calories;
                }
            }
        },
            function (errorT) {
                console.log('Chargement des recettes impossible', errorT);
            });
    }

    // Load a single recipe
    function get(IdRecipe) {
        $scope.Ingredients = [];
        $scope.IdUser = "";
        $scope.User = "";
        $scope.RecipeCategory = "";
        $scope.IdRecipeCategory = "";
        $scope.calories = 0;

        var promiseGetSingle = RecipeService.get(IdRecipe);

        promiseGetSingle.then(function (t) {
            var res = t.data;
            $scope.IdRecipe = res.IdRecipe;
            $scope.IdRecipeCategory = res.IdRecipeCategory;
            $scope.UrlRecipePicture = res.UrlRecipePicture;
            $scope.Name = res.Name;
            $scope.IdUser = res.IdUser;
            $scope.RecipeCategory = res.RecipeCategory;
            $scope.Ingredients = res.Ingredients;
            $scope.IngredientList = $scope.Ingredients;
            $scope.User = res.User;
            $scope.RecipeRates = res.RecipeRates;
            $scope.IsNew = 0;
            $scope.AverageRate = 0;
            $scope.calories = 0;
            $scope.Preparation = res.Preparation;
            $scope.trustPreparation = $sce.trustAsHtml($scope.Preparation);
            $scope.RelatedRecipes = res.RelatedRecipes;


            for (var i = 0; i < $scope.RelatedRecipes.length; i++) {

                $scope.RelatedRecipes[i].AverageRate = 0;
                for (var i2 = 0; i2 < $scope.RelatedRecipes[i].RecipeRates.length; i2++) {
                    $scope.RelatedRecipes[i].AverageRate += $scope.RelatedRecipes[i].RecipeRates[i2].Rate;
                }
                $scope.RelatedRecipes[i].AverageRate = Math.round($scope.RelatedRecipes[i].AverageRate /$scope.RelatedRecipes[i].RecipeRates.length);

                if (isNaN($scope.RelatedRecipes[i].AverageRate))
                    $scope.RelatedRecipes[i].AverageRate = 0;
            }


            for (var i = 0; i < $scope.Ingredients.length; i++) {
                $scope.calories += $scope.Ingredients[i].Calories;
            }

            for (var i = 0; i < $scope.RecipeRates.length; i++) {
                $scope.AverageRate += $scope.RecipeRates[i].Rate;
            }
            $scope.AverageRate = Math.round($scope.AverageRate / $scope.RecipeRates.length);
            if (isNaN($scope.AverageRate))
                $scope.AverageRate = 0;
        },
        function (e) {
            console.log('Chargement de recette imopssible', e);
        });



    }

    // Clear form
    $scope.clear = function () {
        $scope.IdRecipe = res.IdRecipe;
        $scope.IdRecipeCategory = "";
        $scope.UrlRecipePicture = "";
        $scope.Name = "";
        $scope.IdUser = "";
        $scope.RecipeCategory = "";
        $scope.Ingredients = "";
        $scope.User = "";
        $scope.RecipeRates = "";
        $scope.IsNew = 1;
    }


    // Add Ingredient to Recipe
    $scope.addIngredient = function (ingredient) {

        if ($scope.Ingredients.lenght == 10) {
            $scope.Message = "Votre recette comporte deja 10 ingredients";
        }
        else {
            if ($scope.Ingredients.indexOf(ingredient) == -1) {
                $scope.Ingredients.push(ingredient);
                $scope.calories += ingredient.Calories;
            }
        }
    }

    // remove Ingredients form Recipe
    $scope.removeIngredient = function (ingredientIndex) {
        $scope.calories -= $scope.Ingredients[ingredientIndex].Calories;
        $scope.Ingredients.splice(ingredientIndex, 1);

    }




    // Save Recipe
    $scope.saveRate = function () {
        var RecipeRate = {
            IdRecipe: $scope.IdRecipe,
            //IdUser: $scope.IdUser,
            IdUser: 14,
            Rate: $scope.rateValue,
            Title: $scope.Title,
            Comment: $scope.Comment
        }

            var promisePost = RecipeService.postRate(RecipeRate);
            promisePost.then(function (t) {
                $scope.RecipeRates.push(RecipeRate);
            }, function (e) {
                console.log("Error " + e);
            });          
    }




    // Save Recipe
    $scope.save = function () {
        var Recipe = {
            IdRecipe: $scope.IdRecipe,
            IdRecipeCategory: $scope.RecipeCategory,
            UrlRecipePicture: $scope.UrlRecipePicture,
            Name: $scope.Name,
            Preparation: $scope.Preparation,
            IdUser: $scope.User,
            Ingredients: $scope.Ingredients
        };

        if ($scope.IsNew === 1) {
            Recipe.IdUser = 14;
            var promisePost = RecipeService.post(Recipe);
            promisePost.then(function (t) {
                $scope.recipeAdded = true;
                $scope.IdRecipe = t.data.IdRecipe;
                getData();
            }, function (e) {
                $scope.recipeError = true;
                console.log("Error " + e);
            });
        } else { 
            var promisePut = RecipeService.put($scope.IdRecipe, IdRecipe);
            promisePut.then(function (t) {
                $scope.Message = "Recette mis à jours";
                getData();
            }, function (e) {
                console.log("Error " + e);
            });
        }
    };
});
