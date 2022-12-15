using System;
using System.Data;
using System.Data.SqlClient;

using System.Configuration;
using System.Web;
using System.Collections.Generic;
using System.Diagnostics;
using AdaniCall.Business.DataAccess.DataAccessLayer.General;

//Compass Error Class Needs To Be Implemented In This Class

/// <summary>
/// Summary description for Transaction
namespace AdaniCall.Business.DataAccess.DataAccessLayer
{
public class Transaction
{
    #region Declarations

    private DataAccess _DALObject;
    private Transaction _Parent;
    private string _Name;
    private string _ConnectionString;
    private SqlConnection _Connection;
    private Dictionary<string,Command> _CommandList;
    private Dictionary<string,Transaction> _TransactionList;
    private DatabaseErrors _DBErrors;
    private bool _Executed=false;
    private bool _CommitTransaction = true;
	private SqlTransaction _DBTransObject;
    public string _Result;
    private string _ReturnID;
    #endregion Declarations

    #region Constructors
    
    /// <summary>
    /// Constructor With the parent DataAccess Object as the parameter. No default constructor is implemented.
    /// </summary>
    public Transaction(DataAccess dalObject)
    {
        this._CommandList = new Dictionary<string, Command>();
        this._TransactionList = new Dictionary<string, Transaction>();
        this.DALObject = dalObject;
    }
    
    #endregion Constructors
    
    #region Properties

    /// <summary>
    /// Gets or Sets the reference to the Parent DataAcess Object
    /// </summary>
    public DataAccess DALObject
    {
        get
        { return this._DALObject; }
        set
        { this._DALObject = value; }
    }

    /// <summary>
    /// Gets or Sets the reference to the Parent Transaction
    /// </summary>
    public Transaction Parent
    {
        get
        { return this._Parent; }
        set
        { this._Parent = value; }
    }
    public string Result
    {
        get
        { return this._Result; }
        set
        { this._Result = value; }
    }
    public string ReturnID
    {
        get
        { return this._ReturnID; }
        set
        { this._ReturnID = value; }
    }
   
    /// <summary>
    /// Get or sets the Connection String used by the Transaction By Default
    /// </summary>
    public string ConnectionString
    {
        get
        { return this._ConnectionString; }
        set
        { this._ConnectionString = value; }
    }

    /// <summary>
    /// Gets or sets the Sql Connection object used by the Transaction
    /// </summary>
    public SqlConnection Connection
    {
        get
        { return this._Connection; }
        set
        { this._Connection = value; }
    }

    /// <summary>
    /// Gets or sets the Name of the transaction
    /// </summary>
    public string Name
    {
        get
        { return this._Name; }
        set
        { this._Name = value; }
    }

    /// <summary>
    /// Gets or sets the Transaction Collection which are nested under this transaction.
    /// </summary>
    public Dictionary<string, Transaction> TransactionList
    {
        get
        { return this._TransactionList; }
        set
        { this._TransactionList = value; }
    }
    
    /// <summary>
    /// Gets or sets the Command Collection which are nested under this transaction.
    /// </summary>
    public Dictionary<string, Command> CommandList
    {
        get
        { return this._CommandList; }
        set
        { this._CommandList = value; }
    }

    
    /// <summary>
    /// Gets the count of Commands in the Command List of the object
    /// </summary>
    public int Count
    {
        get
        { return this._CommandList.Count; }
    }
    
    /// <summary>
    /// This Read-Only property is set to true when the 
    /// </summary>
    public bool Executed
    {
        get
        { return this._Executed; }
    }

    /// <summary>
    /// Gets or Sets the Database Errors Object. This object is set when the transaction faces an error
    /// while executing the commands of the child transactions. If the ExecuteTransaction Method returns a false value,
    /// this object should be checked for detailed information about the error encountered.
    /// </summary>
    public DatabaseErrors DBErrors
    {  
        get
        { return this._DBErrors; }
        set
        { this._DBErrors = value; }
    }


    /// <summary>
    /// Default indexer of the transaction class is the command list.
    /// The transaction list is not used because it will not be used very often
    /// and can be accessed explicitly through its property
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public Command this[string key]
    {
        get
        { return this._CommandList[key]; }
        set
        { this._CommandList[key] = value; }
    }

