using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaniCall.Business.DataAccess.Constants
{
    public class RolesDBFields
    {

	
        public static string IU_Flag = "IU_Flag"; 


		

        public static string TableNameVal = "Roles";
public static string  ID = "ID";
public static string  RoleName = "RoleName";
public static string  StatusId = "StatusId";
public static string  CreatedDate = "CreatedDate";
public static string  RoleLevel = "RoleLevel";

      
    }
    public class RolesStoredProcedures
    {

        #region Object StoredProcedure

		



		
        public static string RolesSAVE = "Roles_SAVE";
        public static string RolesGetRecordById = "Roles_GetRecordById";

        public static string GetRolesRecords = "Roles_GetRecords";
        public static string GetRolesRecordByValue =  "Roles_GetRecordByValue";
        public static string GetRolesRecordByValueArray = "Roles_GetRecordByValueArray";
         
        #endregion

        #region Collection StoredProcedure
		 
        public static string RolesSearch = "Roles_Search";
        public static string RolesSearchByValue =  "Roles_SearchByValue";
        public static string RolesSearchByValueArray = "Roles_SearchByValueArray";
        #endregion
 
        public static string IsExist = "";
        public static string GetCollectionForQuery = "";
        public static string SortingString = "SortOrder";


      
    }
}
