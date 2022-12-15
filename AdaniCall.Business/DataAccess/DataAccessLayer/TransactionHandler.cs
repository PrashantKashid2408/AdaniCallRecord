using AdaniCall.Utility.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace AdaniCall.Business.DataAccess.DataAccessLayer
{
    public class TransactionHandler
    {
        public TransactionHandler()
        {

        }

        public bool ExecuteUserTransactions(Dictionary<string, Command> commandList)
        {
            bool retValue = false;

            try
            {
                AdaniCall.Business.DataAccess.DataAccessLayer.DataAccess objDataAccess = new AdaniCall.Business.DataAccess.DataAccessLayer.DataAccess();
                Transaction objTransaction = new Transaction(objDataAccess);
                objTransaction.ConnectionString = dbClass.SqlConnectString();
                objTransaction.AddCommandList(commandList);

                if (objTransaction.ExecuteTransaction())
                    retValue = true;                    
            }
            catch (Exception ex)
            {
                Log.WriteLog("", "", ex.Source, ex.Message);
            }

            return retValue;
        }


    }
}
