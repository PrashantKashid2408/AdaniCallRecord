var initialized = false;
var faceSpotted = false;
var startVisible = false;
var noFaceTimeout;

function MakeCall() {
	LoadCall();
	if (thankyouStatus == 0) {
		if (LoadCallCount <= LoadCountAllowed) {
			if ($("#remoteVideoContainer").html() == '') {
				if ($("#start-call-button").prop("disabled") == false && $("#callee-acs-user-id").val() != "") {
					if ($('#start-call-button').hasClass("btn-disable")) {
						$('#start-call-button').removeClass("btn-disable")
						$('#start-call-button').prop("disabled", false)
					}
					$("#start-call-button").click();
					$('#start-call-button').addClass("btn-disable")
					$('#start-call-button').prop("disabled", true)
					$("#cnFaceDetect").hide();
					console.log("this is MakeCall():")
				}
			}
		}
	}
}

function LoadCall() {
	if (LoadCallCount > LoadCountAllowed) {
		FreeAgent($("#callee-acs-user-id").val(), '11indexLoadCall')
		setTimeout(function () {
			window.location.href = '/Home/Call';
		}, 5000);

	}
	else {
		console.log("this is LoadCall() :" + "faceSpotted: " + faceSpotted + ",wasCallConnected:" + wasCallConnected)
		if (!faceSpotted && !wasCallConnected) {
			$("#callee-acs-user-id").val("")
			GetAvailableAgent('face')
			if ($("#callee-acs-user-id").val() != '') {
				faceSpotted = true;
				console.log("this is face spotted:")
				LoadCallCount = LoadCallCount + 1;
				console.log("Call Attemt No: " + LoadCallCount)
			}
		}
	}
}


