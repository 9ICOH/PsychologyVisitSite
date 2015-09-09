var app = angular.module('app', []);

function sendSimpleAjaxRequest(httpMethod, callback, url, reqData, headers) {
    $.ajax("/api" + (url ? "/" + url : ""), {
        type: httpMethod,
        contentType: false,
        processData: false,
        success: callback,
        headers: headers,
        data: reqData,
        error: function (xhr, status) {
            alert(status);
        }
    });
};