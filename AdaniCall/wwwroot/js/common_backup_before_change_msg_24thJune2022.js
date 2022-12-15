var wasCallConnected = false;
var LoadCallCount = 0;
var LoadCountAllowed = 3;

function StartRecording(uniqueCallID, serverid) {
	//alert("Fn Call:" +serverid )
    var ReturnURL = '';
    var pageurl = '/api/Recording/startRecording'
    var pageurlAudio = '/api/Recording/startRecording'

	var callingPage = window.location.href;
	//alert(callingPage)
	if (serverid) {
		if (callingPage.toLowerCase().indexOf("accept") > -1) {
			$.ajax({
				url: pageurl,
				type: "POST",
				contentType: "application/json; charset=utf-8",
				dataType: "json",
                data: JSON.stringify({ sCallId: serverid, recordingFormat: "", UniqueCallID: uniqueCallID }),
				success: function (data) {
					//alert("Call Success:" + serverid)
				}
			});

			//$.ajax({
   //             url: pageurlAudio,
			//	type: "POST",
			//	contentType: "application/json; charset=utf-8",
			//	dataType: "json",
   //             data: JSON.stringify({ sCallId: serverid, recordingFormat: "wav", UniqueCallID: uniqueCallID }),
			//	success: function (data) {
			//		//alert("Call Success:" + serverid)
			//	}
			//});
		}
	}
}

function GetAvailableAgent(txt) {
    var callingPage = window.location.href;
    if (callingPage.toLowerCase().indexOf("call") > -1) {
        //$("#divLoader").append(getLoader());
        $.ajax({
            url: "/User/GetAvailableAgent/",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            cache: false,
            async: false,
            success: function (data) {
                //removeLoader("#divLoader");
                if (data.Data.ID > 0) {
                    $("#callee-acs-user-id").val(data.Data.AgentCallID)
                }
                else if (data.Data.ID == -1) {
                    //showBSAlertNonClosable(__infoCaption, "All the customer care agents are busy at the moment. Please try after some time. Sorry for the inconvenience.", __WARNING);
                    ShowConnectingMsg(txt + ' no one');
                    $("#callee-acs-user-id").val("")
                    setTimeout(function () {
                        closeAllBsDialogs();
                    }, 5000);
                }
            },
            complete: function () {
                setTimeout(function () {
                    //removeLoader("#divLoader");
                }, 300);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                //$("#divLoader").removeClass("box");
                //alert(xhr);
                //alert(ajaxOptions);
                //alert(thrownError);
                //alert(xhr.error().statusText);
                setTimeout(function () {
                    //removeLoader("#divLoader");
                }, 300);
            }
        });
    }
}

function GetKioskDetails(callerID) {
    var callingPage = window.location.href;
    if (callingPage.toLowerCase().indexOf("accept") > -1) {
        //$("#divLoader").append(getLoader());
        $.ajax({
            url: "/User/GetKioskDetails/",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify({ TravellerCallerID: callerID }),
            cache: false,
            async: true,
            success: function (data) {
                //removeLoader("#divLoader");
                if (data.Data.ID > 0) {
                    //alert(data.Data.DeviceName)
                    $("#lblKioskName").text(data.Data.DeviceName)
                    $("#lblKioskName").show();
                }
                else {
                    $("#lblKioskName").hide();
                }
            },
            complete: function () {
                setTimeout(function () {
                    //$("#lblKioskName").hide();
                }, 300);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                $("#lblKioskName").hide();
            }
        });
    }
}

