NgCookingUser.service('Session', function () {
    this.create = function (user) {
        this.id = user.IdUser + user.Login;
        this.IdUser = user.IdUser;
        this.Login = user.Login;
        this.Email = user.Email;
    };
    this.destroy = function () {
        this.id = null;
        this.IdUser = null;
        this.Login = null;
        this.Email = null;
    };
});