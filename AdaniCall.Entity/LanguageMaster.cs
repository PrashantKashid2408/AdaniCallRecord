using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdaniCall.Entity
{
    public class LanguageMaster
    {
        #region Declarations

        private bool _boolObjectChanged;
        private int _intId;
        private string _strLanguage;
        private byte _bytStatusId;
        private DateTime _datCreatedDate;


        #endregion Declarations

        #region Properties

         public bool ObjectChanged
         { 
            get { return this._boolObjectChanged; } 
            set { this._boolObjectChanged = value; }
         } 

         public int ID
         { 
            get { return this._intId; } 
            set { this._intId = value; }
         } 

         public string Language
         { 
            get { return this._strLanguage; } 
            set { this._strLanguage = value; }
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



        #endregion Properties
    }
}
