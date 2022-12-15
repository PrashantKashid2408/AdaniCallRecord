using System;
using System.Data;
using System.Configuration;
using System.Xml;
using AdaniCall.Utility.Common;
/// <summary>
/// Summary description for DatabaseErrors
/// </summary>
namespace AdaniCall.Business.DataAccess.DataAccessLayer.General
{
    public class DatabaseErrors
    {
        #region Declarations

        private int _ErrorId = 0;
        private string _ErrorCode = "";
        private int _ErrorTypeCode = 0;
        private string _ErrorTypeDescription = "";
        private string _ErrorMessage = "";
        private string _ErrorModule = "";

        public enum errorType { DatabaseError = 0, GeneralError = 1 };
        private string xmlFilePath = System.AppDomain.CurrentDomain.BaseDirectory + @"\xml_Data\DatabaseErrors.xml";

        #endregion Declarations

        #region Constructors

        /// <summary>
        /// This constructor will be called only when the system has completed
        /// the said operation successfully and without any errors.
        /// </summary>
        public DatabaseErrors()
        {
            this.ErrorModule = "";
            this.ErrorTypeCode = 1;
            this.ErrorCode = "Success";
            this.ErrorMessage = "The requested action has been performed successfully.";

            GetErrorInformation();
        }

        /// <summary>
        /// This constructor will be called only when the system has raised an 
        /// exception which needs to be handled. In case, if the exception 
        /// raised is of type OleDbException, then the arguement errDetail 
        /// should be passed the ErrorCode returned by the Exception along with
        /// the errType argument as "DatabaseError". In other case, the arguement
        /// errDetail will be set with the Message returned by the Exception along
        /// with the the errType argument as "GeneralError".
        /// </summary>
        /// <param name="errDetail">Will either take the ErrorCode returned by the 
        /// OleDbException class or will take the Error Message returned by the
        /// Exception class.
        /// </param>
        /// <param name="errType">Will take error type defined by the enum type 
        /// DatabaseErrors.errorType
        /// </param>
        /// <param name="errModule">Will take the module name in which the class is
        /// being initialized.
        /// </param>
        public DatabaseErrors(string errDetail, errorType errType, string errModule)
        {
            this.ErrorModule = errModule;
            this.ErrorTypeCode = (int)errType;

            if (errType == errorType.DatabaseError)
            {
                this.ErrorCode = errDetail;
            }
            else
            {
                this.ErrorMessage = errDetail;
            }

            GetErrorInformation();
        }

        #endregion Constructors

        #region Properties
        /// <summary>
        /// get and set Error Id
        /// </summary>
        public int ErrorId
        {
            get
            {
                return this._ErrorId;
            }
            set
            {
                this._ErrorId = value;
            }
        }
        /// <summary>
        /// get and set Error Code
        /// </summary>
        public string ErrorCode
        {
            get
            {
                return this._ErrorCode;
            }
            set
            {
                this._ErrorCode = value;
            }
        }

        /// <summary>
        /// get and set Error Type Code
        /// </summary>
        public int ErrorTypeCode
        {
            get
            {
                return this._ErrorTypeCode;
            }
            set
            {
                this._ErrorTypeCode = value;
            }
        }

        /// <summary>
        /// get and set Error Type Description
        /// </summary>
        public string ErrorTypeDescription
        {
            get
            {
                return this._ErrorTypeDescription;
            }
            set
            {
                this._ErrorTypeDescription = value;
            }
        }

        /// <summary>
        /// get and set Error Message
        /// </summary>
        public string ErrorMessage
        {
            get
            {
                return this._ErrorMessage;
            }
            set
            {
                this._ErrorMessage = value;
            }
        }

        /// <summary>
        /// get and set Error Module
        /// </summary>
        public string ErrorModule
        {
            get
            {
                return this._ErrorModule;
            }
            set
            {
                this._ErrorModule = value;
            }
        }

        #endregion Properties

        #region Other Methods

        /// <summary>
        /// Will retrive the Error Information from the DatabaseError.xml file based 
        /// on the properties set by the calling class.
        /// </summary>
        private void GetErrorInformation()
        {
            DataSet xmlDataSet = new DataSet();

            try
            {
                xmlDataSet.ReadXml(xmlFilePath);

                if (ErrorTypeCode == (int)errorType.DatabaseError)
                {
                    DataRow xmlDataRow = xmlDataSet.Tables[0].Select("ErrorCode='" + ErrorCode + "' and Module = '" + ErrorModule + "'")[0];
                    SetErrorInformation(xmlDataRow);
                }
                else
                {
                    DataRow xmlDataRow = xmlDataSet.Tables[0].Select("UserDefinedMessage='" + ErrorMessage + "' and Module = 'General'")[0];
                    SetErrorInformation(xmlDataRow);
                }
            }
            catch (IndexOutOfRangeException)
            {
                DataRow xmlDataRow = xmlDataSet.Tables[0].Select("ErrorCode='Error Not Found' and Module = 'General'")[0];
                SetErrorInformation(xmlDataRow);
            }
            catch (Exception ex)
            {
                Log.WriteLog("DatabaseErrors", "SetErrorInformation", ex.Source, ex.Message);
            }
        }

        /// <summary>
        /// Will set the details retrieved by the GetErrorInformation method to the 
        /// property variables of the class.
        /// </summary>
        /// <param name="paramDataRow">DataRow object containing the Error Information 
        /// retrieved by the GetErrorInformation method.
        /// </param>
        private void SetErrorInformation(DataRow paramDataRow)
        {
            ErrorId = Convert.ToInt32("0" + paramDataRow["Id"].ToString());
            ErrorCode = paramDataRow["ErrorCode"].ToString();
            ErrorTypeCode = Convert.ToInt32("0" + paramDataRow["TypeCode"].ToString());
            ErrorTypeDescription = paramDataRow["TypeDescription"].ToString();
            ErrorMessage = paramDataRow["UserDefinedMessage"].ToString();
            ErrorModule = paramDataRow["Module"].ToString();
        }

        #endregion Other Methods
    }
}