
function sendAjaxRequest( httpMethod, callback, url, reqData) {
    $.ajax("/api" + (url ? "/" + url : ""), {
        type: httpMethod,
        success: callback,
        data: reqData
    });
}

function MainCtrl($scope) {

    //$scope.action = function () {
    //    $scope.name = 'start';

    //    sendAjaxRequest("GET",
    //        function (data) {
    //            $scope.data = data;
    //            $scope.name = 'finish';
    //        },
    //        "MeetingEventsApi/NearestEvent");
    //}

   //function removeItem(item) {
    //    sendAjaxRequest("DELETE", function () {
    //        for (var i = 0; i < model.registrations().length; i++) {
    //            if (model.registrations()[i].Id == item.Id) {
    //                model.registrations.remove(model.registrations()[i]);
    //                break;
    //            }
    //        }
    //    }, "DeleteRegistration", item.Id);
    //}

    //function getAllRegistrations() {
    //    sendAjaxRequest("RegistrationApiController", "GET", function (data) {
    //        model.registrations.removeAll();
    //        for (var i = 0; i < data.length; i++) {
    //            model.registrations.push(data[i]);
    //        }
    //    }, "Registrations");
    //}

    //function getAllItems() {
    //    sendAjaxRequest("MeetingEventsApiController", "GET", function (data) {
    //        model.registrations.removeAll();
    //        for (var i = 0; i < data.length; i++) {
    //            model.registrations.push(data[i]);
    //        }
    //    }, "AllEvents");
    //}

    //function handleEditorClick() {
    //    sendAjaxRequest("POST", function (newItem) {
    //        model.registrations.push(newItem);
    //        resetClicks();
    //    }, null, {
    //        FirstName: model.editor.firstName,
    //        LastName: model.editor.lastName,
    //        Location: model.editor.location,
    //        Email: model.editor.email,
    //        PhoneNumber: model.editor.phoneNumber,
    //        Skype: model.editor.skype,
    //        Comment: model.editor.comment
    //    });
    //}
}