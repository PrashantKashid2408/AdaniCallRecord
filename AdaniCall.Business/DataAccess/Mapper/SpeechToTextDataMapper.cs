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
    public class SpeechToTextDataMapper
    {
        private static readonly string _module = "AdaniCall.Business.DataAccess.Mapper.SpeechToTextDataMapper";
        private SpeechToText objSpeechToText = null;

        public SpeechToText GetDetails(SqlDataReader sqlDataReader)
        {
            try
            {
                objSpeechToText = new SpeechToText();
               
			    if (sqlDataReader.HasColumn(SpeechToTextDBFields.ID))
                   objSpeechToText.ID = (sqlDataReader[SpeechToTextDBFields.ID] != DBNull.Value ? Convert.ToInt64(sqlDataReader[SpeechToTextDBFields.ID]) : 0); 
                if (sqlDataReader.HasColumn(SpeechToTextDBFields.CallTransactionID))
                   objSpeechToText.CallTransactionID = (sqlDataReader[SpeechToTextDBFields.CallTransactionID] != DBNull.Value ? Convert.ToInt64(sqlDataReader[SpeechToTextDBFields.CallTransactionID]) : 0); 
                if (sqlDataReader.HasColumn(SpeechToTextDBFields.RecognitionStatus))
                   objSpeechToText.RecognitionStatus = (sqlDataReader[SpeechToTextDBFields.RecognitionStatus] != DBNull.Value ? Convert.ToString(sqlDataReader[SpeechToTextDBFields.RecognitionStatus]) : string.Empty); 
                if (sqlDataReader.HasColumn(SpeechToTextDBFields.DisplayText))
                   objSpeechToText.DisplayText = (sqlDataReader[SpeechToTextDBFields.DisplayText] != DBNull.Value ? Convert.ToString(sqlDataReader[SpeechToTextDBFields.DisplayText]) : string.Empty); 
                if (sqlDataReader.HasColumn(SpeechToTextDBFields.Offset))
                   objSpeechToText.Offset = (sqlDataReader[SpeechToTextDBFields.Offset] != DBNull.Value ? Convert.ToInt32(sqlDataReader[SpeechToTextDBFields.Offset]) : 0); 
                if (sqlDataReader.HasColumn(SpeechToTextDBFields.Duration))
                   objSpeechToText.Duration = (sqlDataReader[SpeechToTextDBFields.Duration] != DBNull.Value ? Convert.ToString(sqlDataReader[SpeechToTextDBFields.Duration]) : string.Empty); 
                if (sqlDataReader.HasColumn(SpeechToTextDBFields.ResultReason))
                   objSpeechToText.ResultReason = (sqlDataReader[SpeechToTextDBFields.ResultReason] != DBNull.Value ? Convert.ToString(sqlDataReader[SpeechToTextDBFields.ResultReason]) : string.Empty); 
                if (sqlDataReader.HasColumn(SpeechToTextDBFields.ErrorCode))
                   objSpeechToText.ErrorCode = (sqlDataReader[SpeechToTextDBFields.ErrorCode] != DBNull.Value ? Convert.ToString(sqlDataReader[SpeechToTextDBFields.ErrorCode]) : string.Empty); 
                if (sqlDataReader.HasColumn(SpeechToTextDBFields.ErrorDetails))
                   objSpeechToText.ErrorDetails = (sqlDataReader[SpeechToTextDBFields.ErrorDetails] != DBNull.Value ? Convert.ToString(sqlDataReader[SpeechToTextDBFields.ErrorDetails]) : string.Empty); 
                if (sqlDataReader.HasColumn(SpeechToTextDBFields.LanguageId))
                   objSpeechToText.LanguageId = (sqlDataReader[SpeechToTextDBFields.LanguageId] != DBNull.Value ? Convert.ToInt32(sqlDataReader[SpeechToTextDBFields.LanguageId]) : 0);
                if (sqlDataReader.HasColumn(SpeechToTextDBFields.Language))
                    objSpeechToText.Language = (sqlDataReader[SpeechToTextDBFields.Language] != DBNull.Value ? Convert.ToString(sqlDataReader[SpeechToTextDBFields.Language]) : "");
                if (sqlDataReader.HasColumn(SpeechToTextDBFields.SpeechTextJsonPath))
                   objSpeechToText.SpeechTextJsonPath = (sqlDataReader[SpeechToTextDBFields.SpeechTextJsonPath] != DBNull.Value ? Convert.ToString(sqlDataReader[SpeechToTextDBFields.SpeechTextJsonPath]) : string.Empty); 
                if (sqlDataReader.HasColumn(SpeechToTextDBFields.StatusId))
                   objSpeechToText.StatusId = (sqlDataReader[SpeechToTextDBFields.StatusId] != DBNull.Value ? Convert.ToByte(sqlDataReader[SpeechToTextDBFields.StatusId]) : (byte)0); 
                if (sqlDataReader.HasColumn(SpeechToTextDBFields.CreatedDate))
                   objSpeechToText.CreatedDate = (sqlDataReader[SpeechToTextDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(sqlDataReader[SpeechToTextDBFields.CreatedDate]) : DateTime.Now); 
                if (sqlDataReader.HasColumn(SpeechToTextDBFields.UpdatedDate))
                   objSpeechToText.UpdatedDate = (sqlDataReader[SpeechToTextDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(sqlDataReader[SpeechToTextDBFields.UpdatedDate]) : DateTime.Now); 

            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(sqlDataReader)", ex.Source, ex.Message, ex);
            }
            return objSpeechToText;
        }
		
		public List<SpeechToText> GetDetailsList(SqlDataReader sqlDataReader)
        {
            List<SpeechToText> list = new List<SpeechToText>();
            try
            {
                while (sqlDataReader.Read())
                {
                    objSpeechToText = GetDetails(sqlDataReader);
                    list.Add(objSpeechToText);
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetailsList(sqlDataReader)", ex.Source, ex.Message, ex);
            }
            return list;
        }

        public List<SpeechToText> GetDetails(DataSet dataSet)
        {
            List<SpeechToText> SpeechToTexts = new List<SpeechToText>();

            try
            {
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drow in dataSet.Tables[0].Rows)
                    {
                        objSpeechToText = new SpeechToText();
                       
						if (drow.Table.Columns.Contains(SpeechToTextDBFields.ID)) 
  objSpeechToText.ID = (drow[SpeechToTextDBFields.ID] != DBNull.Value ? Convert.ToInt32(drow[SpeechToTextDBFields.ID]) : 0); 
if (drow.Table.Columns.Contains(SpeechToTextDBFields.CallTransactionID)) 
  objSpeechToText.CallTransactionID = (drow[SpeechToTextDBFields.CallTransactionID] != DBNull.Value ? Convert.ToInt32(drow[SpeechToTextDBFields.CallTransactionID]) : 0); 
if (drow.Table.Columns.Contains(SpeechToTextDBFields.RecognitionStatus)) 
  objSpeechToText.RecognitionStatus = (drow[SpeechToTextDBFields.RecognitionStatus] != DBNull.Value ? Convert.ToString(drow[SpeechToTextDBFields.RecognitionStatus]) : string.Empty); 
if (drow.Table.Columns.Contains(SpeechToTextDBFields.DisplayText)) 
  objSpeechToText.DisplayText = (drow[SpeechToTextDBFields.DisplayText] != DBNull.Value ? Convert.ToString(drow[SpeechToTextDBFields.DisplayText]) : string.Empty); 
if (drow.Table.Columns.Contains(SpeechToTextDBFields.Offset)) 
  objSpeechToText.Offset = (drow[SpeechToTextDBFields.Offset] != DBNull.Value ? Convert.ToInt32(drow[SpeechToTextDBFields.Offset]) : 0); 
if (drow.Table.Columns.Contains(SpeechToTextDBFields.Duration)) 
  objSpeechToText.Duration = (drow[SpeechToTextDBFields.Duration] != DBNull.Value ? Convert.ToString(drow[SpeechToTextDBFields.Duration]) : string.Empty); 
if (drow.Table.Columns.Contains(SpeechToTextDBFields.ResultReason)) 
  objSpeechToText.ResultReason = (drow[SpeechToTextDBFields.ResultReason] != DBNull.Value ? Convert.ToString(drow[SpeechToTextDBFields.ResultReason]) : string.Empty); 
if (drow.Table.Columns.Contains(SpeechToTextDBFields.ErrorCode)) 
  objSpeechToText.ErrorCode = (drow[SpeechToTextDBFields.ErrorCode] != DBNull.Value ? Convert.ToString(drow[SpeechToTextDBFields.ErrorCode]) : string.Empty); 
if (drow.Table.Columns.Contains(SpeechToTextDBFields.ErrorDetails)) 
  objSpeechToText.ErrorDetails = (drow[SpeechToTextDBFields.ErrorDetails] != DBNull.Value ? Convert.ToString(drow[SpeechToTextDBFields.ErrorDetails]) : string.Empty); 
if (drow.Table.Columns.Contains(SpeechToTextDBFields.LanguageId)) 
  objSpeechToText.LanguageId = (drow[SpeechToTextDBFields.LanguageId] != DBNull.Value ? Convert.ToInt32(drow[SpeechToTextDBFields.LanguageId]) : 0); 
if (drow.Table.Columns.Contains(SpeechToTextDBFields.SpeechTextJsonPath)) 
  objSpeechToText.SpeechTextJsonPath = (drow[SpeechToTextDBFields.SpeechTextJsonPath] != DBNull.Value ? Convert.ToString(drow[SpeechToTextDBFields.SpeechTextJsonPath]) : string.Empty); 
if (drow.Table.Columns.Contains(SpeechToTextDBFields.StatusId)) 
  objSpeechToText.StatusId = (drow[SpeechToTextDBFields.StatusId] != DBNull.Value ? Convert.ToByte(drow[SpeechToTextDBFields.StatusId]) : (byte)0); 
if (drow.Table.Columns.Contains(SpeechToTextDBFields.CreatedDate)) 
  objSpeechToText.CreatedDate = (drow[SpeechToTextDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(drow[SpeechToTextDBFields.CreatedDate]) : DateTime.Now); 
if (drow.Table.Columns.Contains(SpeechToTextDBFields.UpdatedDate)) 
  objSpeechToText.UpdatedDate = (drow[SpeechToTextDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(drow[SpeechToTextDBFields.UpdatedDate]) : DateTime.Now); 


                        SpeechToTexts.Add(objSpeechToText);
                    }
                }

            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(dataSet)", ex.Source, ex.Message, ex);
            }

            return SpeechToTexts;
        }
		
		public SpeechToText GetDetailsobj(DataSet dataSet)
        {
            SpeechToText objSpeechToText = new SpeechToText();

            try
            {
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drow in dataSet.Tables[0].Rows)
                    {
                        objSpeechToText = new SpeechToText();
                      
						if (drow.Table.Columns.Contains(SpeechToTextDBFields.ID)) 
  objSpeechToText.ID = (drow[SpeechToTextDBFields.ID] != DBNull.Value ? Convert.ToInt32(drow[SpeechToTextDBFields.ID]) : 0); 
if (drow.Table.Columns.Contains(SpeechToTextDBFields.CallTransactionID)) 
  objSpeechToText.CallTransactionID = (drow[SpeechToTextDBFields.CallTransactionID] != DBNull.Value ? Convert.ToInt32(drow[SpeechToTextDBFields.CallTransactionID]) : 0); 
if (drow.Table.Columns.Contains(SpeechToTextDBFields.RecognitionStatus)) 
  objSpeechToText.RecognitionStatus = (drow[SpeechToTextDBFields.RecognitionStatus] != DBNull.Value ? Convert.ToString(drow[SpeechToTextDBFields.RecognitionStatus]) : string.Empty); 
if (drow.Table.Columns.Contains(SpeechToTextDBFields.DisplayText)) 
  objSpeechToText.DisplayText = (drow[SpeechToTextDBFields.DisplayText] != DBNull.Value ? Convert.ToString(drow[SpeechToTextDBFields.DisplayText]) : string.Empty); 
if (drow.Table.Columns.Contains(SpeechToTextDBFields.Offset)) 
  objSpeechToText.Offset = (drow[SpeechToTextDBFields.Offset] != DBNull.Value ? Convert.ToInt32(drow[SpeechToTextDBFields.Offset]) : 0); 
if (drow.Table.Columns.Contains(SpeechToTextDBFields.Duration)) 
  objSpeechToText.Duration = (drow[SpeechToTextDBFields.Duration] != DBNull.Value ? Convert.ToString(drow[SpeechToTextDBFields.Duration]) : string.Empty); 
if (drow.Table.Columns.Contains(SpeechToTextDBFields.ResultReason)) 
  objSpeechToText.ResultReason = (drow[SpeechToTextDBFields.ResultReason] != DBNull.Value ? Convert.ToString(drow[SpeechToTextDBFields.ResultReason]) : string.Empty); 
if (drow.Table.Columns.Contains(SpeechToTextDBFields.ErrorCode)) 
  objSpeechToText.ErrorCode = (drow[SpeechToTextDBFields.ErrorCode] != DBNull.Value ? Convert.ToString(drow[SpeechToTextDBFields.ErrorCode]) : string.Empty); 
if (drow.Table.Columns.Contains(SpeechToTextDBFields.ErrorDetails)) 
  objSpeechToText.ErrorDetails = (drow[SpeechToTextDBFields.ErrorDetails] != DBNull.Value ? Convert.ToString(drow[SpeechToTextDBFields.ErrorDetails]) : string.Empty); 
if (drow.Table.Columns.Contains(SpeechToTextDBFields.LanguageId)) 
  objSpeechToText.LanguageId = (drow[SpeechToTextDBFields.LanguageId] != DBNull.Value ? Convert.ToInt32(drow[SpeechToTextDBFields.LanguageId]) : 0); 
if (drow.Table.Columns.Contains(SpeechToTextDBFields.SpeechTextJsonPath)) 
  objSpeechToText.SpeechTextJsonPath = (drow[SpeechToTextDBFields.SpeechTextJsonPath] != DBNull.Value ? Convert.ToString(drow[SpeechToTextDBFields.SpeechTextJsonPath]) : string.Empty); 
if (drow.Table.Columns.Contains(SpeechToTextDBFields.StatusId)) 
  objSpeechToText.StatusId = (drow[SpeechToTextDBFields.StatusId] != DBNull.Value ? Convert.ToByte(drow[SpeechToTextDBFields.StatusId]) : (byte)0); 
if (drow.Table.Columns.Contains(SpeechToTextDBFields.CreatedDate)) 
  objSpeechToText.CreatedDate = (drow[SpeechToTextDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(drow[SpeechToTextDBFields.CreatedDate]) : DateTime.Now); 
if (drow.Table.Columns.Contains(SpeechToTextDBFields.UpdatedDate)) 
  objSpeechToText.UpdatedDate = (drow[SpeechToTextDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(drow[SpeechToTextDBFields.UpdatedDate]) : DateTime.Now); 

                        
                    }
                }

            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(dataSet)", ex.Source, ex.Message, ex);
            }

            return objSpeechToText;
        }
		
		public SpeechToText GetDetails(DataTable dataTable)
        {
            SpeechToText objSpeechToText = new SpeechToText();

            try
            {
                if (dataTable != null &&  dataTable.Rows.Count > 0)
                {
                    foreach (DataRow drow in dataTable.Rows)
                    {
                        objSpeechToText = new SpeechToText();
                      
						if (drow.Table.Columns.Contains(SpeechToTextDBFields.ID)) 
  objSpeechToText.ID = (drow[SpeechToTextDBFields.ID] != DBNull.Value ? Convert.ToInt32(drow[SpeechToTextDBFields.ID]) : 0); 
if (drow.Table.Columns.Contains(SpeechToTextDBFields.CallTransactionID)) 
  objSpeechToText.CallTransactionID = (drow[SpeechToTextDBFields.CallTransactionID] != DBNull.Value ? Convert.ToInt32(drow[SpeechToTextDBFields.CallTransactionID]) : 0); 
if (drow.Table.Columns.Contains(SpeechToTextDBFields.RecognitionStatus)) 
  objSpeechToText.RecognitionStatus = (drow[SpeechToTextDBFields.RecognitionStatus] != DBNull.Value ? Convert.ToString(drow[SpeechToTextDBFields.RecognitionStatus]) : string.Empty); 
if (drow.Table.Columns.Contains(SpeechToTextDBFields.DisplayText)) 
  objSpeechToText.DisplayText = (drow[SpeechToTextDBFields.DisplayText] != DBNull.Value ? Convert.ToString(drow[SpeechToTextDBFields.DisplayText]) : string.Empty); 
if (drow.Table.Columns.Contains(SpeechToTextDBFields.Offset)) 
  objSpeechToText.Offset = (drow[SpeechToTextDBFields.Offset] != DBNull.Value ? Convert.ToInt32(drow[SpeechToTextDBFields.Offset]) : 0); 
if (drow.Table.Columns.Contains(SpeechToTextDBFields.Duration)) 
  objSpeechToText.Duration = (drow[SpeechToTextDBFields.Duration] != DBNull.Value ? Convert.ToString(drow[SpeechToTextDBFields.Duration]) : string.Empty); 
if (drow.Table.Columns.Contains(SpeechToTextDBFields.ResultReason)) 
  objSpeechToText.ResultReason = (drow[SpeechToTextDBFields.ResultReason] != DBNull.Value ? Convert.ToString(drow[SpeechToTextDBFields.ResultReason]) : string.Empty); 
if (drow.Table.Columns.Contains(SpeechToTextDBFields.ErrorCode)) 
  objSpeechToText.ErrorCode = (drow[SpeechToTextDBFields.ErrorCode] != DBNull.Value ? Convert.ToString(drow[SpeechToTextDBFields.ErrorCode]) : string.Empty); 
if (drow.Table.Columns.Contains(SpeechToTextDBFields.ErrorDetails)) 
  objSpeechToText.ErrorDetails = (drow[SpeechToTextDBFields.ErrorDetails] != DBNull.Value ? Convert.ToString(drow[SpeechToTextDBFields.ErrorDetails]) : string.Empty); 
if (drow.Table.Columns.Contains(SpeechToTextDBFields.LanguageId)) 
  objSpeechToText.LanguageId = (drow[SpeechToTextDBFields.LanguageId] != DBNull.Value ? Convert.ToInt32(drow[SpeechToTextDBFields.LanguageId]) : 0); 
if (drow.Table.Columns.Contains(SpeechToTextDBFields.SpeechTextJsonPath)) 
  objSpeechToText.SpeechTextJsonPath = (drow[SpeechToTextDBFields.SpeechTextJsonPath] != DBNull.Value ? Convert.ToString(drow[SpeechToTextDBFields.SpeechTextJsonPath]) : string.Empty); 
if (drow.Table.Columns.Contains(SpeechToTextDBFields.StatusId)) 
  objSpeechToText.StatusId = (drow[SpeechToTextDBFields.StatusId] != DBNull.Value ? Convert.ToByte(drow[SpeechToTextDBFields.StatusId]) : (byte)0); 
if (drow.Table.Columns.Contains(SpeechToTextDBFields.CreatedDate)) 
  objSpeechToText.CreatedDate = (drow[SpeechToTextDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(drow[SpeechToTextDBFields.CreatedDate]) : DateTime.Now); 
if (drow.Table.Columns.Contains(SpeechToTextDBFields.UpdatedDate)) 
  objSpeechToText.UpdatedDate = (drow[SpeechToTextDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(drow[SpeechToTextDBFields.UpdatedDate]) : DateTime.Now); 

                        
                    }
                }

            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(DataTable)", ex.Source, ex.Message, ex);
            }

            return objSpeechToText;
        }

    }
}
