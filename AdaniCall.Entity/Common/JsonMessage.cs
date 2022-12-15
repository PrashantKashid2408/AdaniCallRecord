using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdaniCall.Entity.Enums;

namespace AdaniCall.Entity.Common
{
    public class JsonMessage
    {
        #region DECLARTIONS

        //private bool _isSuccess;
        //private string _messageCaption;
        //private string _message;
        //private string _jsonMessageType;
        //private string _returnUrl;
        //private string _flag;
        //private object _data;

        #endregion

        #region PROPERTIES

        public bool IsSuccess { get; set; }
        public string MessageCaption { get; set; }
        public string Message { get; set; }
        public string JsonMessageType { get; set; }

        public string ReturnUrl { get; set; }
        public string Flag { get; set; }
        public object Data { get; set; }

        #endregion

        #region CONSTRUCTORS

        //public JsonMessage()
        //{
        //    //NOTHING TO INITIALIZE
        //}
        /// <summary>
        /// Default Constructor For JsonMessage
        /// </summary>
        /// <param name="isSuccess">success flag</param>
        /// <param name="messageCaption">Popups Caption Text</param>
        /// <param name="message">Message To Show Inside Popup</param>
        /// <param name="jsonMessageType">This Defines Header Color Of The Popup</param>
        [JsonConstructor]
        public JsonMessage(bool isSuccess, string messageCaption, string message, KeyEnums.JsonMessageType jsonMessageType)
        {
            this.IsSuccess = isSuccess;
            this.MessageCaption = messageCaption;
            this.Message = message;
            this.JsonMessageType = jsonMessageType.ToString();
        }

        /// <summary>
        /// Use This Constructor To Provide a ReturnUrl To Redirect Current Request.
        /// </summary>
        /// <param name="isSuccess">success flag</param>
        /// <param name="messageCaption">Popups Caption Text</param>
        /// <param name="message">Message To Show Inside Popup</param>
        /// <param name="jsonMessageType">This Defines Header Color Of The Popup</param>
        /// <param name="returnUrl">Redirect Url Where You Want To Redirect The Request</param>
        public JsonMessage(bool isSuccess, string messageCaption, string message, KeyEnums.JsonMessageType jsonMessageType, string returnUrl)
            : this(isSuccess, messageCaption, message, jsonMessageType)
        {
            this.ReturnUrl = returnUrl;
        }

        /// <summary>
        /// Use This Constructor To Provide An Additional Flag To Process Certain Logic On Client Side along with ReturnUrl
        /// </summary>
        /// <param name="isSuccess">success flag</param>
        /// <param name="messageCaption">Popups Caption Text</param>
        /// <param name="message">Message To Show Inside Popup</param>
        /// <param name="jsonMessageType">This Defines Header Color Of The Popup</param>
        /// <param name="returnUrl">Redirect Url Where You Want To Redirect The Request</param>
        /// <param name="flag">Additional string Value For Client Side Processing</param>
        public JsonMessage(bool isSuccess, string messageCaption, string message, KeyEnums.JsonMessageType jsonMessageType, string returnUrl, string flag)
            : this(isSuccess, messageCaption, message, jsonMessageType, returnUrl)
        {
            this.Flag = flag;
        }

        /// <summary>
        /// Use This Constructor If you Only Want To Provide Dynamic Object To JsonMessage
        /// </summary>
        /// <param name="isSuccess">success flag</param>
        /// <param name="messageCaption">Popups Caption Text</param>
        /// <param name="message">Message To Show Inside Popup</param>
        /// <param name="jsonMessageType">This Defines Header Color Of The Popup</param>
        /// <param name="data">Dynamic Object</param>
        public JsonMessage(bool isSuccess, string messageCaption, string message, KeyEnums.JsonMessageType jsonMessageType, object data)
            : this(isSuccess, messageCaption, message, jsonMessageType)
        {
            this.Data = data;
        }

        /// <summary>
        /// Use This Constructor To Provide More Flexibility By Providing object Itself To Client
        /// Note : If The Object Is Too Heavy Tt May Cause A Performance Degradation !
        /// </summary>
        /// <param name="isSuccess">success flag</param>
        /// <param name="messageCaption">Popups Caption Text</param>
        /// <param name="message">Message To Show Inside Popup</param>
        /// <param name="jsonMessageType">This Defines Header Color Of The Popup</param>
        /// <param name="returnUrl">Redirect Url Where You Want To Redirect The Request</param>
        /// <param name="flag">Additional string Value For Client Side Processing</param>
        /// <param name="data">Dynamic Object</param>
        public JsonMessage(bool isSuccess, string messageCaption, string message, KeyEnums.JsonMessageType jsonMessageType, string returnUrl, string flag, object data)
            : this(isSuccess, messageCaption, message, jsonMessageType, returnUrl, flag)
        {
            this.Data = data;
        }

        #endregion
    }

    public class FileUploadApiMessage : JsonMessage
    {
        private string _uploadedFilePath;
        private string _uploadedFilePathVir;

        /// <summary>
        /// Property will return Full path - eg : http://10.100.0.187/bookcontent/filename.jpg
        /// </summary>
        public string UploadedFilePath { get { return this._uploadedFilePath; } set { this._uploadedFilePath = value; } }

        /// <summary>
        /// Property will return partial path - eg : /bookcontent/filename.jpg
        /// </summary>
        public string UploadedFilePathVir { get { return this._uploadedFilePathVir; } set{ this._uploadedFilePathVir = value; } }

        public FileUploadApiMessage(bool isSuccess, string messageCaption, string message, KeyEnums.JsonMessageType jsonMessageType, string uploadedFilePath, string uploadedFilePathVir)
            : base(isSuccess, messageCaption, message, jsonMessageType)
        {
            this._uploadedFilePath = uploadedFilePath;
            this._uploadedFilePathVir = uploadedFilePathVir;
        }
    }

    public class DropDownList
    {
        public int ValueField { get; set; }
        public string DisplayField { get; set; }
    }

    public class CheckBoxList : DropDownList
    {
        public bool IsSelected { get; set; }
    }

    [Serializable]
    public class Error
    {
        private string _Message = "";
        //private string _Caption = "";

        public bool IsValid { get; set; }
        public string Message { get { return _Message; } set { _Message = value; } }
        //public string Caption { get { return _Caption; } set { _Caption = value; } }
        public int Code { get; set; }
    }
}
