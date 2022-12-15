using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdaniCall.Business.DataAccess.Constants;
using AdaniCall.Business.DataAccess.DataAccessLayer;
using AdaniCall.Business.DataAccess.DataAccessLayer.General;
using AdaniCall.Business.DataAccess.Mapper;
using AdaniCall.Entity;
using AdaniCall.Entity.Common;
using AdaniCall.Utility.Common;


namespace AdaniCall.Business.DataAccess.Wrapper
{
    public class CallTransactionsWrapper : UniversalObject
    {
		private readonly string _module = "AdaniCall.Business.DataAccess.Wrapper.CallTransactions"; 
        private SqlConnection Connection;

        #region UniversalObject Interface Members
        public bool ObjectChanged { get; set; }


        public CallTransactions objWrapperClass = new CallTransactions();
        private CallTransactionsDataMapper objCallTransactionsDataMapper = new CallTransactionsDataMapper();
        #region GetRecords methods
        public bool GetRecordById(int id)
        {
            SqlDataReader sqlDataReader = null;
            try
            {
                if (this.Connection == null)
                    this.Connection = dbClass.GetSqlConnection();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = CallTransactionsStoredProcedures.CallTransactionsGetRecordById;
                sqlCommand.CommandType = CommandType.StoredProcedure;
				sqlCommand.CommandTimeout = 0;
                sqlCommand.Connection = this.Connection;
                sqlCommand.Parameters.AddWithValue(CallTransactionsDBFields.ID, id);
                sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    objWrapperClass = objCallTransactionsDataMapper.GetDetails(sqlDataReader);
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetRecordById(" + id + ")", ex.Source, ex.Message, ex);
                return false;
            }
            finally
            {
                if (sqlDataReader != null)
                    sqlDataReader.Close();
                dbClass.CloseSqlConnection(ref this.Connection);
            }
        }
        public bool GetRecordByValue(string fieldName, string value)
        {
            SqlDataReader sqlDataReader = null;
            try
            {
                if (this.Connection == null)
                    this.Connection = dbClass.GetSqlConnection();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = CallTransactionsStoredProcedures.GetCallTransactionsRecordByValue;
                sqlCommand.CommandType = CommandType.StoredProcedure;
				sqlCommand.CommandTimeout = 0;
                sqlCommand.Connection = this.Connection;
                sqlCommand.Parameters.AddWithValue(fieldName, value);
                sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    objWrapperClass = objCallTransactionsDataMapper.GetDetails(sqlDataReader);
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetRecordByValue(" + fieldName + "," + value + ")", ex.Source, ex.Message, ex);
                return false;
            }
            finally
            {
                if (sqlDataReader != null)
                    sqlDataReader.Close();
                dbClass.CloseSqlConnection(ref this.Connection);
            }
        }
        public bool GetRecordByValue(string[] fieldNames, string[] values)
        {
            SqlDataReader sqlDataReader = null;
            try
            {
                if (this.Connection == null)
                    this.Connection = dbClass.GetSqlConnection();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = CallTransactionsStoredProcedures.GetCallTransactionsRecordByValueArray;
                sqlCommand.CommandType = CommandType.StoredProcedure;
				sqlCommand.CommandTimeout = 0;
                sqlCommand.Connection = this.Connection;
                for (int i = 0; i < fieldNames.Length; i++)
                {
                    sqlCommand.Parameters.AddWithValue(fieldNames[i], values[i]);
                }

                sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    objWrapperClass = objCallTransactionsDataMapper.GetDetails(sqlDataReader);
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetRecordByValue(" + string.Join(",", fieldNames) + "," + string.Join(",", values) + ")", ex.Source, ex.Message, ex);
                return false;
            }
            finally
            {
                if (sqlDataReader != null)
                    sqlDataReader.Close();
                dbClass.CloseSqlConnection(ref this.Connection);
            }
        }
        #endregion
        public bool Save(ref Dictionary<string, Command> commandList, ref int commandCounter)
        {
            try
            {
                if (objWrapperClass.ID > 0)
                {
                    Update(ref commandList, ref commandCounter);
                }
                else
                {
                    Command command = new Command(CallTransactionsStoredProcedures.CallTransactionsSAVE, CommandType.StoredProcedure);
                    command.AddParameter(CallTransactionsDBFields.IU_Flag, "I", DataAccessLayer.DataAccess.DataType.Char, 0, ParameterDirection.Input);
                    command.AddParameter(CallTransactionsDBFields.UniqueCallID, objWrapperClass.UniqueCallID, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                    command.AddParameter(CallTransactionsDBFields.TravellerCallID, objWrapperClass.TravellerCallID, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                    command.AddParameter(CallTransactionsDBFields.KioskID, objWrapperClass.KioskID, DataAccessLayer.DataAccess.DataType.Number, 0, ParameterDirection.Input);
                    command.AddParameter(CallTransactionsDBFields.AgentCallID, objWrapperClass.AgentCallID, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                    command.AddParameter(CallTransactionsDBFields.AgentUserID, objWrapperClass.AgentUserID, DataAccessLayer.DataAccess.DataType.Number, 0, ParameterDirection.Input);
                    command.AddParameter(CallTransactionsDBFields.CallStartTime, objWrapperClass.CallStartTime, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                    command.AddParameter(CallTransactionsDBFields.KioskLocationID, objWrapperClass.KioskLocationID, DataAccessLayer.DataAccess.DataType.Number, 0, ParameterDirection.Input);
                    command.AddParameter(CallTransactionsDBFields.AgentLocationID, objWrapperClass.AgentLocationID, DataAccessLayer.DataAccess.DataType.Number, 0, ParameterDirection.Input);

                    command.AddParameter("RetID", 0, DataAccessLayer.DataAccess.DataType.Number, 0, ParameterDirection.Output);

                    command.Name = CallTransactionsStoredProcedures.CallTransactionsSAVE + commandCounter.ToString();
                    commandCounter++;
                    commandList.Add(command.Name, command);
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "Save", ex.Source, ex.Message, ex);
                return false;
            }
            finally
            {
            }
        }
        public bool Update(ref Dictionary<string, Command> commandList, ref int commandCounter)
        {
            try
            {

                Command command = new Command(CallTransactionsStoredProcedures.CallTransactionsSAVE, CommandType.StoredProcedure);


                command.AddParameter(CallTransactionsDBFields.IU_Flag, "U", DataAccessLayer.DataAccess.DataType.Char, 0, ParameterDirection.Input);
                command.AddParameter(CallTransactionsDBFields.ID, objWrapperClass.ID, DataAccessLayer.DataAccess.DataType.Number, 0, ParameterDirection.Input);
command.AddParameter(CallTransactionsDBFields.TravellerCallID, objWrapperClass.TravellerCallID, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
command.AddParameter(CallTransactionsDBFields.KioskID, objWrapperClass.KioskID, DataAccessLayer.DataAccess.DataType.Number, 0, ParameterDirection.Input);
command.AddParameter(CallTransactionsDBFields.AgentCallID, objWrapperClass.AgentCallID, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
command.AddParameter(CallTransactionsDBFields.AgentUserID, objWrapperClass.AgentUserID, DataAccessLayer.DataAccess.DataType.Number, 0, ParameterDirection.Input);
command.AddParameter(CallTransactionsDBFields.CallStartTime, objWrapperClass.CallStartTime, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
command.AddParameter(CallTransactionsDBFields.CallEndTime, objWrapperClass.CallEndTime, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
command.AddParameter(CallTransactionsDBFields.VideoFileName, objWrapperClass.VideoFileName, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
command.AddParameter(CallTransactionsDBFields.AudioFileName, objWrapperClass.AudioFileName, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
command.AddParameter(CallTransactionsDBFields.KioskLocationID, objWrapperClass.KioskLocationID, DataAccessLayer.DataAccess.DataType.Number, 0, ParameterDirection.Input);
command.AddParameter(CallTransactionsDBFields.AgentLocationID, objWrapperClass.AgentLocationID, DataAccessLayer.DataAccess.DataType.Number, 0, ParameterDirection.Input);
command.AddParameter(CallTransactionsDBFields.SpeechToTextID, objWrapperClass.SpeechToTextID, DataAccessLayer.DataAccess.DataType.Number, 0, ParameterDirection.Input);
command.AddParameter(CallTransactionsDBFields.SpeechToTextStatus, objWrapperClass.SpeechToTextStatus, DataAccessLayer.DataAccess.DataType.Varchar2, 0, ParameterDirection.Input);
command.AddParameter(CallTransactionsDBFields.TextAnalysisID, objWrapperClass.TextAnalysisID, DataAccessLayer.DataAccess.DataType.Number, 0, ParameterDirection.Input);
command.AddParameter(CallTransactionsDBFields.TextAnalysisStatus, objWrapperClass.TextAnalysisStatus, DataAccessLayer.DataAccess.DataType.Varchar2, 0, ParameterDirection.Input);
command.AddParameter(CallTransactionsDBFields.SpeechAnalysisID, objWrapperClass.SpeechAnalysisID, DataAccessLayer.DataAccess.DataType.Number, 0, ParameterDirection.Input);
command.AddParameter(CallTransactionsDBFields.SpeechAnalysisStatus, objWrapperClass.SpeechAnalysisStatus, DataAccessLayer.DataAccess.DataType.Varchar2, 0, ParameterDirection.Input);
command.AddParameter(CallTransactionsDBFields.LanguageId, objWrapperClass.LanguageId, DataAccessLayer.DataAccess.DataType.Number, 0, ParameterDirection.Input);
command.AddParameter(CallTransactionsDBFields.StatusId, objWrapperClass.StatusId, DataAccessLayer.DataAccess.DataType.Varchar2, 0, ParameterDirection.Input);
command.AddParameter(CallTransactionsDBFields.CreatedDate, objWrapperClass.CreatedDate, DataAccessLayer.DataAccess.DataType.DateTime, 0, ParameterDirection.Input);
command.AddParameter(CallTransactionsDBFields.UpdatedDate, objWrapperClass.UpdatedDate, DataAccessLayer.DataAccess.DataType.DateTime, 0, ParameterDirection.Input);

    
                command.Name = CallTransactionsStoredProcedures.CallTransactionsSAVE + commandCounter.ToString();
                commandCounter++;
                commandList.Add(command.Name, command);

                return true;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "Update", ex.Source, ex.Message, ex);
                return false;
            }
            finally
            {


            }
        }
        public bool Delete(ref Dictionary<string, Command> commandList, ref int commandCounter)
        {
            try
            {

                Command command = new Command("SP_MASTERS_Delete", CommandType.StoredProcedure);
                command.AddParameter("@TableName", "CallTransactions", DataAccessLayer.DataAccess.DataType.Varchar, 0, ParameterDirection.Input);
                command.AddParameter("@PrimaryKeyColumn", "ID", DataAccessLayer.DataAccess.DataType.Number, 0, ParameterDirection.Input);
                command.AddParameter("@IDs", objWrapperClass.ID, DataAccessLayer.DataAccess.DataType.Number, 0, ParameterDirection.Input);
                command.Name = "DeleteCallTransactions" + commandCounter.ToString();
                commandCounter++;
                commandList.Add(command.Name, command);

                return true;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "Delete", ex.Source, ex.Message, ex);
                return false;
            }
            finally
            {
            }
        }

        public bool SaveCopy()
        {
            throw new NotImplementedException();
        }

        public bool Move()
        {
            throw new NotImplementedException();
        }

        public bool Print()
        {
            throw new NotImplementedException();
        }
        #endregion UniversalObject Interface Members

        #region Other Methods
        public bool UpdateCallTransactions(string strColumns, string strCondition)
        {
            bool returnValue = false;
            try
            {
                if (!string.IsNullOrEmpty(strColumns))
                {
                    if (this.Connection == null)
                        this.Connection = dbClass.GetSqlConnection();

                    SqlCommand sqlCommand = new SqlCommand(CallTransactionsStoredProcedures.CallTransactions_Update, this.Connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue(CallTransactionsDBFields.Columns, strColumns);
                    sqlCommand.Parameters.AddWithValue(CallTransactionsDBFields.Condition, strCondition);
                    sqlCommand.ExecuteNonQuery();
                    returnValue = true;
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "UpdateCallTransactions(strColumns=" + strColumns + ", strCondition=" + strCondition + ")", ex.Source, ex.Message, ex);
            }
            return returnValue;
        }

        
        #endregion Other Methods

    }

    public class CallTransactionsWrapperColletion : UniversalCollection
    {
		private readonly string _module = "CallTransactions"; 
        private SqlConnection Connection;
        private List<CallTransactions> _Items = new List<CallTransactions>();
        public List<CallTransactions> Items
        { get { return this._Items; } set { this._Items = value; } }

        private DataSet _DtsDataset = null;
        private string _SortingString = "";

        #region UniversalCollection Interface Members Implementation

        #region GetRecords methods
        public bool GetRecords(bool createDataSet, string[,] sortFields)
        {
            if (createDataSet)
                return GetDataSetForQuery(CallTransactionsStoredProcedures.GetCallTransactionsRecords);
            else
                return GetCollectionForQuery(CallTransactionsStoredProcedures.GetCallTransactionsRecords);
        }
        public bool GetRecords(bool createDataSet, string[,] sortFields, bool isParameter)
        {
            if (sortFields != null)
            {
                if (sortFields.Length > 0)
                {
                    _SortingString += "order by ";
                    for (int i = 0; i <= sortFields.GetUpperBound(0); i++)
                    {
                        _SortingString += "" + sortFields[i, 0] + " " + sortFields[i, 1] + ",";
                    }
                    _SortingString = _SortingString.Substring(0, _SortingString.Length - 1);
                }
            }

            SqlParameterCollection sqlParameterCollection = null;
            SqlParameter ObjSqlParameter = new SqlParameter();
            ObjSqlParameter.ParameterName = CallTransactionsStoredProcedures.SortingString;
            ObjSqlParameter.Value = _SortingString;
            sqlParameterCollection.Add(ObjSqlParameter);

            if (createDataSet)
                return GetDataSetForQueryParameter(CallTransactionsStoredProcedures.GetCallTransactionsRecords, sqlParameterCollection);
            else
                return GetDataSetForQueryParameter(CallTransactionsStoredProcedures.GetCallTransactionsRecords, sqlParameterCollection);
        }
        public bool GetRecords(bool createDataSet, string[,] sortFields, bool isParameter, string fieldName, string fieldValue)
        {
            if (sortFields != null)
            {
                if (sortFields.Length > 0)
                {
                    _SortingString += "order by ";
                    for (int i = 0; i <= sortFields.GetUpperBound(0); i++)
                    {
                        _SortingString += "" + sortFields[i, 0] + " " + sortFields[i, 1] + ",";
                    }
                    _SortingString = _SortingString.Substring(0, _SortingString.Length - 1);
                }
            }

            string[] Fieldsname = new string[1];
            string[] Values = new string[1];
            Fieldsname[0] = fieldName;
            Values[0] = fieldValue;

            return GetCollectionForQueryWithParameters(CallTransactionsStoredProcedures.GetCallTransactionsRecordByValue, Fieldsname, Values);
        }
		
	private bool GetCollectionForQueryWithParameters(string sqlQuery, string[] fieldNames, string[] values)
        {
            SqlDataReader _Dtr = null;
            try
            {
                if (this.Connection == null)
                    this.Connection = dbClass.GetSqlConnection();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = sqlQuery;
                sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.CommandTimeout = 0;
                sqlCommand.Connection = this.Connection;

                if (fieldNames != null)
                {
                    if (fieldNames.Length > 0)
                    {
                        for (int i = 0; i < fieldNames.Length; i++)
                        {
                            SqlParameter sqlParameter = new SqlParameter();
                            sqlParameter.ParameterName = fieldNames[i];
                            sqlParameter.Value = values[i];
                            sqlCommand.Parameters.Add(sqlParameter);
                        }
                    }
                }

                _Dtr = sqlCommand.ExecuteReader();
                while (_Dtr.Read())
                {
                    CallTransactionsDataMapper objDataMapper = new CallTransactionsDataMapper();
                    this.Items.Add(objDataMapper.GetDetails(_Dtr));
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetCollectionForQueryWithParameters(" + sqlQuery + ")", ex.Source, ex.Message, ex);
                return false;
            }
            finally
            {
                if (_Dtr != null)
                    _Dtr.Close();
                dbClass.CloseSqlConnection(ref this.Connection);
            }
        }
		
        public bool GetRecords(bool createDataSet, string[,] sortFields, bool isParameter, string[] fieldName, string[] fieldValue)
        {
            SqlParameterCollection sqlParameterCollection = null;
            if (fieldName != null)
            {
                if (fieldName.Length > 0)
                {
                    for (int i = 0; i < fieldName.Length; i++)
                    {
                        SqlParameter sqlParameter = new SqlParameter();
                        sqlParameter.ParameterName = fieldName[i];
                        sqlParameter.Value = fieldValue[i];
                        sqlParameterCollection.Add(sqlParameter);
                    }
                }
            }
            if (sortFields != null)
            {
                if (sortFields.Length > 0)
                {
                    _SortingString += "order by ";
                    for (int i = 0; i <= sortFields.GetUpperBound(0); i++)
                    {
                        _SortingString += "" + sortFields[i, 0] + " " + sortFields[i, 1] + ",";
                    }
                    _SortingString = _SortingString.Substring(0, _SortingString.Length - 1);
                }

                SqlParameter ObjSqlParameter = new SqlParameter();
                ObjSqlParameter.ParameterName = CallTransactionsStoredProcedures.SortingString;
                ObjSqlParameter.Value = _SortingString;
                sqlParameterCollection.Add(ObjSqlParameter);
            }



            if (createDataSet)
                return GetDataSetForQueryParameter(CallTransactionsStoredProcedures.GetCallTransactionsRecords, sqlParameterCollection);
            else
                return GetDataSetForQueryParameter(CallTransactionsStoredProcedures.GetCallTransactionsRecords, sqlParameterCollection);
        }
        #endregion

        #region Seach Method
        public bool Search(string searchString, string[,] sortString)
        {
            throw new NotImplementedException();
        }
        public bool Search(string fieldName, string fieldValue, string[,] sortString)
        {
            try
            {
                SqlParameterCollection sqlParameterCollection = null;
                SqlParameter ObjSqlParameter = new SqlParameter();
                ObjSqlParameter.ParameterName = fieldName;
                ObjSqlParameter.Value = fieldValue;
                sqlParameterCollection.Add(ObjSqlParameter);

                GetCollectionForQueryWithParameter(CallTransactionsStoredProcedures.CallTransactionsSearch, sqlParameterCollection);
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "Search(" + fieldName + "," + fieldValue + ")", ex.Source, ex.Message, ex);
                return false;
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }
        }
        public bool Search(string searchString, bool createDataSet, string[,] sortFields)
        {
            throw new NotImplementedException();
        }
        public bool Search(string fieldName, string fieldValue, bool createDataSet, string[,] sortFields)
        {


            try
            {
                SqlParameterCollection sqlParameterCollection = null;

                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = fieldName;
                sqlParameter.Value = fieldValue;
                sqlParameterCollection.Add(sqlParameter);

                SqlParameter ObjSqlParameter = new SqlParameter();
                ObjSqlParameter.ParameterName = CallTransactionsStoredProcedures.SortingString;
                ObjSqlParameter.Value = _SortingString;
                sqlParameterCollection.Add(ObjSqlParameter);

                if (createDataSet)
                    return GetDataSetForQueryParameter(CallTransactionsStoredProcedures.CallTransactionsSearchByValue, sqlParameterCollection);
                else
                    return GetDataSetForQueryParameter(CallTransactionsStoredProcedures.CallTransactionsSearchByValue, sqlParameterCollection);


            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "Search(" + fieldName + "," + fieldValue + ")", ex.Source, ex.Message, ex);
                return false;
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }
        }
        public bool Search(string[] fieldName, string[] fieldValue, bool createDataSet, string[,] sortFields)
        {


            try
            {



                SqlParameterCollection sqlParameterCollection = null;
                if (fieldName != null)
                {
                    if (fieldName.Length > 0)
                    {
                        for (int i = 0; i < fieldName.Length; i++)
                        {
                            SqlParameter sqlParameter = new SqlParameter();
                            sqlParameter.ParameterName = fieldName[i];
                            sqlParameter.Value = fieldValue[i];
                            sqlParameterCollection.Add(sqlParameter);
                        }
                    }
                }
                if (sortFields != null)
                {
                    if (sortFields.Length > 0)
                    {
                        _SortingString += "order by ";
                        for (int i = 0; i <= sortFields.GetUpperBound(0); i++)
                        {
                            _SortingString += "" + sortFields[i, 0] + " " + sortFields[i, 1] + ",";
                        }
                        _SortingString = _SortingString.Substring(0, _SortingString.Length - 1);
                    }

                    SqlParameter ObjSqlParameter = new SqlParameter();
                    ObjSqlParameter.ParameterName = CallTransactionsStoredProcedures.SortingString;
                    ObjSqlParameter.Value = _SortingString;
                    sqlParameterCollection.Add(ObjSqlParameter);
                }


                if (createDataSet)
                    return GetDataSetForQueryParameter(CallTransactionsStoredProcedures.CallTransactionsSearchByValueArray, sqlParameterCollection);
                else
                    return GetDataSetForQueryParameter(CallTransactionsStoredProcedures.CallTransactionsSearchByValueArray, sqlParameterCollection);


            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "Search(" + fieldName + "," + fieldValue + ")", ex.Source, ex.Message, ex);
                return false;
            }
            finally
            {

                dbClass.CloseSqlConnection(ref this.Connection);
            }
        }
        #endregion

        #region ExecuteQuery Methods
        private bool GetDataSetForQuery(string sqlQuery)
        {
            try
            {
                DataSet _DtsUsers = new DataSet("CallTransactions");
                SqlDataAdapter _Adpusers = new SqlDataAdapter(sqlQuery, this.Connection);
                _Adpusers.Fill(_DtsUsers);
                this._DtsDataset = _DtsUsers;
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDataSetForQuery(" + sqlQuery + ")", ex.Source, ex.Message, ex);
                return false;
            }
            finally { }
        }
        private bool GetDataSetForQueryParameter(string sqlQuery, SqlParameterCollection ObjSqlParameter)
        {
            try
            {
                DataSet _DtsUsers = new DataSet("CallTransactions");
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, this.Connection);
                sqlCommand.CommandText = sqlQuery;
                sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.CommandTimeout = 0;
                sqlCommand.Parameters.Add(ObjSqlParameter);
                SqlDataAdapter _Adpusers = new SqlDataAdapter();
                _Adpusers.SelectCommand = sqlCommand;
                _Adpusers.Fill(this._DtsDataset);
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDataSetForQuery(" + sqlQuery + ")", ex.Source, ex.Message, ex);
                return false;
            }
            finally { }
        }
        private bool GetCollectionForQuery(string sqlQuery)
        {
            SqlDataReader _Dtr = null;
            try
            {
                if (this.Connection == null)
                    this.Connection = dbClass.GetSqlConnection();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = sqlQuery;
                sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.CommandTimeout = 0;
                sqlCommand.Connection = this.Connection;

                _Dtr = sqlCommand.ExecuteReader();
                while (_Dtr.Read())
                {
                    CallTransactionsDataMapper objCallTransactionsDataMapper = new CallTransactionsDataMapper();
                    this.Items.Add(objCallTransactionsDataMapper.GetDetails(_Dtr));
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetCollectionForQuery(" + sqlQuery + ")", ex.Source, ex.Message, ex);
                return false;
            }
            finally
            {
                if (_Dtr != null)
                    _Dtr.Close();
                dbClass.CloseSqlConnection(ref this.Connection);
            }
        }
        private bool GetCollectionForQueryWithParameter(string sqlQuery, SqlParameterCollection ObjSqlParameter)
        {
            SqlDataReader _Dtr = null;
            try
            {
                if (this.Connection == null)
                    this.Connection = dbClass.GetSqlConnection();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = sqlQuery;
                sqlCommand.CommandType = CommandType.StoredProcedure;
		sqlCommand.CommandTimeout = 0;
                sqlCommand.Parameters.Add(ObjSqlParameter);
                sqlCommand.Connection = this.Connection;
                _Dtr = sqlCommand.ExecuteReader();
                while (_Dtr.Read())
                {
                    CallTransactionsDataMapper objCallTransactionsDataMapper = new CallTransactionsDataMapper();
                    this.Items.Add(objCallTransactionsDataMapper.GetDetails(_Dtr));
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetCollectionForQuery(" + sqlQuery + ")", ex.Source, ex.Message, ex);
                return false;
            }
            finally
            {
                if (_Dtr != null)
                    _Dtr.Close();
                dbClass.CloseSqlConnection(ref this.Connection);
            }
        }
        #endregion



        public bool Save(ref Dictionary<string, Command> commandList, ref int commandCounter)
        {
            try
            {
                CallTransactionsWrapper   objCallTransactionsWrapper = new CallTransactionsWrapper();
                for (int i = 0; i < this.Items.Count; i++)
                {
                    if (this.Items[i].ObjectChanged == true)
                    {
                        Dictionary<string, Command> subCommands = new Dictionary<string, Command>();
                          objCallTransactionsWrapper.Save(ref subCommands, ref commandCounter);
                        foreach (KeyValuePair<string, Command> commandPair in subCommands)
                        {
                            commandList.Add(commandPair.Key, commandPair.Value);
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "Save", ex.Source, ex.Message, ex);
                return false;
            }
            finally
            {
            }
        }
        public bool Delete(string ids, ref Dictionary<string, Command> commandList, ref int commandCounter)
        {
            try
            {
                Command command = new Command("SP_MASTERS_DELETE", CommandType.StoredProcedure);
                command.AddParameter("@TableName", CallTransactionsDBFields.TableNameVal, DataAccessLayer.DataAccess.DataType.Varchar, 0, ParameterDirection.Input);
                command.AddParameter("@PrimaryKeyColumn", CallTransactionsDBFields.ID, DataAccessLayer.DataAccess.DataType.Varchar, 0, ParameterDirection.Input);
                command.AddParameter("@IDs", ids, DataAccessLayer.DataAccess.DataType.Varchar, 0, ParameterDirection.Input);
                command.Name = "Delete" + CallTransactionsDBFields.TableNameVal + commandCounter.ToString();
                commandCounter++;
                commandList.Add(command.Name, command);

                return true;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "Delete", ex.Source, ex.Message, ex);
                return false;
            }
            finally
            {
            }
        }

        object UniversalCollection.GetRecordById(int id)
        {
            throw new NotImplementedException();
        }
        object UniversalCollection.GetRecordByValue(string fieldName, string value)
        {
            throw new NotImplementedException();
        }


        #endregion UniversalCollection Interface Members..


        #region Other Methods
        public List<CallTransactions> GetPendingSpeechToText()
        {
            SqlDataReader sqlDataReader = null;
            CallTransactionsDataMapper objDataMapper = new CallTransactionsDataMapper();
            try
            {
                if (this.Connection == null)
                    this.Connection = dbClass.GetSqlConnection();

                SqlCommand sqlCommand = new SqlCommand(CallTransactionsStoredProcedures.SpeechToText_Pending_GetRecords, this.Connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlDataReader = sqlCommand.ExecuteReader();
                _Items = objDataMapper.GetDetailsList(sqlDataReader);
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetPendingSpeechToText()", ex.Source, ex.Message, ex);
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }

            return _Items;
        }

        public List<CallTransactions> GetPendingAudio()
        {
            SqlDataReader sqlDataReader = null;
            CallTransactionsDataMapper objDataMapper = new CallTransactionsDataMapper();
            try
            {
                if (this.Connection == null)
                    this.Connection = dbClass.GetSqlConnection();

                SqlCommand sqlCommand = new SqlCommand(CallTransactionsStoredProcedures.Aduio_Pending_GetRecords, this.Connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlDataReader = sqlCommand.ExecuteReader();
                _Items = objDataMapper.GetDetailsList(sqlDataReader);
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetPendingAudio()", ex.Source, ex.Message, ex);
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }

            return _Items;
        }

        public List<CallTransactions> GetCallTransactions(Int64 LoginID, string ListType, string search = "")
        {
            SqlDataReader sqlDataReader = null;
            CallTransactionsDataMapper objDataMapper = new CallTransactionsDataMapper();
            try
            {
                if (this.Connection == null)
                    this.Connection = dbClass.GetSqlConnection();

                SqlCommand sqlCommand = new SqlCommand(CallTransactionsStoredProcedures.GetCallTransactionsRecords, this.Connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue(CallTransactionsDBFields.ID, LoginID);

                sqlDataReader = sqlCommand.ExecuteReader();
                _Items = objDataMapper.GetDetailsList(sqlDataReader);
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetCallTransactions(LoginID: " + LoginID + ")", ex.Source, ex.Message, ex);
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }

            return _Items;
        }

        public List<Analysis> GetAnalysis(Int64 ID)
        {
            SqlDataReader sqlDataReader = null;
            CallTransactionsDataMapper objDataMapper = new CallTransactionsDataMapper();
            List<Analysis> _Items = new List<Analysis>();
            try
            {
                if (this.Connection == null)
                    this.Connection = dbClass.GetSqlConnection();

                SqlCommand sqlCommand = new SqlCommand(CallTransactionsStoredProcedures.CallAnalysis_GetRecords, this.Connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue(CallTransactionsDBFields.ID, ID);

                sqlDataReader = sqlCommand.ExecuteReader();
                _Items = objDataMapper.GetDetailsAnalysisList(sqlDataReader);
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetAnalysis(ID:" + ID + ")", ex.Source, ex.Message, ex);
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }

            return _Items;
        }
        #endregion 


    }




}
