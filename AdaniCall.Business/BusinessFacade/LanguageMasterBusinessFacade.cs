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

//using System.Web.Mvc;

namespace AdaniCall.Business.BusinessFacade
{
    public class LanguageMasterBusinessFacade//:UniversalObject
    {
        dynamic objdynamicWrapper; 
		LanguageMasterWrapperColletion objLanguageMasterWrapperColletion = new LanguageMasterWrapperColletion();
        LanguageMasterWrapper objLanguageMasterWrapper = new LanguageMasterWrapper();
		private static readonly string _module = "AdaniCall.Business.BusinessFacade.LanguageMasterBusinessFacade";
		public LanguageMasterBusinessFacade()
        {
            
        }
        public LanguageMasterBusinessFacade(dynamic WrapperType)
        {
            objdynamicWrapper = WrapperType; 
        }
        public dynamic GetRecordsList()
        {
            string[,] Sort = new string[1, 2];
            if (objLanguageMasterWrapperColletion.GetRecords(false, Sort))
            {
                return objLanguageMasterWrapperColletion.Items;
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

                objdynamicWrapper.objWrapperClass = objEntity;
                DataAccess.DataAccessLayer.DataAccess dalObject = new DataAccess.DataAccessLayer.DataAccess();
                Transaction TransObj = new Transaction(dalObject);
                TransObj.ConnectionString = dbClass.SqlConnectString();
                Dictionary<string, Command> CommandsObj = new Dictionary<string, Command>();
                int commandCounter = 0;

                bool result = objdynamicWrapper.Save(ref CommandsObj, ref commandCounter);
                TransObj.AddCommandList(CommandsObj);
                if (TransObj.ExecuteTransaction())
                {
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

        public List<LanguageMaster> LanguageMasterList(long SelectedLang = 0)
        {
            LanguageMasterBusinessFacade _LanguageMasterBusinessFacade = new LanguageMasterBusinessFacade();
            try
            {
                return _LanguageMasterBusinessFacade.GetRecordsList();
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "LanguageMasterList()", ex.Source, ex.Message, ex);
            }
            return null;
        }

        public string LanguageNameFromId(string SelectedLang)
        {
            string LanguageName = "";
            try
            {
                List<LanguageMaster> ListSelectListItem = LanguageMasterList();

                if (ListSelectListItem!=null && ListSelectListItem.FindAll(X => X.ID == Convert.ToInt32(SelectedLang)).Count > 0)
                {
                    LanguageName = ListSelectListItem.FindAll(X => X.ID == Convert.ToInt32(SelectedLang))[0].Language;
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "LanguageNameFromId(SelectedLang:" + SelectedLang + ")", ex.Source, ex.Message, ex);
            }

            return LanguageName.ToLower();
        }


    }
}
