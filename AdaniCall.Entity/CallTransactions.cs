using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace  AdaniCall.Entity
{
    public class CallTransactions
    {
        #region Declarations

        private bool _boolObjectChanged;
        private Int64 _intID;
        private string _strTravellerCallID;
        private Int64 _intKioskID;
        private string _strAgentCallID;
        private Int64 _intAgentUserID;
        private string _strCallStartTime;
        private string _strCallEndTime;
        private string _strVideoFileName;
        private string _strAudioFileName;
        private int _intKioskLocationID;
        private int _intAgentLocationID;
        private Int64 _intSpeechToTextID;
        private byte _bytSpeechToTextStatus;
        private Int64 _intTextAnalysisID;
        private byte _bytTextAnalysisStatus;
        private Int64 _intSpeechAnalysisID;
        private byte _bytSpeechAnalysisStatus;
        private int _intLanguageId;
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

            public string TravellerCallID
            { 
            get { return this._strTravellerCallID; } 
            set { this._strTravellerCallID = value; }
            } 

            public Int64 KioskID
            { 
            get { return this._intKioskID; } 
            set { this._intKioskID = value; }
            } 

            public string AgentCallID
            { 
            get { return this._strAgentCallID; } 
            set { this._strAgentCallID = value; }
            } 

            public Int64 AgentUserID
            { 
            get { return this._intAgentUserID; } 
            set { this._intAgentUserID = value; }
            } 

            public string CallStartTime
            { 
            get { return this._strCallStartTime; } 
            set { this._strCallStartTime = value; }
            } 

            public string CallEndTime
            { 
            get { return this._strCallEndTime; } 
            set { this._strCallEndTime = value; }
            } 

            public string VideoFileName
            { 
            get { return this._strVideoFileName; } 
            set { this._strVideoFileName = value; }
            } 

            public string AudioFileName
            { 
            get { return this._strAudioFileName; } 
            set { this._strAudioFileName = value; }
            } 

            public int KioskLocationID
            { 
            get { return this._intKioskLocationID; } 
            set { this._intKioskLocationID = value; }
            } 

            public int AgentLocationID
            { 
            get { return this._intAgentLocationID; } 
            set { this._intAgentLocationID = value; }
            } 

            public Int64 SpeechToTextID
            { 
            get { return this._intSpeechToTextID; } 
            set { this._intSpeechToTextID = value; }
            } 

            public byte SpeechToTextStatus
            { 
            get { return this._bytSpeechToTextStatus; } 
            set { this._bytSpeechToTextStatus = value; }
            } 

            public Int64 TextAnalysisID
            { 
            get { return this._intTextAnalysisID; } 
            set { this._intTextAnalysisID = value; }
            } 

            public byte TextAnalysisStatus
            { 
            get { return this._bytTextAnalysisStatus; } 
            set { this._bytTextAnalysisStatus = value; }
            } 

            public Int64 SpeechAnalysisID
            { 
            get { return this._intSpeechAnalysisID; } 
            set { this._intSpeechAnalysisID = value; }
            } 

            public byte SpeechAnalysisStatus
            { 
            get { return this._bytSpeechAnalysisStatus; } 
            set { this._bytSpeechAnalysisStatus = value; }
            } 

            public int LanguageId
            { 
            get { return this._intLanguageId; } 
            set { this._intLanguageId = value; }
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

            public string UniqueCallID { get; set; }

            public string ServerCallID { get; set; }
            public string RecordingID { get; set; }
            public byte IsAudioProcessed { get; set; }
            public string LanguageName { get; set; }

            public string KioskName { get; set; }
            public string KioskLocation { get; set; }
            public string AgentName { get; set; }
            public string AgentLocation { get; set; }
            public string RowNumber { get; set; }
        #endregion Properties
    }

    public class Analysis
    {
        public Int64 ID { get; set; }

        public Int64 SpeechToTextID { get; set; }
        public string DisplayText { get; set; }
        public string Sentiment { get; set; }
        public string PositiveScore { get; set; }
        public string NegativeScore { get; set; }
        public string NuetralScore { get; set; }

        public Int64 AnalysedSentencesID { get; set; }
        public string Sentence { get; set; }
        public string SentenceSentiment { get; set; }
        public string SentencePositiveScore { get; set; }
        public string SentenceNegativeScore { get; set; }
        public string SentenceNuetralScore { get; set; }

        public Int64 SentenceOpinionID { get; set; }
        public string TargetText { get; set; }
        public string OpinionSentiment { get; set; }
        public string OpinionPositiveScore { get; set; }
        public string OpinionNegativeScore { get; set; }
        public string OpinionNuetralScore { get; set; }

        public Int64 SentenceAssessmentID { get; set; }
        public string AssessmentText { get; set; }
        public string AssessmentSentiment { get; set; }
        public string AssessmentPositiveScore { get; set; }
        public string AssessmentNegativeScore { get; set; }
        public string AssessmentNuetralScore { get; set; }
    }
}
