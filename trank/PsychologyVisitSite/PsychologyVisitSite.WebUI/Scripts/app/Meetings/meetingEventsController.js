function MeetingEventsCtrl($scope, $http) {

    $scope.updateMeetingEvents = function () {
        $http({ method: "GET", url: "/api/MeetingEventsApi/NearestEvent" }).
           success(function (data) {
               $scope.meetingEvents = data;
           }).
           error(function (data, status) {
               $scope.data = data || "Request failed";
               $scope.status = status;
           });
    };

}