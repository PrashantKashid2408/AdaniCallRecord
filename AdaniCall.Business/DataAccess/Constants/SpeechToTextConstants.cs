using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaniCall.Business.DataAccess.Constants
{
    public class SpeechToTextDBFields
    {

	
        public static string IU_Flag = "IU_Flag"; 


		

        public static string TableNameVal = "SpeechToText";
        public static string ID = "ID";
        public static string CallTransactionID = "CallTransactionID";
        public static string RecognitionStatus = "RecognitionStatus";
        public static string DisplayText = "DisplayText";
        public static string Offset = "Offset";
        public static string Duration = "Duration";
        public static string ResultReason = "ResultReason";
        public static string ErrorCode = "ErrorCode";
        public static string ErrorDetails = "ErrorDetails";
        public static string LanguageId = "LanguageId";
        public static string SpeechTextJsonPath = "SpeechTextJsonPath";
        public static string StatusId = "StatusId";
        public static string CreatedDate = "CreatedDate";
        public static string UpdatedDate = "UpdatedDate";
        public static string Language = "Language"; 
    }
    public class SpeechToTextStoredProcedures
    {

        #region Object StoredProcedure

		



		
        public static string SpeechToTextSAVE = "SpeechToText_SAVE";
        public static string SpeechToTextGetRecordById = "SpeechToText_GetRecordById";

        public static string GetSpeechToTextRecords = "SpeechToText_GetRecords";
        public static string GetSpeechToTextRecordByValue =  "SpeechToText_GetRecordByValue";
        public static string GetSpeechToTextRecordByValueArray = "SpeechToText_GetRecordByValueArray";
         
        #endregion

        #region Collection StoredProcedure
		 
        public static string SpeechToTextSearch = "SpeechToText_Search";
        public static string SpeechToTextSearchByValue =  "SpeechToText_SearchByValue";
        public static string SpeechToTextSearchByValueArray = "SpeechToText_SearchByValueArray";
        #endregion
 
        public static string IsExist = "";
        public static string GetCollectionForQuery = "";
        public static string SortingString = "SortOrder";


      
    }
}
