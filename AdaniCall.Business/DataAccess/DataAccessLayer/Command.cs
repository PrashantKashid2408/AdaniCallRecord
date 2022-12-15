using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using AdaniCall.Business.DataAccess.DataAccessLayer.General;


/// <summary>
/// This class instance stores single object for the commands in the command list of the tranaction class.
/// 
namespace AdaniCall.Business.DataAccess.DataAccessLayer
{
    public class Command
    {
        #region ForDebug
        public string Result;
        public string ReturnID;
        #endregion

        #region Declarations

        private DataAccess _DALObject;
        private Transaction _Parent;
        private string _ConnectionString;
        private SqlConnection _Connection;
        private string _Name;
        private SqlCommand DBCommand;
        private string _CommandText;
        private CommandType _CommandType;
        private bool _Executed;
        private DatabaseErrors _DBErrors; //= new DatabaseErrors();
        private Dictionary<string, Parameter> _Parameters;


        #endregion Declarations

        #region Properties

        /// <summary>
        /// Gets or Sets the Data Access Class Object under which the Command is executing.
        /// This must be set if the Command is using OUT or IN OUT parameter of some other command as the IN parameter.
        /// e.g. Master Detail Transactions
        /// </summary>
        public DataAccess DALObject
        {
            get
            { return this._DALObject; }
            set
            { this._DALObject = value; }
        }

        /// <summary>
        /// Gets or Sets the reference to the Parent Transaction
        /// </summary>
        public Transaction Parent
        {
            get
            { return this._Parent; }
            set
            { this._Parent = value; }
        }

        /// <summary>
        /// Get or sets the Connection String used by the Command
        /// </summary>
        public string ConnectionString
        {
            get
            { return this._ConnectionString; }
            set
            { this._ConnectionString = value; }
        }

        /// <summary>
        /// Gets or Sets the Name Of the Command
        /// </summary>
        public string Name
        {
            get
            { return this._Name; }
            set
            { this._Name = value; }
        }

        //public SqlCommand DBCommand
        //{
        //    get
        //    { return this._DBCommand; }
        //    set
        //    { this._DBCommand = value; }
        //}

        /// <summary>
        /// Gets or sets the connection used by the 
        /// </summary>
        public SqlConnection Connection
        {
            get
            { return this._Connection; }
            set
            { this._Connection = value; }
        }

        /// <summary>
        /// Gets or sets the Command string of the Command
        /// </summary>
        public string CommandText
        {
            get
            { return this._CommandText; }
            set
            { this._CommandText = value; }
        }

        /// <summary>
        /// Gets Or Sets the Command Type is a Stored Procedure Or A Text
        /// </summary>
        public CommandType CommandType
        {
            get
            { return this._CommandType; }
            set
            { this._CommandType = value; }
        }

        /// <summary>
        /// Gets the Parameters Added or Used By the Parameter
        /// </summary>
        public Dictionary<string, Parameter> Parameters
        {
            get
            { return this._Parameters; }
            //set
            //{ this._Parameters = value; }
        }

        /// <summary>
        /// Gets or Sets the executed flag indicating if the Command Object is executed or Not
        /// </summary>
        public bool Executed
        {
            get
            { return this._Executed; }
            set
            { this._Executed = value; }
        }

        /// <summary>
        /// This instance of DatabaseErrors Class will be set in case there is any error encountered in the class.
        /// All the methods return a bool value. The calling class should check if any method returns a 'false', 
        /// then access the Compass Error for details about the error encountered during DML operations by the DataAccess Classes.
        /// </summary>
        public DatabaseErrors DBErrors
        {
            get
            { return this._DBErrors; }
            set
            { this._DBErrors = value; }
        }

        #endregion Properties

        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        public Command()
        {
            DBCommand = new SqlCommand();
            _Parameters = new Dictionary<string, Parameter>();

        }
        /// <summary>
        /// String Parameter Constructor accepting only the Command Text. 
        /// This should be used if the Command Type is Text as it is set by default.
        /// </summary>
        /// <param name="commandText">SQL Query</param>
        public Command(string commandText)
            : this()
        {
            this.DBCommand.CommandText = commandText;
            this.DBCommand.CommandType = CommandType.Text;
        }

