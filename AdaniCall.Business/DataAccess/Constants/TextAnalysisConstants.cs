using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaniCall.Business.DataAccess.Constants
{
    public class TextAnalysisDBFields
    {

	
        public static string IU_Flag = "IU_Flag"; 


		

        public static string TableNameVal = "TextAnalysis";
        public static string  ID = "ID";
        public static string  DetectedLanguageName = "DetectedLanguageName";
        public static string  ISO6391Name = "ISO6391Name";
        public static string  ConfidenceScore = "ConfidenceScore";
        public static string  KeyPhrases = "KeyPhrases";
        public static string  DocumentID = "DocumentID";
        public static string  Sentiment = "Sentiment";
        public static string  PositiveScore = "PositiveScore";
        public static string  NuetralScore = "NuetralScore";
        public static string  NegativeScore = "NegativeScore";
        public static string  TextAnalysisJsonPath = "TextAnalysisJsonPath";
        public static string  StatusId = "StatusId";
        public static string  CreatedDate = "CreatedDate";
        public static string  UpdatedDate = "UpdatedDate";
        public static string CallTransactionID = "CallTransactionID";

    }
    public class TextAnalysisStoredProcedures
    {

        #region Object StoredProcedure

		



		
        public static string TextAnalysisSAVE = "TextAnalysis_SAVE";
        public static string TextAnalysisGetRecordById = "TextAnalysis_GetRecordById";

        public static string GetTextAnalysisRecords = "TextAnalysis_GetRecords";
        public static string GetTextAnalysisRecordByValue =  "TextAnalysis_GetRecordByValue";
        public static string GetTextAnalysisRecordByValueArray = "TextAnalysis_GetRecordByValueArray";
         
        #endregion

        #region Collection StoredProcedure
		 
        public static string TextAnalysisSearch = "TextAnalysis_Search";
        public static string TextAnalysisSearchByValue =  "TextAnalysis_SearchByValue";
        public static string TextAnalysisSearchByValueArray = "TextAnalysis_SearchByValueArray";
        #endregion
 
        public static string IsExist = "";
        public static string GetCollectionForQuery = "";
        public static string SortingString = "SortOrder";


      
    }
}