function FreeAgent(agentCallerID) {
    var callingPage = window.location.href;
    if (callingPage.toLowerCase().indexOf("accept") > -1) {
        //$("#divLoader").append(getLoader());
        $.ajax({
            url: "/User/ChangeAvailabilityStatus/",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify({ AvailabilityStatus: "1" }),
            cache: false,
            async: false,
            success: function (data) {
                //removeLoader("#divLoader");
                
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
    else if (callingPage.toLowerCase().indexOf("call") > -1 && agentCallerID!='') {
        //$("#divLoader").append(getLoader());
        $.ajax({
            url: "/User/ChangeAvailabilityStatus/",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify({ AvailabilityStatus: "1", AgentCallerID: agentCallerID }),
            cache: false,
            async: false,
            success: function (data) {
                //removeLoader("#divLoader");

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
}

function MakeCallTransaction(uniqueCallID, incomingCallID) {
    var callingPage = window.location.href;
    if (callingPage.toLowerCase().indexOf("accept") > -1) {
        //$("#divLoader").append(getLoader());
        $.ajax({
            url: "/Home/MakeCallTransaction/",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify({ UniqueCallID: uniqueCallID, IncomingCallID: incomingCallID }),
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
}

function UpdateCallTransactionsEndTime(uniqueCallID) {
    var callingPage = window.location.href;
    if (callingPage.toLowerCase().indexOf("accept") > -1) {
        //$("#divLoader").append(getLoader());
        $.ajax({
            url: "/Home/UpdateCallTransactionsEndTime/",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify({ UniqueCallID: uniqueCallID }),
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
}

function InsertAccessMember(uniqueCallID, callStatus) {
    //$("#divLoader").append(getLoader());
    $.ajax({
        url: "/Home/InsertAM/",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify({ UniqueCallID: uniqueCallID, CallStatus: callStatus }),
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

function ShowDefaultScreen(frm) {
    $("#allStepID").removeClass("video_container_loader");
    RemoveAllMsg()
    //$(".all_steps").find(".all_steps_inner").html("<div class='para-text'>Walk to me and stand on the footprints marked on the floor near the screen.</div>");
    $(".all_steps").find(".all_steps_inner").html("");
    console.log("this is Default Screen from : " + frm)
}


function PreVideoMsg(frm) {
    $("#allStepID").removeClass("video_container_loader");
    RemoveAllMsg()
    $(".all_steps").find(".all_steps_inner").html("<div class='para-text'><p>We are connecting you with our passenger service executive.</p><p class'mtop30'>This call may be recorded for quality and training purposes.</p></div>");
    console.log("this is Default Screen from : " + frm)
}


var noFaceDefault;
function ShowDefaultScreenAfterWait(cnt) {
    if ($("#hdnCallTimeOut").val() == "1") {
        //$("#hdnCallTimeOut").val("")
        //RemoveAllMsg()
        //ShowConnectingMsg(cnt + 'Noface')
        //noFaceDefault = setTimeout(function () {
            ShowDefaultScreen(cnt + 'Noface ')
        //}, 6000);
    }
}

var showConnectingMsgTimeOut = "";
function ShowConnectingMsg(frm) {
    $("#allStepID").removeClass("video_container_loader");
    RemoveAllMsg()
    $(".all_steps").find(".all_steps_inner").html("<div class='para-text'><p>We thank you for your patience.</p><p class='mtop30'>All our passenger service executives are attending to other passengers at the moment.</p><p class='mtop30'>Your time is valuable to us.</p><p class='mtop30'>Please wait while we assign the next available passenger service executive to attend to you.</p></div>");
    var callingPage = window.location.href;
    if (callingPage.toLowerCase().indexOf("call") > -1) {
        showConnectingMsgTimeOut = showConnectingMsgTimeOut + "," + setTimeout(function () {
            //ShowDefaultScreen("3 mins")
            faceSpotted = false;
            //if (LoadCallCount > LoadCountAllowed) {
                //history.go(-2);
            FreeAgent($("#callee-acs-user-id").val())
            setTimeout(function () {
                window.location.href = '/Landing/Index';
            }, 5000);
            //}
        }, 45000);
    }
}

var myCallEndInitiate;
var myCallRinging;
function ShowCallInitiationMsg() {
    $("#allStepID").removeClass("video_container_loader");
    var callingPage = window.location.href;
    if (callingPage.toLowerCase().indexOf("call") > -1) {
        if (noFaceDefault)
            clearTimeout(noFaceDefault);
        if (showConnectingMsgTimeOut && showConnectingMsgTimeOut!="") {
            for (i = 0; i < showConnectingMsgTimeOut.split(',').length; i++)
                if (showConnectingMsgTimeOut.split(',')[i]!='')
                    clearTimeout(showConnectingMsgTimeOut.split(',')[i]);
        }

        showConnectingMsgTimeOut = "";
    }
    RemoveAllMsg()
    //showBSAlertNonClosable(__infoCaption, "We are connecting you with our passenger service executive. This call may be recorded for quality and training purposes.", __INFO);
    $(".all_steps").find(".all_steps_inner").html("<div class='para-text'><p>We are connecting you with our passenger service executive.</p><p class'mtop30'>This call may be recorded for quality and training purposes.</p></div>");
    myCallEndInitiate = setTimeout(function () {
        CallWaitTimeout()
    }, 29000);
}

function ClearTimeOut() {
    try {
        if (myCallRinging)
            clearTimeout(myCallRinging);
    } catch (e) {
    }
    try {
        if (myCallEndInitiate)
            clearTimeout(myCallEndInitiate);
    } catch (e) {
    }
    
}


function ClearNoFaceTimeOut() {
    try {
        if (noFaceTimeout)
            clearTimeout(noFaceTimeout);
    } catch (e) {
    }
}

function ShowRingMsg() {
    RemoveAllMsg();
    var audio = '';
    audio += '<audio id="telephoneRing" preload="auto" controls autoplay loop style="visibility: hidden;">';
    audio += '  <source src="../Content/audio/telephone-ring-02.mp3" type="audio/mpeg">';
    audio += '  Your browser does not support the audio element.';
    audio += '</audio>';
    audio += '<div class="div-ringingcall"><img src="../images/ringing-call.gif" alt="ringing-call.gif" class="img-ringingcall"></div>';
    $(".all_stepsAccept").find(".all_stepsAccept_inner").html(audio);
    //if ($("#telephoneRing").is(":visible")) {
    //    setTimeout(function () {
    //        document.getElementById('telephoneRing').play();
    //    }, 500);
    //}
    myCallRinging = setTimeout(function () {
        RingTimeout()
    }, 26000);
}
//At Agents end
function RingTimeout() {
    //if (!wasCallConnected) {
        RemoveAllMsg()
        FreeAgent("");
        //$('#hangup-call-button').click();
    HangtheCall()
    //}
}

function HangtheCall() {
    var isHangDisabled = false;
    if ($('#hangup-call-button').hasClass("btn-disable")) {
        isHangDisabled = true;
        $('#hangup-call-button').removeClass("btn-disable")
        $('#hangup-call-button').prop("disabled", false);
    }
    $('#hangup-call-button').click();
    if (isHangDisabled) {
        $('#hangup-call-button').addClass("btn-disable")
        $('#hangup-call-button').prop("disabled", true);
    }
}

//Cutomer End Wait Timeout
var callTimeOutCount = 0;
function CallWaitTimeout() {
    //if (callTimeOutCount < 2) {
    if (!wasCallConnected) {
        $("#hdnCallTimeOut").val("1");
        HangtheCall()
        $("#callee-acs-user-id").val("")
        $("#hdnCallStatus").val("0")
        callTimeOutCount = callTimeOutCount + 1
        RemoveAllMsg();
        ShowConnectingMsg(callTimeOutCount + 'WaitTimeout')
        GetAvailableAgent('wait ')
        $('#start-call-button').addClass("btn-disable")
        $('#start-call-button').prop("disabled", false)
        //startVisible = false;
        //if ($("#connectedLabel").is(":hidden") == true && $('#start-call-button').hasClass("btn-disable") == false) {
        //    faceSpotted = false;
        //}
        //if ($("#hdnCallStatus").val() == "0") {
        //    faceSpotted = false;
        //}
            
        //faceSpotted = false;
        //CheckStart()
    }
    //}
    //else {
    //    callTimeOutCount = 0;
    //    ShowDefaultScreenAfterWait(callTimeOutCount)
    //}
}

var thankyouStatus = 0;
function ShowThankYouMsg() {
    $("#allStepID").removeClass("video_container_loader");
    thankyouStatus = 1;
    var callingPage = window.location.href;
    //if ($("#hdnCallStatus").val() != "1") {
        //alert("Thank")
        RemoveAllMsg();
        var seconds = 5;
    $(".all_steps").find(".all_steps_inner").html("<div class='para-text'><p>Thank you for talking to us.<br />We hope we were able to address your queries to your satisfaction.</p><p class'mtop30'>Have a safe onward journey!</p><p class'mtop30'><span class='countdown'>" + seconds + "</span><p></div>");
        var count = setInterval(function () {
            $("span.countdown").html(seconds);
            if (seconds > 2 && seconds < 10) {
                FreeAgent($("#callee-acs-user-id").val())
            }
            if (seconds < 2) {
                clearInterval(count);
                ShowDefaultScreen('ThankYouMsg ')
                $("#hdnCallStatus").val("0")
                if (callingPage.toLowerCase().indexOf("call") > -1) {
                    thankyouStatus = 0;
                    //startVisible = true;
                    faceSpotted = false;
                    //history.go(-2);
                    window.location.href = '/Landing/Index';
                    //$("#allStepID").addClass("video_container_loader");
                }
            }
            seconds--;
            if (seconds < 10) {
                minutes = "0" + seconds
            };
        }, 1000);
    //}
}

function RemoveAllMsg() {
    if ($(".all_steps"))
        $(".all_steps").find(".all_steps_inner").html("");
    if ($(".all_stepsAccept"))
        $(".all_stepsAccept").find(".all_stepsAccept_inner").html("");
}

function CheckCallStatus(objCall) {
    //alert(objCall.state + ":" + objCall.direction)
    console.log("this is Status Check:" + objCall.state + ":" + objCall.direction)
}

function CheckIfAgentInactive() {
    var callingPage = window.location.href;
    if (callingPage.toLowerCase().indexOf("accept") > -1) {
        if (($('#start-call-button').hasClass("btn-disable") || $("#start-call-button").prop("disabled")) && ($('#hangup-call-button').hasClass("btn-disable") || $("#hangup-call-button").prop("disabled"))) {
            $.ajax({
                url: "/User/MakeAgentActive/",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                cache: false,
                async: false,
                success: function (data) {
                },
                complete: function () {
                    setTimeout(function () {
                        //removeLoader("#divLoader");
                    }, 300);
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    setTimeout(function () {
                        //removeLoader("#divLoader");
                    }, 300);
                }
            });
        }
    }
}

function ClearRefreshInterval() {
    try {
        console.log("this is ClearRefreshInterval")
        if (intervalCheckRefreshNeeded)
        clearInterval(intervalCheckRefreshNeeded);
        intervalCheckRefreshNeeded = setInterval(CheckRefreshNeeded, 300000);//1800000 - 30mins//600000 - 10mins//900000 - 15mins//300000 - 5mins
    } catch (e) {
    }
}
function CheckRefreshNeeded() {
    if ($("#hdnCallStatus").val() != "1") {
        console.log("this is CheckRefreshNeeded")
        $.ajax({
            url: "/User/IsRefreshRequired/",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            cache: false,
            async: false,
            success: function (data) {
                if (data.Data.ID == 1) {
                    window.location.reload();
                }
                console.log("this is CheckRefreshNeeded value:" + data.Data.ID)
            },
            complete: function () {
                setTimeout(function () {
                }, 300);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                setTimeout(function () {
                }, 300);
            }
        });
    }
    else {
        console.log("this is CheckRefreshNeeded not executed")
    }
}
var intervalCheckRefreshNeeded;
$(document).ready(function () {
    //steps.step1();      
    ShowDefaultScreen('onload ');

    if (callingPage.toLowerCase().indexOf("call") > -1)
        LoadCall();
    setInterval(function () {
        CheckIfAgentInactive();
    }, 25000);

    if (callingPage.toLowerCase().indexOf("agent") > -1)
        intervalCheckRefreshNeeded = setInterval(CheckRefreshNeeded, 300000);//1800000 - 30mins//600000 - 10mins//900000 - 15mins//300000 - 5mins
});