        /// <summary>
        /// Should be used to set the command object for Stored Procedures without any Parameters
        /// Command Type here can be explicitly set to Stored Procedure Type.
        /// Note: To configure the command for text commands the single argument constructor with string argument should be used.
        /// </summary>
        /// <param name="commandText">Stored Procedure Name</param>
        /// <param name="commandType">Command Type should be set to Stored Procedure Type.</param>
        public Command(String commandText, CommandType commandType)
            : this()
        {
            this.Name = commandText;
            this.CommandText = commandText;
            this.CommandType = commandType;
        }

        #endregion Constructors

        #region Methods
        public void AddParameter(Parameter parameter)
        {
            this.DBCommand.Parameters.Add(parameter);
        }

        public void AddParameter(string parameterName, object value, DataAccess.DataType dataType, int size, ParameterDirection direction)
        {
            Parameter parameter = new Parameter();
            parameter.Name = parameterName;
            parameter.ParameterName = parameterName;
            parameter.Value = value;
            parameter.Type = dataType;
            parameter.Size = size;
            parameter.Direction = direction;
            parameter.ParameterType = DataAccess.ParamType.AddType;

            this.Parameters.Add(parameterName, parameter);
        }

        public bool UseParameter(string name, string parameterName, DataAccess.DataType dataType, int size, ParameterDirection direction)
        {
            if (name.Trim() == "")
            {
                throw new ArgumentException("Parameter(Use Type) Added without a Name.");
            }
            try
            {
                Parameter parameter = new Parameter();
                parameter.Name = name;
                parameter.ParameterName = parameterName;
                parameter.Type = dataType;
                parameter.Size = size;
                parameter.Direction = direction;
                parameter.ParameterType = DataAccess.ParamType.UseType;
                this.Parameters.Add(parameter.Name.Trim(), parameter);
                return true;
            }
            catch (Exception ex)
            {
                this.DBErrors = new DatabaseErrors(ex.Message, DatabaseErrors.errorType.DatabaseError, "Data Access Layer");
                return false;
            }
            finally
            { }
        }

        /*public string GetParameterValue(string parameterName)
        {
            this.DBCommand.Parameters[0].Value = 10;
            return "";
            //return ((SqlParameter)this.parametersCollection[parameterName]).Value.ToString();
        }*/

