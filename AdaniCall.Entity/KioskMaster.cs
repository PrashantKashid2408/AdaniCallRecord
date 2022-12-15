using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace  AdaniCall.Entity
{
    public class KioskMaster
    {
        #region Declarations

        private bool _boolObjectChanged;
        private Int64 _intID;
        private string _strUserName;
        private string _strPassword;
        private string _strTravellerCallerID;
        private int _intLocationID;
        private int _intLocationID2;
        private int _intLocationID3;
        private string _strDeviceName;
        private string _strOperatingSystem;
        private string _strDeviceType;
        private string _strDeviceModel;
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

            public string TravellerCallerID
            { 
            get { return this._strTravellerCallerID; } 
            set { this._strTravellerCallerID = value; }
            } 

            public int LocationID
            { 
            get { return this._intLocationID; } 
            set { this._intLocationID = value; }
            } 

            public int LocationID2
            { 
            get { return this._intLocationID2; } 
            set { this._intLocationID2 = value; }
            } 

            public int LocationID3
            { 
            get { return this._intLocationID3; } 
            set { this._intLocationID3 = value; }
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



        #endregion Properties
    }
}
