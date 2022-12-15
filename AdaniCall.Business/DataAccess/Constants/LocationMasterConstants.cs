using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaniCall.Business.DataAccess.Constants
{
    public class LocationMasterDBFields
    {

	
        public static string IU_Flag = "IU_Flag"; 


		

        public static string TableNameVal = "LocationMaster";
public static string  ID = "ID";
public static string  LocationName = "LocationName";
public static string  LocationType = "LocationType";
public static string  StatusId = "StatusId";
public static string  CreatedDate = "CreatedDate";
public static string  UpdatedDate = "UpdatedDate";

      
    }
    public class LocationMasterStoredProcedures
    {

        #region Object StoredProcedure

		



		
        public static string LocationMasterSAVE = "LocationMaster_SAVE";
        public static string LocationMasterGetRecordById = "LocationMaster_GetRecordById";

        public static string GetLocationMasterRecords = "LocationMaster_GetRecords";
        public static string GetLocationMasterRecordByValue =  "LocationMaster_GetRecordByValue";
        public static string GetLocationMasterRecordByValueArray = "LocationMaster_GetRecordByValueArray";
         
        #endregion

        #region Collection StoredProcedure
		 
        public static string LocationMasterSearch = "LocationMaster_Search";
        public static string LocationMasterSearchByValue =  "LocationMaster_SearchByValue";
        public static string LocationMasterSearchByValueArray = "LocationMaster_SearchByValueArray";
        #endregion
 
        public static string IsExist = "";
        public static string GetCollectionForQuery = "";
        public static string SortingString = "SortOrder";


      
    }
}