	public SqlTransaction DBTransObject
	{
		get
		{ return this._DBTransObject; }
		set
		{ this._DBTransObject = value; }
	}

    public bool CommitTransaction
    {
        get
        { return this._CommitTransaction; }
        set
        { this._CommitTransaction = value; }
    }


    #endregion Properties

    #region Methods

    public bool AddCommand(Command Value)
    {
        if(Value.Name == "")
        {
            throw new ArgumentException("Command Added without a Name");
        }
        try
        {
            Value.Parent = this;
            this.CommandList.Add(Value.Name, Value);
            return true;
        }
        catch (Exception ex)
        {
			Debug.Print(ex.ToString());
			return false;
        }
        finally
        {

        }
    }

    public bool AddCommandList(Dictionary<string, Command> commandList)
    {
        try
        {
            foreach (KeyValuePair<string, Command> commandPair in commandList)
            {
                commandPair.Value.Parent = this;
                this.CommandList.Add(commandPair.Key, commandPair.Value);
            }
            return true;
        }
        catch (Exception ex)
        {
			Debug.Print(ex.ToString());
			return false;
        }
        finally
        { }

    }
    public bool AddTransaction(Transaction Value)
    {
        if (Value.Name.Trim() == "")
        {
            throw new ArgumentException("Transaction Added without a Name");
        }
        try
        {
            Value.Parent = this.Parent;
            this.TransactionList.Add(Value.Name, Value);
            return true;
        }
        catch (Exception ex)
        {
			Debug.Print(ex.ToString());
			return false;
        }
        finally
        {

        }
    }
    /// <summary>
    /// Executes all the Commands in the Transaction List in the order of their insertion.
    /// </summary>
    /// <returns>
    ///     Returns if the execution of the transaction has completed successfully or not.
    ///     If the method returns a false value, then the DBError Property of this object should be used to retrieve and display the detailed error.
    ///  </returns>
    public bool ExecuteTransaction()
    {
		//bool connectionAvailable = true;
        try
        {
            /*using(TransactionScope scope = new TransactionScope())
            {*/
                if(this.Connection == null)
                {
                    this.Connection = new SqlConnection(this.ConnectionString);
                    this.Connection.Open();
					//connectionAvailable = false;
                }
                this.DBTransObject = this.Connection.BeginTransaction();
                Debug.Print("Begin Transaction: " + this.Name + "**************");
                foreach (KeyValuePair <string, Command> c in this.CommandList)
	            {
                    Command command = c.Value;
                    if (command.Connection == null)
                    {
                        command.Connection = this.Connection;
                    }
                    if (!command.Execute(this.DBTransObject))
                    {
                        this.DBErrors = command.DBErrors;
                        this.DBTransObject.Rollback();
                        return false;
                    }
                    else
                    { this.ReturnID = command.ReturnID; }//Edit By tofan 03/June/2013
	            }
                if (this.CommitTransaction)
                {
                  
                    this.DBTransObject.Commit();
                }
                Debug.Print("End Transaction: " + this.Name + "**************");
               /* scope.Complete();
            }*/
            return true;
        }
        catch (SqlException ex)
        {
                AdaniCall.Utility.Common.Log.WriteLog("DataAccess.Transaction", "ExecuteTransaction", ex.Source, ex.Message);
            this.DBErrors = new DatabaseErrors(ex.ToString(), DatabaseErrors.errorType.DatabaseError, "Data Access Layer");
            //trans.Rollback();
            return false;
        }
        catch (Exception ex)
        {
                AdaniCall.Utility.Common.Log.WriteLog("DataAccess.Transaction", "ExecuteTransaction", ex.Source, ex.Message);
            return false;
        }
        finally
        {
            //if (this.Connection.State == ConnectionState.Open && connectionAvailable == false)
            //{
            //    this.Connection.Close();
            //    this.Connection.Dispose();
            //}
            if (this.Connection.State == ConnectionState.Open)
            {
                this.Connection.Close();
                this.Connection.Dispose();
            }
        }
    }
    #endregion Methods
}
}