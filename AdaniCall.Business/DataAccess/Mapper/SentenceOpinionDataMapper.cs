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
    public class SentenceOpinionDataMapper
    {
        private static readonly string _module = "AdaniCall.Business.DataAccess.Mapper.SentenceOpinionDataMapper";
        private SentenceOpinion objSentenceOpinion = null;

        public SentenceOpinion GetDetails(SqlDataReader sqlDataReader)
        {
            try
            {
                objSentenceOpinion = new SentenceOpinion();
               
			    if (sqlDataReader.HasColumn(SentenceOpinionDBFields.ID))
                   objSentenceOpinion.ID = (sqlDataReader[SentenceOpinionDBFields.ID] != DBNull.Value ? Convert.ToInt32(sqlDataReader[SentenceOpinionDBFields.ID]) : 0); 
                if (sqlDataReader.HasColumn(SentenceOpinionDBFields.AnalysedSentencesID))
                   objSentenceOpinion.AnalysedSentencesID = (sqlDataReader[SentenceOpinionDBFields.AnalysedSentencesID] != DBNull.Value ? Convert.ToInt32(sqlDataReader[SentenceOpinionDBFields.AnalysedSentencesID]) : 0); 
                if (sqlDataReader.HasColumn(SentenceOpinionDBFields.TargetText))
                   objSentenceOpinion.TargetText = (sqlDataReader[SentenceOpinionDBFields.TargetText] != DBNull.Value ? Convert.ToString(sqlDataReader[SentenceOpinionDBFields.TargetText]) : string.Empty); 
                if (sqlDataReader.HasColumn(SentenceOpinionDBFields.Sentiment))
                   objSentenceOpinion.Sentiment = (sqlDataReader[SentenceOpinionDBFields.Sentiment] != DBNull.Value ? Convert.ToString(sqlDataReader[SentenceOpinionDBFields.Sentiment]) : string.Empty); 
                if (sqlDataReader.HasColumn(SentenceOpinionDBFields.PositiveScore))
                    objSentenceOpinion.PositiveScore = (sqlDataReader[AnalysedSentencesDBFields.PositiveScore] != DBNull.Value ? Convert.ToDecimal(sqlDataReader[AnalysedSentencesDBFields.PositiveScore]) : 0);
                if (sqlDataReader.HasColumn(SentenceOpinionDBFields.NuetralScore))
                    objSentenceOpinion.NuetralScore = (sqlDataReader[AnalysedSentencesDBFields.NuetralScore] != DBNull.Value ? Convert.ToDecimal(sqlDataReader[AnalysedSentencesDBFields.NuetralScore]) : 0);
                if (sqlDataReader.HasColumn(SentenceOpinionDBFields.NegativeScore))
                    objSentenceOpinion.NegativeScore = (sqlDataReader[AnalysedSentencesDBFields.NegativeScore] != DBNull.Value ? Convert.ToDecimal(sqlDataReader[AnalysedSentencesDBFields.NegativeScore]) : 0);
                if (sqlDataReader.HasColumn(SentenceOpinionDBFields.SentenceLength))
                   objSentenceOpinion.SentenceLength = (sqlDataReader[SentenceOpinionDBFields.SentenceLength] != DBNull.Value ? Convert.ToInt32(sqlDataReader[SentenceOpinionDBFields.SentenceLength]) : 0); 
                if (sqlDataReader.HasColumn(SentenceOpinionDBFields.Offset))
                   objSentenceOpinion.Offset = (sqlDataReader[SentenceOpinionDBFields.Offset] != DBNull.Value ? Convert.ToInt32(sqlDataReader[SentenceOpinionDBFields.Offset]) : 0);
                if (sqlDataReader.HasColumn(SentenceOpinionDBFields.Count))
                    objSentenceOpinion.Count = (sqlDataReader[SentenceOpinionDBFields.Count] != DBNull.Value ? Convert.ToInt32(sqlDataReader[SentenceOpinionDBFields.Count]) : 0);
                if (sqlDataReader.HasColumn(SentenceOpinionDBFields.StatusId))
                   objSentenceOpinion.StatusId = (sqlDataReader[SentenceOpinionDBFields.StatusId] != DBNull.Value ? Convert.ToByte(sqlDataReader[SentenceOpinionDBFields.StatusId]) : (byte)0); 
                if (sqlDataReader.HasColumn(SentenceOpinionDBFields.CreatedDate))
                   objSentenceOpinion.CreatedDate = (sqlDataReader[SentenceOpinionDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(sqlDataReader[SentenceOpinionDBFields.CreatedDate]) : DateTime.Now); 
                if (sqlDataReader.HasColumn(SentenceOpinionDBFields.UpdatedDate))
                   objSentenceOpinion.UpdatedDate = (sqlDataReader[SentenceOpinionDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(sqlDataReader[SentenceOpinionDBFields.UpdatedDate]) : DateTime.Now); 
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(sqlDataReader)", ex.Source, ex.Message, ex);
            }
            return objSentenceOpinion;
        }

        

        public List<SentenceOpinion> GetDetailsList(SqlDataReader sqlDataReader)
        {
            List<SentenceOpinion> list = new List<SentenceOpinion>();
            try
            {
                while (sqlDataReader.Read())
                {
                    objSentenceOpinion = GetDetails(sqlDataReader);
                    list.Add(objSentenceOpinion);
                }

            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetailsList(sqlDataReader)", ex.Source, ex.Message, ex);
            }
            return list;
        }

        public OpinionTotal GetDetailsOpinionTotal(SqlDataReader sqlDataReader)
        {
            OpinionTotal objOT = new OpinionTotal();
            try
            {
                if (sqlDataReader.HasColumn(SentenceOpinionDBFields.Sentiment))
                    objOT.Sentiment = (sqlDataReader[SentenceOpinionDBFields.Sentiment] != DBNull.Value ? Convert.ToString(sqlDataReader[SentenceOpinionDBFields.Sentiment]) : string.Empty);
                if (sqlDataReader.HasColumn(SentenceOpinionDBFields.Count))
                    objOT.Count = (sqlDataReader[SentenceOpinionDBFields.Count] != DBNull.Value ? Convert.ToInt32(sqlDataReader[SentenceOpinionDBFields.Count]) : 0);
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetailsOpinionTotal(sqlDataReader)", ex.Source, ex.Message, ex);
            }
            return objOT;
        }

        public List<OpinionTotal> GetDetailsOpinionTotalList(SqlDataReader sqlDataReader)
        {
            List<OpinionTotal> list = new List<OpinionTotal>();
            OpinionTotal objOT = new OpinionTotal();
            try
            {
                while (sqlDataReader.Read())
                {
                    objOT = GetDetailsOpinionTotal(sqlDataReader);
                    list.Add(objOT);
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetailsOpinionTotalList(sqlDataReader)", ex.Source, ex.Message, ex);
            }
            return list;
        }

        public List<SentenceOpinion> GetDetails(DataSet dataSet)
        {
            List<SentenceOpinion> SentenceOpinions = new List<SentenceOpinion>();

            try
            {
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drow in dataSet.Tables[0].Rows)
                    {
                        objSentenceOpinion = new SentenceOpinion();
                       
						if (drow.Table.Columns.Contains(SentenceOpinionDBFields.ID)) 
  objSentenceOpinion.ID = (drow[SentenceOpinionDBFields.ID] != DBNull.Value ? Convert.ToInt32(drow[SentenceOpinionDBFields.ID]) : 0); 
if (drow.Table.Columns.Contains(SentenceOpinionDBFields.AnalysedSentencesID)) 
  objSentenceOpinion.AnalysedSentencesID = (drow[SentenceOpinionDBFields.AnalysedSentencesID] != DBNull.Value ? Convert.ToInt32(drow[SentenceOpinionDBFields.AnalysedSentencesID]) : 0); 
if (drow.Table.Columns.Contains(SentenceOpinionDBFields.TargetText)) 
  objSentenceOpinion.TargetText = (drow[SentenceOpinionDBFields.TargetText] != DBNull.Value ? Convert.ToString(drow[SentenceOpinionDBFields.TargetText]) : string.Empty); 
if (drow.Table.Columns.Contains(SentenceOpinionDBFields.Sentiment)) 
  objSentenceOpinion.Sentiment = (drow[SentenceOpinionDBFields.Sentiment] != DBNull.Value ? Convert.ToString(drow[SentenceOpinionDBFields.Sentiment]) : string.Empty); 
if (drow.Table.Columns.Contains(SentenceOpinionDBFields.PositiveScore)) 
if (drow.Table.Columns.Contains(SentenceOpinionDBFields.NuetralScore)) 
if (drow.Table.Columns.Contains(SentenceOpinionDBFields.NegativeScore)) 
if (drow.Table.Columns.Contains(SentenceOpinionDBFields.SentenceLength)) 
  objSentenceOpinion.SentenceLength = (drow[SentenceOpinionDBFields.SentenceLength] != DBNull.Value ? Convert.ToInt32(drow[SentenceOpinionDBFields.SentenceLength]) : 0); 
if (drow.Table.Columns.Contains(SentenceOpinionDBFields.Offset)) 
  objSentenceOpinion.Offset = (drow[SentenceOpinionDBFields.Offset] != DBNull.Value ? Convert.ToInt32(drow[SentenceOpinionDBFields.Offset]) : 0); 
if (drow.Table.Columns.Contains(SentenceOpinionDBFields.StatusId)) 
  objSentenceOpinion.StatusId = (drow[SentenceOpinionDBFields.StatusId] != DBNull.Value ? Convert.ToByte(drow[SentenceOpinionDBFields.StatusId]) : (byte)0); 
if (drow.Table.Columns.Contains(SentenceOpinionDBFields.CreatedDate)) 
  objSentenceOpinion.CreatedDate = (drow[SentenceOpinionDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(drow[SentenceOpinionDBFields.CreatedDate]) : DateTime.Now); 
if (drow.Table.Columns.Contains(SentenceOpinionDBFields.UpdatedDate)) 
  objSentenceOpinion.UpdatedDate = (drow[SentenceOpinionDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(drow[SentenceOpinionDBFields.UpdatedDate]) : DateTime.Now); 


                        SentenceOpinions.Add(objSentenceOpinion);
                    }
                }

            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(dataSet)", ex.Source, ex.Message, ex);
            }

            return SentenceOpinions;
        }
		
		public SentenceOpinion GetDetailsobj(DataSet dataSet)
        {
            SentenceOpinion objSentenceOpinion = new SentenceOpinion();

            try
            {
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drow in dataSet.Tables[0].Rows)
                    {
                        objSentenceOpinion = new SentenceOpinion();
                      
						if (drow.Table.Columns.Contains(SentenceOpinionDBFields.ID)) 
  objSentenceOpinion.ID = (drow[SentenceOpinionDBFields.ID] != DBNull.Value ? Convert.ToInt32(drow[SentenceOpinionDBFields.ID]) : 0); 
if (drow.Table.Columns.Contains(SentenceOpinionDBFields.AnalysedSentencesID)) 
  objSentenceOpinion.AnalysedSentencesID = (drow[SentenceOpinionDBFields.AnalysedSentencesID] != DBNull.Value ? Convert.ToInt32(drow[SentenceOpinionDBFields.AnalysedSentencesID]) : 0); 
if (drow.Table.Columns.Contains(SentenceOpinionDBFields.TargetText)) 
  objSentenceOpinion.TargetText = (drow[SentenceOpinionDBFields.TargetText] != DBNull.Value ? Convert.ToString(drow[SentenceOpinionDBFields.TargetText]) : string.Empty); 
if (drow.Table.Columns.Contains(SentenceOpinionDBFields.Sentiment)) 
  objSentenceOpinion.Sentiment = (drow[SentenceOpinionDBFields.Sentiment] != DBNull.Value ? Convert.ToString(drow[SentenceOpinionDBFields.Sentiment]) : string.Empty); 
if (drow.Table.Columns.Contains(SentenceOpinionDBFields.PositiveScore)) 
if (drow.Table.Columns.Contains(SentenceOpinionDBFields.NuetralScore)) 
if (drow.Table.Columns.Contains(SentenceOpinionDBFields.NegativeScore)) 
if (drow.Table.Columns.Contains(SentenceOpinionDBFields.SentenceLength)) 
  objSentenceOpinion.SentenceLength = (drow[SentenceOpinionDBFields.SentenceLength] != DBNull.Value ? Convert.ToInt32(drow[SentenceOpinionDBFields.SentenceLength]) : 0); 
if (drow.Table.Columns.Contains(SentenceOpinionDBFields.Offset)) 
  objSentenceOpinion.Offset = (drow[SentenceOpinionDBFields.Offset] != DBNull.Value ? Convert.ToInt32(drow[SentenceOpinionDBFields.Offset]) : 0); 
if (drow.Table.Columns.Contains(SentenceOpinionDBFields.StatusId)) 
  objSentenceOpinion.StatusId = (drow[SentenceOpinionDBFields.StatusId] != DBNull.Value ? Convert.ToByte(drow[SentenceOpinionDBFields.StatusId]) : (byte)0); 
if (drow.Table.Columns.Contains(SentenceOpinionDBFields.CreatedDate)) 
  objSentenceOpinion.CreatedDate = (drow[SentenceOpinionDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(drow[SentenceOpinionDBFields.CreatedDate]) : DateTime.Now); 
if (drow.Table.Columns.Contains(SentenceOpinionDBFields.UpdatedDate)) 
  objSentenceOpinion.UpdatedDate = (drow[SentenceOpinionDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(drow[SentenceOpinionDBFields.UpdatedDate]) : DateTime.Now); 

                        
                    }
                }

            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(dataSet)", ex.Source, ex.Message, ex);
            }

            return objSentenceOpinion;
        }
		
		public SentenceOpinion GetDetails(DataTable dataTable)
        {
            SentenceOpinion objSentenceOpinion = new SentenceOpinion();

            try
            {
                if (dataTable != null &&  dataTable.Rows.Count > 0)
                {
                    foreach (DataRow drow in dataTable.Rows)
                    {
                        objSentenceOpinion = new SentenceOpinion();
                      
						if (drow.Table.Columns.Contains(SentenceOpinionDBFields.ID)) 
  objSentenceOpinion.ID = (drow[SentenceOpinionDBFields.ID] != DBNull.Value ? Convert.ToInt32(drow[SentenceOpinionDBFields.ID]) : 0); 
if (drow.Table.Columns.Contains(SentenceOpinionDBFields.AnalysedSentencesID)) 
  objSentenceOpinion.AnalysedSentencesID = (drow[SentenceOpinionDBFields.AnalysedSentencesID] != DBNull.Value ? Convert.ToInt32(drow[SentenceOpinionDBFields.AnalysedSentencesID]) : 0); 
if (drow.Table.Columns.Contains(SentenceOpinionDBFields.TargetText)) 
  objSentenceOpinion.TargetText = (drow[SentenceOpinionDBFields.TargetText] != DBNull.Value ? Convert.ToString(drow[SentenceOpinionDBFields.TargetText]) : string.Empty); 
if (drow.Table.Columns.Contains(SentenceOpinionDBFields.Sentiment)) 
  objSentenceOpinion.Sentiment = (drow[SentenceOpinionDBFields.Sentiment] != DBNull.Value ? Convert.ToString(drow[SentenceOpinionDBFields.Sentiment]) : string.Empty); 
if (drow.Table.Columns.Contains(SentenceOpinionDBFields.PositiveScore)) 
if (drow.Table.Columns.Contains(SentenceOpinionDBFields.NuetralScore)) 
if (drow.Table.Columns.Contains(SentenceOpinionDBFields.NegativeScore)) 
if (drow.Table.Columns.Contains(SentenceOpinionDBFields.SentenceLength)) 
  objSentenceOpinion.SentenceLength = (drow[SentenceOpinionDBFields.SentenceLength] != DBNull.Value ? Convert.ToInt32(drow[SentenceOpinionDBFields.SentenceLength]) : 0); 
if (drow.Table.Columns.Contains(SentenceOpinionDBFields.Offset)) 
  objSentenceOpinion.Offset = (drow[SentenceOpinionDBFields.Offset] != DBNull.Value ? Convert.ToInt32(drow[SentenceOpinionDBFields.Offset]) : 0); 
if (drow.Table.Columns.Contains(SentenceOpinionDBFields.StatusId)) 
  objSentenceOpinion.StatusId = (drow[SentenceOpinionDBFields.StatusId] != DBNull.Value ? Convert.ToByte(drow[SentenceOpinionDBFields.StatusId]) : (byte)0); 
if (drow.Table.Columns.Contains(SentenceOpinionDBFields.CreatedDate)) 
  objSentenceOpinion.CreatedDate = (drow[SentenceOpinionDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(drow[SentenceOpinionDBFields.CreatedDate]) : DateTime.Now); 
if (drow.Table.Columns.Contains(SentenceOpinionDBFields.UpdatedDate)) 
  objSentenceOpinion.UpdatedDate = (drow[SentenceOpinionDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(drow[SentenceOpinionDBFields.UpdatedDate]) : DateTime.Now); 

                        
                    }
                }

            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(DataTable)", ex.Source, ex.Message, ex);
            }

            return objSentenceOpinion;
        }

    }
}
