using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdaniCall.Business.DataAccess.Constants;
using System.Data.SqlClient;
using System.Data;
using AdaniCall.Entity;
using AdaniCall.Entity.Common;
using AdaniCall.Utility.Common;

namespace AdaniCall.Business.DataAccess.Mapper
{
    public class CallTransactionsDataMapper
    {
        private static readonly string _module = "AdaniCall.Business.DataAccess.Mapper.CallTransactionsDataMapper";
        private CallTransactions objCallTransactions = null;

        public CallTransactions GetDetails(SqlDataReader sqlDataReader)
        {
            try
            {
                objCallTransactions = new CallTransactions();
               
			    if (sqlDataReader.HasColumn(CallTransactionsDBFields.ID))
                   objCallTransactions.ID = (sqlDataReader[CallTransactionsDBFields.ID] != DBNull.Value ? Convert.ToInt64(sqlDataReader[CallTransactionsDBFields.ID]) : 0);
                if (sqlDataReader.HasColumn(CallTransactionsDBFields.RowNumber))
                    objCallTransactions.RowNumber = (sqlDataReader[CallTransactionsDBFields.RowNumber] != DBNull.Value ? Convert.ToString(sqlDataReader[CallTransactionsDBFields.RowNumber]) : string.Empty);
                if (sqlDataReader.HasColumn(CallTransactionsDBFields.UniqueCallID))
                    objCallTransactions.UniqueCallID = (sqlDataReader[CallTransactionsDBFields.UniqueCallID] != DBNull.Value ? Convert.ToString(sqlDataReader[CallTransactionsDBFields.UniqueCallID]) : string.Empty);
                if (sqlDataReader.HasColumn(CallTransactionsDBFields.TravellerCallID))
                   objCallTransactions.TravellerCallID = (sqlDataReader[CallTransactionsDBFields.TravellerCallID] != DBNull.Value ? Convert.ToString(sqlDataReader[CallTransactionsDBFields.TravellerCallID]) : string.Empty); 
                if (sqlDataReader.HasColumn(CallTransactionsDBFields.KioskID))
                   objCallTransactions.KioskID = (sqlDataReader[CallTransactionsDBFields.KioskID] != DBNull.Value ? Convert.ToInt64(sqlDataReader[CallTransactionsDBFields.KioskID]) : 0); 
                if (sqlDataReader.HasColumn(CallTransactionsDBFields.AgentCallID))
                   objCallTransactions.AgentCallID = (sqlDataReader[CallTransactionsDBFields.AgentCallID] != DBNull.Value ? Convert.ToString(sqlDataReader[CallTransactionsDBFields.AgentCallID]) : string.Empty); 
                if (sqlDataReader.HasColumn(CallTransactionsDBFields.AgentUserID))
                   objCallTransactions.AgentUserID = (sqlDataReader[CallTransactionsDBFields.AgentUserID] != DBNull.Value ? Convert.ToInt64(sqlDataReader[CallTransactionsDBFields.AgentUserID]) : 0); 
                if (sqlDataReader.HasColumn(CallTransactionsDBFields.CallStartTime))
                   objCallTransactions.CallStartTime = (sqlDataReader[CallTransactionsDBFields.CallStartTime] != DBNull.Value ? Convert.ToString(sqlDataReader[CallTransactionsDBFields.CallStartTime]) : string.Empty); 
                if (sqlDataReader.HasColumn(CallTransactionsDBFields.CallEndTime))
                   objCallTransactions.CallEndTime = (sqlDataReader[CallTransactionsDBFields.CallEndTime] != DBNull.Value ? Convert.ToString(sqlDataReader[CallTransactionsDBFields.CallEndTime]) : string.Empty); 
                if (sqlDataReader.HasColumn(CallTransactionsDBFields.VideoFileName))
                   objCallTransactions.VideoFileName = (sqlDataReader[CallTransactionsDBFields.VideoFileName] != DBNull.Value ? Convert.ToString(sqlDataReader[CallTransactionsDBFields.VideoFileName]) : string.Empty); 
                if (sqlDataReader.HasColumn(CallTransactionsDBFields.AudioFileName))
                   objCallTransactions.AudioFileName = (sqlDataReader[CallTransactionsDBFields.AudioFileName] != DBNull.Value ? Convert.ToString(sqlDataReader[CallTransactionsDBFields.AudioFileName]) : string.Empty);
                if (sqlDataReader.HasColumn(CallTransactionsDBFields.KioskLocationID))
                   objCallTransactions.KioskLocationID = (sqlDataReader[CallTransactionsDBFields.KioskLocationID] != DBNull.Value ? Convert.ToInt32(sqlDataReader[CallTransactionsDBFields.KioskLocationID]) : 0); 
                if (sqlDataReader.HasColumn(CallTransactionsDBFields.AgentLocationID))
                   objCallTransactions.AgentLocationID = (sqlDataReader[CallTransactionsDBFields.AgentLocationID] != DBNull.Value ? Convert.ToInt32(sqlDataReader[CallTransactionsDBFields.AgentLocationID]) : 0); 
                if (sqlDataReader.HasColumn(CallTransactionsDBFields.SpeechToTextID))
                   objCallTransactions.SpeechToTextID = (sqlDataReader[CallTransactionsDBFields.SpeechToTextID] != DBNull.Value ? Convert.ToInt64(sqlDataReader[CallTransactionsDBFields.SpeechToTextID]) : 0); 
                if (sqlDataReader.HasColumn(CallTransactionsDBFields.SpeechToTextStatus))
                   objCallTransactions.SpeechToTextStatus = (sqlDataReader[CallTransactionsDBFields.SpeechToTextStatus] != DBNull.Value ? Convert.ToByte(sqlDataReader[CallTransactionsDBFields.SpeechToTextStatus]) : (byte)0); 
                if (sqlDataReader.HasColumn(CallTransactionsDBFields.TextAnalysisID))
                   objCallTransactions.TextAnalysisID = (sqlDataReader[CallTransactionsDBFields.TextAnalysisID] != DBNull.Value ? Convert.ToInt64(sqlDataReader[CallTransactionsDBFields.TextAnalysisID]) : 0); 
                if (sqlDataReader.HasColumn(CallTransactionsDBFields.TextAnalysisStatus))
                   objCallTransactions.TextAnalysisStatus = (sqlDataReader[CallTransactionsDBFields.TextAnalysisStatus] != DBNull.Value ? Convert.ToByte(sqlDataReader[CallTransactionsDBFields.TextAnalysisStatus]) : (byte)0); 
                if (sqlDataReader.HasColumn(CallTransactionsDBFields.SpeechAnalysisID))
                   objCallTransactions.SpeechAnalysisID = (sqlDataReader[CallTransactionsDBFields.SpeechAnalysisID] != DBNull.Value ? Convert.ToInt64(sqlDataReader[CallTransactionsDBFields.SpeechAnalysisID]) : 0); 
                if (sqlDataReader.HasColumn(CallTransactionsDBFields.SpeechAnalysisStatus))
                   objCallTransactions.SpeechAnalysisStatus = (sqlDataReader[CallTransactionsDBFields.SpeechAnalysisStatus] != DBNull.Value ? Convert.ToByte(sqlDataReader[CallTransactionsDBFields.SpeechAnalysisStatus]) : (byte)0);
                if (sqlDataReader.HasColumn(CallTransactionsDBFields.LanguageName))
                    objCallTransactions.LanguageName = (sqlDataReader[CallTransactionsDBFields.LanguageName] != DBNull.Value ? Convert.ToString(sqlDataReader[CallTransactionsDBFields.LanguageName]) : string.Empty);
                if (sqlDataReader.HasColumn(CallTransactionsDBFields.LanguageId))
                   objCallTransactions.LanguageId = (sqlDataReader[CallTransactionsDBFields.LanguageId] != DBNull.Value ? Convert.ToInt32(sqlDataReader[CallTransactionsDBFields.LanguageId]) : 0); 
                if (sqlDataReader.HasColumn(CallTransactionsDBFields.StatusId))
                   objCallTransactions.StatusId = (sqlDataReader[CallTransactionsDBFields.StatusId] != DBNull.Value ? Convert.ToByte(sqlDataReader[CallTransactionsDBFields.StatusId]) : (byte)0); 
                if (sqlDataReader.HasColumn(CallTransactionsDBFields.CreatedDate))
                   objCallTransactions.CreatedDate = (sqlDataReader[CallTransactionsDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(sqlDataReader[CallTransactionsDBFields.CreatedDate]) : DateTime.Now); 
                if (sqlDataReader.HasColumn(CallTransactionsDBFields.UpdatedDate))
                   objCallTransactions.UpdatedDate = (sqlDataReader[CallTransactionsDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(sqlDataReader[CallTransactionsDBFields.UpdatedDate]) : DateTime.Now);

                if (sqlDataReader.HasColumn(CallTransactionsDBFields.KioskName))
                    objCallTransactions.KioskName = (sqlDataReader[CallTransactionsDBFields.KioskName] != DBNull.Value ? Convert.ToString(sqlDataReader[CallTransactionsDBFields.KioskName]) : string.Empty);
                if (sqlDataReader.HasColumn(CallTransactionsDBFields.KioskLocation))
                    objCallTransactions.KioskLocation = (sqlDataReader[CallTransactionsDBFields.KioskLocation] != DBNull.Value ? Convert.ToString(sqlDataReader[CallTransactionsDBFields.KioskLocation]) : string.Empty);
                if (sqlDataReader.HasColumn(CallTransactionsDBFields.AgentName))
                    objCallTransactions.AgentName = (sqlDataReader[CallTransactionsDBFields.AgentName] != DBNull.Value ? Convert.ToString(sqlDataReader[CallTransactionsDBFields.AgentName]) : string.Empty);
                if (sqlDataReader.HasColumn(CallTransactionsDBFields.AgentLocation))
                    objCallTransactions.AgentLocation = (sqlDataReader[CallTransactionsDBFields.AgentLocation] != DBNull.Value ? Convert.ToString(sqlDataReader[CallTransactionsDBFields.AgentLocation]) : string.Empty);
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(sqlDataReader)", ex.Source, ex.Message, ex);
            }
            return objCallTransactions;
        }
		
		public List<CallTransactions> GetDetailsList(SqlDataReader sqlDataReader)
        {
            List<CallTransactions> list = new List<CallTransactions>();
            try
            {
                while (sqlDataReader.Read())
                {
                    objCallTransactions = GetDetails(sqlDataReader);
                    list.Add(objCallTransactions);
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetailsList(sqlDataReader)", ex.Source, ex.Message, ex);
            }
            return list;
        }


        public Analysis GetDetailsAnalysis(SqlDataReader sqlDataReader)
        {
            Analysis objAnalysis = new Analysis();

            try
            {
                if (sqlDataReader.HasColumn(AnalysisDBFields.ID))
                    objAnalysis.ID = (sqlDataReader[AnalysisDBFields.ID] != DBNull.Value ? Convert.ToInt64(sqlDataReader[AnalysisDBFields.ID]) : 0);

                if (sqlDataReader.HasColumn(AnalysisDBFields.SpeechToTextID))
                    objAnalysis.SpeechToTextID = (sqlDataReader[AnalysisDBFields.SpeechToTextID] != DBNull.Value ? Convert.ToInt64(sqlDataReader[AnalysisDBFields.SpeechToTextID]) : 0);
                if (sqlDataReader.HasColumn(AnalysisDBFields.DisplayText))
                    objAnalysis.DisplayText = (sqlDataReader[AnalysisDBFields.DisplayText] != DBNull.Value ? Convert.ToString(sqlDataReader[AnalysisDBFields.DisplayText]) : string.Empty);
                if (sqlDataReader.HasColumn(AnalysisDBFields.Sentiment))
                    objAnalysis.Sentiment = (sqlDataReader[AnalysisDBFields.Sentiment] != DBNull.Value ? Convert.ToString(sqlDataReader[AnalysisDBFields.Sentiment]) : string.Empty);
                if (sqlDataReader.HasColumn(AnalysisDBFields.PositiveScore))
                    objAnalysis.PositiveScore = (sqlDataReader[AnalysisDBFields.PositiveScore] != DBNull.Value ? Convert.ToString(sqlDataReader[AnalysisDBFields.PositiveScore]) : string.Empty);
                if (sqlDataReader.HasColumn(AnalysisDBFields.NegativeScore))
                    objAnalysis.NegativeScore = (sqlDataReader[AnalysisDBFields.NegativeScore] != DBNull.Value ? Convert.ToString(sqlDataReader[AnalysisDBFields.NegativeScore]) : string.Empty);
                if (sqlDataReader.HasColumn(AnalysisDBFields.NuetralScore))
                    objAnalysis.NuetralScore = (sqlDataReader[AnalysisDBFields.NuetralScore] != DBNull.Value ? Convert.ToString(sqlDataReader[AnalysisDBFields.NuetralScore]) : string.Empty);

                if (sqlDataReader.HasColumn(AnalysisDBFields.AnalysedSentencesID))
                    objAnalysis.AnalysedSentencesID = (sqlDataReader[AnalysisDBFields.AnalysedSentencesID] != DBNull.Value ? Convert.ToInt64(sqlDataReader[AnalysisDBFields.AnalysedSentencesID]) : 0);
                if (sqlDataReader.HasColumn(AnalysisDBFields.Sentence))
                    objAnalysis.Sentence = (sqlDataReader[AnalysisDBFields.Sentence] != DBNull.Value ? Convert.ToString(sqlDataReader[AnalysisDBFields.Sentence]) : string.Empty);
                if (sqlDataReader.HasColumn(AnalysisDBFields.SentenceSentiment))
                    objAnalysis.SentenceSentiment = (sqlDataReader[AnalysisDBFields.SentenceSentiment] != DBNull.Value ? Convert.ToString(sqlDataReader[AnalysisDBFields.SentenceSentiment]) : string.Empty);
                if (sqlDataReader.HasColumn(AnalysisDBFields.SentencePositiveScore))
                    objAnalysis.SentencePositiveScore = (sqlDataReader[AnalysisDBFields.SentencePositiveScore] != DBNull.Value ? Convert.ToString(sqlDataReader[AnalysisDBFields.SentencePositiveScore]) : string.Empty);
                if (sqlDataReader.HasColumn(AnalysisDBFields.SentenceNegativeScore))
                    objAnalysis.SentenceNegativeScore = (sqlDataReader[AnalysisDBFields.SentenceNegativeScore] != DBNull.Value ? Convert.ToString(sqlDataReader[AnalysisDBFields.SentenceNegativeScore]) : string.Empty);
                if (sqlDataReader.HasColumn(AnalysisDBFields.SentenceNuetralScore))
                    objAnalysis.SentenceNuetralScore = (sqlDataReader[AnalysisDBFields.SentenceNuetralScore] != DBNull.Value ? Convert.ToString(sqlDataReader[AnalysisDBFields.SentenceNuetralScore]) : string.Empty);

                if (sqlDataReader.HasColumn(AnalysisDBFields.SentenceOpinionID))
                    objAnalysis.SentenceOpinionID = (sqlDataReader[AnalysisDBFields.SentenceOpinionID] != DBNull.Value ? Convert.ToInt64(sqlDataReader[AnalysisDBFields.SentenceOpinionID]) : 0);
                if (sqlDataReader.HasColumn(AnalysisDBFields.TargetText))
                    objAnalysis.TargetText = (sqlDataReader[AnalysisDBFields.SentenceNuetralScore] != DBNull.Value ? Convert.ToString(sqlDataReader[AnalysisDBFields.TargetText]) : string.Empty);
                if (sqlDataReader.HasColumn(AnalysisDBFields.OpinionSentiment))
                    objAnalysis.OpinionSentiment = (sqlDataReader[AnalysisDBFields.OpinionSentiment] != DBNull.Value ? Convert.ToString(sqlDataReader[AnalysisDBFields.OpinionSentiment]) : string.Empty);
                if (sqlDataReader.HasColumn(AnalysisDBFields.OpinionPositiveScore))
                    objAnalysis.OpinionPositiveScore = (sqlDataReader[AnalysisDBFields.OpinionPositiveScore] != DBNull.Value ? Convert.ToString(sqlDataReader[AnalysisDBFields.OpinionPositiveScore]) : string.Empty);
                if (sqlDataReader.HasColumn(AnalysisDBFields.OpinionNegativeScore))
                    objAnalysis.OpinionNegativeScore = (sqlDataReader[AnalysisDBFields.OpinionNegativeScore] != DBNull.Value ? Convert.ToString(sqlDataReader[AnalysisDBFields.OpinionNegativeScore]) : string.Empty);
                if (sqlDataReader.HasColumn(AnalysisDBFields.OpinionNuetralScore))
                    objAnalysis.OpinionNuetralScore = (sqlDataReader[AnalysisDBFields.OpinionNuetralScore] != DBNull.Value ? Convert.ToString(sqlDataReader[AnalysisDBFields.OpinionNuetralScore]) : string.Empty);

                if (sqlDataReader.HasColumn(AnalysisDBFields.SentenceAssessmentID))
                    objAnalysis.SentenceAssessmentID = (sqlDataReader[AnalysisDBFields.SentenceAssessmentID] != DBNull.Value ? Convert.ToInt64(sqlDataReader[AnalysisDBFields.SentenceAssessmentID]) : 0);
                if (sqlDataReader.HasColumn(AnalysisDBFields.AssessmentText))
                    objAnalysis.AssessmentText = (sqlDataReader[AnalysisDBFields.AssessmentText] != DBNull.Value ? Convert.ToString(sqlDataReader[AnalysisDBFields.AssessmentText]) : string.Empty);
                if (sqlDataReader.HasColumn(AnalysisDBFields.AssessmentSentiment))
                    objAnalysis.AssessmentSentiment = (sqlDataReader[AnalysisDBFields.AssessmentSentiment] != DBNull.Value ? Convert.ToString(sqlDataReader[AnalysisDBFields.AssessmentSentiment]) : string.Empty);
                if (sqlDataReader.HasColumn(AnalysisDBFields.AssessmentPositiveScore))
                    objAnalysis.AssessmentPositiveScore = (sqlDataReader[AnalysisDBFields.AssessmentPositiveScore] != DBNull.Value ? Convert.ToString(sqlDataReader[AnalysisDBFields.AssessmentPositiveScore]) : string.Empty);
                if (sqlDataReader.HasColumn(AnalysisDBFields.AssessmentNegativeScore))
                    objAnalysis.AssessmentNegativeScore = (sqlDataReader[AnalysisDBFields.AssessmentNegativeScore] != DBNull.Value ? Convert.ToString(sqlDataReader[AnalysisDBFields.AssessmentNegativeScore]) : string.Empty);
                if (sqlDataReader.HasColumn(AnalysisDBFields.AssessmentNuetralScore))
                    objAnalysis.AssessmentNuetralScore = (sqlDataReader[AnalysisDBFields.AssessmentNuetralScore] != DBNull.Value ? Convert.ToString(sqlDataReader[AnalysisDBFields.AssessmentNuetralScore]) : string.Empty);
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetailsAnalysis(sqlDataReader)", ex.Source, ex.Message, ex);
            }
            return objAnalysis;
        }

        public List<Analysis> GetDetailsAnalysisList(SqlDataReader sqlDataReader)
        {
            List<Analysis> list = new List<Analysis>();
            Analysis objAnalysis = new Analysis();
            try
            {
                while (sqlDataReader.Read())
                {
                    objAnalysis = GetDetailsAnalysis(sqlDataReader);
                    list.Add(objAnalysis);
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetailsAnalysisList(sqlDataReader)", ex.Source, ex.Message, ex);
            }
            return list;
        }

        public List<CallTransactions> GetDetails(DataSet dataSet)
        {
            List<CallTransactions> CallTransactionss = new List<CallTransactions>();

            try
            {
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drow in dataSet.Tables[0].Rows)
                    {
                        objCallTransactions = new CallTransactions();
                       
						if (drow.Table.Columns.Contains(CallTransactionsDBFields.ID)) 
  objCallTransactions.ID = (drow[CallTransactionsDBFields.ID] != DBNull.Value ? Convert.ToInt32(drow[CallTransactionsDBFields.ID]) : 0); 
if (drow.Table.Columns.Contains(CallTransactionsDBFields.TravellerCallID)) 
  objCallTransactions.TravellerCallID = (drow[CallTransactionsDBFields.TravellerCallID] != DBNull.Value ? Convert.ToString(drow[CallTransactionsDBFields.TravellerCallID]) : string.Empty); 
if (drow.Table.Columns.Contains(CallTransactionsDBFields.KioskID)) 
  objCallTransactions.KioskID = (drow[CallTransactionsDBFields.KioskID] != DBNull.Value ? Convert.ToInt32(drow[CallTransactionsDBFields.KioskID]) : 0); 
if (drow.Table.Columns.Contains(CallTransactionsDBFields.AgentCallID)) 
  objCallTransactions.AgentCallID = (drow[CallTransactionsDBFields.AgentCallID] != DBNull.Value ? Convert.ToString(drow[CallTransactionsDBFields.AgentCallID]) : string.Empty); 
if (drow.Table.Columns.Contains(CallTransactionsDBFields.AgentUserID)) 
  objCallTransactions.AgentUserID = (drow[CallTransactionsDBFields.AgentUserID] != DBNull.Value ? Convert.ToInt32(drow[CallTransactionsDBFields.AgentUserID]) : 0); 
if (drow.Table.Columns.Contains(CallTransactionsDBFields.CallStartTime)) 
  objCallTransactions.CallStartTime = (drow[CallTransactionsDBFields.CallStartTime] != DBNull.Value ? Convert.ToString(drow[CallTransactionsDBFields.CallStartTime]) : string.Empty); 
if (drow.Table.Columns.Contains(CallTransactionsDBFields.CallEndTime)) 
  objCallTransactions.CallEndTime = (drow[CallTransactionsDBFields.CallEndTime] != DBNull.Value ? Convert.ToString(drow[CallTransactionsDBFields.CallEndTime]) : string.Empty); 
if (drow.Table.Columns.Contains(CallTransactionsDBFields.VideoFileName)) 
  objCallTransactions.VideoFileName = (drow[CallTransactionsDBFields.VideoFileName] != DBNull.Value ? Convert.ToString(drow[CallTransactionsDBFields.VideoFileName]) : string.Empty); 
if (drow.Table.Columns.Contains(CallTransactionsDBFields.AudioFileName)) 
  objCallTransactions.AudioFileName = (drow[CallTransactionsDBFields.AudioFileName] != DBNull.Value ? Convert.ToString(drow[CallTransactionsDBFields.AudioFileName]) : string.Empty); 
if (drow.Table.Columns.Contains(CallTransactionsDBFields.KioskLocationID)) 
  objCallTransactions.KioskLocationID = (drow[CallTransactionsDBFields.KioskLocationID] != DBNull.Value ? Convert.ToInt32(drow[CallTransactionsDBFields.KioskLocationID]) : 0); 
if (drow.Table.Columns.Contains(CallTransactionsDBFields.AgentLocationID)) 
  objCallTransactions.AgentLocationID = (drow[CallTransactionsDBFields.AgentLocationID] != DBNull.Value ? Convert.ToInt32(drow[CallTransactionsDBFields.AgentLocationID]) : 0); 
if (drow.Table.Columns.Contains(CallTransactionsDBFields.SpeechToTextID)) 
  objCallTransactions.SpeechToTextID = (drow[CallTransactionsDBFields.SpeechToTextID] != DBNull.Value ? Convert.ToInt32(drow[CallTransactionsDBFields.SpeechToTextID]) : 0); 
if (drow.Table.Columns.Contains(CallTransactionsDBFields.SpeechToTextStatus)) 
  objCallTransactions.SpeechToTextStatus = (drow[CallTransactionsDBFields.SpeechToTextStatus] != DBNull.Value ? Convert.ToByte(drow[CallTransactionsDBFields.SpeechToTextStatus]) : (byte)0); 
if (drow.Table.Columns.Contains(CallTransactionsDBFields.TextAnalysisID)) 
  objCallTransactions.TextAnalysisID = (drow[CallTransactionsDBFields.TextAnalysisID] != DBNull.Value ? Convert.ToInt32(drow[CallTransactionsDBFields.TextAnalysisID]) : 0); 
if (drow.Table.Columns.Contains(CallTransactionsDBFields.TextAnalysisStatus)) 
  objCallTransactions.TextAnalysisStatus = (drow[CallTransactionsDBFields.TextAnalysisStatus] != DBNull.Value ? Convert.ToByte(drow[CallTransactionsDBFields.TextAnalysisStatus]) : (byte)0); 
if (drow.Table.Columns.Contains(CallTransactionsDBFields.SpeechAnalysisID)) 
  objCallTransactions.SpeechAnalysisID = (drow[CallTransactionsDBFields.SpeechAnalysisID] != DBNull.Value ? Convert.ToInt32(drow[CallTransactionsDBFields.SpeechAnalysisID]) : 0); 
if (drow.Table.Columns.Contains(CallTransactionsDBFields.SpeechAnalysisStatus)) 
  objCallTransactions.SpeechAnalysisStatus = (drow[CallTransactionsDBFields.SpeechAnalysisStatus] != DBNull.Value ? Convert.ToByte(drow[CallTransactionsDBFields.SpeechAnalysisStatus]) : (byte)0); 
if (drow.Table.Columns.Contains(CallTransactionsDBFields.LanguageId)) 
  objCallTransactions.LanguageId = (drow[CallTransactionsDBFields.LanguageId] != DBNull.Value ? Convert.ToInt32(drow[CallTransactionsDBFields.LanguageId]) : 0); 
if (drow.Table.Columns.Contains(CallTransactionsDBFields.StatusId)) 
  objCallTransactions.StatusId = (drow[CallTransactionsDBFields.StatusId] != DBNull.Value ? Convert.ToByte(drow[CallTransactionsDBFields.StatusId]) : (byte)0); 
if (drow.Table.Columns.Contains(CallTransactionsDBFields.CreatedDate)) 
  objCallTransactions.CreatedDate = (drow[CallTransactionsDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(drow[CallTransactionsDBFields.CreatedDate]) : DateTime.Now); 
if (drow.Table.Columns.Contains(CallTransactionsDBFields.UpdatedDate)) 
  objCallTransactions.UpdatedDate = (drow[CallTransactionsDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(drow[CallTransactionsDBFields.UpdatedDate]) : DateTime.Now); 


                        CallTransactionss.Add(objCallTransactions);
                    }
                }

            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(dataSet)", ex.Source, ex.Message, ex);
            }

            return CallTransactionss;
        }
		
		public CallTransactions GetDetailsobj(DataSet dataSet)
        {
            CallTransactions objCallTransactions = new CallTransactions();

            try
            {
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drow in dataSet.Tables[0].Rows)
                    {
                        objCallTransactions = new CallTransactions();
                      
						if (drow.Table.Columns.Contains(CallTransactionsDBFields.ID)) 
  objCallTransactions.ID = (drow[CallTransactionsDBFields.ID] != DBNull.Value ? Convert.ToInt32(drow[CallTransactionsDBFields.ID]) : 0); 
if (drow.Table.Columns.Contains(CallTransactionsDBFields.TravellerCallID)) 
  objCallTransactions.TravellerCallID = (drow[CallTransactionsDBFields.TravellerCallID] != DBNull.Value ? Convert.ToString(drow[CallTransactionsDBFields.TravellerCallID]) : string.Empty); 
if (drow.Table.Columns.Contains(CallTransactionsDBFields.KioskID)) 
  objCallTransactions.KioskID = (drow[CallTransactionsDBFields.KioskID] != DBNull.Value ? Convert.ToInt32(drow[CallTransactionsDBFields.KioskID]) : 0); 
if (drow.Table.Columns.Contains(CallTransactionsDBFields.AgentCallID)) 
  objCallTransactions.AgentCallID = (drow[CallTransactionsDBFields.AgentCallID] != DBNull.Value ? Convert.ToString(drow[CallTransactionsDBFields.AgentCallID]) : string.Empty); 
if (drow.Table.Columns.Contains(CallTransactionsDBFields.AgentUserID)) 
  objCallTransactions.AgentUserID = (drow[CallTransactionsDBFields.AgentUserID] != DBNull.Value ? Convert.ToInt32(drow[CallTransactionsDBFields.AgentUserID]) : 0); 
if (drow.Table.Columns.Contains(CallTransactionsDBFields.CallStartTime)) 
  objCallTransactions.CallStartTime = (drow[CallTransactionsDBFields.CallStartTime] != DBNull.Value ? Convert.ToString(drow[CallTransactionsDBFields.CallStartTime]) : string.Empty); 
if (drow.Table.Columns.Contains(CallTransactionsDBFields.CallEndTime)) 
  objCallTransactions.CallEndTime = (drow[CallTransactionsDBFields.CallEndTime] != DBNull.Value ? Convert.ToString(drow[CallTransactionsDBFields.CallEndTime]) : string.Empty); 
if (drow.Table.Columns.Contains(CallTransactionsDBFields.VideoFileName)) 
  objCallTransactions.VideoFileName = (drow[CallTransactionsDBFields.VideoFileName] != DBNull.Value ? Convert.ToString(drow[CallTransactionsDBFields.VideoFileName]) : string.Empty); 
if (drow.Table.Columns.Contains(CallTransactionsDBFields.AudioFileName)) 
  objCallTransactions.AudioFileName = (drow[CallTransactionsDBFields.AudioFileName] != DBNull.Value ? Convert.ToString(drow[CallTransactionsDBFields.AudioFileName]) : string.Empty); 
if (drow.Table.Columns.Contains(CallTransactionsDBFields.KioskLocationID)) 
  objCallTransactions.KioskLocationID = (drow[CallTransactionsDBFields.KioskLocationID] != DBNull.Value ? Convert.ToInt32(drow[CallTransactionsDBFields.KioskLocationID]) : 0); 
if (drow.Table.Columns.Contains(CallTransactionsDBFields.AgentLocationID)) 
  objCallTransactions.AgentLocationID = (drow[CallTransactionsDBFields.AgentLocationID] != DBNull.Value ? Convert.ToInt32(drow[CallTransactionsDBFields.AgentLocationID]) : 0); 
if (drow.Table.Columns.Contains(CallTransactionsDBFields.SpeechToTextID)) 
  objCallTransactions.SpeechToTextID = (drow[CallTransactionsDBFields.SpeechToTextID] != DBNull.Value ? Convert.ToInt32(drow[CallTransactionsDBFields.SpeechToTextID]) : 0); 
if (drow.Table.Columns.Contains(CallTransactionsDBFields.SpeechToTextStatus)) 
  objCallTransactions.SpeechToTextStatus = (drow[CallTransactionsDBFields.SpeechToTextStatus] != DBNull.Value ? Convert.ToByte(drow[CallTransactionsDBFields.SpeechToTextStatus]) : (byte)0); 
if (drow.Table.Columns.Contains(CallTransactionsDBFields.TextAnalysisID)) 
  objCallTransactions.TextAnalysisID = (drow[CallTransactionsDBFields.TextAnalysisID] != DBNull.Value ? Convert.ToInt32(drow[CallTransactionsDBFields.TextAnalysisID]) : 0); 
if (drow.Table.Columns.Contains(CallTransactionsDBFields.TextAnalysisStatus)) 
  objCallTransactions.TextAnalysisStatus = (drow[CallTransactionsDBFields.TextAnalysisStatus] != DBNull.Value ? Convert.ToByte(drow[CallTransactionsDBFields.TextAnalysisStatus]) : (byte)0); 
if (drow.Table.Columns.Contains(CallTransactionsDBFields.SpeechAnalysisID)) 
  objCallTransactions.SpeechAnalysisID = (drow[CallTransactionsDBFields.SpeechAnalysisID] != DBNull.Value ? Convert.ToInt32(drow[CallTransactionsDBFields.SpeechAnalysisID]) : 0); 
if (drow.Table.Columns.Contains(CallTransactionsDBFields.SpeechAnalysisStatus)) 
  objCallTransactions.SpeechAnalysisStatus = (drow[CallTransactionsDBFields.SpeechAnalysisStatus] != DBNull.Value ? Convert.ToByte(drow[CallTransactionsDBFields.SpeechAnalysisStatus]) : (byte)0); 
if (drow.Table.Columns.Contains(CallTransactionsDBFields.LanguageId)) 
  objCallTransactions.LanguageId = (drow[CallTransactionsDBFields.LanguageId] != DBNull.Value ? Convert.ToInt32(drow[CallTransactionsDBFields.LanguageId]) : 0); 
if (drow.Table.Columns.Contains(CallTransactionsDBFields.StatusId)) 
  objCallTransactions.StatusId = (drow[CallTransactionsDBFields.StatusId] != DBNull.Value ? Convert.ToByte(drow[CallTransactionsDBFields.StatusId]) : (byte)0); 
if (drow.Table.Columns.Contains(CallTransactionsDBFields.CreatedDate)) 
  objCallTransactions.CreatedDate = (drow[CallTransactionsDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(drow[CallTransactionsDBFields.CreatedDate]) : DateTime.Now); 
if (drow.Table.Columns.Contains(CallTransactionsDBFields.UpdatedDate)) 
  objCallTransactions.UpdatedDate = (drow[CallTransactionsDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(drow[CallTransactionsDBFields.UpdatedDate]) : DateTime.Now); 

                        
                    }
                }

            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(dataSet)", ex.Source, ex.Message, ex);
            }

            return objCallTransactions;
        }
		
		public CallTransactions GetDetails(DataTable dataTable)
        {
            CallTransactions objCallTransactions = new CallTransactions();

            try
            {
                if (dataTable != null &&  dataTable.Rows.Count > 0)
                {
                    foreach (DataRow drow in dataTable.Rows)
                    {
                        objCallTransactions = new CallTransactions();
                      
						if (drow.Table.Columns.Contains(CallTransactionsDBFields.ID)) 
  objCallTransactions.ID = (drow[CallTransactionsDBFields.ID] != DBNull.Value ? Convert.ToInt32(drow[CallTransactionsDBFields.ID]) : 0); 
if (drow.Table.Columns.Contains(CallTransactionsDBFields.TravellerCallID)) 
  objCallTransactions.TravellerCallID = (drow[CallTransactionsDBFields.TravellerCallID] != DBNull.Value ? Convert.ToString(drow[CallTransactionsDBFields.TravellerCallID]) : string.Empty); 
if (drow.Table.Columns.Contains(CallTransactionsDBFields.KioskID)) 
  objCallTransactions.KioskID = (drow[CallTransactionsDBFields.KioskID] != DBNull.Value ? Convert.ToInt32(drow[CallTransactionsDBFields.KioskID]) : 0); 
if (drow.Table.Columns.Contains(CallTransactionsDBFields.AgentCallID)) 
  objCallTransactions.AgentCallID = (drow[CallTransactionsDBFields.AgentCallID] != DBNull.Value ? Convert.ToString(drow[CallTransactionsDBFields.AgentCallID]) : string.Empty); 
if (drow.Table.Columns.Contains(CallTransactionsDBFields.AgentUserID)) 
  objCallTransactions.AgentUserID = (drow[CallTransactionsDBFields.AgentUserID] != DBNull.Value ? Convert.ToInt32(drow[CallTransactionsDBFields.AgentUserID]) : 0); 
if (drow.Table.Columns.Contains(CallTransactionsDBFields.CallStartTime)) 
  objCallTransactions.CallStartTime = (drow[CallTransactionsDBFields.CallStartTime] != DBNull.Value ? Convert.ToString(drow[CallTransactionsDBFields.CallStartTime]) : string.Empty); 
if (drow.Table.Columns.Contains(CallTransactionsDBFields.CallEndTime)) 
  objCallTransactions.CallEndTime = (drow[CallTransactionsDBFields.CallEndTime] != DBNull.Value ? Convert.ToString(drow[CallTransactionsDBFields.CallEndTime]) : string.Empty); 
if (drow.Table.Columns.Contains(CallTransactionsDBFields.VideoFileName)) 
  objCallTransactions.VideoFileName = (drow[CallTransactionsDBFields.VideoFileName] != DBNull.Value ? Convert.ToString(drow[CallTransactionsDBFields.VideoFileName]) : string.Empty); 
if (drow.Table.Columns.Contains(CallTransactionsDBFields.AudioFileName)) 
  objCallTransactions.AudioFileName = (drow[CallTransactionsDBFields.AudioFileName] != DBNull.Value ? Convert.ToString(drow[CallTransactionsDBFields.AudioFileName]) : string.Empty); 
if (drow.Table.Columns.Contains(CallTransactionsDBFields.KioskLocationID)) 
  objCallTransactions.KioskLocationID = (drow[CallTransactionsDBFields.KioskLocationID] != DBNull.Value ? Convert.ToInt32(drow[CallTransactionsDBFields.KioskLocationID]) : 0); 
if (drow.Table.Columns.Contains(CallTransactionsDBFields.AgentLocationID)) 
  objCallTransactions.AgentLocationID = (drow[CallTransactionsDBFields.AgentLocationID] != DBNull.Value ? Convert.ToInt32(drow[CallTransactionsDBFields.AgentLocationID]) : 0); 
if (drow.Table.Columns.Contains(CallTransactionsDBFields.SpeechToTextID)) 
  objCallTransactions.SpeechToTextID = (drow[CallTransactionsDBFields.SpeechToTextID] != DBNull.Value ? Convert.ToInt32(drow[CallTransactionsDBFields.SpeechToTextID]) : 0); 
if (drow.Table.Columns.Contains(CallTransactionsDBFields.SpeechToTextStatus)) 
  objCallTransactions.SpeechToTextStatus = (drow[CallTransactionsDBFields.SpeechToTextStatus] != DBNull.Value ? Convert.ToByte(drow[CallTransactionsDBFields.SpeechToTextStatus]) : (byte)0); 
if (drow.Table.Columns.Contains(CallTransactionsDBFields.TextAnalysisID)) 
  objCallTransactions.TextAnalysisID = (drow[CallTransactionsDBFields.TextAnalysisID] != DBNull.Value ? Convert.ToInt32(drow[CallTransactionsDBFields.TextAnalysisID]) : 0); 
if (drow.Table.Columns.Contains(CallTransactionsDBFields.TextAnalysisStatus)) 
  objCallTransactions.TextAnalysisStatus = (drow[CallTransactionsDBFields.TextAnalysisStatus] != DBNull.Value ? Convert.ToByte(drow[CallTransactionsDBFields.TextAnalysisStatus]) : (byte)0); 
if (drow.Table.Columns.Contains(CallTransactionsDBFields.SpeechAnalysisID)) 
  objCallTransactions.SpeechAnalysisID = (drow[CallTransactionsDBFields.SpeechAnalysisID] != DBNull.Value ? Convert.ToInt32(drow[CallTransactionsDBFields.SpeechAnalysisID]) : 0); 
if (drow.Table.Columns.Contains(CallTransactionsDBFields.SpeechAnalysisStatus)) 
  objCallTransactions.SpeechAnalysisStatus = (drow[CallTransactionsDBFields.SpeechAnalysisStatus] != DBNull.Value ? Convert.ToByte(drow[CallTransactionsDBFields.SpeechAnalysisStatus]) : (byte)0); 
if (drow.Table.Columns.Contains(CallTransactionsDBFields.LanguageId)) 
  objCallTransactions.LanguageId = (drow[CallTransactionsDBFields.LanguageId] != DBNull.Value ? Convert.ToInt32(drow[CallTransactionsDBFields.LanguageId]) : 0); 
if (drow.Table.Columns.Contains(CallTransactionsDBFields.StatusId)) 
  objCallTransactions.StatusId = (drow[CallTransactionsDBFields.StatusId] != DBNull.Value ? Convert.ToByte(drow[CallTransactionsDBFields.StatusId]) : (byte)0); 
if (drow.Table.Columns.Contains(CallTransactionsDBFields.CreatedDate)) 
  objCallTransactions.CreatedDate = (drow[CallTransactionsDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(drow[CallTransactionsDBFields.CreatedDate]) : DateTime.Now); 
if (drow.Table.Columns.Contains(CallTransactionsDBFields.UpdatedDate)) 
  objCallTransactions.UpdatedDate = (drow[CallTransactionsDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(drow[CallTransactionsDBFields.UpdatedDate]) : DateTime.Now); 

                        
                    }
                }

            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(DataTable)", ex.Source, ex.Message, ex);
            }

            return objCallTransactions;
        }

    }
}