        /// <summary>
        /// Executes the Command
        /// </summary>
        /// <returns>Returns a true if the execution is successfull else returns a false. 
        /// DatabaseErrors object of the class should be accessed to get the details of the error.</returns>
        public bool Execute(SqlTransaction trans)
        {
            try
            {
                this.Result = "";
                this.ReturnID = "0";
                if (this.Connection == null)
                {
                    this.Connection = new SqlConnection(this.ConnectionString);
                    this.Connection.Open();
                }
                this.DBCommand = new SqlCommand(this.CommandText, this.Connection);
                this.DBCommand.Transaction = trans;
                this.DBCommand.CommandType = this.CommandType;

                foreach (KeyValuePair<string, Parameter> p in this.Parameters)
                {
                    Parameter parameter = p.Value;

                    if (parameter.ParameterType == DataAccess.ParamType.UseType)
                    {
                        Parameter parentParam = GetParameterObjectFromName(parameter.Name);
                        parameter.Value = parentParam.Value;
                    }
                    SqlParameter SqlParameter = new SqlParameter(parameter.ParameterName, DataAccess.ConvertTypeToSqlType(parameter.Type), parameter.Size);
                    SqlParameter.Direction = parameter.Direction;
                    if (parameter.Type == DataAccess.DataType.Number)
                        SqlParameter.Precision = Convert.ToByte(parameter.Size);

                    SqlParameter.Value = Conversion.ValueToDB(parameter.Value);
                    this.DBCommand.Parameters.Add(SqlParameter);
                    this.Result += parameter.ParameterName + ":= " + GetDBFormat(parameter) + ";\n";
                }
                this.DBCommand.ExecuteNonQuery();
                Debug.Print(this.CommandText + "(" + this.Result.Replace(";\n", ",") + ")");
                foreach (KeyValuePair<string, Parameter> p in this.Parameters)
                {
                    Parameter parameter = p.Value;
                    if (parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Output)
                    {
                        parameter.Value = this.DBCommand.Parameters[parameter.ParameterName].Value;
                        this.ReturnID = parameter.Value.ToString();
                    }
                }
                this.Executed = true;
                return true;
            }
            catch (SqlException ex)
            {
                //Handle Unique Key, Primary Key Violation here. Set DatabaseErrors Object accordingly.
                AdaniCall.Utility.Common.Log.WriteLog("DataAccess.Command", "Execute this.CommandText: (" + this.CommandText + ")", ex.Source, ex.Message);
                if (ex.Message.Contains("INFO_WORKFLOW_ERROR"))
                {
                    this.DBErrors = new DatabaseErrors();
                    this.DBErrors.ErrorMessage = ex.Message.Substring(20, ex.Message.Length - 55);
                }
                else
                {
                    string constraintName = DataAccess.GetUniqueConstraintFromMsg(ex.Message);
                    this.DBErrors = new DatabaseErrors(constraintName, DatabaseErrors.errorType.DatabaseError, "Data Access Layer");
                }

                return false;
            }
            catch (Exception ex)
            {
                //Handle unexpected exceptions here.

                Debug.Print(ex.ToString());
                return false;
            }
            finally
            {

            }
        }

        private Parameter GetParameterObjectFromName(string name)
        {
            if (name.Trim() == "")
            {
                throw new ArgumentException("Invalid Name Passed in the ");
                //return null;
            }
            try
            {
                //Sample name string: '..\..\..\T1\T2\C1\P1'  -- This is where the reference value is.
                //Where T1, T2 are transactions, C1 is a Command, P1 is a Parameter.
                //Current Execution Position '
                Transaction transobject = this.Parent;
                string[] nameComponents = name.Split('\\');

                int iCtr = 0;
                while (nameComponents[iCtr] == "..")
                {
                    transobject = transobject.Parent;
                }

                //Length - 3 is used because
                //§ 1 Less for the Length being more than UBound
                //§ 2 Less for the Command Name and the Parameter Name in the Name String to be ignored to find the Par
                for (int i = iCtr; i < nameComponents.Length - 3; i++)
                {
                    transobject = transobject.TransactionList[nameComponents[i]];
                }
                return transobject.CommandList[nameComponents[nameComponents.Length - 2]].Parameters[nameComponents[nameComponents.Length - 1]];
            }
            catch (Exception ex)
            {
                Debug.Print(ex.ToString());
                return null;
            }
            finally
            {
            }
        }
        private string GetDBFormat(Parameter param)
        {
            if (param.Value == null || param.Value == DBNull.Value)
            {
                return "NULL";
            }

            switch (param.Type)
            {
                case DataAccess.DataType.Char:
                    return "'" + param.Value.ToString() + "'";
                case DataAccess.DataType.XML:
                    return "'" + param.Value.ToString() + "'";
                //break;
                case DataAccess.DataType.Varchar:
                    return "'" + param.Value.ToString() + "'";
                // break;
                case DataAccess.DataType.Varchar2:
                    return "'" + param.Value.ToString() + "'";
                // break;
                case DataAccess.DataType.Number:
                    return param.Value.ToString();
                // break;
                case DataAccess.DataType.DateTime:
                case DataAccess.DataType.Date:
                    return "'" + Convert.ToDateTime(param.Value).ToString("dd-MMM-yyyy") + "'";
                //break;
                default:
                    return "'" + param.Value.ToString() + "'";
                // break;
            }
        }
        #endregion Methods
    }
}
