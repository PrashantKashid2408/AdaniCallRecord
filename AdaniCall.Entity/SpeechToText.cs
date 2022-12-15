using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace  AdaniCall.Entity
{
    public class SpeechToText
    {
        #region Declarations

        private bool _boolObjectChanged;
        private Int64 _intID;
        private Int64 _intCallTransactionID;
        private string _strRecognitionStatus;
        private string _strDisplayText;
        private int _intOffset;
        private string _strDuration;
        private string _strResultReason;
        private string _strErrorCode;
        private string _strErrorDetails;
        private int _intLanguageId;
        private string _strSpeechTextJsonPath;
        private byte _bytStatusId;
        private DateTime _datCreatedDate;
        private DateTime _datUpdatedDate;

        #endregion Declarations

        #region Properties

         public bool ObjectChanged
         { 
            get { return this._boolObjectChanged; } 
            set { this._boolObjectChanged = value; }
         } 

         public Int64 ID
         { 
            get { return this._intID; } 
            set { this._intID = value; }
         } 

         public Int64 CallTransactionID
         { 
            get { return this._intCallTransactionID; } 
            set { this._intCallTransactionID = value; }
         } 

         public string RecognitionStatus
         { 
            get { return this._strRecognitionStatus; } 
            set { this._strRecognitionStatus = value; }
         } 

         public string DisplayText
         { 
            get { return this._strDisplayText; } 
            set { this._strDisplayText = value; }
         } 

         public int Offset
         { 
            get { return this._intOffset; } 
            set { this._intOffset = value; }
         } 

         public string Duration
         { 
            get { return this._strDuration; } 
            set { this._strDuration = value; }
         } 

         public string ResultReason
         { 
            get { return this._strResultReason; } 
            set { this._strResultReason = value; }
         } 

         public string ErrorCode
         { 
            get { return this._strErrorCode; } 
            set { this._strErrorCode = value; }
         } 

         public string ErrorDetails
         { 
            get { return this._strErrorDetails; } 
            set { this._strErrorDetails = value; }
         } 

         public int LanguageId
         { 
            get { return this._intLanguageId; } 
            set { this._intLanguageId = value; }
         } 

         public string SpeechTextJsonPath
         { 
            get { return this._strSpeechTextJsonPath; } 
            set { this._strSpeechTextJsonPath = value; }
         } 

         public byte StatusId
         { 
            get { return this._bytStatusId; } 
            set { this._bytStatusId = value; }
         } 

         public DateTime CreatedDate
         { 
            get { return this._datCreatedDate; } 
            set { this._datCreatedDate = value; }
         } 

         public DateTime UpdatedDate
         { 
            get { return this._datUpdatedDate; } 
            set { this._datUpdatedDate = value; }
         }

        public string Language { get; set; }

        #endregion Properties
    }
}
