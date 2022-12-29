using AdaniCall.Models;
using Azure.Communication.CallAutomation;
using Azure.Messaging.EventGrid.SystemEvents;
using Azure.Messaging.EventGrid;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Web.Http;
using AdaniCall.Utility.Common;
using AdaniCall.Entity;
using System.Reflection;
using System.Net;
using AdaniCall.Business.BusinessFacade;
using AdaniCall.Business.DataAccess.Constants;
using static AdaniCall.Models.CommonData;
using Microsoft.Extensions.Logging;

namespace AdaniCall.Controllers
{
    [Route("api/Recording")]
    public class RecordingController : ApiController
    {
        private readonly string blobStorageConnectionString;
        private readonly string callbackUri;
        private readonly string containerName;
        private readonly CallAutomationClient callAutomationClient;
        private const string CallRecodingActiveErrorCode = "8553";
        private const string CallRecodingActiveError = "Recording is already in progress, one recording can be active at one time.";
        private readonly string _module = "AdaniCall.Controllers.CallRecordingsController";
        private string RootPath;
        public ILogger<RecordingController> Logger { get; }
        static Dictionary<string, string> recordingData = new Dictionary<string, string>();
        public static string recFileFormat;

        public RecordingController(ILogger<RecordingController> logger, IConfiguration configuration)
        {
            blobStorageConnectionString = configuration["BlobStorageConnectionString"].ToString();
            containerName = configuration["BlobContainerName"].ToString();
            callAutomationClient = new CallAutomationClient(configuration["ACSResourceConnectionString"].ToString());
            RootPath = configuration["RootPath"].ToString() + configuration["VideoPath"].ToString();
            callbackUri = configuration["CallBackURI"].ToString();
            Logger = logger;
        }

        [HttpPost]
        [Route("startRecording")]
        public async Task<IActionResult> StartRecordingAsync(RecordParams objRecordParams)
        {
            try
            {
                string serverCallId = objRecordParams.sCallID.ToString();
                string uniqueCallID = objRecordParams.UniqueCallID.ToString();
                Console.WriteLine("SERVERCALLID: " + serverCallId + "UNIQUECALLID: " + uniqueCallID);
                if (!string.IsNullOrEmpty(serverCallId))
                {
                    var uri = new Uri(callbackUri);
                    StartRecordingOptions recordingOptions = new StartRecordingOptions(new ServerCallLocator(serverCallId));
                    var startRecordingResponse = await callAutomationClient.GetCallRecording()
                        .StartRecordingAsync(recordingOptions).ConfigureAwait(false);
                    Logger.LogInformation("BLOBSTORAGECONNECTIONSTRING :   " + blobStorageConnectionString+"   " + "CONTAINERNAME: " + containerName+" " + "CALLAUTOMATIONCLIENT: " + callAutomationClient+"   "+ "CALLBACKURI: "+ callbackUri+"  "+ "ROOTPATH: "+ RootPath);
                   Logger.LogInformation($"StartRecordingAsync response -- >  {startRecordingResponse.GetRawResponse()}, Recording Id: {startRecordingResponse.Value.RecordingId}");

                    var recordingId = startRecordingResponse.Value.RecordingId;
                    if (!recordingData.ContainsKey(serverCallId))
                    {
                        recordingData.Add(serverCallId, string.Empty);
                    }
                    recordingData[serverCallId] = recordingId;
                    if (uniqueCallID != "")
                    {
                        CallTransactionsBusinessFacade objBF = new CallTransactionsBusinessFacade();
                        objBF.UpdateCallTransactions(CallTransactionsDBFields.ServerCallID + "='" + serverCallId + "'," + CallTransactionsDBFields.RecordingID + "='" + recordingId + "'", CallTransactionsDBFields.UniqueCallID + "='" + uniqueCallID + "'");
                    }

                    return Json(recordingId);
                }
                else
                {
                    return Content(HttpStatusCode.BadRequest, new { Message = "serverCallId is invalid" });
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "StartRecordingAsync(sCallID=" + objRecordParams.sCallID + ",recordingFormat:" + objRecordParams.recordingFormat + ")", ex.Source, ex.Message);
                if (ex.Message.Contains(CallRecodingActiveErrorCode))
                {
                    Log.WriteLog(_module, "StartRecordingAsync(Message=" + CallRecodingActiveError + ")", ex.Source, ex.Message);
                    return Content(HttpStatusCode.BadRequest, new { Message = CallRecodingActiveError });
                
                }
                return Json(new { Exception = ex });
            }
        }

