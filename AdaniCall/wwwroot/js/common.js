var wasCallConnected = false;
var LoadCallCount = 0;
var LoadCountAllowed = 3;

function StartRecording(uniqueCallID, serverid) {
    var callingPage = window.location.href;
    if (serverid) {
        if (callingPage.toLowerCase().indexOf("accept") > -1) {
            $.ajax({
                url: "/api/Recording/startRecording/",
                type: "POST",
                contentType: "application/x-www-form-urlencoded",
                dataType: "json",
                data: {
                    sCallId: serverid,
                    recordingFormat: "",
                    UniqueCallID: uniqueCallID,
                },
                success: function (data) { },
            });
        }
    }
}

function GetAvailableAgent(txt) {
    var callingPage = window.location.href;
    if (callingPage.toLowerCase().indexOf("call") > -1) {
        $.ajax({
            url: "/User/GetAvailableAgent/",
            type: "POST",
            contentType: "application/x-www-form-urlencoded",
            dataType: "json",
            cache: false,
            async: false,
            success: function (data) {
                if (data.data.id > 0) {
                    $("#callee-acs-user-id").val(data.data.agentCallID);
                } else if (data.data.id == -1) {
                    ShowConnectingMsg(txt + " no one");
                    $("#callee-acs-user-id").val("");
                    setTimeout(function () { }, 5000);
                }
            },
            complete: function () {
                setTimeout(function () { }, 300);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                setTimeout(function () { }, 300);
            },
        });
    }
}

function GetKioskDetails(callerID) {
    var callingPage = window.location.href;
    if (callingPage.toLowerCase().indexOf("accept") > -1) {
        $.ajax({
            url: "/User/GetKioskDetails/",
            type: "POST",
            contentType: "application/x-www-form-urlencoded",
            dataType: "json",
            data: { TravellerCallerID: callerID },
            cache: false,
            async: true,
            success: function (data) {
                if (data.data.id > 0) {
                    $("#lblKioskName").text(data.data.deviceName);
                    $("#lblKioskName").show();
                } else {
                    $("#lblKioskName").hide();
                }
            },
            complete: function () {
                setTimeout(function () { }, 300);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                $("#lblKioskName").hide();
            },
        });
    }
}

function FreeAgent(agentCallerID) {
    var callingPage = window.location.href;
    if (callingPage.toLowerCase().indexOf("accept") > -1) {
        $.ajax({
            url: "/User/ChangeAvailabilityStatus/",
            type: "POST",
            contentType: "application/x-www-form-urlencoded",
            dataType: "json",
            data: { AvailabilityStatus: "1" },
            cache: false,
            async: false,
            success: function (data) { },
            complete: function () {
                setTimeout(function () { }, 300);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                setTimeout(function () { }, 300);
            },
        });
    } else if (
        callingPage.toLowerCase().indexOf("call") > -1 &&
        agentCallerID != ""
    ) {
        $.ajax({
            url: "/User/ChangeAvailabilityStatus/",
            type: "POST",
            contentType: "application/x-www-form-urlencoded",
            dataType: "json",
            data: { AvailabilityStatus: "1", AgentCallerID: agentCallerID },
            cache: false,
            async: false,
            success: function (data) { },
            complete: function () {
                setTimeout(function () { }, 300);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                setTimeout(function () { }, 300);
            },
        });
    }
}

function MakeCallTransaction(uniqueCallID, incomingCallID) {
    var callingPage = window.location.href;
    if (callingPage.toLowerCase().indexOf("accept") > -1) {
        $.ajax({
            url: "/Home/MakeCallTransaction/",
            type: "POST",
            contentType: "application/x-www-form-urlencoded",
            dataType: "json",
            data: { UniqueCallID: uniqueCallID, IncomingCallID: incomingCallID },
            cache: false,
            async: true,
            success: function (data) { },
            complete: function () {
                setTimeout(function () { }, 300);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                setTimeout(function () { }, 300);
            },
        });
    }
}

