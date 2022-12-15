using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Diagnostics;

/// <summary>
/// Summary description for DataAccess
namespace AdaniCall.Business.DataAccess.DataAccessLayer
{
    public class DataAccess
    {
        #region Declarations

        private string _ConnectionString;
        private Dictionary<string, Transaction> _TransactionList = null;

        #region Enumerators
        public enum DataType
        {
            Char,
            Varchar,
            Varchar2,
            NVarChar,
            Number,
            XML,
            DateTime,
            Date
        }

        public enum ParamType
        {
            AddType,
            UseType
        }
        #endregion Enumerators

        #endregion Declarations

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public DataAccess()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or Sets the default connection string to be used in the child transactions.
        /// </summary>
        public string ConnectionString
        {
            get
            { return this._ConnectionString; }
            set
            { this._ConnectionString = value; }
        }

        /// <summary>
        /// Gets the count of Transactions in the Transaction List of the Data Access Class.
        /// </summary>
        public int Count
        {
            get
            { return this._TransactionList.Count; }
        }
        #endregion Properties

        #region Methods
        public static SqlDbType ConvertTypeToSqlType(DataAccess.DataType value)
        {
            switch (value)
            {
                case DataType.Char:
                    return SqlDbType.Char;
                case DataType.Number:
                    return SqlDbType.Int;
                case DataType.DateTime:
                case DataType.Date:
                    return SqlDbType.DateTime;
                case DataType.XML:
                    return SqlDbType.Xml;
                case DataType.Varchar:
                case DataType.Varchar2:
                case DataType.NVarChar:
                    return SqlDbType.NVarChar;
                default:
                    return SqlDbType.VarChar;

            }
        }

        public bool AddTransaction(Transaction Value)
        {
            if (Value.Name.Trim() == "")
            {
                throw new ArgumentException("Transaction passed without a Name");
                //return false;
            }
            try
            {
                this._TransactionList.Add(Value.Name, Value);
                return true;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.ToString());
                return false;
            }
        }

        public static string GetUniqueConstraintFromMsg(string errMessage)
        {
            try
            {
                //Sample Error Code

                //Violation of Foreign Key Constraint
                //The statement has been terminated.
                //The DELETE statement conflicted with the REFERENCE constraint "FK_LOCATION_MENU_LOCATIONID". The conflict occurred in database "ECUCommon", table "dbo.Menu", column 'LocationId'.

                //Violation of Unique Key Constraint
                //The statement has been terminated.
                //Violation of UNIQUE KEY constraint 'UNQ_LOCATION_SHORTCODE'. Cannot insert duplicate key in object 'dbo.location'.

                int constraintStart = errMessage.IndexOf("constraint");
                //the variable constraintStart will first be initialized with the IndexOf the word "constraint"

                string quote;
                quote = errMessage.Substring(constraintStart + 11, 1);
                //to find the single quote or the double quote in which the constraint name is unclosed we will add
                //11 to the constraintStart variable. This 11 is Len("constraint") + 1(space). Please refer the 
                //Error messages above

                int bracketStart = errMessage.IndexOf(quote);
                int bracketEnd = errMessage.IndexOf(quote, bracketStart + 1);
                string strConstraint = errMessage.Substring(bracketStart + 1, bracketEnd - (bracketStart + 1));
                return strConstraint;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.ToString());
                return "";
            }
        }


        #endregion Methods
    }
}
