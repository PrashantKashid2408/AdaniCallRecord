using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdaniCall.Business.DataAccess.Constants;
using System.Data.SqlClient;
using System.Data;
using AdaniCall.Entity;
using AdaniCall.Entity.Common;
using AdaniCall.Utility.Common;

namespace AdaniCall.Business.DataAccess.Mapper
{
    public class UsersDataMapper
    {
        private static readonly string _module = "AdaniCall.Business.DataAccess.Mapper.UsersDataMapper";
        private Users objUsers = null;

        public Users GetDetails(SqlDataReader sqlDataReader)
        {
            try
            {
                objUsers = new Users();
               
			    if (sqlDataReader.HasColumn(UsersDBFields.ID))
                   objUsers.ID = (sqlDataReader[UsersDBFields.ID] != DBNull.Value ? Convert.ToInt64(sqlDataReader[UsersDBFields.ID]) : 0); 
                if (sqlDataReader.HasColumn(UsersDBFields.UserName))
                   objUsers.UserName = (sqlDataReader[UsersDBFields.UserName] != DBNull.Value ? Convert.ToString(sqlDataReader[UsersDBFields.UserName]) : string.Empty); 
                if (sqlDataReader.HasColumn(UsersDBFields.Password))
                   objUsers.Password = (sqlDataReader[UsersDBFields.Password] != DBNull.Value ? Convert.ToString(sqlDataReader[UsersDBFields.Password]) : string.Empty); 
                if (sqlDataReader.HasColumn(UsersDBFields.FirstName))
                   objUsers.FirstName = (sqlDataReader[UsersDBFields.FirstName] != DBNull.Value ? Convert.ToString(sqlDataReader[UsersDBFields.FirstName]) : string.Empty); 
                if (sqlDataReader.HasColumn(UsersDBFields.LastName))
                   objUsers.LastName = (sqlDataReader[UsersDBFields.LastName] != DBNull.Value ? Convert.ToString(sqlDataReader[UsersDBFields.LastName]) : string.Empty); 
                if (sqlDataReader.HasColumn(UsersDBFields.AlternateEmail))
                   objUsers.AlternateEmail = (sqlDataReader[UsersDBFields.AlternateEmail] != DBNull.Value ? Convert.ToString(sqlDataReader[UsersDBFields.AlternateEmail]) : string.Empty); 
                if (sqlDataReader.HasColumn(UsersDBFields.Profile_Logo))
                   objUsers.Profile_Logo = (sqlDataReader[UsersDBFields.Profile_Logo] != DBNull.Value ? Convert.ToString(sqlDataReader[UsersDBFields.Profile_Logo]) : string.Empty); 
                if (sqlDataReader.HasColumn(UsersDBFields.RoleId))
                   objUsers.RoleId = (sqlDataReader[UsersDBFields.RoleId] != DBNull.Value ? Convert.ToByte(sqlDataReader[UsersDBFields.RoleId]) : (byte)0); 
                if (sqlDataReader.HasColumn(UsersDBFields.ParentId))
                   objUsers.ParentId = (sqlDataReader[UsersDBFields.ParentId] != DBNull.Value ? Convert.ToInt64(sqlDataReader[UsersDBFields.ParentId]) : 0); 
                if (sqlDataReader.HasColumn(UsersDBFields.AgentLocationID))
                   objUsers.AgentLocationID = (sqlDataReader[UsersDBFields.AgentLocationID] != DBNull.Value ? Convert.ToInt32(sqlDataReader[UsersDBFields.AgentLocationID]) : 0); 
                if (sqlDataReader.HasColumn(UsersDBFields.LanguageId))
                   objUsers.LanguageId = (sqlDataReader[UsersDBFields.LanguageId] != DBNull.Value ? Convert.ToInt32(sqlDataReader[UsersDBFields.LanguageId]) : 0);
                if (sqlDataReader.HasColumn(UsersDBFields.KioskID))
                    objUsers.KioskID = (sqlDataReader[UsersDBFields.KioskID] != DBNull.Value ? Convert.ToInt64(sqlDataReader[UsersDBFields.KioskID]) : 0);
                if (sqlDataReader.HasColumn(UsersDBFields.AgentCallID))
                   objUsers.AgentCallID = (sqlDataReader[UsersDBFields.AgentCallID] != DBNull.Value ? Convert.ToString(sqlDataReader[UsersDBFields.AgentCallID]) : string.Empty); 
                if (sqlDataReader.HasColumn(UsersDBFields.IsEmailVerified))
                   objUsers.IsEmailVerified = (sqlDataReader[UsersDBFields.IsEmailVerified] != DBNull.Value ? Convert.ToBoolean(sqlDataReader[UsersDBFields.IsEmailVerified]) : false); 
                if (sqlDataReader.HasColumn(UsersDBFields.EmailVerficationCode))
                    objUsers.EmailVerficationCode = (sqlDataReader[UsersDBFields.EmailVerficationCode] != DBNull.Value ? Convert.ToString(sqlDataReader[UsersDBFields.EmailVerficationCode]) : string.Empty);
                if (sqlDataReader.HasColumn(UsersDBFields.EmailVerificationDate))
                   objUsers.EmailVerificationDate = (sqlDataReader[UsersDBFields.EmailVerificationDate] != DBNull.Value ? Convert.ToDateTime(sqlDataReader[UsersDBFields.EmailVerificationDate]) : DateTime.Now); 
                if (sqlDataReader.HasColumn(UsersDBFields.StatusId))
                   objUsers.StatusId = (sqlDataReader[UsersDBFields.StatusId] != DBNull.Value ? Convert.ToByte(sqlDataReader[UsersDBFields.StatusId]) : (byte)0); 
                if (sqlDataReader.HasColumn(UsersDBFields.CreatedDate))
                   objUsers.CreatedDate = (sqlDataReader[UsersDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(sqlDataReader[UsersDBFields.CreatedDate]) : DateTime.Now); 
                if (sqlDataReader.HasColumn(UsersDBFields.UpdatedDate))
                   objUsers.UpdatedDate = (sqlDataReader[UsersDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(sqlDataReader[UsersDBFields.UpdatedDate]) : DateTime.Now); 
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(sqlDataReader)", ex.Source, ex.Message, ex);
            }
            return objUsers;
        }
		
		public List<Users> GetDetailsList(SqlDataReader sqlDataReader)
        {
            List<Users> list = new List<Users>();
            try
            {
                while (sqlDataReader.Read())
                {
                    objUsers = GetDetails(sqlDataReader);
                    list.Add(objUsers);
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetailsList(sqlDataReader)", ex.Source, ex.Message, ex);
            }
            return list;
        }

        public List<Users> GetDetails(DataSet dataSet)
        {
            List<Users> Userss = new List<Users>();

            try
            {
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drow in dataSet.Tables[0].Rows)
                    {
                        objUsers = new Users();
                       
						if (drow.Table.Columns.Contains(UsersDBFields.ID)) 
                          objUsers.ID = (drow[UsersDBFields.ID] != DBNull.Value ? Convert.ToInt32(drow[UsersDBFields.ID]) : 0); 
                        if (drow.Table.Columns.Contains(UsersDBFields.UserName)) 
                          objUsers.UserName = (drow[UsersDBFields.UserName] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.UserName]) : string.Empty); 
                        if (drow.Table.Columns.Contains(UsersDBFields.Password)) 
                          objUsers.Password = (drow[UsersDBFields.Password] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.Password]) : string.Empty); 
                        if (drow.Table.Columns.Contains(UsersDBFields.FirstName)) 
                          objUsers.FirstName = (drow[UsersDBFields.FirstName] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.FirstName]) : string.Empty); 
                        if (drow.Table.Columns.Contains(UsersDBFields.LastName)) 
                          objUsers.LastName = (drow[UsersDBFields.LastName] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.LastName]) : string.Empty); 
                        if (drow.Table.Columns.Contains(UsersDBFields.AlternateEmail)) 
                          objUsers.AlternateEmail = (drow[UsersDBFields.AlternateEmail] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.AlternateEmail]) : string.Empty); 
                        if (drow.Table.Columns.Contains(UsersDBFields.Profile_Logo)) 
                          objUsers.Profile_Logo = (drow[UsersDBFields.Profile_Logo] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.Profile_Logo]) : string.Empty); 
                        if (drow.Table.Columns.Contains(UsersDBFields.RoleId)) 
                          objUsers.RoleId = (drow[UsersDBFields.RoleId] != DBNull.Value ? Convert.ToByte(drow[UsersDBFields.RoleId]) : (byte)0); 
                        if (drow.Table.Columns.Contains(UsersDBFields.ParentId)) 
                          objUsers.ParentId = (drow[UsersDBFields.ParentId] != DBNull.Value ? Convert.ToInt32(drow[UsersDBFields.ParentId]) : 0); 
                        if (drow.Table.Columns.Contains(UsersDBFields.AgentLocationID)) 
                          objUsers.AgentLocationID = (drow[UsersDBFields.AgentLocationID] != DBNull.Value ? Convert.ToInt32(drow[UsersDBFields.AgentLocationID]) : 0); 
                        if (drow.Table.Columns.Contains(UsersDBFields.LanguageId)) 
                          objUsers.LanguageId = (drow[UsersDBFields.LanguageId] != DBNull.Value ? Convert.ToInt32(drow[UsersDBFields.LanguageId]) : 0); 
                        if (drow.Table.Columns.Contains(UsersDBFields.AgentCallID)) 
                          objUsers.AgentCallID = (drow[UsersDBFields.AgentCallID] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.AgentCallID]) : string.Empty); 
                        if (drow.Table.Columns.Contains(UsersDBFields.IsEmailVerified)) 
                          objUsers.IsEmailVerified = (drow[UsersDBFields.IsEmailVerified] != DBNull.Value ? Convert.ToBoolean(drow[UsersDBFields.IsEmailVerified]) : false); 
                        if (drow.Table.Columns.Contains(UsersDBFields.EmailVerficationCode)) 
                            objUsers.EmailVerficationCode = (drow[UsersDBFields.EmailVerficationCode] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.EmailVerficationCode]) : string.Empty); 
                        if (drow.Table.Columns.Contains(UsersDBFields.EmailVerificationDate)) 
                          objUsers.EmailVerificationDate = (drow[UsersDBFields.EmailVerificationDate] != DBNull.Value ? Convert.ToDateTime(drow[UsersDBFields.EmailVerificationDate]) : DateTime.Now); 
                        if (drow.Table.Columns.Contains(UsersDBFields.StatusId)) 
                          objUsers.StatusId = (drow[UsersDBFields.StatusId] != DBNull.Value ? Convert.ToByte(drow[UsersDBFields.StatusId]) : (byte)0); 
                        if (drow.Table.Columns.Contains(UsersDBFields.CreatedDate)) 
                          objUsers.CreatedDate = (drow[UsersDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(drow[UsersDBFields.CreatedDate]) : DateTime.Now); 
                        if (drow.Table.Columns.Contains(UsersDBFields.UpdatedDate)) 
                          objUsers.UpdatedDate = (drow[UsersDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(drow[UsersDBFields.UpdatedDate]) : DateTime.Now); 

                        Userss.Add(objUsers);
                    }
                }

            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(dataSet)", ex.Source, ex.Message, ex);
            }

            return Userss;
        }
		
		public Users GetDetailsobj(DataSet dataSet)
        {
            Users objUsers = new Users();

            try
            {
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drow in dataSet.Tables[0].Rows)
                    {
                        objUsers = new Users();
                      
						if (drow.Table.Columns.Contains(UsersDBFields.ID)) 
                          objUsers.ID = (drow[UsersDBFields.ID] != DBNull.Value ? Convert.ToInt32(drow[UsersDBFields.ID]) : 0); 
                        if (drow.Table.Columns.Contains(UsersDBFields.UserName)) 
                          objUsers.UserName = (drow[UsersDBFields.UserName] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.UserName]) : string.Empty); 
                        if (drow.Table.Columns.Contains(UsersDBFields.Password)) 
                          objUsers.Password = (drow[UsersDBFields.Password] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.Password]) : string.Empty); 
                        if (drow.Table.Columns.Contains(UsersDBFields.FirstName)) 
                          objUsers.FirstName = (drow[UsersDBFields.FirstName] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.FirstName]) : string.Empty); 
                        if (drow.Table.Columns.Contains(UsersDBFields.LastName)) 
                          objUsers.LastName = (drow[UsersDBFields.LastName] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.LastName]) : string.Empty); 
                        if (drow.Table.Columns.Contains(UsersDBFields.AlternateEmail)) 
                          objUsers.AlternateEmail = (drow[UsersDBFields.AlternateEmail] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.AlternateEmail]) : string.Empty); 
                        if (drow.Table.Columns.Contains(UsersDBFields.Profile_Logo)) 
                          objUsers.Profile_Logo = (drow[UsersDBFields.Profile_Logo] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.Profile_Logo]) : string.Empty); 
                        if (drow.Table.Columns.Contains(UsersDBFields.RoleId)) 
                          objUsers.RoleId = (drow[UsersDBFields.RoleId] != DBNull.Value ? Convert.ToByte(drow[UsersDBFields.RoleId]) : (byte)0); 
                        if (drow.Table.Columns.Contains(UsersDBFields.ParentId)) 
                          objUsers.ParentId = (drow[UsersDBFields.ParentId] != DBNull.Value ? Convert.ToInt32(drow[UsersDBFields.ParentId]) : 0); 
                        if (drow.Table.Columns.Contains(UsersDBFields.AgentLocationID)) 
                          objUsers.AgentLocationID = (drow[UsersDBFields.AgentLocationID] != DBNull.Value ? Convert.ToInt32(drow[UsersDBFields.AgentLocationID]) : 0); 
                        if (drow.Table.Columns.Contains(UsersDBFields.LanguageId)) 
                          objUsers.LanguageId = (drow[UsersDBFields.LanguageId] != DBNull.Value ? Convert.ToInt32(drow[UsersDBFields.LanguageId]) : 0); 
                        if (drow.Table.Columns.Contains(UsersDBFields.AgentCallID)) 
                          objUsers.AgentCallID = (drow[UsersDBFields.AgentCallID] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.AgentCallID]) : string.Empty); 
                        if (drow.Table.Columns.Contains(UsersDBFields.IsEmailVerified)) 
                          objUsers.IsEmailVerified = (drow[UsersDBFields.IsEmailVerified] != DBNull.Value ? Convert.ToBoolean(drow[UsersDBFields.IsEmailVerified]) : false); 
                        if (drow.Table.Columns.Contains(UsersDBFields.EmailVerficationCode)) 
                        if (drow.Table.Columns.Contains(UsersDBFields.EmailVerificationDate)) 
                          objUsers.EmailVerificationDate = (drow[UsersDBFields.EmailVerificationDate] != DBNull.Value ? Convert.ToDateTime(drow[UsersDBFields.EmailVerificationDate]) : DateTime.Now); 
                        if (drow.Table.Columns.Contains(UsersDBFields.StatusId)) 
                          objUsers.StatusId = (drow[UsersDBFields.StatusId] != DBNull.Value ? Convert.ToByte(drow[UsersDBFields.StatusId]) : (byte)0); 
                        if (drow.Table.Columns.Contains(UsersDBFields.CreatedDate)) 
                          objUsers.CreatedDate = (drow[UsersDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(drow[UsersDBFields.CreatedDate]) : DateTime.Now); 
                        if (drow.Table.Columns.Contains(UsersDBFields.UpdatedDate)) 
                          objUsers.UpdatedDate = (drow[UsersDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(drow[UsersDBFields.UpdatedDate]) : DateTime.Now); 

                        
                    }
                }

            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(dataSet)", ex.Source, ex.Message, ex);
            }

            return objUsers;
        }
		
		public Users GetDetails(DataTable dataTable)
        {
            Users objUsers = new Users();

            try
            {
                if (dataTable != null &&  dataTable.Rows.Count > 0)
                {
                    foreach (DataRow drow in dataTable.Rows)
                    {
                        objUsers = new Users();
                      
						if (drow.Table.Columns.Contains(UsersDBFields.ID)) 
                          objUsers.ID = (drow[UsersDBFields.ID] != DBNull.Value ? Convert.ToInt32(drow[UsersDBFields.ID]) : 0); 
                        if (drow.Table.Columns.Contains(UsersDBFields.UserName)) 
                          objUsers.UserName = (drow[UsersDBFields.UserName] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.UserName]) : string.Empty); 
                        if (drow.Table.Columns.Contains(UsersDBFields.Password)) 
                          objUsers.Password = (drow[UsersDBFields.Password] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.Password]) : string.Empty); 
                        if (drow.Table.Columns.Contains(UsersDBFields.FirstName)) 
                          objUsers.FirstName = (drow[UsersDBFields.FirstName] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.FirstName]) : string.Empty); 
                        if (drow.Table.Columns.Contains(UsersDBFields.LastName)) 
                          objUsers.LastName = (drow[UsersDBFields.LastName] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.LastName]) : string.Empty); 
                        if (drow.Table.Columns.Contains(UsersDBFields.AlternateEmail)) 
                          objUsers.AlternateEmail = (drow[UsersDBFields.AlternateEmail] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.AlternateEmail]) : string.Empty); 
                        if (drow.Table.Columns.Contains(UsersDBFields.Profile_Logo)) 
                          objUsers.Profile_Logo = (drow[UsersDBFields.Profile_Logo] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.Profile_Logo]) : string.Empty); 
                        if (drow.Table.Columns.Contains(UsersDBFields.RoleId)) 
                          objUsers.RoleId = (drow[UsersDBFields.RoleId] != DBNull.Value ? Convert.ToByte(drow[UsersDBFields.RoleId]) : (byte)0); 
                        if (drow.Table.Columns.Contains(UsersDBFields.ParentId)) 
                          objUsers.ParentId = (drow[UsersDBFields.ParentId] != DBNull.Value ? Convert.ToInt32(drow[UsersDBFields.ParentId]) : 0); 
                        if (drow.Table.Columns.Contains(UsersDBFields.AgentLocationID)) 
                          objUsers.AgentLocationID = (drow[UsersDBFields.AgentLocationID] != DBNull.Value ? Convert.ToInt32(drow[UsersDBFields.AgentLocationID]) : 0); 
                        if (drow.Table.Columns.Contains(UsersDBFields.LanguageId)) 
                          objUsers.LanguageId = (drow[UsersDBFields.LanguageId] != DBNull.Value ? Convert.ToInt32(drow[UsersDBFields.LanguageId]) : 0); 
                        if (drow.Table.Columns.Contains(UsersDBFields.AgentCallID)) 
                          objUsers.AgentCallID = (drow[UsersDBFields.AgentCallID] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.AgentCallID]) : string.Empty); 
                        if (drow.Table.Columns.Contains(UsersDBFields.IsEmailVerified)) 
                          objUsers.IsEmailVerified = (drow[UsersDBFields.IsEmailVerified] != DBNull.Value ? Convert.ToBoolean(drow[UsersDBFields.IsEmailVerified]) : false); 
                        if (drow.Table.Columns.Contains(UsersDBFields.EmailVerficationCode)) 
                        if (drow.Table.Columns.Contains(UsersDBFields.EmailVerificationDate)) 
                          objUsers.EmailVerificationDate = (drow[UsersDBFields.EmailVerificationDate] != DBNull.Value ? Convert.ToDateTime(drow[UsersDBFields.EmailVerificationDate]) : DateTime.Now); 
                        if (drow.Table.Columns.Contains(UsersDBFields.StatusId)) 
                          objUsers.StatusId = (drow[UsersDBFields.StatusId] != DBNull.Value ? Convert.ToByte(drow[UsersDBFields.StatusId]) : (byte)0); 
                        if (drow.Table.Columns.Contains(UsersDBFields.CreatedDate)) 
                          objUsers.CreatedDate = (drow[UsersDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(drow[UsersDBFields.CreatedDate]) : DateTime.Now); 
                        if (drow.Table.Columns.Contains(UsersDBFields.UpdatedDate)) 
                          objUsers.UpdatedDate = (drow[UsersDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(drow[UsersDBFields.UpdatedDate]) : DateTime.Now); 

                        
                    }
                }

            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(DataTable)", ex.Source, ex.Message, ex);
            }

            return objUsers;
        }

    }
}
