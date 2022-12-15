using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Collections.Generic;
using AdaniCall.Business.DataAccess.DataAccessLayer;
namespace AdaniCall.Business.DataAccess.DataAccessLayer.General
{
/// <summary>
/// This interface will be used by all the collection classes.
/// </summary>
public interface UniversalCollection
{

    //----------------------------------Properties----------------------------------//
    /// <summary>
    /// (Dataset) Dataset containing all the records for the children.
    /// </summary>
    /// 
    ////DataSet Records
    ////{
    ////    get;
    ////    set;
    ////}

    /// <summary>
    /// (Object Array) Object containing an object array for the children.
    /// </summary>
    /// 
    ////Object[] Items
    ////{
    ////    get;
    ////    set;
    ////}

    //-----------------------------------Methods-----------------------------------//

    /// <summary>
    /// Gets all elements in the database and populates the Records dataset.
    /// </summary>
    /// <param name="createDataSet">Create Dataset or Object Array</param>
    /// <param name="sortFields">Sort fields array</param>
    /// <returns>Returns true or false</returns>
    bool GetRecords(bool createDataSet, string[,] sortFields);

    /// <summary>
    /// Gets all the records that satiate the selection criteria given in the 
    /// Search String and populates the Records dataset. 
    /// </summary>
    /// <param name="searchString"></param>
    /// <param name="createDataSet">To create dataset property if the value is true else it would return Object array property</param>
    /// <param name="sortFields">Sort field array</param>
    /// <returns>Returns true or false</returns>
    bool Search(string searchString, bool createDataSet, string[,] sortFields);

    /// <summary>
    /// Gets all the records that satiate the selection criteria given in the 
    /// Search String and populates the Records dataset.
    /// </summary>
    /// <param name="fieldName">Field Name</param>
    /// <param name="fieldValue">Field value</param>
    /// <param name="createDataSet">To create dataset property if the value is true else it would return Object array property</param>
    /// <param name="sortFields">Sort field array</param>
    /// <returns></returns>
    bool Search(string fieldName, string fieldValue, bool createDataSet, string[,] sortFields);

    /// <summary>
    /// Returns a datarow for the given Primary Key Value.
    /// </summary>
    /// <param name="id">Primary key id</param>
    /// <returns>Returns true or false</returns>
    Object GetRecordById(int id);

    /// <summary>
    /// Returns a datarow record for the fieldname and value pair. 
    /// The top 1 record, sorted by the primary key, should be used for the purpose. 
    /// For more than one record, the Search method should be used.
    /// </summary>
    /// <param name="fieldName">Field name</param>
    /// <param name="value">Field Value</param>
    /// <returns>Returns true or false</returns>
    Object GetRecordByValue(string fieldName, string value);

    /// <summary>
    /// Deletes the records for comma separated Primary Key IDs of the records.
    /// </summary>
    /// <param name="ids">Comma separated primary ids value</param>
    /// <returns>Returns true or false</returns>
    bool Delete(string ids, ref Dictionary<string, Command> commandList, ref int commandCounter);

    /// <summary>
    /// Saves all the records in the collection. 
    /// This can be implemented in two ways:
    /// 1.	Write a save method to bulk save all the child objects which have 
    ///     their objectChanged Property set to true.
    /// 2.	Call the save method of the child objects which have 
    ///     their objectChanged Property set to true.
    /// </summary>
    /// <returns>Returns true or false</returns>
    bool Save(ref Dictionary<string, Command> commandList, ref int commandCounter);
}

public interface UniversalCollectionNew
{

    //----------------------------------Properties----------------------------------//
    /// <summary>
    /// (List of the object class Type containing all the records for the children.
    /// Not defined in the interface as generic list can't be defined in the interface without specifying the type.
    /// </summary>
    
    //-----------------------------------Methods-----------------------------------//

    /// <summary>
    /// Gets all elements in the database and populates the Records dataset.
    /// </summary>
    /// <returns>Returns true or false</returns>
    bool GetRecords(bool createDataSet, string[,] sortFields);

    /// <summary>
    /// Gets all the records that satiate the selection criteria given in the 
    /// Search String and populates the Records dataset. 
    /// </summary>
    /// <param name="searchString"></param>
    /// <param name="sortString">Sort field array</param>
    /// <returns>Returns true or false</returns>
    bool Search(string searchString, string[,] sortString);

    /// <summary>
    /// Gets all the records that satiate the selection criteria given in the 
    /// Search String and populates the Records dataset.
    /// </summary>
    /// <param name="fieldName">Field Name</param>
    /// <param name="fieldValue">Field value</param>
    /// <param name="sortString">Sort field array</param>
    /// <returns></returns>
    bool Search(string fieldName, string fieldValue, string[,] sortString);

