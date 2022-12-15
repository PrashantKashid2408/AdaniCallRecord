using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaniCall.Business.DataAccess.Constants
{
    public class KioskMasterDBFields
    {

	
        public static string IU_Flag = "IU_Flag"; 


		

        public static string TableNameVal = "KioskMaster";
public static string  ID = "ID";
public static string  UserName = "UserName";
public static string  Password = "Password";
public static string  TravellerCallerID = "TravellerCallerID";
public static string  LocationID = "LocationID";
public static string  LocationID2 = "LocationID2";
public static string  LocationID3 = "LocationID3";
public static string  DeviceName = "DeviceName";
public static string  OperatingSystem = "OperatingSystem";
public static string  DeviceType = "DeviceType";
public static string  DeviceModel = "DeviceModel";
public static string  StatusId = "StatusId";
public static string  CreatedDate = "CreatedDate";
public static string  UpdatedDate = "UpdatedDate";

      
    }
    public class KioskMasterStoredProcedures
    {

        #region Object StoredProcedure

		



		
        public static string KioskMasterSAVE = "KioskMaster_SAVE";
        public static string KioskMasterGetRecordById = "KioskMaster_GetRecordById";
        public static string Kiosk_GetByCallerID = "Kiosk_GetByCallerID";
        public static string GetKioskMasterRecords = "KioskMaster_GetRecords";
        public static string GetKioskMasterRecordByValue =  "KioskMaster_GetRecordByValue";
        public static string GetKioskMasterRecordByValueArray = "KioskMaster_GetRecordByValueArray";
         
        #endregion

        #region Collection StoredProcedure
		 
        public static string KioskMasterSearch = "KioskMaster_Search";
        public static string KioskMasterSearchByValue =  "KioskMaster_SearchByValue";
        public static string KioskMasterSearchByValueArray = "KioskMaster_SearchByValueArray";
        #endregion
 
        public static string IsExist = "";
        public static string GetCollectionForQuery = "";
        public static string SortingString = "SortOrder";


      
    }
}
