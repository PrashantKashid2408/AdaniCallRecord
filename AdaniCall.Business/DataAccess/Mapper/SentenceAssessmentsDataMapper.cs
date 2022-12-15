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
    public class SentenceAssessmentsDataMapper
    {
        private static readonly string _module = "AdaniCall.Business.DataAccess.Mapper.SentenceAssessmentsDataMapper";
        private SentenceAssessments objSentenceAssessments = null;

        public SentenceAssessments GetDetails(SqlDataReader sqlDataReader)
        {
            try
            {
                objSentenceAssessments = new SentenceAssessments();
               
			    if (sqlDataReader.HasColumn(SentenceAssessmentsDBFields.ID))
                   objSentenceAssessments.ID = (sqlDataReader[SentenceAssessmentsDBFields.ID] != DBNull.Value ? Convert.ToInt32(sqlDataReader[SentenceAssessmentsDBFields.ID]) : 0); 
                if (sqlDataReader.HasColumn(SentenceAssessmentsDBFields.SentenceOpinionID))
                   objSentenceAssessments.SentenceOpinionID = (sqlDataReader[SentenceAssessmentsDBFields.SentenceOpinionID] != DBNull.Value ? Convert.ToInt32(sqlDataReader[SentenceAssessmentsDBFields.SentenceOpinionID]) : 0); 
                if (sqlDataReader.HasColumn(SentenceAssessmentsDBFields.AssessmentText))
                   objSentenceAssessments.AssessmentText = (sqlDataReader[SentenceAssessmentsDBFields.AssessmentText] != DBNull.Value ? Convert.ToString(sqlDataReader[SentenceAssessmentsDBFields.AssessmentText]) : string.Empty); 
                if (sqlDataReader.HasColumn(SentenceAssessmentsDBFields.Sentiment))
                   objSentenceAssessments.Sentiment = (sqlDataReader[SentenceAssessmentsDBFields.Sentiment] != DBNull.Value ? Convert.ToString(sqlDataReader[SentenceAssessmentsDBFields.Sentiment]) : string.Empty); 
                if (sqlDataReader.HasColumn(SentenceAssessmentsDBFields.PositiveScore))
                    objSentenceAssessments.PositiveScore = (sqlDataReader[AnalysedSentencesDBFields.PositiveScore] != DBNull.Value ? Convert.ToDecimal(sqlDataReader[AnalysedSentencesDBFields.PositiveScore]) : 0);
                if (sqlDataReader.HasColumn(SentenceAssessmentsDBFields.NuetralScore))
                    objSentenceAssessments.NuetralScore = (sqlDataReader[AnalysedSentencesDBFields.NuetralScore] != DBNull.Value ? Convert.ToDecimal(sqlDataReader[AnalysedSentencesDBFields.NuetralScore]) : 0);
                if (sqlDataReader.HasColumn(SentenceAssessmentsDBFields.NegativeScore))
                    objSentenceAssessments.NegativeScore = (sqlDataReader[AnalysedSentencesDBFields.NegativeScore] != DBNull.Value ? Convert.ToDecimal(sqlDataReader[AnalysedSentencesDBFields.NegativeScore]) : 0);
                if (sqlDataReader.HasColumn(SentenceAssessmentsDBFields.SentenceLength))
                   objSentenceAssessments.SentenceLength = (sqlDataReader[SentenceAssessmentsDBFields.SentenceLength] != DBNull.Value ? Convert.ToInt32(sqlDataReader[SentenceAssessmentsDBFields.SentenceLength]) : 0); 
                if (sqlDataReader.HasColumn(SentenceAssessmentsDBFields.Offset))
                   objSentenceAssessments.Offset = (sqlDataReader[SentenceAssessmentsDBFields.Offset] != DBNull.Value ? Convert.ToInt32(sqlDataReader[SentenceAssessmentsDBFields.Offset]) : 0); 
                if (sqlDataReader.HasColumn(SentenceAssessmentsDBFields.IsNegated))
                   objSentenceAssessments.IsNegated = (sqlDataReader[SentenceAssessmentsDBFields.IsNegated] != DBNull.Value ? Convert.ToString(sqlDataReader[SentenceAssessmentsDBFields.IsNegated]) : string.Empty);
                if (sqlDataReader.HasColumn(SentenceAssessmentsDBFields.Count))
                    objSentenceAssessments.Count = (sqlDataReader[SentenceAssessmentsDBFields.Count] != DBNull.Value ? Convert.ToInt32(sqlDataReader[SentenceAssessmentsDBFields.Count]) : 0);
                if (sqlDataReader.HasColumn(SentenceAssessmentsDBFields.StatusId))
                   objSentenceAssessments.StatusId = (sqlDataReader[SentenceAssessmentsDBFields.StatusId] != DBNull.Value ? Convert.ToByte(sqlDataReader[SentenceAssessmentsDBFields.StatusId]) : (byte)0); 
                if (sqlDataReader.HasColumn(SentenceAssessmentsDBFields.CreatedDate))
                   objSentenceAssessments.CreatedDate = (sqlDataReader[SentenceAssessmentsDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(sqlDataReader[SentenceAssessmentsDBFields.CreatedDate]) : DateTime.Now); 
                if (sqlDataReader.HasColumn(SentenceAssessmentsDBFields.UpdatedDate))
                   objSentenceAssessments.UpdatedDate = (sqlDataReader[SentenceAssessmentsDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(sqlDataReader[SentenceAssessmentsDBFields.UpdatedDate]) : DateTime.Now); 

            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(sqlDataReader)", ex.Source, ex.Message, ex);
            }
            return objSentenceAssessments;
        }
		
		public List<SentenceAssessments> GetDetailsList(SqlDataReader sqlDataReader)
        {
            List<SentenceAssessments> list = new List<SentenceAssessments>();
            try
            {
                while (sqlDataReader.Read())
                {
                    objSentenceAssessments = GetDetails(sqlDataReader);
                    list.Add(objSentenceAssessments);
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetailsList(sqlDataReader)", ex.Source, ex.Message, ex);
            }
            return list;
        }

        public AssesmentTotal GetDetailsAssesmentTotal(SqlDataReader sqlDataReader)
        {
            AssesmentTotal objOT = new AssesmentTotal();
            try
            {
                if (sqlDataReader.HasColumn(SentenceAssessmentsDBFields.Sentiment))
                    objOT.Sentiment = (sqlDataReader[SentenceAssessmentsDBFields.Sentiment] != DBNull.Value ? Convert.ToString(sqlDataReader[SentenceAssessmentsDBFields.Sentiment]) : string.Empty);
                if (sqlDataReader.HasColumn(SentenceAssessmentsDBFields.Count))
                    objOT.Count = (sqlDataReader[SentenceAssessmentsDBFields.Count] != DBNull.Value ? Convert.ToInt32(sqlDataReader[SentenceAssessmentsDBFields.Count]) : 0);
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetailsAssesmentTotal(sqlDataReader)", ex.Source, ex.Message, ex);
            }
            return objOT;
        }

        public List<AssesmentTotal> GetDetailsAssesmentTotalList(SqlDataReader sqlDataReader)
        {
            List<AssesmentTotal> list = new List<AssesmentTotal>();
            AssesmentTotal objAT = new AssesmentTotal();
            try
            {
                while (sqlDataReader.Read())
                {
                    objAT = GetDetailsAssesmentTotal(sqlDataReader);
                    list.Add(objAT);
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetailsAssesmentTotalList(sqlDataReader)", ex.Source, ex.Message, ex);
            }
            return list;
        }

        public List<SentenceAssessments> GetDetails(DataSet dataSet)
        {
            List<SentenceAssessments> SentenceAssessmentss = new List<SentenceAssessments>();

            try
            {
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drow in dataSet.Tables[0].Rows)
                    {
                        objSentenceAssessments = new SentenceAssessments();
                       
						if (drow.Table.Columns.Contains(SentenceAssessmentsDBFields.ID)) 
  objSentenceAssessments.ID = (drow[SentenceAssessmentsDBFields.ID] != DBNull.Value ? Convert.ToInt32(drow[SentenceAssessmentsDBFields.ID]) : 0); 
if (drow.Table.Columns.Contains(SentenceAssessmentsDBFields.SentenceOpinionID)) 
  objSentenceAssessments.SentenceOpinionID = (drow[SentenceAssessmentsDBFields.SentenceOpinionID] != DBNull.Value ? Convert.ToInt32(drow[SentenceAssessmentsDBFields.SentenceOpinionID]) : 0); 
if (drow.Table.Columns.Contains(SentenceAssessmentsDBFields.AssessmentText)) 
  objSentenceAssessments.AssessmentText = (drow[SentenceAssessmentsDBFields.AssessmentText] != DBNull.Value ? Convert.ToString(drow[SentenceAssessmentsDBFields.AssessmentText]) : string.Empty); 
if (drow.Table.Columns.Contains(SentenceAssessmentsDBFields.Sentiment)) 
  objSentenceAssessments.Sentiment = (drow[SentenceAssessmentsDBFields.Sentiment] != DBNull.Value ? Convert.ToString(drow[SentenceAssessmentsDBFields.Sentiment]) : string.Empty); 
if (drow.Table.Columns.Contains(SentenceAssessmentsDBFields.PositiveScore)) 
if (drow.Table.Columns.Contains(SentenceAssessmentsDBFields.NuetralScore)) 
if (drow.Table.Columns.Contains(SentenceAssessmentsDBFields.NegativeScore)) 
if (drow.Table.Columns.Contains(SentenceAssessmentsDBFields.SentenceLength)) 
  objSentenceAssessments.SentenceLength = (drow[SentenceAssessmentsDBFields.SentenceLength] != DBNull.Value ? Convert.ToInt32(drow[SentenceAssessmentsDBFields.SentenceLength]) : 0); 
if (drow.Table.Columns.Contains(SentenceAssessmentsDBFields.Offset)) 
  objSentenceAssessments.Offset = (drow[SentenceAssessmentsDBFields.Offset] != DBNull.Value ? Convert.ToInt32(drow[SentenceAssessmentsDBFields.Offset]) : 0); 
if (drow.Table.Columns.Contains(SentenceAssessmentsDBFields.IsNegated)) 
  objSentenceAssessments.IsNegated = (drow[SentenceAssessmentsDBFields.IsNegated] != DBNull.Value ? Convert.ToString(drow[SentenceAssessmentsDBFields.IsNegated]) : string.Empty); 
if (drow.Table.Columns.Contains(SentenceAssessmentsDBFields.StatusId)) 
  objSentenceAssessments.StatusId = (drow[SentenceAssessmentsDBFields.StatusId] != DBNull.Value ? Convert.ToByte(drow[SentenceAssessmentsDBFields.StatusId]) : (byte)0); 
if (drow.Table.Columns.Contains(SentenceAssessmentsDBFields.CreatedDate)) 
  objSentenceAssessments.CreatedDate = (drow[SentenceAssessmentsDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(drow[SentenceAssessmentsDBFields.CreatedDate]) : DateTime.Now); 
if (drow.Table.Columns.Contains(SentenceAssessmentsDBFields.UpdatedDate)) 
  objSentenceAssessments.UpdatedDate = (drow[SentenceAssessmentsDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(drow[SentenceAssessmentsDBFields.UpdatedDate]) : DateTime.Now); 


                        SentenceAssessmentss.Add(objSentenceAssessments);
                    }
                }

            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(dataSet)", ex.Source, ex.Message, ex);
            }

            return SentenceAssessmentss;
        }
		
		public SentenceAssessments GetDetailsobj(DataSet dataSet)
        {
            SentenceAssessments objSentenceAssessments = new SentenceAssessments();

            try
            {
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drow in dataSet.Tables[0].Rows)
                    {
                        objSentenceAssessments = new SentenceAssessments();
                      
						if (drow.Table.Columns.Contains(SentenceAssessmentsDBFields.ID)) 
  objSentenceAssessments.ID = (drow[SentenceAssessmentsDBFields.ID] != DBNull.Value ? Convert.ToInt32(drow[SentenceAssessmentsDBFields.ID]) : 0); 
if (drow.Table.Columns.Contains(SentenceAssessmentsDBFields.SentenceOpinionID)) 
  objSentenceAssessments.SentenceOpinionID = (drow[SentenceAssessmentsDBFields.SentenceOpinionID] != DBNull.Value ? Convert.ToInt32(drow[SentenceAssessmentsDBFields.SentenceOpinionID]) : 0); 
if (drow.Table.Columns.Contains(SentenceAssessmentsDBFields.AssessmentText)) 
  objSentenceAssessments.AssessmentText = (drow[SentenceAssessmentsDBFields.AssessmentText] != DBNull.Value ? Convert.ToString(drow[SentenceAssessmentsDBFields.AssessmentText]) : string.Empty); 
if (drow.Table.Columns.Contains(SentenceAssessmentsDBFields.Sentiment)) 
  objSentenceAssessments.Sentiment = (drow[SentenceAssessmentsDBFields.Sentiment] != DBNull.Value ? Convert.ToString(drow[SentenceAssessmentsDBFields.Sentiment]) : string.Empty); 
if (drow.Table.Columns.Contains(SentenceAssessmentsDBFields.PositiveScore)) 
if (drow.Table.Columns.Contains(SentenceAssessmentsDBFields.NuetralScore)) 
if (drow.Table.Columns.Contains(SentenceAssessmentsDBFields.NegativeScore)) 
if (drow.Table.Columns.Contains(SentenceAssessmentsDBFields.SentenceLength)) 
  objSentenceAssessments.SentenceLength = (drow[SentenceAssessmentsDBFields.SentenceLength] != DBNull.Value ? Convert.ToInt32(drow[SentenceAssessmentsDBFields.SentenceLength]) : 0); 
if (drow.Table.Columns.Contains(SentenceAssessmentsDBFields.Offset)) 
  objSentenceAssessments.Offset = (drow[SentenceAssessmentsDBFields.Offset] != DBNull.Value ? Convert.ToInt32(drow[SentenceAssessmentsDBFields.Offset]) : 0); 
if (drow.Table.Columns.Contains(SentenceAssessmentsDBFields.IsNegated)) 
  objSentenceAssessments.IsNegated = (drow[SentenceAssessmentsDBFields.IsNegated] != DBNull.Value ? Convert.ToString(drow[SentenceAssessmentsDBFields.IsNegated]) : string.Empty); 
if (drow.Table.Columns.Contains(SentenceAssessmentsDBFields.StatusId)) 
  objSentenceAssessments.StatusId = (drow[SentenceAssessmentsDBFields.StatusId] != DBNull.Value ? Convert.ToByte(drow[SentenceAssessmentsDBFields.StatusId]) : (byte)0); 
if (drow.Table.Columns.Contains(SentenceAssessmentsDBFields.CreatedDate)) 
  objSentenceAssessments.CreatedDate = (drow[SentenceAssessmentsDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(drow[SentenceAssessmentsDBFields.CreatedDate]) : DateTime.Now); 
if (drow.Table.Columns.Contains(SentenceAssessmentsDBFields.UpdatedDate)) 
  objSentenceAssessments.UpdatedDate = (drow[SentenceAssessmentsDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(drow[SentenceAssessmentsDBFields.UpdatedDate]) : DateTime.Now); 

                        
                    }
                }

            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(dataSet)", ex.Source, ex.Message, ex);
            }

            return objSentenceAssessments;
        }
		
		public SentenceAssessments GetDetails(DataTable dataTable)
        {
            SentenceAssessments objSentenceAssessments = new SentenceAssessments();

            try
            {
                if (dataTable != null &&  dataTable.Rows.Count > 0)
                {
                    foreach (DataRow drow in dataTable.Rows)
                    {
                        objSentenceAssessments = new SentenceAssessments();
                      
						if (drow.Table.Columns.Contains(SentenceAssessmentsDBFields.ID)) 
  objSentenceAssessments.ID = (drow[SentenceAssessmentsDBFields.ID] != DBNull.Value ? Convert.ToInt32(drow[SentenceAssessmentsDBFields.ID]) : 0); 
if (drow.Table.Columns.Contains(SentenceAssessmentsDBFields.SentenceOpinionID)) 
  objSentenceAssessments.SentenceOpinionID = (drow[SentenceAssessmentsDBFields.SentenceOpinionID] != DBNull.Value ? Convert.ToInt32(drow[SentenceAssessmentsDBFields.SentenceOpinionID]) : 0); 
if (drow.Table.Columns.Contains(SentenceAssessmentsDBFields.AssessmentText)) 
  objSentenceAssessments.AssessmentText = (drow[SentenceAssessmentsDBFields.AssessmentText] != DBNull.Value ? Convert.ToString(drow[SentenceAssessmentsDBFields.AssessmentText]) : string.Empty); 
if (drow.Table.Columns.Contains(SentenceAssessmentsDBFields.Sentiment)) 
  objSentenceAssessments.Sentiment = (drow[SentenceAssessmentsDBFields.Sentiment] != DBNull.Value ? Convert.ToString(drow[SentenceAssessmentsDBFields.Sentiment]) : string.Empty); 
if (drow.Table.Columns.Contains(SentenceAssessmentsDBFields.PositiveScore)) 
if (drow.Table.Columns.Contains(SentenceAssessmentsDBFields.NuetralScore)) 
if (drow.Table.Columns.Contains(SentenceAssessmentsDBFields.NegativeScore)) 
if (drow.Table.Columns.Contains(SentenceAssessmentsDBFields.SentenceLength)) 
  objSentenceAssessments.SentenceLength = (drow[SentenceAssessmentsDBFields.SentenceLength] != DBNull.Value ? Convert.ToInt32(drow[SentenceAssessmentsDBFields.SentenceLength]) : 0); 
if (drow.Table.Columns.Contains(SentenceAssessmentsDBFields.Offset)) 
  objSentenceAssessments.Offset = (drow[SentenceAssessmentsDBFields.Offset] != DBNull.Value ? Convert.ToInt32(drow[SentenceAssessmentsDBFields.Offset]) : 0); 
if (drow.Table.Columns.Contains(SentenceAssessmentsDBFields.IsNegated)) 
  objSentenceAssessments.IsNegated = (drow[SentenceAssessmentsDBFields.IsNegated] != DBNull.Value ? Convert.ToString(drow[SentenceAssessmentsDBFields.IsNegated]) : string.Empty); 
if (drow.Table.Columns.Contains(SentenceAssessmentsDBFields.StatusId)) 
  objSentenceAssessments.StatusId = (drow[SentenceAssessmentsDBFields.StatusId] != DBNull.Value ? Convert.ToByte(drow[SentenceAssessmentsDBFields.StatusId]) : (byte)0); 
if (drow.Table.Columns.Contains(SentenceAssessmentsDBFields.CreatedDate)) 
  objSentenceAssessments.CreatedDate = (drow[SentenceAssessmentsDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(drow[SentenceAssessmentsDBFields.CreatedDate]) : DateTime.Now); 
if (drow.Table.Columns.Contains(SentenceAssessmentsDBFields.UpdatedDate)) 
  objSentenceAssessments.UpdatedDate = (drow[SentenceAssessmentsDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(drow[SentenceAssessmentsDBFields.UpdatedDate]) : DateTime.Now); 

                        
                    }
                }

            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(DataTable)", ex.Source, ex.Message, ex);
            }

            return objSentenceAssessments;
        }

    }
}