function UpdateCallTransactionsEndTime(uniqueCallID) {
    var callingPage = window.location.href;
    if (callingPage.toLowerCase().indexOf("accept") > -1) {
        var callLanguage = $("#hdnCallLanguage").val();
        $("#hdnCallLanguage").val("3");
        $.ajax({
            url: "/Home/UpdateCallTransactionsEndTime/",
            type: "POST",
            contentType: "application/x-www-form-urlencoded",
            dataType: "json",
            data: { UniqueCallID: uniqueCallID, CallLanguage: callLanguage },
            cache: false,
            async: true,
            success: function (data) { },
            complete: function () {
                setTimeout(function () { }, 300);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                setTimeout(function () { }, 300);
            },
        });
    }
}

function InsertAccessMember(uniqueCallID, callStatus) {
    $.ajax({
        url: "/Home/InsertAM/",
        type: "POST",
        contentType: "application/x-www-form-urlencoded",
        dataType: "json",
        data: { UniqueCallID: uniqueCallID, CallStatus: callStatus },
        cache: false,
        async: true,
        success: function (data) { },
        complete: function () {
            setTimeout(function () { }, 300);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            setTimeout(function () { }, 300);
        },
    });
}

function ShowDefaultScreen(frm) {
    $("#allStepID").removeClass("video_container_loader");
    RemoveAllMsg();

    if (frm == "ThankYouMsg") $(".all_steps").find(".all_steps_inner").html("");
    else
        $(".all_steps")
            .find(".all_steps_inner")
            .html(
                "<div class='para-text'><p>Connecting to a passenger service agent...</p></div>"
            );
    console.log("this is Default Screen from : " + frm);
}

function PreVideoMsg(frm) {
    $("#allStepID").removeClass("video_container_loader");
    RemoveAllMsg();
    $(".all_steps")
        .find(".all_steps_inner")
        .html(
            "<div class='para-text'><p>Connecting to a passenger service agent...</p></div>"
        );
    console.log("this is Default Screen from : " + frm);
}

var noFaceDefault;
function ShowDefaultScreenAfterWait(cnt) {
    if ($("#hdnCallTimeOut").val() == "1") {
        ShowDefaultScreen(cnt + "Noface ");
    }
}

var showConnectingMsgTimeOut = "";
function ShowConnectingMsg(frm) {
    $("#allStepID").removeClass("video_container_loader");
    RemoveAllMsg();

    $(".all_steps")
        .find(".all_steps_inner")
        .html(
            "<div class='para-text'><p>Connecting to a passenger service agent...</p></div>"
        );
    var callingPage = window.location.href;
    if (callingPage.toLowerCase().indexOf("call") > -1) {
        showConnectingMsgTimeOut =
            showConnectingMsgTimeOut +
            "," +
            setTimeout(function () {
                faceSpotted = false;

                FreeAgent($("#callee-acs-user-id").val());
                setTimeout(function () {
                    window.location.href = "/Landing/Index";
                }, 5000);
            }, 45000);
    }
}

var myCallEndInitiate;
var myCallRinging;
function ShowCallInitiationMsg() {
    $("#allStepID").removeClass("video_container_loader");
    var callingPage = window.location.href;
    if (callingPage.toLowerCase().indexOf("call") > -1) {
        if (noFaceDefault) clearTimeout(noFaceDefault);
        if (showConnectingMsgTimeOut && showConnectingMsgTimeOut != "") {
            for (i = 0; i < showConnectingMsgTimeOut.split(",").length; i++)
                if (showConnectingMsgTimeOut.split(",")[i] != "")
                    clearTimeout(showConnectingMsgTimeOut.split(",")[i]);
        }

        showConnectingMsgTimeOut = "";
    }
    RemoveAllMsg();

    $(".all_steps")
        .find(".all_steps_inner")
        .html(
            "<div class='para-text'><p>Connecting to a passenger service agent...</p></div>"
        );
    myCallEndInitiate = setTimeout(function () {
        CallWaitTimeout();
    }, 29000);
}

