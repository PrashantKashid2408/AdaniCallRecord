using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace  AdaniCall.Entity
{
    public class Roles
    {
        #region Declarations

         private bool _boolObjectChanged;
private byte _bytID;
private string _strRoleName;
private byte _bytStatusId;
private DateTime _datCreatedDate;
private string _strRoleLevel;


        #endregion Declarations

        #region Properties

         public bool ObjectChanged
 { 
    get { return this._boolObjectChanged; } 
    set { this._boolObjectChanged = value; }
 } 

 public byte ID
 { 
    get { return this._bytID; } 
    set { this._bytID = value; }
 } 

 public string RoleName
 { 
    get { return this._strRoleName; } 
    set { this._strRoleName = value; }
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

 public string RoleLevel
 { 
    get { return this._strRoleLevel; } 
    set { this._strRoleLevel = value; }
 } 



        #endregion Properties
    }
}
