// Make sure to install the necessary dependencies
const {
  CallClient,
  VideoStreamRenderer,
  LocalVideoStream,
  Features,
} = require("@azure/communication-calling");
const {
  AzureCommunicationTokenCredential,
} = require("@azure/communication-common");
const { AzureLogger, setLogLevel } = require("@azure/logger");
// Set the log level and output
setLogLevel("verbose");
AzureLogger.log = (...args) => {
  // console.log(...args);
};

// Calling web sdk objects
let callAgent;
let deviceManager;
let call;
let incomingCall;
let outgoingCall;
let localVideoStream;
let localVideoStreamRenderer;

// UI widgets
let userAccessToken = document.getElementById("user-access-token");
let calleeAcsUserId = document.getElementById("callee-acs-user-id");
let initializeCallAgentButton = document.getElementById(
  "initialize-call-agent"
);
let startCallButton = document.getElementById("start-call-button");
let hangUpCallButton = document.getElementById("hangup-call-button");
let hdnhangUpCallButton = document.getElementById("hdnhangup-call-button");
let acceptCallButton = document.getElementById("accept-call-button");
let startVideoButton = document.getElementById("start-video-button");
let stopVideoButton = document.getElementById("stop-video-button");
let connectedLabel = document.getElementById("connectedLabel");
let remoteVideosGallery = document.getElementById("remoteVideosGallery");
let localVideoContainer = document.getElementById("localVideoContainer");

/**
 * Using the CallClient, initialize a CallAgent instance with a CommunicationUserCredential which will enable us to make outgoing calls and receive incoming calls.
 * You can then use the CallClient.getDeviceManager() API instance to get the DeviceManager.
 */
initializeCallAgentButton.onclick = async () => {
  try {
    const callClient = new CallClient();
    tokenCredential = new AzureCommunicationTokenCredential(
      userAccessToken.value.trim()
    );
    callAgent = await callClient.createCallAgent(tokenCredential);
    // Set up a camera device to use.
    deviceManager = await callClient.getDeviceManager();
    await deviceManager.askDevicePermission({ video: true });
    await deviceManager.askDevicePermission({ audio: true });
    // Listen for an incoming call to accept.
    callAgent.on("incomingCall", async (args) => {
      try {
        ShowRingMsg();
        incomingCall = args.incomingCall;
        acceptCallButton.disabled = false;
        hangUpCallButton.disabled = false; // Added
        $("#accept-call-button").removeClass("btn-disable"); //Added
        $("#hangup-call-button").removeClass("btn-disable"); //Added
        startCallButton.disabled = true;
        $("#start-call-button").addClass("btn-disable");
      } catch (error) {
        console.error(error);
      }
    });

    startCallButton.disabled = false;
    $("#start-call-button").removeClass("btn-disable");
    initializeCallAgentButton.disabled = true;
  } catch (error) {
    console.error(error);
  }
};

/**
 * Place a 1:1 outgoing video call to a user
 * Add an event listener to initiate a call when the `startCallButton` is clicked:
 * First you have to enumerate local cameras using the deviceManager `getCameraList` API.
 * In this quickstart we're using the first camera in the collection. Once the desired camera is selected, a
 * LocalVideoStream instance will be constructed and passed within `videoOptions` as an item within the
 * localVideoStream array to the call method. Once your call connects it will automatically start sending a video stream to the other participant.
 */
startCallButton.onclick = async () => {
  try {
    const localVideoStream = await createLocalVideoStream();
    const videoOptions = localVideoStream
      ? { localVideoStreams: [localVideoStream] }
      : undefined;
    call = callAgent.startCall(
      [{ communicationUserId: calleeAcsUserId.value.trim() }],
      { videoOptions }
    );
    // Subscribe to the call's properties and events.
    subscribeToCall(call);
  } catch (error) {
    console.error("startCallButton:" + error);
  }
};

/**
 * Accepting an incoming call with video
 * Add an event listener to accept a call when the `acceptCallButton` is clicked:
 * After subscribing to the `CallAgent.on('incomingCall')` event, you can accept the incoming call.
 * You can pass the local video stream which you want to use to accept the call with.
 */