function ClearTimeOut() {
    try {
        if (myCallRinging) clearTimeout(myCallRinging);
    } catch (e) { }
    try {
        if (myCallEndInitiate) clearTimeout(myCallEndInitiate);
    } catch (e) { }
}

function ClearNoFaceTimeOut() {
    try {
        if (noFaceTimeout) clearTimeout(noFaceTimeout);
    } catch (e) { }
}

function ShowRingMsg() {
    RemoveAllMsg();
    var audio = "";
    audio +=
        '<audio id="telephoneRing" preload="auto" controls autoplay loop style="visibility: hidden;">';
    audio +=
        '  <source src="../Content/audio/telephone-ring-02.mp3" type="audio/mpeg">';
    audio += "  Your browser does not support the audio element.";
    audio += "</audio>";
    audio +=
        '<div class="div-ringingcall"><img src="../images/ringing-call.gif" alt="ringing-call.gif" class="img-ringingcall"></div>';
    $(".all_stepsAccept").find(".all_stepsAccept_inner").html(audio);

    myCallRinging = setTimeout(function () {
        RingTimeout();
    }, 26000);
}

function RingTimeout() {
    RemoveAllMsg();
    FreeAgent("");

    HangtheCall();
}

function HangtheCall() {
    var isHangDisabled = false;
    if ($("#hangup-call-button").hasClass("btn-disable")) {
        isHangDisabled = true;
        $("#hangup-call-button").removeClass("btn-disable");
        $("#hangup-call-button").prop("disabled", false);
    }

    $("#hdnhangup-call-button").click();

    if (isHangDisabled) {
        $("#hangup-call-button").addClass("btn-disable");
        $("#hangup-call-button").prop("disabled", true);
    }
}

function hangtheCallLangPopup(langSel) {
    BootstrapDialog.show({
        title: "Select Language",
        id: "divSelLang",
        size: BootstrapDialog.SIZE_NORMAL,
        type: getDialogType("PRIMARY"),
        message: function () {
            var $message = $("<div></div>");
            var html = "";
            html += "<div>";
            html +=
                "   <p><strong>Select the Language in which the conversation took place.</strong></p>";
            html +=
                '   <div style="display: flex; flex-direction: row; justify-content: space-between">';
            html +=
                '       <button id="langEn" type="button" class="btnLang" onclick="hangtheCallWithLang(3)" style="width: 220px;">English</button>';
            html +=
                '       <button id="langHn" type="button" class="btnLang" onclick="hangtheCallWithLang(4)" style="width: 220px;">Hindi</button>';
            html += "   </div>";
            html += '   <div class="clearfix"></div>';
            html += "</div>";
            $message.append(html);
            return $message;
        },

        closable: false,
        draggable: false,

        onshown: function (dialogRef) { },
    });
}

function hangtheCallWithLang(langSel) {
    console.log("this is hang clicked for : " + langSel);
    $("#hdnCallLanguage").val(langSel);
    HangtheCall();
    $("#divSelLang").modal("hide");
}

var callTimeOutCount = 0;
function CallWaitTimeout() {
    if (!wasCallConnected) {
        $("#hdnCallTimeOut").val("1");
        HangtheCall();
        $("#callee-acs-user-id").val("");
        $("#hdnCallStatus").val("0");
        callTimeOutCount = callTimeOutCount + 1;
        RemoveAllMsg();
        ShowConnectingMsg(callTimeOutCount + "WaitTimeout");
        GetAvailableAgent("wait ");
        $("#start-call-button").addClass("btn-disable");
        $("#start-call-button").prop("disabled", false);
    }
}

