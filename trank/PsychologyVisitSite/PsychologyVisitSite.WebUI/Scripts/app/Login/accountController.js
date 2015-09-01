app.controller('AccountCtrl', ['$scope', '$http',
function ($scope, $http) {

    $scope.authentication = {
        isAuth: false,
        userName: ""
    };
    var tokenKey = 'accessToken';

    function showError(jqXHR) {
        $scope.result = jqXHR.status + ': ' + jqXHR.statusText;
    }

    $scope.callApi = function () {
        $scope.result = '';

        var token = sessionStorage.getItem(tokenKey);
        var headers = {};
        if (token) {
            headers.Authorization = 'Bearer ' + token;
        }

        $.ajax({
            type: 'GET',
            url: '/api/values',
            headers: headers
        }).done(function (data) {
            $scope.result = data;
        }).fail(showError);
    }

    $scope.register = function () {
        $scope.result = '';

        var data = {
            Email: $scope.registerEmail,
            Password: $scope.registerPassword,
            ConfirmPassword: $scope.registerPassword2
        };

        $.ajax({
            type: 'POST',
            url: '/api/Account/Register',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(data)
        }).done(function (data) {
            $scope.result = "Done!";
        }).fail(showError);
    }

    $scope.login = function () {
        $scope.result = '';

        var loginData = {
            grant_type: 'password',
            username: $scope.loginEmail,
            password: $scope.loginPassword
        };

        //$http({
        //    method: "POST",
        //    url: "/Token",
        //    data: loginData
        //})
        //     .success(function (data) {
        //         $scope.user(data.userName);
        //         // Cache the access token in session storage.
        //         sessionStorage.setItem(tokenKey, data.access_token);
        //     })
        //     .error(showError);

        $.ajax({
            type: 'POST',
            url: '/Token',
            data: loginData
        }).done(function (data) {
            $scope.authentication.userName = data.userName;
            $scope.authentication.isAuth = true;
            // Cache the access token in session storage.
            sessionStorage.setItem(tokenKey, data.access_token);
            $scope.$apply();
        }).fail(showError);
    }

    $scope.logout = function () {
        $scope.user = '';
        sessionStorage.removeItem(tokenKey);
    }



}]);