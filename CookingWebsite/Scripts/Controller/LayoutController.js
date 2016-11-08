NgCooking.controller('LayoutController', 'authService');

NgCooking.controller('LayoutController', function ($scope, authService) {

    var u = authService.currentUser();

    $scope.IdUser = -1;
    $scope.Email = '';
    $scope.Login = '';

    $scope.Connected = false;
    $scope.badPassWord = false;

    authService.subscribe($scope, function somethingChanged() {
        var u = authService.currentUser();

        if (u == null)
            $scope.ProfileLink = 'http://localhost:51312/User/List/';
        else {
            $scope.IdUser = u.IdUser;
            $scope.Email = u.Email;
            $scope.Login = u.Login;
            $scope.ProfileLink = 'http://localhost:51312/User/Detail/' + u.IdUser
            $scope.Connected = true;
        }
    });

    if (u == null)
        $scope.ProfileLink = 'http://localhost:51312/User/List/';
    else {
        $scope.IdUser = u.IdUser;
        $scope.Email = u.Email;
        $scope.Login = u.Login;
        $scope.ProfileLink = 'http://localhost:51312/User/Detail/' + u.IdUser
        $scope.Connected = true;
    }

    // User LogOut
    $scope.logOut = function () {
        authService.logout();
        $scope.IdUser = -1;
        $scope.Email = '';
        $scope.Login = '';
        $scope.Connected = false;
        $scope.ProfileLink = 'http://localhost:51312/User/List/';
    }
})