        [HttpPost]
        [Route("getRecordingFile")]
        public async Task<ActionResult> GetRecordingFile([FromBody] object request)
        {
            try
            {
                var httpContent = new BinaryData(request.ToString()).ToStream();
                EventGridEvent cloudEvent = EventGridEvent.ParseMany(BinaryData.FromStream(httpContent)).FirstOrDefault();

                if (cloudEvent.EventType == SystemEventNames.EventGridSubscriptionValidation)
                {
                    var eventData = cloudEvent.Data.ToObjectFromJson<SubscriptionValidationEventData>();

                    Logger.LogInformation("Microsoft.EventGrid.SubscriptionValidationEvent response  -- >" + cloudEvent.Data);

                    var responseData = new SubscriptionValidationResponse
                    {
                        ValidationResponse = eventData.ValidationCode
                    };

                    if (responseData.ValidationResponse != null)
                    {
                        return Ok(responseData);
                    }
                }

                if (cloudEvent.EventType == SystemEventNames.AcsRecordingFileStatusUpdated)
                {
                    Logger.LogInformation($"Event type is -- > {cloudEvent.EventType}");

                    Logger.LogInformation("Microsoft.Communication.RecordingFileStatusUpdated response  -- >" + cloudEvent.Data);

                    var eventData = cloudEvent.Data.ToObjectFromJson<AcsRecordingFileStatusUpdatedEventData>();

                    Logger.LogInformation("Start processing metadata -- >");

                    await ProcessFile(eventData.RecordingStorageInfo.RecordingChunks[0].MetadataLocation,
                        eventData.RecordingStorageInfo.RecordingChunks[0].DocumentId,
                        FileFormat.Json,
                        FileDownloadType.Metadata);

                    Logger.LogInformation("Start processing recorded media -- >");

                    await ProcessFile(eventData.RecordingStorageInfo.RecordingChunks[0].ContentLocation,
                        eventData.RecordingStorageInfo.RecordingChunks[0].DocumentId,
                        string.IsNullOrWhiteSpace(recFileFormat) ? FileFormat.Mp4 : recFileFormat,
                        FileDownloadType.Recording);
                }

                return Ok();
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetRecordingFile()", "Source " + ex.Source + ",Message:" + ex.Message, ex.StackTrace);
                      return Json(new { Exception = ex });
            }
        }

        //public async Task<ActionResult> GetRecordingFile([FromBody] object request)
        //{
        //    try
        //    {
        //        string output = JsonConvert.SerializeObject(request);
        //        var httpContent = new BinaryData(request.ToString()).ToStream();
        //       // EventGridEvent cloudEvent = EventGridEvent.ParseMany(BinaryData.FromStream(httpContent)).FirstOrDefault();
        //        EventGridEvent cloudEvent = EventGridEvent.ParseMany(await BinaryData.FromStreamAsync(httpContent)).FirstOrDefault();
        //        if (cloudEvent.EventType == SystemEventNames.EventGridSubscriptionValidation)
        //        {
        //            var eventData = cloudEvent.Data.ToObjectFromJson<SubscriptionValidationEventData>();

        //            //    Logger.LogInformation("Microsoft.EventGrid.SubscriptionValidationEvent response  -- >" + cloudEvent.Data);

        //            var responseData = new SubscriptionValidationResponse
        //            {
        //                ValidationResponse = eventData.ValidationCode
        //            };

        //            if (responseData.ValidationResponse != null)
        //            {
        //                return Ok(responseData);
        //            }
        //        }

        //        if (cloudEvent.EventType == SystemEventNames.AcsRecordingFileStatusUpdated)
        //        {
        //            //Logger.LogInformation($"Event type is -- > {cloudEvent.EventType}");