var thankyouStatus = 0;
function ShowThankYouMsg() {
    $("#allStepID").removeClass("video_container_loader");
    thankyouStatus = 1;
    var callingPage = window.location.href;

    RemoveAllMsg();
    var seconds = 5;
    $(".all_steps")
        .find(".all_steps_inner")
        .html(
            "<div class='para-text'><p>Thank you for talking to us.<br />Have a safe journey!<br /><br /></p><p><span class='countdown'>" +
            seconds +
            "</span><p></div>"
        );
    var count = setInterval(function () {
        $("span.countdown").html(seconds);
        if (seconds > 2 && seconds < 10) {
            FreeAgent($("#callee-acs-user-id").val());
        }
        if (seconds < 2) {
            clearInterval(count);

            $("#hdnCallStatus").val("0");
            if (callingPage.toLowerCase().indexOf("call") > -1) {
                thankyouStatus = 0;

                faceSpotted = false;

                window.location.href = "/Landing/Index";
            }
        }
        seconds--;
        if (seconds < 10) {
            minutes = "0" + seconds;
        }
    }, 1000);
}

function RemoveAllMsg() {
    if ($(".all_steps")) $(".all_steps").find(".all_steps_inner").html("");
    if ($(".all_stepsAccept"))
        $(".all_stepsAccept").find(".all_stepsAccept_inner").html("");
}

function CheckCallStatus(objCall) {
    console.log(
        "this is Status Check:" + objCall.state + ":" + objCall.direction
    );
}

function CheckIfAgentInactive() {
    var callingPage = window.location.href;
    if (callingPage.toLowerCase().indexOf("accept") > -1) {
        if (
            ($("#start-call-button").hasClass("btn-disable") ||
                $("#start-call-button").prop("disabled")) &&
            ($("#hangup-call-button").hasClass("btn-disable") ||
                $("#hangup-call-button").prop("disabled"))
        ) {
            $.ajax({
                url: "/User/MakeAgentActive/",
                type: "POST",
                contentType: "application/x-www-form-urlencoded",
                dataType: "json",
                cache: false,
                async: false,
                success: function (data) { },
                complete: function () {
                    setTimeout(function () { }, 300);
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    setTimeout(function () { }, 300);
                },
            });
        }
    }
}

function ClearRefreshInterval() {
    try {
        console.log("this is ClearRefreshInterval");
        if (intervalCheckRefreshNeeded) clearInterval(intervalCheckRefreshNeeded);
        intervalCheckRefreshNeeded = setInterval(CheckRefreshNeeded, 300000); //1800000 - 30mins//600000 - 10mins//900000 - 15mins//300000 - 5mins
    } catch (e) { }
}
function CheckRefreshNeeded() {
    if ($("#hdnCallStatus").val() != "1") {
        console.log("this is CheckRefreshNeeded");
        $.ajax({
            url: "/User/IsRefreshRequired/",
            type: "POST",
            contentType: "application/x-www-form-urlencoded",
            dataType: "json",
            cache: false,
            async: false,
            success: function (data) {
                if (data.data.id == 1) {
                    window.location.reload();
                }
                console.log("this is CheckRefreshNeeded value:" + data.data.id);
            },
            complete: function () {
                setTimeout(function () { }, 300);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                setTimeout(function () { }, 300);
            },
        });
    } else {
        console.log("this is CheckRefreshNeeded not executed");
    }
}
var intervalCheckRefreshNeeded;
$(document).ready(function () {
    //steps.step1();
    ShowDefaultScreen("onload ");
    var callingPage = window.location.href;
    if (callingPage.toLowerCase().indexOf("call") > -1) LoadCall();
    setInterval(function () {
        CheckIfAgentInactive();
    }, 25000);

    setInterval(function () {
        if (callingPage.toLowerCase().indexOf("call") > -1)
            InsertAccessMemberPing("KioskPing");
    }, 300000);

    setInterval(function () {
        if (callingPage.toLowerCase().indexOf("accept") > -1)
            InsertAccessMemberPing("AgentPing");
    }, 240000);

    if (callingPage.toLowerCase().indexOf("accept") > -1)
        intervalCheckRefreshNeeded = setInterval(CheckRefreshNeeded, 300000); //1800000 - 30mins//600000 - 10mins//900000 - 15mins//300000 - 5mins
});