acceptCallButton.onclick = async () => {
  try {
    const localVideoStream = await createLocalVideoStream();
    const videoOptions = localVideoStream
      ? { localVideoStreams: [localVideoStream] }
      : undefined;
    call = await incomingCall.accept({ videoOptions });
    // Subscribe to the call's properties and events.
    subscribeToCall(call);
    ClearTimeOut();
    ClearRefreshInterval();
  } catch (error) {
    console.error("acceptCallButton:" + error);
  }
};

/**
 * Subscribe to a call obj.
 * Listen for property changes and collection updates.
 */
subscribeToCall = (call) => {
  try {
    // Inspect the initial call.id value.
    //console.log(`Call Id: ${call.id}`);
    //Subscribe to call's 'idChanged' event for value changes.
    call.on("idChanged", () => {
      //console.log(`Call Id changed: ${call.id}`);
    });

    // Inspect the initial call.state value.
    console.log(`Call state: ${call.state}`);
    // Subscribe to call's 'stateChanged' event for value changes.
    call.on("stateChanged", async () => {
      console.log(`Call state changed: ${call.state}`);
      CheckCallStatus(call);
      if (call.state === "Connected") {
        wasCallConnected = true;
        ClearTimeOut();
        ClearNoFaceTimeOut();
        setTimeout(function () {
          const callRecordingApi = call.feature(Features.Recording);
          const isRecordingActiveChangedHandler = () => {
            console.log(
              "this is Recording started:" + callRecordingApi.isRecordingActive
            );
          };
          callRecordingApi.on(
            "isRecordingActiveChanged",
            isRecordingActiveChangedHandler
          );
        }, 1000);
        $("#hdnCallStatus").val("1");
        RemoveAllMsg();
        InsertAccessMember(call.id, "Connected");
        MakeCallTransaction(
          call.id,
            calleeAcsUserId.value.trim()
        );
        connectedLabel.hidden = false;
        acceptCallButton.disabled = true;
        $('#accept-call-button').addClass("btn-disable")
        startCallButton.disabled = true;
        $('#start-call-button').addClass("btn-disable")
        $('#start-call-button').prop("disabled", true)
        hangUpCallButton.disabled = false;
        $('#hangup-call-button').removeClass("btn-disable")
        startVideoButton.disabled = false;
        stopVideoButton.disabled = false;
        $("#cnFaceDetect").hide();
        $("#callee-acs-user-id").val("")
        remoteVideosGallery.hidden = false;
      } else if (call.state === "Disconnected") {
        $("#hdnCallStatus").val("0")
        ClearNoFaceTimeOut()
        var CallLanguage = $("#hdnCallLanguage").val();
                if (CallLanguage === undefined || CallLanguage == '')
                    CallLanguage = "3";
                UpdateCallTransactionsEndTime(call.id, CallLanguage);
        connectedLabel.hidden = true;
        if (callingPage.toLowerCase().indexOf("call") > -1) {
            if (wasCallConnected) {
                $(".all_steps").find(".all_steps_inner").html("");
                ShowThankYouMsg();
                wasCallConnected = false;
            }
        startCallButton.disabled = false;
        $('#start-call-button').removeClass("btn-disable")
                    closeAllBsDialogs();
                    FreeAgent($("#callee-acs-user-id").val())
                    $("#callee-acs-user-id").val("");
                }
                else if (callingPage.toLowerCase().indexOf("accept") > -1) {
                    $("#callee-acs-user-id").val("");
                    FreeAgent('');
                }
        hangUpCallButton.disabled = true;
        $('#hangup-call-button').addClass("btn-disable")
        startVideoButton.disabled = true;
        stopVideoButton.disabled = true;
        try {
            if (wasCallConnected)
                wasCallConnected = false;
        } catch (e) {

        }
        console.log(
          `Call ended, call end reason={code=${call.callEndReason.code}, subCode=${call.callEndReason.subCode}}`
        );
      }
      else if (call.state === 'Ringing') {
        //if (callingPage.toLowerCase().indexOf("call") > -1) {
            $("#hdnCallStatus").val("1")
        //}
        //RemoveAllMsg();
        ShowCallInitiationMsg();
        ClearNoFaceTimeOut()
    }
    else if (call.state === 'Connecting') {
        //if (callingPage.toLowerCase().indexOf("call") > -1) {
            $("#hdnCallStatus").val("1")
        //}
        //RemoveAllMsg();
        ShowConnectingMsg('Connecting');
        ClearNoFaceTimeOut()
    }
    else if (call.state === 'EarlyMedia') {
        //if (callingPage.toLowerCase().indexOf("call") > -1) {
            $("#hdnCallStatus").val("1")
        //}
        startCallButton.disabled = true;
        $('#start-call-button').addClass("btn-disable")
        $('#start-call-button').prop("disabled", true)
        RemoveAllMsg();
        ClearTimeOut()
        ClearNoFaceTimeOut()
    }
});
    

    call.localVideoStreams.forEach(async (lvs) => {
      localVideoStream = lvs;
      await displayLocalVideoStream();
    });
    call.on("localVideoStreamsUpdated", (e) => {
      e.added.forEach(async (lvs) => {
        localVideoStream = lvs;
        await displayLocalVideoStream();
      });
      e.removed.forEach((lvs) => {
        removeLocalVideoStream();
      });
    });

    // Inspect the call's current remote participants and subscribe to them.
    call.remoteParticipants.forEach((remoteParticipant) => {
      subscribeToRemoteParticipant(remoteParticipant);
    });
    // Subscribe to the call's 'remoteParticipantsUpdated' event to be
    // notified when new participants are added to the call or removed from the call.
    call.on("remoteParticipantsUpdated", (e) => {
      // Subscribe to new remote participants that are added to the call.
      e.added.forEach((remoteParticipant) => {
        subscribeToRemoteParticipant(remoteParticipant);
      });
      // Unsubscribe from participants that are removed from the call
      e.removed.forEach((remoteParticipant) => {
        console.log("Remote participant removed from the call.");
      });
    });
  } catch (error) {
    console.error("subscribeToCall:" + error);
  }
};

