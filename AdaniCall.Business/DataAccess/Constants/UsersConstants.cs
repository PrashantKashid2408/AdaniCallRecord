using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaniCall.Business.DataAccess.Constants
{
    public class UsersDBFields
    {

	
        public static string IU_Flag = "IU_Flag"; 


		

        public static string TableNameVal = "Users";
        public static string  ID = "ID";
        public static string  UserName = "UserName";
        public static string  Password = "Password";
        public static string LoginMode = "LoginMode";
        public static string  FirstName = "FirstName";
        public static string  LastName = "LastName";
        public static string  AlternateEmail = "AlternateEmail";
        public static string  Profile_Logo = "Profile_Logo";
        public static string  RoleId = "RoleId";
        public static string  ParentId = "ParentId";
        public static string  AgentLocationID = "AgentLocationID";
        public static string  LanguageId = "LanguageId";
        public static string  AgentCallID = "AgentCallID";
        public static string  IsEmailVerified = "IsEmailVerified";
        public static string  EmailVerficationCode = "EmailVerficationCode";
        public static string  EmailVerificationDate = "EmailVerificationDate";
        public static string  StatusId = "StatusId";
        public static string  CreatedDate = "CreatedDate";
        public static string  UpdatedDate = "UpdatedDate";
        public static string KioskID = "KioskID";
        public static string AgentAvailability = "AgentAvailability";

    }
    public class UsersStoredProcedures
    {

        #region Object StoredProcedure

		



		
        public static string UsersSAVE = "Users_SAVE";
        public static string UsersGetRecordById = "Users_GetRecordById";
        public static string Users_UpdateAvailability = "Users_UpdateAvailability";

        public static string GetUsersRecords = "Users_GetRecords";
        public static string GetUsersRecordByValue =  "Users_GetRecordByValue";
        public static string GetUsersRecordByValueArray = "Users_GetRecordByValueArray";
        public static string Users_Login = "Users_Login";
        public static string Users_Availability_Get = "Users_Availability_Get";

        #endregion

        #region Collection StoredProcedure

        public static string UsersSearch = "Users_Search";
        public static string UsersSearchByValue =  "Users_SearchByValue";
        public static string UsersSearchByValueArray = "Users_SearchByValueArray";
        #endregion
 
        public static string IsExist = "";
        public static string GetCollectionForQuery = "";
        public static string SortingString = "SortOrder";


      
    }
}