        //            // Logger.LogInformation("Microsoft.Communication.RecordingFileStatusUpdated response  -- >" + cloudEvent.Data);

        //            var eventData = cloudEvent.Data.ToObjectFromJson<AcsRecordingFileStatusUpdatedEventData>();

        //            //   Logger.LogInformation("Start processing metadata -- >");

        //            await ProcessFile(eventData.RecordingStorageInfo.RecordingChunks[0].MetadataLocation,
        //                eventData.RecordingStorageInfo.RecordingChunks[0].DocumentId,
        //                FileFormat.Json,
        //                FileDownloadType.Metadata);

        //            //   Logger.LogInformation("Start processing recorded media -- >");

        //            await ProcessFile(eventData.RecordingStorageInfo.RecordingChunks[0].ContentLocation,
        //                eventData.RecordingStorageInfo.RecordingChunks[0].DocumentId,
        //                string.IsNullOrWhiteSpace(recFileFormat) ? FileFormat.Mp4 : recFileFormat,
        //                FileDownloadType.Recording);
        //        }

        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.WriteLog(_module, "GetRecordingFile()", "Source " + ex.Source + ",Message:" + ex.Message, ex.StackTrace);
        //        return Json(new { Exception = ex });
        //    }
        //}

        private async Task<bool> ProcessFile(string downloadLocation, string documentId, string fileFormat, string downloadType)
        {
            try
            {
                var recordingDownloadUri = new Uri(downloadLocation);
                var response = await callAutomationClient.GetCallRecording().DownloadStreamingAsync(recordingDownloadUri);

                // Logger.LogInformation($"Download {downloadType} response  -- >" + response.GetRawResponse());
                // Logger.LogInformation($"Save downloaded {downloadType} -- >");

                string filePath = RootPath + @"\" + documentId + "." + fileFormat;
                using (Stream streamToReadFrom = response.Value)
                {
                    using (Stream streamToWriteTo = System.IO.File.Open(filePath, FileMode.Create))
                    {
                        await streamToReadFrom.CopyToAsync(streamToWriteTo);
                        await streamToWriteTo.FlushAsync();
                    }
                }

                string recordedfileName = "";
                string uniqueCallID = "";

                if (string.Equals(downloadType, FileDownloadType.Metadata, StringComparison.InvariantCultureIgnoreCase) && System.IO.File.Exists(filePath))
                {
                    Root deserializedFilePath = JsonConvert.DeserializeObject<Root>(System.IO.File.ReadAllText(filePath));
                    recFileFormat = deserializedFilePath.recordingInfo.format;
                    recordedfileName = deserializedFilePath.chunkDocumentId;
                    uniqueCallID = deserializedFilePath.callId;
                    //  Logger.LogInformation($"Recording File Format is -- > {recFileFormat}");
                }

                // Logger.LogInformation($"Starting to upload {downloadType} to BlobStorage into container -- > {containerName}");

                var blobStorageHelperInfo = await BlobStorageHelper.UploadFileAsync(blobStorageConnectionString, containerName, filePath, filePath);
                if (blobStorageHelperInfo.Status)
                {
                    // Logger.LogInformation(blobStorageHelperInfo.Message);
                    // Logger.LogInformation($"Deleting temporary {downloadType} file being created");

                    System.IO.File.Delete(filePath);
                }
                else
                {
                    //  Logger.LogError($"{downloadType} file was not uploaded,{blobStorageHelperInfo.Message}");
                }
                CallTransactionsBusinessFacade objBF = new CallTransactionsBusinessFacade();
                if (uniqueCallID != "")
                {
                    if (recFileFormat.ToLower() == "mp4" && recordedfileName != "")
                    {
                        objBF.UpdateCallTransactions(CallTransactionsDBFields.VideoFileName + "='" + recordedfileName + "'," + CallTransactionsDBFields.UpdatedDate + "=getDate()", CallTransactionsDBFields.UniqueCallID + "='" + uniqueCallID + "'");
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "ProcessFile()", ex.Source, ex.Message);
                return false;
            }

        }
    }
}