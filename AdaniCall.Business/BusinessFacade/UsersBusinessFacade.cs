using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdaniCall.Business.DataAccess.Wrapper;
using AdaniCall.Business.DataAccess.Mapper;
using AdaniCall.Business.DataAccess.DataAccessLayer.General;
using AdaniCall.Business.DataAccess.DataAccessLayer;
using AdaniCall.Entity;
using AdaniCall.Business.DataAccess.Constants;
using AdaniCall.Utility;
using AdaniCall.Entity.Common;
using AdaniCall.Utility.Common;
using AdaniCall.Resources;
using AdaniCall.Entity.Enums;


namespace AdaniCall.Business.BusinessFacade
{
    public class UsersBusinessFacade//:UniversalObject
    {
        dynamic objdynamicWrapper;
        UsersWrapperColletion objUsersWrapperColletion = new UsersWrapperColletion();
        UsersWrapper objUsersWrapper = new UsersWrapper();
        private static readonly string _module = "AdaniCall.Business.BusinessFacade.UsersBusinessFacade";
        JsonMessage _jsonMessage = null;

        public UsersBusinessFacade()
        {

        }
        public UsersBusinessFacade(dynamic WrapperType)
        {
            objdynamicWrapper = WrapperType;
        }
        public dynamic GetRecordsList()
        {
            string[,] Sort = new string[1, 2];
            if (objdynamicWrapper.GetRecords(false, Sort))
            {
                return objdynamicWrapper.Items;
            }
            return null;
        }
        public dynamic GetRecordsListByValue(string Field, String Values)
        {
            string[,] Sort = new string[1, 2];

            if (objdynamicWrapper.GetRecords(false, Sort, true, Field, Values))
            {
                return objdynamicWrapper.Items;
            }
            return null;
        }

        public dynamic GetRecordByValue(string Field, string Values)
        {
            string[,] Sort = new string[1, 2];

            if (objdynamicWrapper.GetRecordByValue(Field, Values))
            {
                return objdynamicWrapper.objUsers;
            }
            return null;
        }

        public dynamic GetRecords(int Id)
        {

            if (objdynamicWrapper.GetRecordById(Id))
            {
                return objdynamicWrapper.objWrapperClass;
            }
            return null;
        }
        public bool Save(dynamic objEntity)
        {
            try
            {

                objUsersWrapper.objWrapperClass = objEntity;
                DataAccess.DataAccessLayer.DataAccess dalObject = new DataAccess.DataAccessLayer.DataAccess();
                Transaction TransObj = new Transaction(dalObject);
                TransObj.ConnectionString = dbClass.SqlConnectString();
                Dictionary<string, Command> CommandsObj = new Dictionary<string, Command>();
                int commandCounter = 0;

                bool result = objUsersWrapper.Save(ref CommandsObj, ref commandCounter);
                TransObj.AddCommandList(CommandsObj);
                if (TransObj.ExecuteTransaction())
                {
                    long ID = 0;
                    if (long.TryParse(TransObj.ReturnID, out ID) && ID > 0)
                    {
                        objEntity.ID = ID;
                    }
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally { }

        }

        public JsonMessage ChangeAvailabilityStatus(Int64 ID, string StatusID, string AgentCallerID = "")
        {
            try
            {
                UsersWrapper objWrapper = new UsersWrapper();
                objWrapper.ChangeAvailabilityStatus(ID, StatusID, AgentCallerID);
                string strMessage = "";

                _jsonMessage = new JsonMessage(true, Resource.lbl_success, strMessage, KeyEnums.JsonMessageType.SUCCESS, "", "");
            }
            catch (Exception ex)
            {
                _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_internalServerErrorOccurred, KeyEnums.JsonMessageType.ERROR, "", "0", null);
                Log.WriteLog(_module, "ChangeAvailabilityStatus(ID=" + ID + ",StatusID=" + StatusID + ")", ex.Source, ex.Message, ex);
            }

            return _jsonMessage;
        }

        public Users Authenticate(string username, string password, string LoginMode = "")
        {
            try
            {
                return objUsersWrapper.Authenticate(username, password, LoginMode);
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "Authenticate(username=" + username + ", password=" + password + ",LoginMode:" + LoginMode + ")", ex.Source, ex.Message, ex);
            }
            return null;
        }

        public Users GetAvailableAgent(Int64 UserID)
        {
            try
            {
                return objUsersWrapper.GetAvailableAgent(UserID);
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetAvailableAgent(UserID:" + UserID + ")", ex.Source, ex.Message, ex);
            }
            return null;
        }

    }
}
