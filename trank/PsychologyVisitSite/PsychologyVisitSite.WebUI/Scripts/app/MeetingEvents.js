function MeetingEventsCtrl($scope) {

    $scope.action = function() {
        $scope.name = 'start';

        sendAjaxRequest("GET",
            function(data) {
                $scope.data = data;
                $scope.name = 'finish';
            },
            "MeetingEventsApi/NearestEvent");
    }
}