//Call this method to show BootStrap Alert with Custom Styles
function showBSAlert(title, message, type, isClosable, redirectUrl) {
    BootstrapDialog.show({
        title: title,
        message: message,
        type: getDialogType(type),
        buttons: [{
            label: 'Ok',
            cssClass: 'btn btn-primary',
            action: function (dialogItself) {
                dialogItself.close();
            }
        }]
    });
}

function showBSAlertNonClosable(title, message, type, isClosable, redirectUrl) {
    BootstrapDialog.show({
        id: "divBSAlert",
        title: title,
        message: message,
        closable: false,
        type: getDialogType(type)
    });
}

//Call this method to show BootStrap Confirmation
function showBSConfirm(message) {
    BootstrapDialog.confirm(message, function (result) {
        if (result) {
            return true;
        } else {
            return false;
        }
    });
}

//Call this method to show BootStrap Popup in which you can pass Html to show in popup
function showBSHtml(title, html, type, label) {
    if (label == undefined || label=="" || label==null)
        label = 'OK';

    BootstrapDialog.show({
        id: "divBSHtml",
        title: title,
        type: getDialogType(type),
        message: function () {
            var $message = $('<div id="divDialogMsg"></div>');
            $message.append(html);
            return $message;
        },
        closeByBackdrop: false,
        buttons: [
            {
                label: label,                
                id: 'btnDialogCancel',
                action: function (dialogItself) {
                    dialogItself.close();
                }
            }]
    });
}

function showBSRedirect(data) {
    if (data.ReturnUrl != null && data.ReturnUrl != "")
        showBSAlert(data.MessageCaption, data.Message, data.JsonMessageType, false, data.ReturnUrl);
    else
        showBSAlert(data.MessageCaption, data.Message, data.JsonMessageType);
}

function getDialogType(type) {
    switch (type.toUpperCase()) {
        case "PRIMARY":
            return BootstrapDialog.TYPE_PRIMARY;
            break;
        case "INFO":
            return BootstrapDialog.TYPE_INFO;
            break;
        case "SUCCESS":
            return BootstrapDialog.TYPE_SUCCESS;
            break;
        case "WARNING":
            return BootstrapDialog.TYPE_WARNING;
            break;
        case "DANGER":
        case "ERROR":
        case "FAILURE":
            return BootstrapDialog.TYPE_DANGER;
            break;
        case "DEFAULT":
            return BootstrapDialog.TYPE_DEFAULT;
            break;
        default:
            return BootstrapDialog.TYPE_DEFAULT;
            break;
    }
}

function closeAllBsDialogs() {
    $.each(BootstrapDialog.dialogs, function (id, dialog) {
        dialog.close();
    });
}