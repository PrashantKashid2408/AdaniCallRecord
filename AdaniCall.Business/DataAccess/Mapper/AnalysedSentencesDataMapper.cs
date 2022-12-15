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
    public class AnalysedSentencesDataMapper
    {
        private static readonly string _module = "AdaniCall.Business.DataAccess.Mapper.AnalysedSentencesDataMapper";
        private AnalysedSentences objAnalysedSentences = null;

        public AnalysedSentences GetDetails(SqlDataReader sqlDataReader)
        {
            try
            {
                objAnalysedSentences = new AnalysedSentences();
               
			    if (sqlDataReader.HasColumn(AnalysedSentencesDBFields.ID))
                   objAnalysedSentences.ID = (sqlDataReader[AnalysedSentencesDBFields.ID] != DBNull.Value ? Convert.ToInt64(sqlDataReader[AnalysedSentencesDBFields.ID]) : 0); 
                if (sqlDataReader.HasColumn(AnalysedSentencesDBFields.TextAnalysisID))
                   objAnalysedSentences.TextAnalysisID = (sqlDataReader[AnalysedSentencesDBFields.TextAnalysisID] != DBNull.Value ? Convert.ToInt64(sqlDataReader[AnalysedSentencesDBFields.TextAnalysisID]) : 0); 
                if (sqlDataReader.HasColumn(AnalysedSentencesDBFields.PositiveScore))
                   objAnalysedSentences.PositiveScore = (sqlDataReader[AnalysedSentencesDBFields.PositiveScore] != DBNull.Value ? Convert.ToDecimal(sqlDataReader[AnalysedSentencesDBFields.PositiveScore]) : 0);
                if (sqlDataReader.HasColumn(AnalysedSentencesDBFields.NuetralScore))
                    objAnalysedSentences.NuetralScore = (sqlDataReader[AnalysedSentencesDBFields.NuetralScore] != DBNull.Value ? Convert.ToDecimal(sqlDataReader[AnalysedSentencesDBFields.NuetralScore]) : 0);
                if (sqlDataReader.HasColumn(AnalysedSentencesDBFields.NegativeScore))
                    objAnalysedSentences.NegativeScore = (sqlDataReader[AnalysedSentencesDBFields.NegativeScore] != DBNull.Value ? Convert.ToDecimal(sqlDataReader[AnalysedSentencesDBFields.NegativeScore]) : 0);
                if (sqlDataReader.HasColumn(AnalysedSentencesDBFields.Offset))
                   objAnalysedSentences.Offset = (sqlDataReader[AnalysedSentencesDBFields.Offset] != DBNull.Value ? Convert.ToInt32(sqlDataReader[AnalysedSentencesDBFields.Offset]) : 0); 
                if (sqlDataReader.HasColumn(AnalysedSentencesDBFields.SentenceLength))
                   objAnalysedSentences.SentenceLength = (sqlDataReader[AnalysedSentencesDBFields.SentenceLength] != DBNull.Value ? Convert.ToInt32(sqlDataReader[AnalysedSentencesDBFields.SentenceLength]) : 0);
                if (sqlDataReader.HasColumn(AnalysedSentencesDBFields.Sentence))
                    objAnalysedSentences.Sentence = (sqlDataReader[AnalysedSentencesDBFields.Sentence] != DBNull.Value ? Convert.ToString(sqlDataReader[AnalysedSentencesDBFields.Sentence]) : string.Empty);
                if (sqlDataReader.HasColumn(AnalysedSentencesDBFields.Sentiment))
                   objAnalysedSentences.Sentiment = (sqlDataReader[AnalysedSentencesDBFields.Sentiment] != DBNull.Value ? Convert.ToString(sqlDataReader[AnalysedSentencesDBFields.Sentiment]) : string.Empty); 
                if (sqlDataReader.HasColumn(AnalysedSentencesDBFields.StatusId))
                   objAnalysedSentences.StatusId = (sqlDataReader[AnalysedSentencesDBFields.StatusId] != DBNull.Value ? Convert.ToByte(sqlDataReader[AnalysedSentencesDBFields.StatusId]) : (byte)0); 
                if (sqlDataReader.HasColumn(AnalysedSentencesDBFields.CreatedDate))
                   objAnalysedSentences.CreatedDate = (sqlDataReader[AnalysedSentencesDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(sqlDataReader[AnalysedSentencesDBFields.CreatedDate]) : DateTime.Now); 
                if (sqlDataReader.HasColumn(AnalysedSentencesDBFields.UpdatedDate))
                   objAnalysedSentences.UpdatedDate = (sqlDataReader[AnalysedSentencesDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(sqlDataReader[AnalysedSentencesDBFields.UpdatedDate]) : DateTime.Now); 
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(sqlDataReader)", ex.Source, ex.Message, ex);
            }
            return objAnalysedSentences;
        }
		
		public List<AnalysedSentences> GetDetailsList(SqlDataReader sqlDataReader)
        {
            List<AnalysedSentences> list = new List<AnalysedSentences>();
            try
            {
                while (sqlDataReader.Read())
                {
                    objAnalysedSentences = GetDetails(sqlDataReader);
                    list.Add(objAnalysedSentences);
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetailsList(sqlDataReader)", ex.Source, ex.Message, ex);
            }
            return list;
        }

        public List<AnalysedSentences> GetDetails(DataSet dataSet)
        {
            List<AnalysedSentences> AnalysedSentencess = new List<AnalysedSentences>();

            try
            {
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drow in dataSet.Tables[0].Rows)
                    {
                        objAnalysedSentences = new AnalysedSentences();
                       
						if (drow.Table.Columns.Contains(AnalysedSentencesDBFields.ID)) 
  objAnalysedSentences.ID = (drow[AnalysedSentencesDBFields.ID] != DBNull.Value ? Convert.ToInt32(drow[AnalysedSentencesDBFields.ID]) : 0); 
if (drow.Table.Columns.Contains(AnalysedSentencesDBFields.TextAnalysisID)) 
  objAnalysedSentences.TextAnalysisID = (drow[AnalysedSentencesDBFields.TextAnalysisID] != DBNull.Value ? Convert.ToInt32(drow[AnalysedSentencesDBFields.TextAnalysisID]) : 0); 
if (drow.Table.Columns.Contains(AnalysedSentencesDBFields.PositiveScore)) 
if (drow.Table.Columns.Contains(AnalysedSentencesDBFields.NuetralScore)) 
if (drow.Table.Columns.Contains(AnalysedSentencesDBFields.NegativeScore)) 
if (drow.Table.Columns.Contains(AnalysedSentencesDBFields.Offset)) 
  objAnalysedSentences.Offset = (drow[AnalysedSentencesDBFields.Offset] != DBNull.Value ? Convert.ToInt32(drow[AnalysedSentencesDBFields.Offset]) : 0); 
if (drow.Table.Columns.Contains(AnalysedSentencesDBFields.SentenceLength)) 
  objAnalysedSentences.SentenceLength = (drow[AnalysedSentencesDBFields.SentenceLength] != DBNull.Value ? Convert.ToInt32(drow[AnalysedSentencesDBFields.SentenceLength]) : 0); 
if (drow.Table.Columns.Contains(AnalysedSentencesDBFields.Sentiment)) 
  objAnalysedSentences.Sentiment = (drow[AnalysedSentencesDBFields.Sentiment] != DBNull.Value ? Convert.ToString(drow[AnalysedSentencesDBFields.Sentiment]) : string.Empty); 
if (drow.Table.Columns.Contains(AnalysedSentencesDBFields.StatusId)) 
  objAnalysedSentences.StatusId = (drow[AnalysedSentencesDBFields.StatusId] != DBNull.Value ? Convert.ToByte(drow[AnalysedSentencesDBFields.StatusId]) : (byte)0); 
if (drow.Table.Columns.Contains(AnalysedSentencesDBFields.CreatedDate)) 
  objAnalysedSentences.CreatedDate = (drow[AnalysedSentencesDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(drow[AnalysedSentencesDBFields.CreatedDate]) : DateTime.Now); 
if (drow.Table.Columns.Contains(AnalysedSentencesDBFields.UpdatedDate)) 
  objAnalysedSentences.UpdatedDate = (drow[AnalysedSentencesDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(drow[AnalysedSentencesDBFields.UpdatedDate]) : DateTime.Now); 


                        AnalysedSentencess.Add(objAnalysedSentences);
                    }
                }

            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(dataSet)", ex.Source, ex.Message, ex);
            }

            return AnalysedSentencess;
        }
		
		public AnalysedSentences GetDetailsobj(DataSet dataSet)
        {
            AnalysedSentences objAnalysedSentences = new AnalysedSentences();

            try
            {
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drow in dataSet.Tables[0].Rows)
                    {
                        objAnalysedSentences = new AnalysedSentences();
                      
						if (drow.Table.Columns.Contains(AnalysedSentencesDBFields.ID)) 
  objAnalysedSentences.ID = (drow[AnalysedSentencesDBFields.ID] != DBNull.Value ? Convert.ToInt32(drow[AnalysedSentencesDBFields.ID]) : 0); 
if (drow.Table.Columns.Contains(AnalysedSentencesDBFields.TextAnalysisID)) 
  objAnalysedSentences.TextAnalysisID = (drow[AnalysedSentencesDBFields.TextAnalysisID] != DBNull.Value ? Convert.ToInt32(drow[AnalysedSentencesDBFields.TextAnalysisID]) : 0); 
if (drow.Table.Columns.Contains(AnalysedSentencesDBFields.PositiveScore)) 
if (drow.Table.Columns.Contains(AnalysedSentencesDBFields.NuetralScore)) 
if (drow.Table.Columns.Contains(AnalysedSentencesDBFields.NegativeScore)) 
if (drow.Table.Columns.Contains(AnalysedSentencesDBFields.Offset)) 
  objAnalysedSentences.Offset = (drow[AnalysedSentencesDBFields.Offset] != DBNull.Value ? Convert.ToInt32(drow[AnalysedSentencesDBFields.Offset]) : 0); 
if (drow.Table.Columns.Contains(AnalysedSentencesDBFields.SentenceLength)) 
  objAnalysedSentences.SentenceLength = (drow[AnalysedSentencesDBFields.SentenceLength] != DBNull.Value ? Convert.ToInt32(drow[AnalysedSentencesDBFields.SentenceLength]) : 0); 
if (drow.Table.Columns.Contains(AnalysedSentencesDBFields.Sentiment)) 
  objAnalysedSentences.Sentiment = (drow[AnalysedSentencesDBFields.Sentiment] != DBNull.Value ? Convert.ToString(drow[AnalysedSentencesDBFields.Sentiment]) : string.Empty); 
if (drow.Table.Columns.Contains(AnalysedSentencesDBFields.StatusId)) 
  objAnalysedSentences.StatusId = (drow[AnalysedSentencesDBFields.StatusId] != DBNull.Value ? Convert.ToByte(drow[AnalysedSentencesDBFields.StatusId]) : (byte)0); 
if (drow.Table.Columns.Contains(AnalysedSentencesDBFields.CreatedDate)) 
  objAnalysedSentences.CreatedDate = (drow[AnalysedSentencesDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(drow[AnalysedSentencesDBFields.CreatedDate]) : DateTime.Now); 
if (drow.Table.Columns.Contains(AnalysedSentencesDBFields.UpdatedDate)) 
  objAnalysedSentences.UpdatedDate = (drow[AnalysedSentencesDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(drow[AnalysedSentencesDBFields.UpdatedDate]) : DateTime.Now); 

                        
                    }
                }

            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(dataSet)", ex.Source, ex.Message, ex);
            }

            return objAnalysedSentences;
        }
		
		public AnalysedSentences GetDetails(DataTable dataTable)
        {
            AnalysedSentences objAnalysedSentences = new AnalysedSentences();

            try
            {
                if (dataTable != null &&  dataTable.Rows.Count > 0)
                {
                    foreach (DataRow drow in dataTable.Rows)
                    {
                        objAnalysedSentences = new AnalysedSentences();
                      
						if (drow.Table.Columns.Contains(AnalysedSentencesDBFields.ID)) 
  objAnalysedSentences.ID = (drow[AnalysedSentencesDBFields.ID] != DBNull.Value ? Convert.ToInt32(drow[AnalysedSentencesDBFields.ID]) : 0); 
if (drow.Table.Columns.Contains(AnalysedSentencesDBFields.TextAnalysisID)) 
  objAnalysedSentences.TextAnalysisID = (drow[AnalysedSentencesDBFields.TextAnalysisID] != DBNull.Value ? Convert.ToInt32(drow[AnalysedSentencesDBFields.TextAnalysisID]) : 0); 
if (drow.Table.Columns.Contains(AnalysedSentencesDBFields.PositiveScore)) 
if (drow.Table.Columns.Contains(AnalysedSentencesDBFields.NuetralScore)) 
if (drow.Table.Columns.Contains(AnalysedSentencesDBFields.NegativeScore)) 
if (drow.Table.Columns.Contains(AnalysedSentencesDBFields.Offset)) 
  objAnalysedSentences.Offset = (drow[AnalysedSentencesDBFields.Offset] != DBNull.Value ? Convert.ToInt32(drow[AnalysedSentencesDBFields.Offset]) : 0); 
if (drow.Table.Columns.Contains(AnalysedSentencesDBFields.SentenceLength)) 
  objAnalysedSentences.SentenceLength = (drow[AnalysedSentencesDBFields.SentenceLength] != DBNull.Value ? Convert.ToInt32(drow[AnalysedSentencesDBFields.SentenceLength]) : 0); 
if (drow.Table.Columns.Contains(AnalysedSentencesDBFields.Sentiment)) 
  objAnalysedSentences.Sentiment = (drow[AnalysedSentencesDBFields.Sentiment] != DBNull.Value ? Convert.ToString(drow[AnalysedSentencesDBFields.Sentiment]) : string.Empty); 
if (drow.Table.Columns.Contains(AnalysedSentencesDBFields.StatusId)) 
  objAnalysedSentences.StatusId = (drow[AnalysedSentencesDBFields.StatusId] != DBNull.Value ? Convert.ToByte(drow[AnalysedSentencesDBFields.StatusId]) : (byte)0); 
if (drow.Table.Columns.Contains(AnalysedSentencesDBFields.CreatedDate)) 
  objAnalysedSentences.CreatedDate = (drow[AnalysedSentencesDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(drow[AnalysedSentencesDBFields.CreatedDate]) : DateTime.Now); 
if (drow.Table.Columns.Contains(AnalysedSentencesDBFields.UpdatedDate)) 
  objAnalysedSentences.UpdatedDate = (drow[AnalysedSentencesDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(drow[AnalysedSentencesDBFields.UpdatedDate]) : DateTime.Now); 

                        
                    }
                }

            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(DataTable)", ex.Source, ex.Message, ex);
            }

            return objAnalysedSentences;
        }

    }
}
