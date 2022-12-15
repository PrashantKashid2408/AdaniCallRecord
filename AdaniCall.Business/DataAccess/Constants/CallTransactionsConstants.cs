using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaniCall.Business.DataAccess.Constants
{
    public class CallTransactionsDBFields
    {
	
        public static string IU_Flag = "IU_Flag"; 

        public static string TableNameVal = "CallTransactions";
        public static string  ID = "ID";
        public static string UniqueCallID = "UniqueCallID"; 
        public static string  TravellerCallID = "TravellerCallID";
        public static string  KioskID = "KioskID";
        public static string  AgentCallID = "AgentCallID";
        public static string  AgentUserID = "AgentUserID";
        public static string  CallStartTime = "CallStartTime";
        public static string  CallEndTime = "CallEndTime";
        public static string  VideoFileName = "VideoFileName";
        public static string  AudioFileName = "AudioFileName";
        public static string  KioskLocationID = "KioskLocationID";
        public static string  AgentLocationID = "AgentLocationID";
        public static string  SpeechToTextID = "SpeechToTextID";
        public static string  SpeechToTextStatus = "SpeechToTextStatus";
        public static string  TextAnalysisID = "TextAnalysisID";
        public static string  TextAnalysisStatus = "TextAnalysisStatus";
        public static string  SpeechAnalysisID = "SpeechAnalysisID";
        public static string  SpeechAnalysisStatus = "SpeechAnalysisStatus";
        public static string  LanguageId = "LanguageId";
        public static string  StatusId = "StatusId";
        public static string  CreatedDate = "CreatedDate";
        public static string  UpdatedDate = "UpdatedDate";

        public static string Columns = "Columns";
        public static string Condition = "Condition";

        public static string ServerCallID = "ServerCallID";
        public static string RecordingID = "RecordingID";

        public static string ServerCallAudioID = "ServerCallAudioID";
        public static string RecordingAudioID = "RecordingAudioID";
        public static string IsAudioProcessed = "IsAudioProcessed";
        public static string LanguageName = "LanguageName";

        public static string KioskName = "KioskName";
        public static string KioskLocation = "KioskLocation";
        public static string AgentName = "AgentName";
        public static string AgentLocation = "AgentLocation";
        public static string RowNumber = "RowNumber";
    }

    public class AnalysisDBFields
    {
        public static string ID = "ID";
        public static string SpeechToTextID = "SpeechToTextID";
        public static string DisplayText = "DisplayText";
        public static string Sentiment = "Sentiment";
        public static string PositiveScore = "PositiveScore";
        public static string NegativeScore = "NegativeScore";
        public static string NuetralScore = "NuetralScore";

        public static string AnalysedSentencesID = "AnalysedSentencesID";
        public static string Sentence = "Sentence";
        public static string SentenceSentiment = "SentenceSentiment";
        public static string SentencePositiveScore = "SentencePositiveScore";
        public static string SentenceNegativeScore = "SentenceNegativeScore";
        public static string SentenceNuetralScore = "SentenceNuetralScore";

        public static string SentenceOpinionID = "SentenceOpinionID";
        public static string TargetText = "TargetText";
        public static string OpinionSentiment = "OpinionSentiment";
        public static string OpinionPositiveScore = "OpinionPositiveScore";
        public static string OpinionNegativeScore = "OpinionNegativeScore";
        public static string OpinionNuetralScore = "OpinionNuetralScore";

        public static string SentenceAssessmentID = "SentenceAssessmentID";
        public static string AssessmentText = "AssessmentText";
        public static string AssessmentSentiment = "AssessmentSentiment";
        public static string AssessmentPositiveScore = "AssessmentPositiveScore";
        public static string AssessmentNegativeScore = "AssessmentNegativeScore";
        public static string AssessmentNuetralScore = "AssessmentNuetralScore";
    }

    public class CallTransactionsStoredProcedures
    {

        #region Object StoredProcedure

        public static string CallTransactionsSAVE = "CallTransactions_SAVE";
        public static string CallTransactionsGetRecordById = "CallTransactions_GetRecordById";
        public static string CallTransactions_Update = "CallTransactions_Update"; 
        public static string GetCallTransactionsRecords = "CallTransactions_GetRecords";

        public static string CallAnalysis_GetRecords = "CallAnalysis_GetRecords";

        public static string SpeechToText_Pending_GetRecords = "SpeechToText_Pending_GetRecords";
        public static string Aduio_Pending_GetRecords = "Aduio_Pending_GetRecords";


        public static string GetCallTransactionsRecordByValue =  "CallTransactions_GetRecordByValue";
        public static string GetCallTransactionsRecordByValueArray = "CallTransactions_GetRecordByValueArray";
         
        #endregion

        #region Collection StoredProcedure
		 
        public static string CallTransactionsSearch = "CallTransactions_Search";
        public static string CallTransactionsSearchByValue =  "CallTransactions_SearchByValue";
        public static string CallTransactionsSearchByValueArray = "CallTransactions_SearchByValueArray";
        #endregion
 
        public static string IsExist = "";
        public static string GetCollectionForQuery = "";
        public static string SortingString = "SortOrder";


      
    }
}
