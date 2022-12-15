var initialized = false;
var faceSpotted = false;
var startVisible = false;
var noFaceTimeout;
function button_callback() {
    if (initialized) return;
    var update_memory = pico.instantiate_detection_memory(5);
    var facefinder_classify_region = function (r, c, s, pixels, ldim) {
        return -1.0;
    };
    var cascadeurl =
        "https://raw.githubusercontent.com/nenadmarkus/pico/c2e81f9d23cc11d1a612fd21e4f9de0921a5d0d9/rnt/cascades/facefinder";
    fetch(cascadeurl).then(function (response) {
        response.arrayBuffer().then(function (buffer) {
            var bytes = new Int8Array(buffer);
            facefinder_classify_region = pico.unpack_cascade(bytes);
            console.log("* cascade loaded");
        });
    });

    var ctx = document.getElementsByTagName("canvas")[0].getContext("2d");
    function rgba_to_grayscale(rgba, nrows, ncols) {
        var gray = new Uint8Array(nrows * ncols);
        for (var r = 0; r < nrows; ++r)
            for (var c = 0; c < ncols; ++c)
                gray[r * ncols + c] =
                    (2 * rgba[r * 4 * ncols + 4 * c + 0] +
                        7 * rgba[r * 4 * ncols + 4 * c + 1] +
                        1 * rgba[r * 4 * ncols + 4 * c + 2]) /
                    10;
        return gray;
    }

    var processfn = function (video, dt) {
        ctx.drawImage(video, 0, 0);
        var rgba = ctx.getImageData(0, 0, 640, 480).data;

        image = {
            pixels: rgba_to_grayscale(rgba, 480, 640),
            nrows: 480,
            ncols: 640,
            ldim: 640,
        };
        params = {
            shiftfactor: 0.1, // move the detection window by 10% of its size
            minsize: 100, // minimum size of a face
            maxsize: 1000, // maximum size of a face
            scalefactor: 1.1, // for multiscale processing: resize the
        };

        dets = pico.run_cascade(image, facefinder_classify_region, params);
        dets = update_memory(dets);
        dets = pico.cluster_detections(dets, 0.2);

        for (i = 0; i < dets.length; ++i)
            if (dets[i][3] > 50.0) {
                ctx.beginPath();
                ctx.arc(dets[i][1], dets[i][0], dets[i][2] / 2, 0, 2 * Math.PI, false);
                ctx.lineWidth = 3;
                ctx.strokeStyle = "red";
                ctx.stroke();
                if (!faceSpotted && !wasCallConnected) {
                    GetAvailableAgent("face");
                    if ($("#callee-acs-user-id").val() != "") {
                        faceSpotted = true;
                      //  $("#initialize-call-agent").click();
                        startVisible = false;
                        console.log("this is face spotted:");
                    }
                }
            }
    };

    var mycamvas = new camvas(ctx, processfn);

    initialized = true;
}

function CheckStart() {
    LoadCall();
    if (thankyouStatus == 0) {
        if (LoadCallCount <= LoadCountAllowed) {
            if (!startVisible && $("#remoteVideoContainer").html() == "") {
                if (
                    $("#start-call-button").prop("disabled") == false &&
                    $("#callee-acs-user-id").val() != ""
                ) {
                    startVisible = true;
                    if ($("#start-call-button").hasClass("btn-disable")) {
                        $("#start-call-button").removeClass("btn-disable");
                        $("#start-call-button").prop("disabled", false);
                    }
                  //  $("#start-call-button").click();
                    $("#start-call-button").addClass("btn-disable");
                    $("#start-call-button").prop("disabled", true);
                    $("#cnFaceDetect").hide();
                    console.log("this is CheckStart():");
                }
            }
        }
    }
}

//setInterval(CheckStart, 5000);

function LoadCall() {
    if (LoadCallCount > LoadCountAllowed) {
        if (LoadCallCount > LoadCountAllowed) {
            FreeAgent($("#callee-acs-user-id").val());
          //  setTimeout(function () {
               // window.location.href = "/Landing/Index";
          //  }, 5000);
        }
    } else {
        if (!faceSpotted && !wasCallConnected) {
            GetAvailableAgent("face");
            if ($("#callee-acs-user-id").val() != "") {
                faceSpotted = true;
               // $("#initialize-call-agent").click();
                startVisible = false;
                console.log("this is face spotted:");
                LoadCallCount = LoadCallCount + 1;
            }
        }
    }
}
