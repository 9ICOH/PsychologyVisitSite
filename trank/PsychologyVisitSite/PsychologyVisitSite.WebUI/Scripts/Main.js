
function sendAjaxRequest(controller, httpMethod, callback, url, reqData) {
    $.ajax("/api/" + controller + (url ? "/" + url : ""), {
        type: httpMethod,
        success: callback,
        data: reqData
    });
}