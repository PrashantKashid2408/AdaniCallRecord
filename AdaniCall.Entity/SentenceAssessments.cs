using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace  AdaniCall.Entity
{
    public class SentenceAssessments
    {
        #region Declarations

        private bool _boolObjectChanged;
        private Int64 _intID;
        private Int64 _intSentenceOpinionID;
        private string _strAssessmentText;
        private string _strSentiment;
        private int _intSentenceLength;
        private int _intOffset;
        private string _strIsNegated;
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

         public Int64 SentenceOpinionID
        { 
            get { return this._intSentenceOpinionID; } 
            set { this._intSentenceOpinionID = value; }
         } 

         public string AssessmentText
         { 
            get { return this._strAssessmentText; } 
            set { this._strAssessmentText = value; }
         } 

         public string Sentiment
         { 
            get { return this._strSentiment; } 
            set { this._strSentiment = value; }
         } 

         public int SentenceLength
         { 
            get { return this._intSentenceLength; } 
            set { this._intSentenceLength = value; }
         } 

         public int Offset
         { 
            get { return this._intOffset; } 
            set { this._intOffset = value; }
         } 

         public string IsNegated
         { 
            get { return this._strIsNegated; } 
            set { this._strIsNegated = value; }
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

        public Decimal PositiveScore { get; set; }
        public Decimal NuetralScore { get; set; }
        public Decimal NegativeScore { get; set; }

        public int Count { get; set; }

        public List<AssesmentTotal> EntityAssesmentTotal { get; set; }
        #endregion Properties
    }

    public class AssesmentTotal
    {
        public int Count { get; set; }
        public string Sentiment { get; set; }
    }
}
