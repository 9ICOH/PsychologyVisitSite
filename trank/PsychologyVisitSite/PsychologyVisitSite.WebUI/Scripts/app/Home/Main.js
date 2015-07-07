
function sendSimpleAjaxRequest(httpMethod, callback, url, reqData) {
    $.ajax("/api" + (url ? "/" + url : ""), {
        type: httpMethod,
        contentType: false,
        processData: false,
        success: callback,
        data: reqData,
        error: function (xhr, status) {
            alert(status);
        }
    });
}

function MainCtrl($scope) {

    $scope.loadImages = function (srcList) {
        $(function () {
            setInterval("slideSwitch()", 5000);
        });

        var sdShow = document.getElementById('slideshow');

        srcList.forEach(function (src) {
            var img = document.createElement('img');
            img.class = "active";
            img.src = src;
            sdShow.appendChild(img);
        });
    }

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

                sendSimpleAjaxRequest("POST",
                     function (result) {
                         alert(result);
                     }, "InformationApi/UploadFile", data);
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

    $scope.getImgUrls = function () {
        sendSimpleAjaxRequest("GET",
            function (srcList) {
                $scope.loadImages(srcList);
                $scope.$apply();
            },
            "InformationApi/GetMainImgUrls");
    }
}

function showImgs(e) {

    var files = e.target.files;
    for (var i = 0, f; f = files[i]; i++) {

        if (!f.type.match('image.*')) continue;

        var fr = new FileReader();
        fr.onload = (function () {
            return function (ev) {
                var li = document.createElement('li');
                var div = document.createElement('div');
                div.id = "img_wrapper";
                var img = document.createElement('img');

                img.src = ev.target.result;
                div.appendChild(img);
                li.appendChild(div);
                document.getElementById('list').insertBefore(li, null);
            };
        })(f);

        fr.readAsDataURL(f);
    }
}

function handleFileSelect(evt) {
    evt.stopPropagation();
    evt.preventDefault();

    var files = evt.dataTransfer.files; // FileList object.

    for (var i = 0, f; f = files[i]; i++) {

        if (!f.type.match('image.*')) continue;

        var fr = new FileReader();
        fr.onload = (function () {
            return function (ev) {
                var li = document.createElement('li');
                var div = document.createElement('div');
                div.id = "img_wrapper";
                var img = document.createElement('img');

                img.src = ev.target.result;
                div.appendChild(img);
                li.appendChild(div);
                document.getElementById('list').insertBefore(li, null);
            };
        })(f);
        fr.readAsDataURL(f);
    }
}

function handleDragOver(evt) {
    evt.stopPropagation();
    evt.preventDefault();
    evt.dataTransfer.dropEffect = 'copy'; // Explicitly show this is a copy.
}

function slideSwitch() {
    var $active = $('#slideshow IMG.active');

    if ($active.length == 0) $active = $('#slideshow IMG:last');

    var $next = $active.next().length ? $active.next()
        : $('#slideshow IMG:first');

    $active.addClass('last-active');

    $next.css({ opacity: 0.0 })
        .addClass('active')
        .animate({ opacity: 1.0 }, 1000, function () {
            $active.removeClass('active last-active');
        });
}