/**
 * Subscribe to a remote participant obj.
 * Listen for property changes and collection udpates.
 */
subscribeToRemoteParticipant = (remoteParticipant) => {
  try {
    // Inspect the initial remoteParticipant.state value.
    console.log(`Remote participant state: ${remoteParticipant.state}`);
    // Subscribe to remoteParticipant's 'stateChanged' event for value changes.
    remoteParticipant.on("stateChanged", () => {
      console.log(
        `Remote participant state changed: ${remoteParticipant.state}`
      );
    });

    // Inspect the remoteParticipants's current videoStreams and subscribe to them.
    remoteParticipant.videoStreams.forEach((remoteVideoStream) => {
      subscribeToRemoteVideoStream(remoteVideoStream);
    });
    // Subscribe to the remoteParticipant's 'videoStreamsUpdated' event to be
    // notified when the remoteParticiapant adds new videoStreams and removes video streams.
    remoteParticipant.on("videoStreamsUpdated", (e) => {
      // Subscribe to new remote participant's video streams that were added.
      e.added.forEach((remoteVideoStream) => {
        subscribeToRemoteVideoStream(remoteVideoStream);
      });
      // Unsubscribe from remote participant's video streams that were removed.
      e.removed.forEach((remoteVideoStream) => {
        console.log("Remote participant video stream was removed.");
      });
    });
  } catch (error) {
    console.error("subscribeToRemoteParticipant:" + error);
  }
};

/**
 * Subscribe to a remote participant's remote video stream obj.
 * You have to subscribe to the 'isAvailableChanged' event to render the remoteVideoStream. If the 'isAvailable' property
 * changes to 'true', a remote participant is sending a stream. Whenever availability of a remote stream changes
 * you can choose to destroy the whole 'Renderer', a specific 'RendererView' or keep them, but this will result in displaying blank video frame.
 */
