// @grant        window.close
$(document).ready(function () {
    /**/
    
});

// Append The Html Returned From This Method to your div which has class=box
// Start Loaders
function getLoader() {
    return $("#scriptLoader").html();
}
function removeLoader(selector) {
    $(selector).find(".overlay, .loading-img").remove();
}
function getLoaderSmall() {
    return $("#scriptLoaderSmall").html();
}
function removeLoaderSmall(selector) {
    $(selector).find(".overlay, .loading-img-small").remove();
}


function SubmitForm(formName) {
    $("#" + formName).submit();
}
function SubmitFormWritePres(formName, hdnId, val) {
    if (hdnId) {
        $("#" + hdnId).val(val);
    }
    $("#" + formName).submit();
}
// End Loaders
var loginSocial = {
    showFP: function () {
        BootstrapDialog.show({
            id: "divFPpopup",
            title: __forgotPassword,
            message: function () {
                var $message = $('<div id="divForgotPwd" class="pTB10-LR05"></div>');
                var html = '<div class="body">';
                html += '<div class="">';                
                html += '<div class="input_holder">';
                html += '   <label for="input-1">' + __emailAddress + '</label>:';
                html += '       <input id="txtUsername" maxlength="100" type="text" class="input__field input__field--haruki form-control" />';                
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
                    cssClass: 'btn-default',
                    action: function (dialogItself) {
                        dialogItself.close();
                    }
                }, {
                    label: __msglogRegSubmit,
                    cssClass: 'btn-primary',
                    id: 'btnFPsubmit',
                    action: function (dialog) {
                        alert("Forgor Password");
                    }
                }
            ],
            onshown: function (dialogRef) {
                $("#txtUsername").val($("#UserName").val())//.focus();
            }
        });
    }
}

function CallEnter(objEvent, obj) {
    if (objEvent) {
        if (objEvent.which || objEvent.keyCode) {
            if ((objEvent.which == 13) || (objEvent.keyCode == 13)) {
                $("#" + obj).click();
                return false;
            }
        }
    }
    else
        return true;
}

function getAlert(message, type, hasIcon) {
    var i = "danger";
    var c = "ban";
    switch (type) {
        case "error":
        case "failure":
        case "danger":
            c = "danger";
            i = "ban"
            break;
        case "info":
            c = i = "info";
            break;
        case "warning":
            c = i = "warning";
            break;
        case "success":
            c = "success";
            i = "check";
            break;
        default:
            c = "danger";
            i = "ban"
            break;
    }
    
    var html = $("#scriptAlert").text();
    if (hasIcon)
        html = html.replace("<!--", "").replace("-->", "").replace("[[ICON]]", i);
    html = html.replace("[[CLASS]]", c).replace("[[MESSAGE]]", message);
    
    return html;
}


function getParameterByName(name, url) {
    if (!url) url = window.location.href;
    name = name.replace(/[\[\]]/g, "\\$&");
    var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
        results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, " "));
}



// convert Formdata to object
$.fn.serializeObject = function () {
    var o = {};
    var a = this.serializeArray();
    $.each(a, function () {
        if (o[this.name] !== undefined) {
            if (!o[this.name].push) {
                o[this.name] = [o[this.name]];
            }
            o[this.name].push(this.value || '');
        } else {
            o[this.name] = this.value || '';
        }
    });
    return o;
};

function CopyText(result) {
    var textArea = document.createElement("textarea");
    textArea.value = result;

    // Avoid scrolling to bottom
    textArea.style.top = "0";
    textArea.style.left = "0";
    textArea.style.position = "fixed";

    document.body.appendChild(textArea);
    textArea.focus();
    textArea.select();

    document.execCommand("copy");
    document.body.removeChild(textArea);
}


function getLocations(role) {
    //alert(role)
    var roleid = "0";
    if (role) { roleid = role }
    var companyID = $("#CompanyID  option:selected").val();
    if (roleid != "3") {
        $("#LocationID").find('option').remove();

        $("#LocationID").append(getLoader());
        $.ajax({
            url: "/DashBoard/GetCompanyLocaitons/",
            data: JSON.stringify({ companyID: companyID }),
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: true,
            cache: false,
            success: function (data) {
                removeLoader("#LocationID");
                $.each(data.Data, function () {
                    $("#LocationID").append(
                        $('<option/>', {
                            value: this.Value,
                            text: this.Text
                        })
                    );
                });
            },
            complete: function () {
                setTimeout(function () {
                    removeLoader("#LocationID");
                }, 300);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                $("#LocationID").removeClass("box");
                setTimeout(function () {
                    removeLoader("#LocationID");
                }, 300);
            }
        });
    }
}


function InsertAccessMemberPing(PingFrom) {
    //$("#divLoader").append(getLoader());
    $.ajax({
        url: "/Home/InsertAMPing/",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify({ pingFrom: PingFrom }),
        cache: false,
        async: true,
        success: function (data) {
            //removeLoader("#divLoader");
            //$("#callee-acs-user-id").val(data.Data.AgentCallID)
        },
        complete: function () {
            setTimeout(function () {
                //removeLoader("#divLoader");
            }, 300);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            //$("#divLoader").removeClass("box");
            setTimeout(function () {
                //removeLoader("#divLoader");
            }, 300);
        }
    });
}