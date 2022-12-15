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

namespace AdaniCall.Business.BusinessFacade
{
    public class AccessMemberBusinessFacade//:UniversalObject
    {
        dynamic objdynamicWrapper; 
		AccessMemberWrapperColletion objAccessMemberWrapperColletion = new AccessMemberWrapperColletion();
        AccessMemberWrapper objAccessMemberWrapper = new AccessMemberWrapper();
		private static readonly string _module = "AdaniCall.Business.BusinessFacade.AccessMemberBusinessFacade";
		public AccessMemberBusinessFacade()
        {
            
        }
        public AccessMemberBusinessFacade(dynamic WrapperType)
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
                objAccessMemberWrapper.objWrapperClass = objEntity;
                DataAccess.DataAccessLayer.DataAccess dalObject = new DataAccess.DataAccessLayer.DataAccess();
                Transaction TransObj = new Transaction(dalObject);
                TransObj.ConnectionString = dbClass.SqlConnectString();
                Dictionary<string, Command> CommandsObj = new Dictionary<string, Command>();
                int commandCounter = 0;

                bool result = objAccessMemberWrapper.Save(ref CommandsObj, ref commandCounter);
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

        public bool UpdateAccessMember(string strColumns, string strCondition)
        {
            try
            {
                AccessMemberWrapper objWrapper = new AccessMemberWrapper();
                objWrapper.UpdateAccessMember(strColumns, strCondition);
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "UpdateAccessMember(strColumns=" + strColumns + ",strCondition=" + strCondition + ")", ex.Source, ex.Message, ex);
                return false;
            }

            return true;
        }
    }
}
