/// <reference path="../Common/global.js" />
var currentP = "Login";
//forgot password
var loginSocial = {
    showFP: function () {
        BootstrapDialog.show({
            id: "divFPpopup",
            title: __forgotPassword,
            size: BootstrapDialog.SIZE_SMALL,
            message: function () {
                var $message = $('<div id="divForgotPwd" class="pTB10-LR05"></div>');
                var html = '<div class="body">';
                html += '<div class="">';
                html += '<div class="input_holder">';
                html += '   <label for="input-1">' + __emailAddress + '</label>:';
                html += '       <input onkeydown="CallEnter(event, \'btnFPsubmit\')" id="txtUsername" maxlength="100" type="text" class="input__field input__field--haruki form-control" />'; //onkeydown="CallEnter(event, \'btnFPsubmit\')"
                html += '</div>';
                html += '<div>&nbsp;</div>';
                html += '</div>';
                html += '</div>';
                $message.append(html);
                return $message;
            },
            closeByBackdrop: false,
            closable: false,
            buttons: [
                {
                    label: __msglogRegClose,
                    cssClass: 'btn btn-default',
                    action: function (dialogItself) {
                        dialogItself.close();
                    }
                }, {
                    label: __msglogRegSubmit,
                    cssClass: 'btn btn-primary',
                    id: 'btnFPsubmit',
                    action: function (dialog) {
                        if ($.trim($("#txtUsername").val()) != "") {
                            $("#divForgotPwd").append(getLoader());
                            $(".modal-content").append($("#scriptLoader").text());
                            $(".modal-content").attr('class', 'modal-content box');
                            $.ajax({
                                url: '/User/ForgotPassword',
                                data: { "username": $.trim($("#txtUsername").val()) },
                                type: "POST",
                                contentType: "application/x-www-form-urlencoded",
                                dataType: "json",
                                success: function (result) {
                                    removeLoader("#divForgotPwd");
                                    if (result != null) {
                                        $(".modal-content").attr('class', 'modal-content');

                                        if (result.IsSuccess) {
                                            dialog.close();
                                            showBSHtml("Information", result.Message, result.JsonMessageType);
                                        }
                                        else {
                                            $("#divForgotPwd div.alert").remove();
                                            $("#divForgotPwd").prepend(getAlert(result.Message, result.JsonMessageType, false));
                                            $("#txtUsername").val("").focus();
                                        }
                                    }
                                },
                                complete: function () {
                                    setTimeout(function () { //code added by Vikas
                                        removeLoader(".modal-content");
                                        removeLoader("#divForgotPwd");
                                    }, 300);
                                },
                                error: function (xhr, ajaxOptions, thrownError) {
                                    dialog.close();
                                    console.log(xhr.error().statusText);
                                    removeLoader("#divForgotPwd");
                                }
                            });
                        }
                        else {
                            $("#divForgotPwd div.alert").remove();
                            $("#divForgotPwd").prepend(getAlert(__msglogRegEmailAddressRequired, "danger", false));
                        }
                    }
                }
            ],
            onshown: function (dialogRef) {
                $("#txtUsername").val($("#UserName").val())
            }
        });
    }
}

function SubmitLogin() {
    
    var isRemember = false;
    var autologin = false;
    if ($("#rememberme").prop('checked') == true) {
        isRemember = true;
        autologin = false;
    }
    else {
        isRemember = false;
        autologin = false;
    }
    var url = "";
    var flag = !0;
    var username = $("#txtUserName").val().trim();
    if ((username == "")) {
        $("#divLoginMsg > div.alert").remove();
        $("#divLoginMsg").prepend(getAlert(__msglogRegEmailAddressRequired, "danger", false));
    }
    else if ($("#txtPassword").val().trim() == "") {
        $("#divLoginMsg > div.alert").remove();
        $("#divLoginMsg").prepend(getAlert(__msglogRegPassword, "danger", false));
    }
    else {
        $("#divLoginMsg").append(getLoader());
        DoLogin(username, $("#txtPassword").val().trim(), $("#hdnQueryString").val(), isRemember, autologin)
    }
    closeAlertDismissable();
};

function DoLogin(username, password, queryString, isRemember, autologin) {    
    $.ajax({
        url: '/User/Login',
        data: { "username": username, "password": password, "queryString": queryString, "isRemember": isRemember, "autologin": autologin },//$("#frmLogin").serialize(),
        type: "POST",
        contentType: "application/x-www-form-urlencoded",
        dataType: "json",
        cache: false,
        success: function (data) {
            if($("#divLoginMsg"))
                $("#divLoginMsg > div.alert").remove();
            removeLoader("#divLoginMsg");
            if (data.isSuccess) {
                localStorage.setItem("logout", 0);
                if (data.returnUrl != null && data.returnUrl != undefined)
                    window.location.href = data.returnUrl;
            }
            else if (!data.isSuccess) {
                $("#divLoginBox").removeClass("box");
                $("#divLoginMsg > div.alert").remove();
                $("#divLoginMsg").prepend(getAlert(__msglogRegInvalidEmailAddressPass, data.JsonMessageType, false));

                $("#txtPassword").val('');
                $("#txtUserName").val('').focus();
            }
        },
        complete: function () {
            setTimeout(function () { //code added by Vikas
                removeLoader("#divLoginMsg");
            }, 300);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            $("#divLoginBox").removeClass("box");
            setTimeout(function () { //code added by Vikas
                removeLoader("#divLoginMsg");
            }, 300);
            console.log(xhr.error().statusText);
        }
    });
}

$(document).ready(function () {
    //
});

var logReg = {
    login: function (event) {
        $("#divLoginMsg").slideToggle(300);
        $("#txtUserName").focus();
        $("#divRegMsg").slideUp("fast");
        event.stopPropagation();
        logReg.loginNoClose();
        logReg.closeLogin();        
    },
    reg: function (event) {
        $("#divRegMsg").slideToggle(300);
        $("#divLoginMsg").slideUp("fast");
        $("#txtUserName").focus();
        event.stopPropagation();
        logReg.regNoClose();
        logReg.closeReg();
    },
    closeLogin: function () {
        $("html, body").click(function () {
            $("#divLoginMsg").slideUp("fast");
        });
    },
    loginNoClose: function () {
        $("#divLoginMsg").click(function (event) {
            event.stopPropagation();
        })
    },
    closeReg: function () {
        $("html, body").click(function () {
            $("#divRegMsg").slideUp("fast");
        });
    },
    regNoClose: function () {
        $("#divRegMsg").click(function (event) {
            event.stopPropagation();
        })
    }
}

function closeAlertDismissable(){
    $(".alert-dismissable").find("button.close").click(function(){
        $(".alert-dismissable").remove();
    });
}