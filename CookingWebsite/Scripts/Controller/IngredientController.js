NgCookingIngredient.controller('IngredientController', ['IngredientService', 'IngredientCategoryService', 'authService']);

NgCookingIngredient.controller('IngredientController', function ($scope, IngredientService, IngredientCategoryService, authService) {

    $scope.ConnectedUser = authService.currentUser();

    $scope.IsNew = 1;


    authService.subscribe($scope, function somethingChanged() {
        $scope.ConnectedUser = authService.currentUser();

        if ($scope.ConnectedUser == null)
            $scope.IsConnected = false;
        else
            $scope.IsConnected = true;
    });


    getData();
    getIngredientCategories();
    $scope.Connected = false;
    $scope.badPassWord = false;
    $scope.IdUser = -1;

    $scope.byRange = function (fieldName, minValue, maxValue) {
        if (minValue === undefined) minValue = 0;
        if (maxValue === undefined) maxValue = 15000;

        return function predicateFunc(item) {
            var keys = fieldName.split('.');
            var val = item;
            for (var i = 0; i < keys.length; i++) {
                val = val[keys[i]];
            }

            return minValue <= val && val <= maxValue;
        };
    };

    function getIngredientCategories() {
        if ($scope.IngredientCategories === undefined || $scope.IngredientCategories.length === 0) {
            var promiseGet = IngredientCategoryService.getIngredientCategories();
            promiseGet.then(function (t) {
                $scope.IngredientCategories = t.data;


            },
                function (errorT) {
                    console.log('Chargement des catégories d\'ingredients impossible', errorT);
                });
        }
    }

    // Load all Ingredients
    function getData() {
        var promiseGet = IngredientService.getIngredients();

        promiseGet.then(function (t) {
            $scope.Ingredients = t.data;
            for (var i = 0; i < $scope.Ingredients.length; i++) {
                $scope.Ingredients[i].CaloriesValue = 0;
                $scope.Ingredients[i].CaloriesValue = ($scope.Ingredients[i].Calories / 600) * 100;
            }
        },
            function (errorT) {
                console.log('Chargement des ingredients impossible', errorT);
            });
    }

    // Load a single Ingredient
    $scope.get = function (ts) {
        var promiseGetSingle = IngredientService.get(ts.IdIngredient);

        promiseGetSingle.then(function (t) {
            var res = t.data;
            $scope.IdIngredient = res.IdIngredient;
            $scope.Name = res.Name;
            $scope.Calories = res.Calories;
            $scope.IdIngredientCategory = res.IdIngredientCategory;
            $scope.IngredientCategory = res.IngredientCategory;
            $scope.Recipes = res.Recipes;
            $scope.UrlIngredientPicture = res.UrlIngredientPicture;
            $scope.IsNew = 0;
        },
        function (e) {
            console.log('Chargement de l\'ingrédient imopssible', e);
        });
    }

    // Clear form
    $scope.clear = function () {
        $scope.IsNew = 1;
        $scope.IdIngredient = -1;
        $scope.Name = "";
        $scope.UrlIngredientPicture = "",
        $scope.IdIngredientCategory = 0;
    }

    // Save Ingredient
    $scope.save = function () {
        var Ingredient = {
            IdIngredient: $scope.IdIngredient,
            Name: $scope.Name,
            Calories: $scope.Calories,
            UrlIngredientPicture: $scope.UrlIngredientPicture,
            IdIngredientCategory: $scope.IngredientCategory
        };

        if ($scope.IsNew === 1) {
            var promisePost = IngredientService.post(Ingredient);
            promisePost.then(function (t) {
                $scope.IdIngredient = t.data.IdIngredient;
                getData();
            }, function (e) {
                console.log("Error " + e);
            });
        } else {   // Already exists tv show, update 
            var promisePut = UserService.put($scope.IdIngredient, Ingredient);
            promisePut.then(function (t) {
                $scope.Message = "Ingredient mis à jours";
                getData();
            }, function (e) {
                console.log("Error " + e);
            });
        }
    };
});