    /// <summary>
    /// Returns a datarow for the given Primary Key Value.
    /// </summary>
    /// <param name="id">Primary key id</param>
    /// <returns>Returns true or false</returns>
    Object GetRecordById(int id);

    /// <summary>
    /// Returns a datarow record for the fieldname and value pair. 
    /// The top 1 record, sorted by the primary key, should be used for the purpose. 
    /// For more than one record, the Search method should be used.
    /// </summary>
    /// <param name="fieldName">Field name</param>
    /// <param name="value">Field Value</param>
    /// <returns>Returns true or false</returns>
    Object GetRecordByValue(string fieldName, string value);

    /// <summary>
    /// Deletes the records for comma separated Primary Key IDs of the records.
    /// </summary>
    /// <param name="ids">Comma separated primary ids value</param>
    /// <returns>Returns true or false</returns>
    bool Delete(string ids, ref Dictionary<string, Command> commandList, ref int commandCounter);

    /// <summary>
    /// Saves all the records in the collection. 
    /// This can be implemented in two ways:
    /// 1.	Write a save method to bulk save all the child objects which have 
    ///     their objectChanged Property set to true.
    /// 2.	Call the save method of the child objects which have 
    ///     their objectChanged Property set to true.
    /// </summary>
    /// <returns>Returns true or false</returns>
    bool Save(ref Dictionary<string, Command> commandList, ref int commandCounter);
}

/// <summary>
/// This interface will be used by all the classes except collection classes.
/// </summary>
public interface UniversalObject
{
    //----------------------------------Properties----------------------------------//
    /// <summary>
    /// This property will be set if any of the properties are changed 
    /// (from the existing value) after the constructor populates the class. 
    /// While setting the values, if the values are same as the previous value, 
    /// the flag will not be set. Intended to be used during the save operation, 
    /// if the actually saving is required or not.
    /// </summary>
    bool ObjectChanged
    {
        get;
        set;
    }

    //-----------------------------------Methods-----------------------------------//
    /// <summary>
    /// Populates the object for the given Id
    /// </summary>
    /// <param name="id">Pass the primary id</param>
    /// <returns>Returns true or false</returns>
    bool GetRecordById(int id);

    /// <summary>
    /// Populates the object for the fieldName and value pair. 
    /// The top 1 record, sorted by the primary key, should be used 
    /// for the purpose. For more than one record, the Search method 
    /// of the collection class should be used.
    /// </summary>
    /// <param name="fieldName">Field Name</param>
    /// <param name="value">Field Value</param>
    /// <returns>Returns true or false</returns>
    bool GetRecordByValue(string fieldName, string value);

    /// <summary>
    /// Populates the object for the array of fieldName and value pairs.
    /// The top 1 record, sorted by the primary key, should be used 
    /// for the purpose. For more than one record, the Search method 
    /// of the collection class should be used.
    /// </summary>
    /// <param name="fieldNames">string array of fieldNames</param>
    /// <param name="values">string array of values</param>
    /// <returns>Returns true or false</returns>
    bool GetRecordByValue(string[] fieldNames, string[] values);

    /// <summary>
    /// Saves the object data to the database with a new primary key. 
    /// Usually a insert SP should be called from here. If the object 
    /// contains the primary key (i.e. for previously saved record) 
    /// then update method should be called internally. (This will make 
    /// the user class indifferent to the fact if is a first save or not.)
    /// </summary>
    /// <returns>Returns true or false</returns>
    bool Save(ref Dictionary<string, Command> commandList, ref int commandCounter);

    /// <summary>
    /// Save the object data to the database under the same primary key. 
    /// (Will throw exception if there is no primary key.
    /// </summary>
    /// <returns>Returns true or false</returns>
    bool Update(ref Dictionary<string, Command> commandList, ref int commandCounter);

    /// <summary>
    /// Deletes the record from the database for the given primary key.
    /// </summary>
    /// <returns>Returns true or false</returns>
    bool Delete(ref Dictionary<string, Command> commandList, ref int commandCounter);


   // bool Delete(string ids, string ISDeleteColumnName, string ISDELETEVALUE, ref Dictionary<string, Command> commandList, ref int commandCounter);

    /// <summary>
    /// Saves the object data to the database with a new primary 
    /// key (Even if the object has a primary key)
    /// </summary>
    /// 
    /// <returns>Returns true or false</returns>
    bool SaveCopy();

    /// <summary>
    /// Moves the object data under a new primary key. This is equivalent 
    /// to calling the saveCopy Method followed by the delete Method.
    /// </summary>
    /// <returns>Returns true or false</returns>
    bool Move();

    /// <summary>
    /// Default report for any object, if exists, should be implemented here. 
    /// Or optionally a list of possible reports can be displayed for selection.
    /// </summary>
    /// <returns>Returns true or false</returns>
    bool Print();
}
}