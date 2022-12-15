using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaniCall.Business.DataAccess.Constants
{
    public class AnalysedSentencesDBFields
    {
        public static string IU_Flag = "IU_Flag"; 

        public static string TableNameVal = "AnalysedSentences";
        public static string  ID = "ID";
        public static string  TextAnalysisID = "TextAnalysisID";
        public static string  PositiveScore = "PositiveScore";
        public static string  NuetralScore = "NuetralScore";
        public static string  NegativeScore = "NegativeScore";
        public static string  Offset = "Offset";
        public static string  SentenceLength = "SentenceLength";
        public static string  Sentiment = "Sentiment";
        public static string  StatusId = "StatusId";
        public static string  CreatedDate = "CreatedDate";
        public static string  UpdatedDate = "UpdatedDate";
        public static string Sentence = "Sentence";

    }
    public class AnalysedSentencesStoredProcedures
    {

        #region Object StoredProcedure

		



		
        public static string AnalysedSentencesSAVE = "AnalysedSentences_SAVE";
        public static string AnalysedSentencesGetRecordById = "AnalysedSentences_GetRecordById";

        public static string GetAnalysedSentencesRecords = "AnalysedSentences_GetRecords";
        public static string GetAnalysedSentencesRecordByValue =  "AnalysedSentences_GetRecordByValue";
        public static string GetAnalysedSentencesRecordByValueArray = "AnalysedSentences_GetRecordByValueArray";
         
        #endregion

        #region Collection StoredProcedure
		 
        public static string AnalysedSentencesSearch = "AnalysedSentences_Search";
        public static string AnalysedSentencesSearchByValue =  "AnalysedSentences_SearchByValue";
        public static string AnalysedSentencesSearchByValueArray = "AnalysedSentences_SearchByValueArray";
        #endregion
 
        public static string IsExist = "";
        public static string GetCollectionForQuery = "";
        public static string SortingString = "SortOrder";


      
    }
}
