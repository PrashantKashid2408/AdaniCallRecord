using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdaniCall.Entity
{
    public class Users
    {
        #region Declarations

        private bool _boolObjectChanged;
        private Int64 _intID;
        private string _strUserName;
        private string _strPassword;
        private string _strFirstName;
        private string _strLastName;
        private string _strAlternateEmail;
        private string _strProfile_Logo;
        private byte _bytRoleId;
        private Int64 _intParentId;
        private int _intAgentLocationID;
        private int _intLanguageId;
        private string _strAgentCallID;
        private bool _boolIsEmailVerified;
        private DateTime _datEmailVerificationDate;
        private byte _bytStatusId;
        private DateTime _datCreatedDate;
        private DateTime _datUpdatedDate;


        #endregion Declarations

        #region Properties

        public bool ObjectChanged
        {
            get { return this._boolObjectChanged; }
            set { this._boolObjectChanged = value; }
        }

        public Int64 ID
        {
            get { return this._intID; }
            set { this._intID = value; }
        }

        public string UserName
        {
            get { return this._strUserName; }
            set { this._strUserName = value; }
        }

        public string Password
        {
            get { return this._strPassword; }
            set { this._strPassword = value; }
        }

        public string FirstName
        {
            get { return this._strFirstName; }
            set { this._strFirstName = value; }
        }

        public string LastName
        {
            get { return this._strLastName; }
            set { this._strLastName = value; }
        }

        public string AlternateEmail
        {
            get { return this._strAlternateEmail; }
            set { this._strAlternateEmail = value; }
        }

        public string Profile_Logo
        {
            get { return this._strProfile_Logo; }
            set { this._strProfile_Logo = value; }
        }

        public byte RoleId
        {
            get { return this._bytRoleId; }
            set { this._bytRoleId = value; }
        }

        public Int64 ParentId
        {
            get { return this._intParentId; }
            set { this._intParentId = value; }
        }

        public int AgentLocationID
        {
            get { return this._intAgentLocationID; }
            set { this._intAgentLocationID = value; }
        }

        public int LanguageId
        {
            get { return this._intLanguageId; }
            set { this._intLanguageId = value; }
        }

        public string AgentCallID
        {
            get { return this._strAgentCallID; }
            set { this._strAgentCallID = value; }
        }

        public bool IsEmailVerified
        {
            get { return this._boolIsEmailVerified; }
            set { this._boolIsEmailVerified = value; }
        }

        public DateTime EmailVerificationDate
        {
            get { return this._datEmailVerificationDate; }
            set { this._datEmailVerificationDate = value; }
        }

        public byte StatusId
        {
            get { return this._bytStatusId; }
            set { this._bytStatusId = value; }
        }

        public DateTime CreatedDate
        {
            get { return this._datCreatedDate; }
            set { this._datCreatedDate = value; }
        }

        public DateTime UpdatedDate
        {
            get { return this._datUpdatedDate; }
            set { this._datUpdatedDate = value; }
        }

        public string EmailVerficationCode { get; set; }

        public Int64 KioskID { get; set; }

        public int AgentAvailability { get; set; }

        #endregion Properties
    }
}
