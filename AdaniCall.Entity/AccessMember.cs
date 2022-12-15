using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace  AdaniCall.Entity
{
    public class AccessMember
    {
        #region Declarations

        private bool _boolObjectChanged;
        private decimal _decID;
        private long _intUserID;
        private string _strCallerID;
        private long _intKioskID;
        private int _intLocationID;
        private string _strUrl;
        private string _strReferrerURL;
        private string _strport;
        private string _strHost;
        private string _strREMOTE_HOST;
        private string _strREMOTE_ADDR_IP;
        private string _strUseragent;
        private string _strBrowserType;
        private string _strBrowserVersion;
        private string _strPlatform;
        private string _strClickedBy;
        private byte _bytStatusId;
        private DateTime _datCreatedDate;
        private string _strDeviceName;
        private string _strOperatingSystem;
        private string _strDeviceType;
        private string _strDeviceModel;
        private string _strBuild;
        private string _strVersion;
        private byte _bytRole;


        #endregion Declarations

        #region Properties

         public bool ObjectChanged
         { 
            get { return this._boolObjectChanged; } 
            set { this._boolObjectChanged = value; }
         } 

         public decimal ID
         { 
            get { return this._decID; } 
            set { this._decID = value; }
         } 

         public long UserID
         { 
            get { return this._intUserID; } 
            set { this._intUserID = value; }
         } 

         public string CallerID
         { 
            get { return this._strCallerID; } 
            set { this._strCallerID = value; }
         } 

         public long KioskID
         { 
            get { return this._intKioskID; } 
            set { this._intKioskID = value; }
         } 

         public int LocationID
         { 
            get { return this._intLocationID; } 
            set { this._intLocationID = value; }
         } 

         public string Url
         { 
            get { return this._strUrl; } 
            set { this._strUrl = value; }
         } 

         public string ReferrerURL
         { 
            get { return this._strReferrerURL; } 
            set { this._strReferrerURL = value; }
         } 

         public string port
         { 
            get { return this._strport; } 
            set { this._strport = value; }
         } 

         public string Host
         { 
            get { return this._strHost; } 
            set { this._strHost = value; }
         } 

         public string REMOTE_HOST
         { 
            get { return this._strREMOTE_HOST; } 
            set { this._strREMOTE_HOST = value; }
         } 

         public string REMOTE_ADDR_IP
         { 
            get { return this._strREMOTE_ADDR_IP; } 
            set { this._strREMOTE_ADDR_IP = value; }
         } 

         public string Useragent
         { 
            get { return this._strUseragent; } 
            set { this._strUseragent = value; }
         } 

         public string BrowserType
         { 
            get { return this._strBrowserType; } 
            set { this._strBrowserType = value; }
         } 

         public string BrowserVersion
         { 
            get { return this._strBrowserVersion; } 
            set { this._strBrowserVersion = value; }
         } 

         public string Platform
         { 
            get { return this._strPlatform; } 
            set { this._strPlatform = value; }
         } 

         public string ClickedBy
         { 
            get { return this._strClickedBy; } 
            set { this._strClickedBy = value; }
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

         public string DeviceName
         { 
            get { return this._strDeviceName; } 
            set { this._strDeviceName = value; }
         } 

         public string OperatingSystem
         { 
            get { return this._strOperatingSystem; } 
            set { this._strOperatingSystem = value; }
         } 

         public string DeviceType
         { 
            get { return this._strDeviceType; } 
            set { this._strDeviceType = value; }
         } 

         public string DeviceModel
         { 
            get { return this._strDeviceModel; } 
            set { this._strDeviceModel = value; }
         } 

         public string Build
         { 
            get { return this._strBuild; } 
            set { this._strBuild = value; }
         } 

         public string Version
         { 
            get { return this._strVersion; } 
            set { this._strVersion = value; }
         } 

         public byte Role
         { 
            get { return this._bytRole; } 
            set { this._bytRole = value; }
         }

        public string UniqueCallID { get; set; }


        #endregion Properties
    }
}
