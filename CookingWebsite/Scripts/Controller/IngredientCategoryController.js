﻿NgCookingIngredientCat.controller('IngredientCategoryController', ['IngredientCategoryService', 'cookies']);

NgCookingIngredientCat.controller('IngredientCategoryController', function ($scope, IngredientCategoryService,$cookies) {

    $scope.IsNew = 1;
    $scope.Connected = false;
    $scope.badPassWord = false;
    $scope.IdUser = -1;

    var Curr_SessUser_IdUser = $cookies.get('Session_IdUser');

    if (Curr_SessUser_IdUser) {
        $scope.IdUser = Curr_SessUser_IdUser;
        $scope.ProfileLink = 'http://localhost:51312/User/Detail/' + $scope.IdUser;
        $scope.Connected = true;
    }
    else
        $scope.ProfileLink = 'http://localhost:51312/User/Detail/List/'

    getData();

    // Load all IngredientCategories
    function getData() {
        var promiseGet = IngredientCategoryService.getIngredientCategories();

        promiseGet.then(function (t) {
            $scope.IngredientCategories = t.data
        },
            function (errorT) {
                console.log('Chargement des catégories d\'ingredients impossible', errorT);
            });
    }

    // Load a single IngredientCategory
    $scope.get = function (ts) {
        var promiseGetSingle = IngredientCategoryService.get(ts.IdIngredientCategory);

        promiseGetSingle.then(function (t) {
            var res = t.data;
            $scope.IdIngredientCategory = res.IdIngredientCategory;
            $scope.Name = res.Name;
            $scope.Description = res.Description;
            $scope.Ingredients = res.Ingredients;
            $scope.IsNew = 0;
        },
        function (e) {
            console.log('Chargement de la catégorie d\'ingrédient imopssible', e);
        });
    }

    // Clear form
    $scope.clear = function () {
        $scope.IsNew = 1;
        $scope.Ingredients = "";
        $scope.IdIngredientCategory = -1;
        $scope.Name = "";
        $scope.Description = "";
    }

    // Save IngredientCategory
    $scope.save = function () {
        var IngredientCategory = {
            IdIngredientCategory: $scope.IdIngredientCategory,
            Name: $scope.Name,
            Description: $scope.Description
        };

        if ($scope.IsNew === 1) {
            var promisePost = IngredientCategoryService.post(IngredientCategory);
            promisePost.then(function (t) {
                $scope.IdIngredientCategory = t.data.IdIngredientCategory;
                getData();
            }, function (e) {
                console.log("Error " + e);
            });
        } else {   // Already exists tv show, update 
            var promisePut = UserService.put(IngredientCategory);
            promisePut.then(function (t) {
                $scope.Message = "Catégorie d'Ingredient mis à jours";
                getData();
            }, function (e) {
                console.log("Error " + e);
            });
        }
    };
});