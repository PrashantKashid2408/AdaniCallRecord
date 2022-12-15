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
    public class TextAnalysisDataMapper
    {
        private static readonly string _module = "AdaniCall.Business.DataAccess.Mapper.TextAnalysisDataMapper";
        private TextAnalysis objTextAnalysis = null;

        public TextAnalysis GetDetails(SqlDataReader sqlDataReader)
        {
            try
            {
                objTextAnalysis = new TextAnalysis();
               
			    if (sqlDataReader.HasColumn(TextAnalysisDBFields.CallTransactionID))
                   objTextAnalysis.CallTransactionID = (sqlDataReader[TextAnalysisDBFields.CallTransactionID] != DBNull.Value ? Convert.ToInt64(sqlDataReader[TextAnalysisDBFields.CallTransactionID]) : 0);
                if (sqlDataReader.HasColumn(TextAnalysisDBFields.ID))
                    objTextAnalysis.ID = (sqlDataReader[TextAnalysisDBFields.ID] != DBNull.Value ? Convert.ToInt64(sqlDataReader[TextAnalysisDBFields.ID]) : 0);
                if (sqlDataReader.HasColumn(TextAnalysisDBFields.DetectedLanguageName))
                   objTextAnalysis.DetectedLanguageName = (sqlDataReader[TextAnalysisDBFields.DetectedLanguageName] != DBNull.Value ? Convert.ToString(sqlDataReader[TextAnalysisDBFields.DetectedLanguageName]) : string.Empty); 
                if (sqlDataReader.HasColumn(TextAnalysisDBFields.ISO6391Name))
                   objTextAnalysis.ISO6391Name = (sqlDataReader[TextAnalysisDBFields.ISO6391Name] != DBNull.Value ? Convert.ToString(sqlDataReader[TextAnalysisDBFields.ISO6391Name]) : string.Empty); 
                if (sqlDataReader.HasColumn(TextAnalysisDBFields.ConfidenceScore))
                    objTextAnalysis.ConfidenceScore = (sqlDataReader[TextAnalysisDBFields.ConfidenceScore] != DBNull.Value ? Convert.ToDecimal(sqlDataReader[TextAnalysisDBFields.ConfidenceScore]) : 0);
                if (sqlDataReader.HasColumn(TextAnalysisDBFields.KeyPhrases))
                   objTextAnalysis.KeyPhrases = (sqlDataReader[TextAnalysisDBFields.KeyPhrases] != DBNull.Value ? Convert.ToString(sqlDataReader[TextAnalysisDBFields.KeyPhrases]) : string.Empty); 
                if (sqlDataReader.HasColumn(TextAnalysisDBFields.DocumentID))
                   objTextAnalysis.DocumentID = (sqlDataReader[TextAnalysisDBFields.DocumentID] != DBNull.Value ? Convert.ToString(sqlDataReader[TextAnalysisDBFields.DocumentID]) : string.Empty); 
                if (sqlDataReader.HasColumn(TextAnalysisDBFields.Sentiment))
                   objTextAnalysis.Sentiment = (sqlDataReader[TextAnalysisDBFields.Sentiment] != DBNull.Value ? Convert.ToString(sqlDataReader[TextAnalysisDBFields.Sentiment]) : string.Empty); 
                if (sqlDataReader.HasColumn(TextAnalysisDBFields.PositiveScore))
                    objTextAnalysis.PositiveScore = (sqlDataReader[TextAnalysisDBFields.PositiveScore] != DBNull.Value ? Convert.ToDecimal(sqlDataReader[TextAnalysisDBFields.PositiveScore]) : 0);
                if (sqlDataReader.HasColumn(TextAnalysisDBFields.NuetralScore))
                    objTextAnalysis.NuetralScore = (sqlDataReader[TextAnalysisDBFields.NuetralScore] != DBNull.Value ? Convert.ToDecimal(sqlDataReader[TextAnalysisDBFields.NuetralScore]) : 0);
                if (sqlDataReader.HasColumn(TextAnalysisDBFields.NegativeScore))
                    objTextAnalysis.NegativeScore = (sqlDataReader[TextAnalysisDBFields.NegativeScore] != DBNull.Value ? Convert.ToDecimal(sqlDataReader[TextAnalysisDBFields.NegativeScore]) : 0);
                if (sqlDataReader.HasColumn(TextAnalysisDBFields.TextAnalysisJsonPath))
                   objTextAnalysis.TextAnalysisJsonPath = (sqlDataReader[TextAnalysisDBFields.TextAnalysisJsonPath] != DBNull.Value ? Convert.ToString(sqlDataReader[TextAnalysisDBFields.TextAnalysisJsonPath]) : string.Empty); 
                if (sqlDataReader.HasColumn(TextAnalysisDBFields.StatusId))
                   objTextAnalysis.StatusId = (sqlDataReader[TextAnalysisDBFields.StatusId] != DBNull.Value ? Convert.ToByte(sqlDataReader[TextAnalysisDBFields.StatusId]) : (byte)0); 
                if (sqlDataReader.HasColumn(TextAnalysisDBFields.CreatedDate))
                   objTextAnalysis.CreatedDate = (sqlDataReader[TextAnalysisDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(sqlDataReader[TextAnalysisDBFields.CreatedDate]) : DateTime.Now); 
                if (sqlDataReader.HasColumn(TextAnalysisDBFields.UpdatedDate))
                   objTextAnalysis.UpdatedDate = (sqlDataReader[TextAnalysisDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(sqlDataReader[TextAnalysisDBFields.UpdatedDate]) : DateTime.Now); 

            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(sqlDataReader)", ex.Source, ex.Message, ex);
            }
            return objTextAnalysis;
        }
		
		public List<TextAnalysis> GetDetailsList(SqlDataReader sqlDataReader)
        {
            List<TextAnalysis> list = new List<TextAnalysis>();
            try
            {
                while (sqlDataReader.Read())
                {
                    objTextAnalysis = GetDetails(sqlDataReader);
                    list.Add(objTextAnalysis);
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetailsList(sqlDataReader)", ex.Source, ex.Message, ex);
            }
            return list;
        }

        public List<TextAnalysis> GetDetails(DataSet dataSet)
        {
            List<TextAnalysis> TextAnalysiss = new List<TextAnalysis>();

            try
            {
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drow in dataSet.Tables[0].Rows)
                    {
                        objTextAnalysis = new TextAnalysis();
                       
						if (drow.Table.Columns.Contains(TextAnalysisDBFields.ID)) 
  objTextAnalysis.ID = (drow[TextAnalysisDBFields.ID] != DBNull.Value ? Convert.ToInt32(drow[TextAnalysisDBFields.ID]) : 0); 
if (drow.Table.Columns.Contains(TextAnalysisDBFields.DetectedLanguageName)) 
  objTextAnalysis.DetectedLanguageName = (drow[TextAnalysisDBFields.DetectedLanguageName] != DBNull.Value ? Convert.ToString(drow[TextAnalysisDBFields.DetectedLanguageName]) : string.Empty); 
if (drow.Table.Columns.Contains(TextAnalysisDBFields.ISO6391Name)) 
  objTextAnalysis.ISO6391Name = (drow[TextAnalysisDBFields.ISO6391Name] != DBNull.Value ? Convert.ToString(drow[TextAnalysisDBFields.ISO6391Name]) : string.Empty); 
if (drow.Table.Columns.Contains(TextAnalysisDBFields.ConfidenceScore)) 
if (drow.Table.Columns.Contains(TextAnalysisDBFields.KeyPhrases)) 
  objTextAnalysis.KeyPhrases = (drow[TextAnalysisDBFields.KeyPhrases] != DBNull.Value ? Convert.ToString(drow[TextAnalysisDBFields.KeyPhrases]) : string.Empty); 
if (drow.Table.Columns.Contains(TextAnalysisDBFields.DocumentID)) 
  objTextAnalysis.DocumentID = (drow[TextAnalysisDBFields.DocumentID] != DBNull.Value ? Convert.ToString(drow[TextAnalysisDBFields.DocumentID]) : string.Empty); 
if (drow.Table.Columns.Contains(TextAnalysisDBFields.Sentiment)) 
  objTextAnalysis.Sentiment = (drow[TextAnalysisDBFields.Sentiment] != DBNull.Value ? Convert.ToString(drow[TextAnalysisDBFields.Sentiment]) : string.Empty); 
if (drow.Table.Columns.Contains(TextAnalysisDBFields.PositiveScore)) 
if (drow.Table.Columns.Contains(TextAnalysisDBFields.NuetralScore)) 
if (drow.Table.Columns.Contains(TextAnalysisDBFields.NegativeScore)) 
if (drow.Table.Columns.Contains(TextAnalysisDBFields.TextAnalysisJsonPath)) 
  objTextAnalysis.TextAnalysisJsonPath = (drow[TextAnalysisDBFields.TextAnalysisJsonPath] != DBNull.Value ? Convert.ToString(drow[TextAnalysisDBFields.TextAnalysisJsonPath]) : string.Empty); 
if (drow.Table.Columns.Contains(TextAnalysisDBFields.StatusId)) 
  objTextAnalysis.StatusId = (drow[TextAnalysisDBFields.StatusId] != DBNull.Value ? Convert.ToByte(drow[TextAnalysisDBFields.StatusId]) : (byte)0); 
if (drow.Table.Columns.Contains(TextAnalysisDBFields.CreatedDate)) 
  objTextAnalysis.CreatedDate = (drow[TextAnalysisDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(drow[TextAnalysisDBFields.CreatedDate]) : DateTime.Now); 
if (drow.Table.Columns.Contains(TextAnalysisDBFields.UpdatedDate)) 
  objTextAnalysis.UpdatedDate = (drow[TextAnalysisDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(drow[TextAnalysisDBFields.UpdatedDate]) : DateTime.Now); 


                        TextAnalysiss.Add(objTextAnalysis);
                    }
                }

            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(dataSet)", ex.Source, ex.Message, ex);
            }

            return TextAnalysiss;
        }
		
		public TextAnalysis GetDetailsobj(DataSet dataSet)
        {
            TextAnalysis objTextAnalysis = new TextAnalysis();

            try
            {
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drow in dataSet.Tables[0].Rows)
                    {
                        objTextAnalysis = new TextAnalysis();
                      
						if (drow.Table.Columns.Contains(TextAnalysisDBFields.ID)) 
  objTextAnalysis.ID = (drow[TextAnalysisDBFields.ID] != DBNull.Value ? Convert.ToInt32(drow[TextAnalysisDBFields.ID]) : 0); 
if (drow.Table.Columns.Contains(TextAnalysisDBFields.DetectedLanguageName)) 
  objTextAnalysis.DetectedLanguageName = (drow[TextAnalysisDBFields.DetectedLanguageName] != DBNull.Value ? Convert.ToString(drow[TextAnalysisDBFields.DetectedLanguageName]) : string.Empty); 
if (drow.Table.Columns.Contains(TextAnalysisDBFields.ISO6391Name)) 
  objTextAnalysis.ISO6391Name = (drow[TextAnalysisDBFields.ISO6391Name] != DBNull.Value ? Convert.ToString(drow[TextAnalysisDBFields.ISO6391Name]) : string.Empty); 
if (drow.Table.Columns.Contains(TextAnalysisDBFields.ConfidenceScore)) 
if (drow.Table.Columns.Contains(TextAnalysisDBFields.KeyPhrases)) 
  objTextAnalysis.KeyPhrases = (drow[TextAnalysisDBFields.KeyPhrases] != DBNull.Value ? Convert.ToString(drow[TextAnalysisDBFields.KeyPhrases]) : string.Empty); 
if (drow.Table.Columns.Contains(TextAnalysisDBFields.DocumentID)) 
  objTextAnalysis.DocumentID = (drow[TextAnalysisDBFields.DocumentID] != DBNull.Value ? Convert.ToString(drow[TextAnalysisDBFields.DocumentID]) : string.Empty); 
if (drow.Table.Columns.Contains(TextAnalysisDBFields.Sentiment)) 
  objTextAnalysis.Sentiment = (drow[TextAnalysisDBFields.Sentiment] != DBNull.Value ? Convert.ToString(drow[TextAnalysisDBFields.Sentiment]) : string.Empty); 
if (drow.Table.Columns.Contains(TextAnalysisDBFields.PositiveScore)) 
if (drow.Table.Columns.Contains(TextAnalysisDBFields.NuetralScore)) 
if (drow.Table.Columns.Contains(TextAnalysisDBFields.NegativeScore)) 
if (drow.Table.Columns.Contains(TextAnalysisDBFields.TextAnalysisJsonPath)) 
  objTextAnalysis.TextAnalysisJsonPath = (drow[TextAnalysisDBFields.TextAnalysisJsonPath] != DBNull.Value ? Convert.ToString(drow[TextAnalysisDBFields.TextAnalysisJsonPath]) : string.Empty); 
if (drow.Table.Columns.Contains(TextAnalysisDBFields.StatusId)) 
  objTextAnalysis.StatusId = (drow[TextAnalysisDBFields.StatusId] != DBNull.Value ? Convert.ToByte(drow[TextAnalysisDBFields.StatusId]) : (byte)0); 
if (drow.Table.Columns.Contains(TextAnalysisDBFields.CreatedDate)) 
  objTextAnalysis.CreatedDate = (drow[TextAnalysisDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(drow[TextAnalysisDBFields.CreatedDate]) : DateTime.Now); 
if (drow.Table.Columns.Contains(TextAnalysisDBFields.UpdatedDate)) 
  objTextAnalysis.UpdatedDate = (drow[TextAnalysisDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(drow[TextAnalysisDBFields.UpdatedDate]) : DateTime.Now); 

                        
                    }
                }

            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(dataSet)", ex.Source, ex.Message, ex);
            }

            return objTextAnalysis;
        }
		
		public TextAnalysis GetDetails(DataTable dataTable)
        {
            TextAnalysis objTextAnalysis = new TextAnalysis();

            try
            {
                if (dataTable != null &&  dataTable.Rows.Count > 0)
                {
                    foreach (DataRow drow in dataTable.Rows)
                    {
                        objTextAnalysis = new TextAnalysis();
                      
						if (drow.Table.Columns.Contains(TextAnalysisDBFields.ID)) 
  objTextAnalysis.ID = (drow[TextAnalysisDBFields.ID] != DBNull.Value ? Convert.ToInt32(drow[TextAnalysisDBFields.ID]) : 0); 
if (drow.Table.Columns.Contains(TextAnalysisDBFields.DetectedLanguageName)) 
  objTextAnalysis.DetectedLanguageName = (drow[TextAnalysisDBFields.DetectedLanguageName] != DBNull.Value ? Convert.ToString(drow[TextAnalysisDBFields.DetectedLanguageName]) : string.Empty); 
if (drow.Table.Columns.Contains(TextAnalysisDBFields.ISO6391Name)) 
  objTextAnalysis.ISO6391Name = (drow[TextAnalysisDBFields.ISO6391Name] != DBNull.Value ? Convert.ToString(drow[TextAnalysisDBFields.ISO6391Name]) : string.Empty); 
if (drow.Table.Columns.Contains(TextAnalysisDBFields.ConfidenceScore)) 
if (drow.Table.Columns.Contains(TextAnalysisDBFields.KeyPhrases)) 
  objTextAnalysis.KeyPhrases = (drow[TextAnalysisDBFields.KeyPhrases] != DBNull.Value ? Convert.ToString(drow[TextAnalysisDBFields.KeyPhrases]) : string.Empty); 
if (drow.Table.Columns.Contains(TextAnalysisDBFields.DocumentID)) 
  objTextAnalysis.DocumentID = (drow[TextAnalysisDBFields.DocumentID] != DBNull.Value ? Convert.ToString(drow[TextAnalysisDBFields.DocumentID]) : string.Empty); 
if (drow.Table.Columns.Contains(TextAnalysisDBFields.Sentiment)) 
  objTextAnalysis.Sentiment = (drow[TextAnalysisDBFields.Sentiment] != DBNull.Value ? Convert.ToString(drow[TextAnalysisDBFields.Sentiment]) : string.Empty); 
if (drow.Table.Columns.Contains(TextAnalysisDBFields.PositiveScore)) 
if (drow.Table.Columns.Contains(TextAnalysisDBFields.NuetralScore)) 
if (drow.Table.Columns.Contains(TextAnalysisDBFields.NegativeScore)) 
if (drow.Table.Columns.Contains(TextAnalysisDBFields.TextAnalysisJsonPath)) 
  objTextAnalysis.TextAnalysisJsonPath = (drow[TextAnalysisDBFields.TextAnalysisJsonPath] != DBNull.Value ? Convert.ToString(drow[TextAnalysisDBFields.TextAnalysisJsonPath]) : string.Empty); 
if (drow.Table.Columns.Contains(TextAnalysisDBFields.StatusId)) 
  objTextAnalysis.StatusId = (drow[TextAnalysisDBFields.StatusId] != DBNull.Value ? Convert.ToByte(drow[TextAnalysisDBFields.StatusId]) : (byte)0); 
if (drow.Table.Columns.Contains(TextAnalysisDBFields.CreatedDate)) 
  objTextAnalysis.CreatedDate = (drow[TextAnalysisDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(drow[TextAnalysisDBFields.CreatedDate]) : DateTime.Now); 
if (drow.Table.Columns.Contains(TextAnalysisDBFields.UpdatedDate)) 
  objTextAnalysis.UpdatedDate = (drow[TextAnalysisDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(drow[TextAnalysisDBFields.UpdatedDate]) : DateTime.Now); 

                        
                    }
                }

            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(DataTable)", ex.Source, ex.Message, ex);
            }

            return objTextAnalysis;
        }

    }
}
