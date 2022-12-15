using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaniCall.Business.DataAccess.Constants
{
    public class SentenceOpinionDBFields
    {
	
        public static string IU_Flag = "IU_Flag"; 
        public static string TableNameVal = "SentenceOpinion";
        public static string  ID = "ID";
        public static string  AnalysedSentencesID = "AnalysedSentencesID";
        public static string  TargetText = "TargetText";
        public static string  Sentiment = "Sentiment";
        public static string  PositiveScore = "PositiveScore";
        public static string  NuetralScore = "NuetralScore";
        public static string  NegativeScore = "NegativeScore";
        public static string  SentenceLength = "SentenceLength";
        public static string  Offset = "Offset";
        public static string  StatusId = "StatusId";
        public static string  CreatedDate = "CreatedDate";
        public static string  UpdatedDate = "UpdatedDate";
        public static string Count = "Count";
    }

    public class SentenceOpinionStoredProcedures
    {

        #region Object StoredProcedure

		
        public static string SentenceOpinionSAVE = "SentenceOpinion_SAVE";
        public static string SentenceOpinionGetRecordById = "SentenceOpinion_GetRecordById";

        public static string GetSentenceOpinionRecords = "SentenceOpinion_GetRecords";
        public static string GetSentenceOpinionRecordByValue =  "SentenceOpinion_GetRecordByValue";
        public static string GetSentenceOpinionRecordByValueArray = "SentenceOpinion_GetRecordByValueArray";
         
        #endregion

        #region Collection StoredProcedure
		 
        public static string SentenceOpinionSearch = "SentenceOpinion_Search";
        public static string SentenceOpinionSearchByValue =  "SentenceOpinion_SearchByValue";
        public static string SentenceOpinionSearchByValueArray = "SentenceOpinion_SearchByValueArray";
        #endregion
 
        public static string IsExist = "";
        public static string GetCollectionForQuery = "";
        public static string SortingString = "SortOrder";


      
    }
}
