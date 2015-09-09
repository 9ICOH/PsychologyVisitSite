app.controller('MainEditorCtrl', ['$scope', '$http',
function ($scope, $http) {

    $scope.imageDropped = function () {
        var files = $scope.uploadedFiles;

        if (files != null && files.length > 0) {
            if (window.FormData !== undefined) {
                var imgsData = new FormData();
                for (var x = 0; x < files.length; x++) {
                    imgsData.append("file" + x, files[x]);
                }

                var token = sessionStorage.getItem('accessToken');
                var headers = {};
                if (token) {
                    headers.Authorization = 'Bearer ' + token;
                }

                sendSimpleAjaxRequest("POST",
                     function (result) {
                         alert(result);
                     }, "InformationApi/UploadFiles", imgsData, headers);
            } else {
                alert("Браузер не поддерживает загрузку файлов HTML5!");
            }
        }

        // $scope.uploadedFiles = null;
    };

    $scope.saveChanges = function () {
        $scope.imageDropped();
        $('#editHomeModal').modal('hide');
    };

    $scope.showUploadedFiles = function (files) {
        $scope.srcs = new Array();

        for (var i = 0, f; f = files[i]; i++) {
            if (!f.type.match('image.*')) continue;
            var fr = new FileReader();

            fr.onload = (function () {
                return function (ev) {
                    $scope.srcs.push(ev.target.result);
                    $scope.$apply();
                };
            })(f);
            fr.readAsDataURL(f);
        }
    };

}]);

app.directive("imagedrop", ['$parse', '$document', function ($parse, $document) {
    return {
        restrict: "A",
        link: function (scope, element, attrs) {
            var onImageDrop = $parse(attrs.onImageDrop);

            var onDragOver = function (e) {
                //e.dataTransfer.dropEffect = 'copy'; // Explicitly show this is a copy.
                e.stopPropagation();
                e.preventDefault();
                // angular.element('body').addClass("dragOver");
            };

            var onDragEnd = function (e) {
                e.preventDefault();
                //  angular.element('body').removeClass("dragOver");
            };

            var loadFile = function (files) {
                scope.showUploadedFiles(files);
                scope.uploadedFiles = files;
                scope.$apply(onImageDrop(scope));
            };

            $document.bind("dragover", onDragOver);

            element.bind("dragleave", onDragEnd)
                   .bind("drop", function (e) {
                       onDragEnd(e);
                       loadFile(e.originalEvent.dataTransfer.files);
                   });
        }
    };
}]);