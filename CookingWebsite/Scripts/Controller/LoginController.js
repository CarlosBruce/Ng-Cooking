NgCooking.controller('LoginController', ['location', 'UserService', 'authService']);

NgCooking.controller('LoginController', function ($scope, $location, UserService, authService) {

    $scope.Login = '';
    $scope.Password = '';

    $scope.ConnectedUser = authService.currentUser();

    // User LogIn
    $scope.logUserIn = function () {
        var User = {
            IdUser: -1,          
            Login: $scope.Login,
            Email: "",
            Password: $scope.Password
        };

        var promisePost = UserService.postLogin(User);
        promisePost.then(function (t) {

            if (t.data.IdUser > 0)  {
                var element = angular.element('.popin');
                element.removeClass('displayed');
                User.IdUser = t.data.IdUser;
                User.Email = t.data.Email;
                authService.login(User);
                $scope.badPassWord = false;
            }
            else
                $scope.badPassWord = true;
        }, function (e) {
            console.log("Error " + e);
            $scope.badPassWord = true;
        });

    }

})