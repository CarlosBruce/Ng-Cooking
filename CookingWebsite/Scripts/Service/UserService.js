
NgCookingUser.service('UserService', function ($http) {

    this.postLogin = function (User) {
        //var request = $http({
        //    method: "post",
        //    url: "http://localhost:51371/api/User/login",
        //    data: User,
        //});
        //return request;

        return $http.get("http://localhost:51371/api/User/?Login=" + User.Login + "&password=" + User.Password);
    }

    this.post = function (User) {
        var request = $http({
            method: "post",
            url: "http://localhost:51371/api/User",
            data: User,
        });
        return request;
    }

    this.get = function (Id) {
        return $http.get("http://localhost:51371/api/User/" + Id);
    }

    this.getUsers = function () {
        return $http.get("http://localhost:51371/api/User");
    }
});