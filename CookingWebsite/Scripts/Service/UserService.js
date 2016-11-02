angular.module('ngRoute').service('UserService', function ($http) {

    //Create new
    this.post = function (User) {
        var request = $http({
            method: "post",
            url: "http://localhost:51371/api/User",
            data: User,
        });
        return request;
    }
    //Get Single 
    this.get = function (Id) {
        return $http.get("http://localhost:51371/api/User/" + Id);
    }

    //Get All
    this.getUsers = function () {
        return $http.get("http://localhost:51371/api/User");
    }
});