using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace  AdaniCall.Entity
{
    public class LocationMaster
    {
        #region Declarations

         private bool _boolObjectChanged;
private int _intID;
private string _strLocationName;
private byte _bytLocationType;
private byte _bytStatusId;
private DateTime _datCreatedDate;
private DateTime _datUpdatedDate;


        #endregion Declarations

        #region Properties

         public bool ObjectChanged
 { 
    get { return this._boolObjectChanged; } 
    set { this._boolObjectChanged = value; }
 } 

 public int ID
 { 
    get { return this._intID; } 
    set { this._intID = value; }
 } 

 public string LocationName
 { 
    get { return this._strLocationName; } 
    set { this._strLocationName = value; }
 } 

 public byte LocationType
 { 
    get { return this._bytLocationType; } 
    set { this._bytLocationType = value; }
 } 

 public byte StatusId
 { 
    get { return this._bytStatusId; } 
    set { this._bytStatusId = value; }
 } 

 public DateTime CreatedDate
 { 
    get { return this._datCreatedDate; } 
    set { this._datCreatedDate = value; }
 } 

 public DateTime UpdatedDate
 { 
    get { return this._datUpdatedDate; } 
    set { this._datUpdatedDate = value; }
 } 



        #endregion Properties
    }
}
