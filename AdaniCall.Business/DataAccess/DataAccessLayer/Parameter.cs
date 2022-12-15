using System;
using System.Data;
using System.Configuration;
using System.Web;

/// <summary>
/// Holds the instance to one parameter in the parameter collection used by the Command Class
namespace AdaniCall.Business.DataAccess.DataAccessLayer
{
    public class Parameter
    {
        #region Declarations

        private string _Name;
        private string _ParameterName;
        private object _Value;
        private DataAccess.DataType _Type;
        private int _Size;
        private ParameterDirection _Direction;
        private DataAccess.ParamType _ParameterType;

        #endregion Declarations

        #region Properties

        /// <summary>
        /// Gets or sets the Name Of the Parameter used as the key in the Parameters Collection of the Command Object
        /// </summary>
        public string Name
        {
            get
            { return this._Name; }
            set
            { this._Name = value; }
        }

        /// <summary>
        /// Gets or Sets the Name of the Parameter as used in the Command (Stored Procedure)
        /// </summary>
        public string ParameterName
        {
            get
            { return this._ParameterName; }
            set
            { this._ParameterName = value; }
        }

        /// <summary>
        /// Gets or Sets the Parameter Value
        /// </summary>
        public object Value
        {
            get
            { return this._Value; }
            set
            { this._Value = value; }
        }

        /// <summary>
        /// Gets or Sets the Parameter's DataType (Char, Varchar, Varchar2 or Number)
        /// </summary>
        public DataAccess.DataType Type
        {
            get
            { return this._Type; }
            set
            { this._Type = value; }
        }

        /// <summary>
        /// Gets or Sets the Parameter Size
        /// </summary>
        public int Size
        {
            get
            { return this._Size; }
            set
            { this._Size = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public ParameterDirection Direction
        {
            get
            { return this._Direction; }
            set
            { this._Direction = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DataAccess.ParamType ParameterType
        {
            get
            { return this._ParameterType; }
            set
            { this._ParameterType = value; }
        }

        #endregion Properties

        #region Constructors

        public Parameter()
        {
            // TODO: Add constructor logic here
            this.Direction = ParameterDirection.Input;
            this.ParameterType = DataAccess.ParamType.AddType;
            //
        }
        #endregion Constructors
    }
}
