﻿
NgCookingUser.controller('UserController', ['location', 'UserService', 'authService']);

NgCookingUser.controller('UserController', function ($scope, $location, UserService, authService) {

    $scope.ConnectedUser = authService.currentUser();

    if ($scope.ConnectedUser == null)
        $scope.IsConnected = false;
    else
        $scope.IsConnected = true;



    authService.subscribe($scope, function somethingChanged() {
        $scope.ConnectedUser = authService.currentUser();

        if ($scope.ConnectedUser == null)
            $scope.IsConnected = false;
        else
            $scope.IsConnected = true;
    });


    var urlarray = $location.absUrl().split("/");
    if (urlarray.length > 0 && $location.absUrl().includes("Detail")) {
        var idUser = urlarray[urlarray.length - 1] || "Unknown";
        if (idUser > 0) {
            get(idUser);
            $scope.IsNew = 0;
        }
    }

    if (urlarray.length > 0 && $location.absUrl().includes("User"))
        getData();

    //User Page Filter
    $scope.UserFilterOptions = [
       { "Description": "Ordre alphabétique (A->A)", "Value": "+Login" },
       { "Description": "Ordre alphabétique (Z->A)", "Value": "-Login" },
       { "Description": "Les mieux notés d'abord", "Value": "-AverageRate" },
       { "Description": "Les moins bien notés d'abord", "Value": "+AverageRate" },
       { "Description": "Les plus productifs d'abord", "Value": "-TotalRecipe" },
       { "Description": "Les moins productifs d'abord", "Value": "+TotalRecipe" }];


    //    // Load all Users
    function getData() {
        var promiseGet = UserService.getUsers();

        promiseGet.then(function (t) {
            $scope.Users = t.data;
            for (var i = 0; i < $scope.Users.length; i++) {
                $scope.Users[i].AverageRate = 0;
                $scope.Users[i].TotalRecipe = $scope.Users[i].Recipes.length;
                for (var i2 = 0; i2 < $scope.Users[i].RecipeRates.length; i2++) {
                    $scope.Users[i].AverageRate += $scope.Users[i].RecipeRates[i2].Rate;
                }
                $scope.Users[i].AverageRate =  Math.round($scope.Users[i].AverageRate / $scope.Users[i].RecipeRates.length);
            }

        },
            function (errorT) {
                console.log('Chargement des utilisateurs impossible', errorT);
            });
    }



    // Load a single User
    function get(IdUser) {
        var promiseGetSingle = UserService.get(IdUser);

        promiseGetSingle.then(function (t) {
            var res = t.data;
            $scope.IdUser = res.IdUser;
            $scope.Login = res.Login;
            $scope.Email = res.Email;
            $scope.Password = res.Password;
            $scope.UrlProfilPicture = res.UrlProfilPicture;
            $scope.Recipes = res.Recipes;
            $scope.RecipeRates = res.RecipeRates;
            $scope.AverageRate = 0;

            for (var i = 0; i < $scope.RecipeRates.length; i++) {
                $scope.AverageRate += $scope.RecipeRates[i].Rate;
            }
            var recipesRates = 0;
            for (var i = 0; i < $scope.Recipes.length; i++) {
                recipesRates = 0;
                $scope.Recipes[i].AverageRate = 0;
                for (var i2 = 0; i2 < $scope.RecipeRates.length; i2++) {
                    if ($scope.RecipeRates[i2].IdRecipe == $scope.Recipes[i].IdRecipe) {
                        $scope.Recipes[i].AverageRate += $scope.RecipeRates[i2].Rate;
                        recipesRates++;
                    }

                }
                $scope.Recipes[i].AverageRate = $scope.Recipes[i].AverageRate / recipesRates;
            }
            $scope.AverageRate = $scope.AverageRate / $scope.RecipeRates.length;
            $scope.TotalRecipe = $scope.Recipes.length;
            //$scope.Level = ;
            $scope.IsNew = 0;
        },
        function (e) {
            console.log('Chargement de l\'utilisateur imopssible', e);
        });
    }


    // Clear form
    $scope.clear = function () {
        $scope.IsNew = 1;
        $scope.IdUser = -1;
        $scope.Email = "";
        $scope.Password = 0;
        $scope.Login = "";
    }

    // Save User
    $scope.save = function () {
        var User = {
            IdUser: $scope.IdUser,
            Login: $scope.Login,
            Email: $scope.Email,
            Password: $scope.Password
        };

        if ($scope.IsNew === 1) {
            var promisePost = UserService.post(User);
            promisePost.then(function (t) {
                $scope.IdUser = t.data.IdUser;
                getData();
            }, function (e) {
                console.log("Error " + e);
            });
        } else {   // Already exists tv show, update 
            var promisePut = UserService.put($scope.IdUser, User);
            promisePut.then(function (t) {
                $scope.Message = "Utilisateur mis à jours";
                getData();
            }, function (e) {
                console.log("Error " + e);
            });
        }
    };
});

//UserService,