app.controller('MainCtrl',
function ($scope, $http) {
    $scope.updateLastInformation = function () {
        $http({ method: "GET", url: "/api/InformationApi/LastInformation" }).
           success(function (data) {
               $scope.lastInformation = data;
           }).
           error(function (data, status) {
               $scope.data = data || "Request failed";
               $scope.status = status;
           });
    };

    $scope.updateImgUrls = function() {
        $http({ method: "GET", url: "/api/InformationApi/GetMainImgUrls" }).
            success(function(srcList) {
                $scope.carouselImages = srcList;
            }).
            error(function(data, status) {
                $scope.data = data || "Request failed";
                $scope.status = status;
            });
    };
});


