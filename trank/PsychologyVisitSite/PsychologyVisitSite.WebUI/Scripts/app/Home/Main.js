var myModule = angular.module('app', []);


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
        var sdShow = document.getElementById('homeCarouselInner');
        var indicators = document.getElementById('homeCarouselIndicators');

        for (var i = 0; i < srcList.length; i++) {
            var div = document.createElement('div');
            var li = document.createElement('li');

            if (i == 0) {
                div.className = "item active";
                li.className = "active";
            } else {
                div.className = "item";
            }
            var divCaption = document.createElement('div');
            divCaption.className = "carousel-caption";
            var img = document.createElement('img');
            img.id = "slideshow";
            img.src = srcList[i];
            div.appendChild(img);
            div.appendChild(divCaption);
            sdShow.appendChild(div);

            var dataTarget = document.createAttribute("data-target");
            dataTarget.value = "#myCarousel";
            li.attributes.setNamedItem(dataTarget);
            var dataSlideTo = document.createAttribute("data-slide-to");
            dataSlideTo.value = i;
            li.attributes.setNamedItem(dataSlideTo);
            indicators.appendChild(li);
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

    $scope.getImgUrls = function () {
        sendSimpleAjaxRequest("GET",
            function (srcList) {
                $scope.loadImages(srcList);
                $scope.$apply();
            },
            "InformationApi/GetMainImgUrls");
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