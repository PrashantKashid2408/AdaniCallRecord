using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaniCall.Business.DataAccess.Constants
{
    public class SentenceAssessmentsDBFields
    {

	
        public static string IU_Flag = "IU_Flag"; 


		

        public static string TableNameVal = "SentenceAssessments";
        public static string  ID = "ID";
        public static string SentenceOpinionID = "SentenceOpinionID";
        public static string  AssessmentText = "AssessmentText";
        public static string  Sentiment = "Sentiment";
        public static string  PositiveScore = "PositiveScore";
        public static string  NuetralScore = "NuetralScore";
        public static string  NegativeScore = "NegativeScore";
        public static string  SentenceLength = "SentenceLength";
        public static string  Offset = "Offset";
        public static string  IsNegated = "IsNegated";
        public static string  StatusId = "StatusId";
        public static string  CreatedDate = "CreatedDate";
        public static string  UpdatedDate = "UpdatedDate";
        public static string Count = "Count";
    }
    public class SentenceAssessmentsStoredProcedures
    {

        #region Object StoredProcedure

		



		
        public static string SentenceAssessmentsSAVE = "SentenceAssessments_SAVE";
        public static string SentenceAssessmentsGetRecordById = "SentenceAssessments_GetRecordById";

        public static string GetSentenceAssessmentsRecords = "SentenceAssessments_GetRecords";
        public static string GetSentenceAssessmentsRecordByValue =  "SentenceAssessments_GetRecordByValue";
        public static string GetSentenceAssessmentsRecordByValueArray = "SentenceAssessments_GetRecordByValueArray";
         
        #endregion

        #region Collection StoredProcedure
		 
        public static string SentenceAssessmentsSearch = "SentenceAssessments_Search";
        public static string SentenceAssessmentsSearchByValue =  "SentenceAssessments_SearchByValue";
        public static string SentenceAssessmentsSearchByValueArray = "SentenceAssessments_SearchByValueArray";
        #endregion
 
        public static string IsExist = "";
        public static string GetCollectionForQuery = "";
        public static string SortingString = "SortOrder";


      
    }
}
