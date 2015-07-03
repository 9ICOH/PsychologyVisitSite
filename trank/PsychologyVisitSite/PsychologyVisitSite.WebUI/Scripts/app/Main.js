
function sendSimpleAjaxRequest(httpMethod, callback, url, reqData) {
    $.ajax("/api" + (url ? "/" + url : ""), {
        type: httpMethod,
        success: callback,
        data: reqData,
        error: function (xhr, status) {
        alert(status);
    }
    });
}

function MainCtrl($scope) {

    $scope.loadImage = function (srcMain) {
        document.getElementById('imgMain').src = srcMain;
    }

    $scope.uploadImage = function () {
        var files = document.getElementById('uploadImgs').files;
        if (files.length > 0) {
            if (window.FormData !== undefined) {
                var data = new FormData();
                for (var x = 0; x < files.length; x++) {
                    data.append("file" + x, files[x]);
                }

                //sendSimpleAjaxRequest("POST",
                //     function (result) {
                //         alert(result);
                //     }, "InformationApi/UploadFile", data);

                $.ajax({
                    type: "POST",
                    url: '/api/InformationApi/UploadFile',
                    contentType: false,
                    processData: false,
                    data: data,
                    success: function (result) {
                        alert(result);
                    },
                    error: function (xhr, status, p3) {
                        alert(status);
                    }
                });

            } else {
                alert("Браузер не поддерживает загрузку файлов HTML5!");
            }
        }
    }

    $scope.getLastInformation = function () {
        sendSimpleAjaxRequest("GET",
            function (data) {
                $scope.information = data;
                $scope.$apply();
            },
            "InformationApi/LastInformation");
    }

    $scope.showMainImg = function () {
        sendSimpleAjaxRequest("GET",
            function (src) {
                $scope.loadImage(src);
                $scope.$apply();
            },
            "InformationApi/GetMainImgUrl");
    }
}

function showImgs(e) {

    var files = e.target.files;
    for (var i = 0, f; f = files[i]; i++) {

        if (!f.type.match('image.*')) continue;

        var fr = new FileReader();
        fr.onload = (function (theFile) {
            return function (ev) {
                var li = document.createElement('li');
                li.innerHTML = "<div class='.img_wrapper.loaded'>" + "<img src='" + ev.target.result + "' />" + "</div>";
                document.getElementById('list').insertBefore(li, null);
            };
        })(f);

        fr.readAsDataURL(f);
    }
}

