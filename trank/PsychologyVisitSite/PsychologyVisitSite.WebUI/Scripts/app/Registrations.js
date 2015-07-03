function RegistrationsCtrl($scope) {
    $scope.registration = {}

    $scope.getAllRegistrations = function () {
        sendSimpleAjaxRequest("GET",
            function (data) {
                $scope.registrations = data;
                $scope.$apply();
            },
            "RegistrationApi/Registrations");
    }

    $scope.getLastRegistration = function () {
        sendSimpleAjaxRequest("GET",
            function (data) {
                $scope.lastRegistration = data;
                $scope.$apply();
            },
            "RegistrationApi/LastRegistration");
    }

    $scope.createRegistration = function () {
        sendSimpleAjaxRequest("POST",
            function () {
                $scope.getAllRegistrations.call();
            },
            "RegistrationApi/AddRegistrationItem", $scope.registration);
        $scope.registration = null;
    }

}