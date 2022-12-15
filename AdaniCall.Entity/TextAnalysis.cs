using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace  AdaniCall.Entity
{
    public class TextAnalysis
    {
        #region Declarations

        private bool _boolObjectChanged;
        private Int64 _intID;
        private string _strDetectedLanguageName;
        private string _strISO6391Name;
        private string _strKeyPhrases;
        private string _strDocumentID;
        private string _strSentiment;
        private string _strTextAnalysisJsonPath;
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

         public string DetectedLanguageName
         { 
            get { return this._strDetectedLanguageName; } 
            set { this._strDetectedLanguageName = value; }
         } 

         public string ISO6391Name
         { 
            get { return this._strISO6391Name; } 
            set { this._strISO6391Name = value; }
         } 

         public string KeyPhrases
         { 
            get { return this._strKeyPhrases; } 
            set { this._strKeyPhrases = value; }
         } 

         public string DocumentID
         { 
            get { return this._strDocumentID; } 
            set { this._strDocumentID = value; }
         } 

         public string Sentiment
         { 
            get { return this._strSentiment; } 
            set { this._strSentiment = value; }
         } 

         public string TextAnalysisJsonPath
         { 
            get { return this._strTextAnalysisJsonPath; } 
            set { this._strTextAnalysisJsonPath = value; }
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

        public Decimal ConfidenceScore { get; set; }
        public Decimal PositiveScore { get; set; }
        public Decimal NuetralScore { get; set; }
        public Decimal NegativeScore { get; set; }

        public Int64 CallTransactionID { get; set; }

        public List<AnalysedSentences> AnalysedSentencesList { get; set; }

        #endregion Properties
    }
}
