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
    public class CallTransactionsBusinessFacade//:UniversalObject
    {
        dynamic objdynamicWrapper; 
		CallTransactionsWrapperColletion objCallTransactionsWrapperColletion = new CallTransactionsWrapperColletion();
        CallTransactionsWrapper objCallTransactionsWrapper = new CallTransactionsWrapper();
		private static readonly string _module = "AdaniCall.Business.BusinessFacade.CallTransactionsBusinessFacade";
		public CallTransactionsBusinessFacade()
        {
            
        }
        public CallTransactionsBusinessFacade(dynamic WrapperType)
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

        public bool Save(CallTransactions objEntity)
        {
            try
            {
                objCallTransactionsWrapper.objWrapperClass = objEntity;
                DataAccess.DataAccessLayer.DataAccess dalObject = new DataAccess.DataAccessLayer.DataAccess();
                Transaction TransObj = new Transaction(dalObject);
                TransObj.ConnectionString = dbClass.SqlConnectString();
                Dictionary<string, Command> CommandsObj = new Dictionary<string, Command>();
                int commandCounter = 0;

                bool result = objCallTransactionsWrapper.Save(ref CommandsObj, ref commandCounter);
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

        public bool UpdateCallTransactions(string strColumns, string strCondition)
        {
            try
            {
                CallTransactionsWrapper objWrapper = new CallTransactionsWrapper();
                objWrapper.UpdateCallTransactions(strColumns, strCondition);
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "UpdateCallTransactions(strColumns=" + strColumns + ",strCondition=" + strCondition + ")", ex.Source, ex.Message, ex);
                return false;
            }

            return true;
        }

        public List<CallTransactions> GetPendingSpeechToText()
        {
            try
            {
                return objCallTransactionsWrapperColletion.GetPendingSpeechToText();
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetPendingSpeechToText()", ex.Source, ex.Message, ex);
            }
            return new List<CallTransactions>();
        }

        public List<CallTransactions> GetPendingAudio()
        {
            try
            {
                return objCallTransactionsWrapperColletion.GetPendingAudio();
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetPendingAudio()", ex.Source, ex.Message, ex);
            }
            return new List<CallTransactions>();
        }

        public List<CallTransactions> GetCallTransactions(Int64 LoginID, string ListType, string search = "")
        {
            List<CallTransactions> _TransactionsList = new List<CallTransactions>();
            try
            {
                _TransactionsList = objCallTransactionsWrapperColletion.GetCallTransactions(LoginID, ListType, search);
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetCallTransactions(LoginID:" + LoginID + ",ListType" + ListType + ",search=" + search + ")", ex.Source, ex.Message, ex);
            }

            return _TransactionsList;
        }

        public List<Analysis> GetAnalysis(Int64 ID)
        {
            List<Analysis> _List = new List<Analysis>();
            try
            {
                _List = objCallTransactionsWrapperColletion.GetAnalysis(ID);
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetAnalysis(ID:" + ID + ")", ex.Source, ex.Message, ex);
            }

            return _List;
        }
    }
}
