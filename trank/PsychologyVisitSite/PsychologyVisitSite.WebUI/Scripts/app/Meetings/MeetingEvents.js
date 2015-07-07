function MeetingEventsCtrl($scope) {

    $scope.action = function() {
        $scope.name = 'start';

        sendSimpleAjaxRequest("GET",
            function(data) {
                $scope.data = data;
                $scope.name = 'finish';
                $scope.$apply();
            },
            "MeetingEventsApi/NearestEvent");
    }
}