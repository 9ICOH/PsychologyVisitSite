app.controller('RegistrationsCtrl',
    function($scope, $http) {
        $scope.registration = {}

        $scope.updateAllRegistrations = function() {
            $http({ method: "GET", url: "/api/RegistrationApi/Registrations" }).
                success(function(data) {
                    $scope.registrations = data;
                }).
                error(function(data, status) {
                    $scope.data = data || "Request failed";
                    $scope.status = status;
                });
        }

        $scope.getLastRegistration = function() {
            $http({ method: "GET", url: "/api/RegistrationApi/LastRegistration" }).
                success(function(data) {
                    $scope.lastRegistration = data;
                }).
                error(function(data, status) {
                    $scope.data = data || "Request failed";
                    $scope.status = status;
                });
        }

        $scope.createRegistration = function() {
            $http({ method: "POST", url: "/api/RegistrationApi/AddRegistrationItem" }).
                success(function() {
                    $scope.updateAllRegistrations.call();
                    $scope.registration = null;
                }).
                error(function(data, status) {
                    $scope.data = data || "Request failed";
                    $scope.status = status;
                });
        }

    });