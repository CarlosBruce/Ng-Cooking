﻿NgCookingRecipeCat.controller('RecipeCategoryController', ['RecipeCategoryService', 'cookies']);

NgCookingRecipeCat.controller('RecipeCategoryController', function ($scope, RecipeCategoryService,Session,$cookies) {

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

    // Load all RecipeCategories
    function getData() {
        var promiseGet = RecipeCategoryService.getRecipeCategories();

        promiseGet.then(function (t) {
            $scope.RecipeCategories = t.data
        },
            function (errorT) {
                console.log('Chargement des catégories de recettes impossible', errorT);
            });
    }

    // Load a single RecipeCategory
    $scope.get = function (ts) {
        var promiseGetSingle = RecipeCategoryService.get(ts.IdRecipeCategory);

        promiseGetSingle.then(function (t) {
            var res = t.data;
            $scope.IdRecipeCategory = res.IdRecipeCategory;
            $scope.Name = res.Name;
            $scope.Recipes = res.Recipes;
            $scope.IsNew = 0;
        },
        function (e) {
            console.log('Chargement de la catégorie de recette imopssible', e);
        });
    }

    // Clear form
    $scope.clear = function () {
        $scope.IsNew = 1;
        $scope.Recipes = "";
        $scope.IdRecipeCategory = -1;
        $scope.Name = "";
    }

    // Save RecipeCategory
    $scope.save = function () {
        var RecipeCategory = {
            IdRecipeCategory: $scope.IdRecipeCategory,
            Name: $scope.Name
        };

        if ($scope.IsNew === 1) {
            var promisePost = RecipeCategoryService.post(RecipeCategory);
            promisePost.then(function (t) {
                $scope.IdRecipeCategory = t.data.IdRecipeCategory;
                getData();
            }, function (e) {
                console.log("Error " + e);
            });
        } else {   // Already exists tv show, update 
            var promisePut = UserService.put(RecipeCategory);
            promisePut.then(function (t) {
                $scope.Message = "Catégorie de recette mis à jours";
                getData();
            }, function (e) {
                console.log("Error " + e);
            });
        }
    };
});