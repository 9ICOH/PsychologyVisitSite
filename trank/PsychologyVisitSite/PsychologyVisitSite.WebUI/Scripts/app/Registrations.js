function RegistrationsCtrl($scope) {
    $scope.registration = {}

    $scope.getAllRegistrations = function () {
        $scope.name = 'start';

        sendAjaxRequest("GET",
            function (data) {
                $scope.registrations = data;
                $scope.name = 'finish';
            },
            "RegistrationApi/Registrations");
    }

    $scope.createRegistration = function () {
        $scope.name = 'start';

        sendAjaxRequest("POST",
            function () {
                $scope.name = 'finish';
                $scope.getAllRegistrations.call();
            },
            "RegistrationApi/AddRegistrationItem", $scope.registration);
    }

}