subscribeToRemoteVideoStream = async (remoteVideoStream) => {
  let renderer = new VideoStreamRenderer(remoteVideoStream);
  let view;
  let remoteVideoContainer = document.createElement("div");
  remoteVideoContainer.className = "remote-video-container";

  /**
     * isReceiving API is currently a @beta feature.
     * To use this api, please use 'beta' version of Azure Communication Services Calling Web SDK.
     * Create a CSS class to style your loading spinner.
     *
    let loadingSpinner = document.createElement('div');
    loadingSpinner.className = 'loading-spinner';
    remoteVideoStream.on('isReceivingChanged', () => {
        try {
            if (remoteVideoStream.isAvailable) {
                const isReceiving = remoteVideoStream.isReceiving;
                const isLoadingSpinnerActive = remoteVideoContainer.contains(loadingSpinner);
                if (!isReceiving && !isLoadingSpinnerActive) {
                    remoteVideoContainer.appendChild(loadingSpinner);
                } else if (isReceiving && isLoadingSpinnerActive) {
                    remoteVideoContainer.removeChild(loadingSpinner);
                }
            }
        } catch (e) {
            console.error(e);
        }
    });
    */

  const createView = async () => {
    // Create a renderer view for the remote video stream.
    view = await renderer.createView();
    // Attach the renderer view to the UI.
    remoteVideoContainer.appendChild(view.target);
    remoteVideosGallery.appendChild(remoteVideoContainer);
  };

  // Remote participant has switched video on/off
  remoteVideoStream.on("isAvailableChanged", async () => {
    try {
      if (remoteVideoStream.isAvailable) {
        await createView();
      } else {
        view.dispose();
        remoteVideosGallery.removeChild(remoteVideoContainer);
      }
    } catch (e) {
      console.error(e);
    }
  });

  // Remote participant has video on initially.
  if (remoteVideoStream.isAvailable) {
    try {
      await createView();
    } catch (e) {
      console.error(e);
    }
  }
};

/**
 * Start your local video stream.
 * This will send your local video stream to remote participants so they can view it.
 */
startVideoButton.onclick = async () => {
  try {
    const localVideoStream = await createLocalVideoStream();
    await call.startVideo(localVideoStream);
  } catch (error) {
    console.error(error);
  }
};

/**
 * Stop your local video stream.
 * This will stop your local video stream from being sent to remote participants.
 */
stopVideoButton.onclick = async () => {
  try {
    await call.stopVideo(localVideoStream);
  } catch (error) {
    console.error(error);
  }
};

/**
 * To render a LocalVideoStream, you need to create a new instance of VideoStreamRenderer, and then
 * create a new VideoStreamRendererView instance using the asynchronous createView() method.
 * You may then attach view.target to any UI element.
 */
createLocalVideoStream = async () => {
  const camera = (await deviceManager.getCameras())[0];
  if (camera) {
    return new LocalVideoStream(camera);
  } else {
    console.error(`No camera device found on the system`);
  }
};

/**
 * Display your local video stream preview in your UI
 */
displayLocalVideoStream = async () => {
  try {
    localVideoStreamRenderer = new VideoStreamRenderer(localVideoStream);
    const view = await localVideoStreamRenderer.createView();
    localVideoContainer.hidden = false;
    localVideoContainer.appendChild(view.target);
  } catch (error) {
    console.error(error);
  }
};

/**
 * Remove your local video stream preview from your UI
 */
removeLocalVideoStream = async () => {
  try {
    localVideoStreamRenderer.dispose();
    localVideoContainer.hidden = true;
  } catch (error) {
    console.error(error);
  }
};

/**
 * End current call
 */
hangUpCallButton.addEventListener("click", async () => {
  // end the current call
  if (wasCallConnected)
  hangtheCallLangPopup(3);
  else
  $('#hdnhangup-call-button').click();
  //await call.hangUp();
});

hdnhangUpCallButton.addEventListener("click", async () => {
    wasCallConnected = false;
    ClearTimeOut()
    ClearRefreshInterval();
    // end the current call
    FreeAgent($("#callee-acs-user-id").val())
    acceptCallButton.disabled = true;
    $('#accept-call-button').addClass("btn-disable")
    closeAllBsDialogs();
    try {
        var callingPage = window.location.href;
        if (callingPage.toLowerCase().indexOf("call") > -1) {
            //ShowConnectingMsg('WaitTimeout')
        }
        else if (callingPage.toLowerCase().indexOf("accept") > -1) {
            RemoveAllMsg()
        }
        
        await call.hangUp();
        //hangtheCallLangPopup(3);
        //await call.reject();
    } catch (e) {
        hangUpCallButton.disabled = true;
        $('#hangup-call-button').addClass("btn-disable")
    }
});