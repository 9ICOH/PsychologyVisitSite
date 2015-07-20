var app = angular.module('app', []);

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
};