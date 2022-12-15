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
    public class KioskMasterDataMapper
    {
        private static readonly string _module = "AdaniCall.Business.DataAccess.Mapper.KioskMasterDataMapper";
        private KioskMaster objKioskMaster = null;

        public KioskMaster GetDetails(SqlDataReader sqlDataReader)
        {
            try
            {
                objKioskMaster = new KioskMaster();
               
			    if (sqlDataReader.HasColumn(KioskMasterDBFields.ID))
                   objKioskMaster.ID = (sqlDataReader[KioskMasterDBFields.ID] != DBNull.Value ? Convert.ToInt64(sqlDataReader[KioskMasterDBFields.ID]) : 0); 
                if (sqlDataReader.HasColumn(KioskMasterDBFields.UserName))
                   objKioskMaster.UserName = (sqlDataReader[KioskMasterDBFields.UserName] != DBNull.Value ? Convert.ToString(sqlDataReader[KioskMasterDBFields.UserName]) : string.Empty); 
                if (sqlDataReader.HasColumn(KioskMasterDBFields.Password))
                   objKioskMaster.Password = (sqlDataReader[KioskMasterDBFields.Password] != DBNull.Value ? Convert.ToString(sqlDataReader[KioskMasterDBFields.Password]) : string.Empty); 
                if (sqlDataReader.HasColumn(KioskMasterDBFields.TravellerCallerID))
                   objKioskMaster.TravellerCallerID = (sqlDataReader[KioskMasterDBFields.TravellerCallerID] != DBNull.Value ? Convert.ToString(sqlDataReader[KioskMasterDBFields.TravellerCallerID]) : string.Empty); 
                if (sqlDataReader.HasColumn(KioskMasterDBFields.LocationID))
                   objKioskMaster.LocationID = (sqlDataReader[KioskMasterDBFields.LocationID] != DBNull.Value ? Convert.ToInt32(sqlDataReader[KioskMasterDBFields.LocationID]) : 0); 
                if (sqlDataReader.HasColumn(KioskMasterDBFields.LocationID2))
                   objKioskMaster.LocationID2 = (sqlDataReader[KioskMasterDBFields.LocationID2] != DBNull.Value ? Convert.ToInt32(sqlDataReader[KioskMasterDBFields.LocationID2]) : 0); 
                if (sqlDataReader.HasColumn(KioskMasterDBFields.LocationID3))
                   objKioskMaster.LocationID3 = (sqlDataReader[KioskMasterDBFields.LocationID3] != DBNull.Value ? Convert.ToInt32(sqlDataReader[KioskMasterDBFields.LocationID3]) : 0); 
                if (sqlDataReader.HasColumn(KioskMasterDBFields.DeviceName))
                   objKioskMaster.DeviceName = (sqlDataReader[KioskMasterDBFields.DeviceName] != DBNull.Value ? Convert.ToString(sqlDataReader[KioskMasterDBFields.DeviceName]) : string.Empty); 
                if (sqlDataReader.HasColumn(KioskMasterDBFields.OperatingSystem))
                   objKioskMaster.OperatingSystem = (sqlDataReader[KioskMasterDBFields.OperatingSystem] != DBNull.Value ? Convert.ToString(sqlDataReader[KioskMasterDBFields.OperatingSystem]) : string.Empty); 
                if (sqlDataReader.HasColumn(KioskMasterDBFields.DeviceType))
                   objKioskMaster.DeviceType = (sqlDataReader[KioskMasterDBFields.DeviceType] != DBNull.Value ? Convert.ToString(sqlDataReader[KioskMasterDBFields.DeviceType]) : string.Empty); 
                if (sqlDataReader.HasColumn(KioskMasterDBFields.DeviceModel))
                   objKioskMaster.DeviceModel = (sqlDataReader[KioskMasterDBFields.DeviceModel] != DBNull.Value ? Convert.ToString(sqlDataReader[KioskMasterDBFields.DeviceModel]) : string.Empty); 
                if (sqlDataReader.HasColumn(KioskMasterDBFields.StatusId))
                   objKioskMaster.StatusId = (sqlDataReader[KioskMasterDBFields.StatusId] != DBNull.Value ? Convert.ToByte(sqlDataReader[KioskMasterDBFields.StatusId]) : (byte)0); 
                if (sqlDataReader.HasColumn(KioskMasterDBFields.CreatedDate))
                   objKioskMaster.CreatedDate = (sqlDataReader[KioskMasterDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(sqlDataReader[KioskMasterDBFields.CreatedDate]) : DateTime.Now); 
                if (sqlDataReader.HasColumn(KioskMasterDBFields.UpdatedDate))
                   objKioskMaster.UpdatedDate = (sqlDataReader[KioskMasterDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(sqlDataReader[KioskMasterDBFields.UpdatedDate]) : DateTime.Now); 

            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(sqlDataReader)", ex.Source, ex.Message, ex);
            }
            return objKioskMaster;
        }
		
		public List<KioskMaster> GetDetailsList(SqlDataReader sqlDataReader)
        {
            List<KioskMaster> list = new List<KioskMaster>();
            try
            {
                while (sqlDataReader.Read())
                {
                    objKioskMaster = GetDetails(sqlDataReader);
                    list.Add(objKioskMaster);
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetailsList(sqlDataReader)", ex.Source, ex.Message, ex);
            }
            return list;
        }

        public List<KioskMaster> GetDetails(DataSet dataSet)
        {
            List<KioskMaster> KioskMasters = new List<KioskMaster>();

            try
            {
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drow in dataSet.Tables[0].Rows)
                    {
                        objKioskMaster = new KioskMaster();
                       
						if (drow.Table.Columns.Contains(KioskMasterDBFields.ID)) 
  objKioskMaster.ID = (drow[KioskMasterDBFields.ID] != DBNull.Value ? Convert.ToInt32(drow[KioskMasterDBFields.ID]) : 0); 
if (drow.Table.Columns.Contains(KioskMasterDBFields.UserName)) 
  objKioskMaster.UserName = (drow[KioskMasterDBFields.UserName] != DBNull.Value ? Convert.ToString(drow[KioskMasterDBFields.UserName]) : string.Empty); 
if (drow.Table.Columns.Contains(KioskMasterDBFields.Password)) 
  objKioskMaster.Password = (drow[KioskMasterDBFields.Password] != DBNull.Value ? Convert.ToString(drow[KioskMasterDBFields.Password]) : string.Empty); 
if (drow.Table.Columns.Contains(KioskMasterDBFields.TravellerCallerID)) 
  objKioskMaster.TravellerCallerID = (drow[KioskMasterDBFields.TravellerCallerID] != DBNull.Value ? Convert.ToString(drow[KioskMasterDBFields.TravellerCallerID]) : string.Empty); 
if (drow.Table.Columns.Contains(KioskMasterDBFields.LocationID)) 
  objKioskMaster.LocationID = (drow[KioskMasterDBFields.LocationID] != DBNull.Value ? Convert.ToInt32(drow[KioskMasterDBFields.LocationID]) : 0); 
if (drow.Table.Columns.Contains(KioskMasterDBFields.LocationID2)) 
  objKioskMaster.LocationID2 = (drow[KioskMasterDBFields.LocationID2] != DBNull.Value ? Convert.ToInt32(drow[KioskMasterDBFields.LocationID2]) : 0); 
if (drow.Table.Columns.Contains(KioskMasterDBFields.LocationID3)) 
  objKioskMaster.LocationID3 = (drow[KioskMasterDBFields.LocationID3] != DBNull.Value ? Convert.ToInt32(drow[KioskMasterDBFields.LocationID3]) : 0); 
if (drow.Table.Columns.Contains(KioskMasterDBFields.DeviceName)) 
  objKioskMaster.DeviceName = (drow[KioskMasterDBFields.DeviceName] != DBNull.Value ? Convert.ToString(drow[KioskMasterDBFields.DeviceName]) : string.Empty); 
if (drow.Table.Columns.Contains(KioskMasterDBFields.OperatingSystem)) 
  objKioskMaster.OperatingSystem = (drow[KioskMasterDBFields.OperatingSystem] != DBNull.Value ? Convert.ToString(drow[KioskMasterDBFields.OperatingSystem]) : string.Empty); 
if (drow.Table.Columns.Contains(KioskMasterDBFields.DeviceType)) 
  objKioskMaster.DeviceType = (drow[KioskMasterDBFields.DeviceType] != DBNull.Value ? Convert.ToString(drow[KioskMasterDBFields.DeviceType]) : string.Empty); 
if (drow.Table.Columns.Contains(KioskMasterDBFields.DeviceModel)) 
  objKioskMaster.DeviceModel = (drow[KioskMasterDBFields.DeviceModel] != DBNull.Value ? Convert.ToString(drow[KioskMasterDBFields.DeviceModel]) : string.Empty); 
if (drow.Table.Columns.Contains(KioskMasterDBFields.StatusId)) 
  objKioskMaster.StatusId = (drow[KioskMasterDBFields.StatusId] != DBNull.Value ? Convert.ToByte(drow[KioskMasterDBFields.StatusId]) : (byte)0); 
if (drow.Table.Columns.Contains(KioskMasterDBFields.CreatedDate)) 
  objKioskMaster.CreatedDate = (drow[KioskMasterDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(drow[KioskMasterDBFields.CreatedDate]) : DateTime.Now); 
if (drow.Table.Columns.Contains(KioskMasterDBFields.UpdatedDate)) 
  objKioskMaster.UpdatedDate = (drow[KioskMasterDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(drow[KioskMasterDBFields.UpdatedDate]) : DateTime.Now); 


                        KioskMasters.Add(objKioskMaster);
                    }
                }

            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(dataSet)", ex.Source, ex.Message, ex);
            }

            return KioskMasters;
        }
		
		public KioskMaster GetDetailsobj(DataSet dataSet)
        {
            KioskMaster objKioskMaster = new KioskMaster();

            try
            {
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drow in dataSet.Tables[0].Rows)
                    {
                        objKioskMaster = new KioskMaster();
                      
						if (drow.Table.Columns.Contains(KioskMasterDBFields.ID)) 
  objKioskMaster.ID = (drow[KioskMasterDBFields.ID] != DBNull.Value ? Convert.ToInt32(drow[KioskMasterDBFields.ID]) : 0); 
if (drow.Table.Columns.Contains(KioskMasterDBFields.UserName)) 
  objKioskMaster.UserName = (drow[KioskMasterDBFields.UserName] != DBNull.Value ? Convert.ToString(drow[KioskMasterDBFields.UserName]) : string.Empty); 
if (drow.Table.Columns.Contains(KioskMasterDBFields.Password)) 
  objKioskMaster.Password = (drow[KioskMasterDBFields.Password] != DBNull.Value ? Convert.ToString(drow[KioskMasterDBFields.Password]) : string.Empty); 
if (drow.Table.Columns.Contains(KioskMasterDBFields.TravellerCallerID)) 
  objKioskMaster.TravellerCallerID = (drow[KioskMasterDBFields.TravellerCallerID] != DBNull.Value ? Convert.ToString(drow[KioskMasterDBFields.TravellerCallerID]) : string.Empty); 
if (drow.Table.Columns.Contains(KioskMasterDBFields.LocationID)) 
  objKioskMaster.LocationID = (drow[KioskMasterDBFields.LocationID] != DBNull.Value ? Convert.ToInt32(drow[KioskMasterDBFields.LocationID]) : 0); 
if (drow.Table.Columns.Contains(KioskMasterDBFields.LocationID2)) 
  objKioskMaster.LocationID2 = (drow[KioskMasterDBFields.LocationID2] != DBNull.Value ? Convert.ToInt32(drow[KioskMasterDBFields.LocationID2]) : 0); 
if (drow.Table.Columns.Contains(KioskMasterDBFields.LocationID3)) 
  objKioskMaster.LocationID3 = (drow[KioskMasterDBFields.LocationID3] != DBNull.Value ? Convert.ToInt32(drow[KioskMasterDBFields.LocationID3]) : 0); 
if (drow.Table.Columns.Contains(KioskMasterDBFields.DeviceName)) 
  objKioskMaster.DeviceName = (drow[KioskMasterDBFields.DeviceName] != DBNull.Value ? Convert.ToString(drow[KioskMasterDBFields.DeviceName]) : string.Empty); 
if (drow.Table.Columns.Contains(KioskMasterDBFields.OperatingSystem)) 
  objKioskMaster.OperatingSystem = (drow[KioskMasterDBFields.OperatingSystem] != DBNull.Value ? Convert.ToString(drow[KioskMasterDBFields.OperatingSystem]) : string.Empty); 
if (drow.Table.Columns.Contains(KioskMasterDBFields.DeviceType)) 
  objKioskMaster.DeviceType = (drow[KioskMasterDBFields.DeviceType] != DBNull.Value ? Convert.ToString(drow[KioskMasterDBFields.DeviceType]) : string.Empty); 
if (drow.Table.Columns.Contains(KioskMasterDBFields.DeviceModel)) 
  objKioskMaster.DeviceModel = (drow[KioskMasterDBFields.DeviceModel] != DBNull.Value ? Convert.ToString(drow[KioskMasterDBFields.DeviceModel]) : string.Empty); 
if (drow.Table.Columns.Contains(KioskMasterDBFields.StatusId)) 
  objKioskMaster.StatusId = (drow[KioskMasterDBFields.StatusId] != DBNull.Value ? Convert.ToByte(drow[KioskMasterDBFields.StatusId]) : (byte)0); 
if (drow.Table.Columns.Contains(KioskMasterDBFields.CreatedDate)) 
  objKioskMaster.CreatedDate = (drow[KioskMasterDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(drow[KioskMasterDBFields.CreatedDate]) : DateTime.Now); 
if (drow.Table.Columns.Contains(KioskMasterDBFields.UpdatedDate)) 
  objKioskMaster.UpdatedDate = (drow[KioskMasterDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(drow[KioskMasterDBFields.UpdatedDate]) : DateTime.Now); 

                        
                    }
                }

            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(dataSet)", ex.Source, ex.Message, ex);
            }

            return objKioskMaster;
        }
		
		public KioskMaster GetDetails(DataTable dataTable)
        {
            KioskMaster objKioskMaster = new KioskMaster();

            try
            {
                if (dataTable != null &&  dataTable.Rows.Count > 0)
                {
                    foreach (DataRow drow in dataTable.Rows)
                    {
                        objKioskMaster = new KioskMaster();
                      
						if (drow.Table.Columns.Contains(KioskMasterDBFields.ID)) 
  objKioskMaster.ID = (drow[KioskMasterDBFields.ID] != DBNull.Value ? Convert.ToInt32(drow[KioskMasterDBFields.ID]) : 0); 
if (drow.Table.Columns.Contains(KioskMasterDBFields.UserName)) 
  objKioskMaster.UserName = (drow[KioskMasterDBFields.UserName] != DBNull.Value ? Convert.ToString(drow[KioskMasterDBFields.UserName]) : string.Empty); 
if (drow.Table.Columns.Contains(KioskMasterDBFields.Password)) 
  objKioskMaster.Password = (drow[KioskMasterDBFields.Password] != DBNull.Value ? Convert.ToString(drow[KioskMasterDBFields.Password]) : string.Empty); 
if (drow.Table.Columns.Contains(KioskMasterDBFields.TravellerCallerID)) 
  objKioskMaster.TravellerCallerID = (drow[KioskMasterDBFields.TravellerCallerID] != DBNull.Value ? Convert.ToString(drow[KioskMasterDBFields.TravellerCallerID]) : string.Empty); 
if (drow.Table.Columns.Contains(KioskMasterDBFields.LocationID)) 
  objKioskMaster.LocationID = (drow[KioskMasterDBFields.LocationID] != DBNull.Value ? Convert.ToInt32(drow[KioskMasterDBFields.LocationID]) : 0); 
if (drow.Table.Columns.Contains(KioskMasterDBFields.LocationID2)) 
  objKioskMaster.LocationID2 = (drow[KioskMasterDBFields.LocationID2] != DBNull.Value ? Convert.ToInt32(drow[KioskMasterDBFields.LocationID2]) : 0); 
if (drow.Table.Columns.Contains(KioskMasterDBFields.LocationID3)) 
  objKioskMaster.LocationID3 = (drow[KioskMasterDBFields.LocationID3] != DBNull.Value ? Convert.ToInt32(drow[KioskMasterDBFields.LocationID3]) : 0); 
if (drow.Table.Columns.Contains(KioskMasterDBFields.DeviceName)) 
  objKioskMaster.DeviceName = (drow[KioskMasterDBFields.DeviceName] != DBNull.Value ? Convert.ToString(drow[KioskMasterDBFields.DeviceName]) : string.Empty); 
if (drow.Table.Columns.Contains(KioskMasterDBFields.OperatingSystem)) 
  objKioskMaster.OperatingSystem = (drow[KioskMasterDBFields.OperatingSystem] != DBNull.Value ? Convert.ToString(drow[KioskMasterDBFields.OperatingSystem]) : string.Empty); 
if (drow.Table.Columns.Contains(KioskMasterDBFields.DeviceType)) 
  objKioskMaster.DeviceType = (drow[KioskMasterDBFields.DeviceType] != DBNull.Value ? Convert.ToString(drow[KioskMasterDBFields.DeviceType]) : string.Empty); 
if (drow.Table.Columns.Contains(KioskMasterDBFields.DeviceModel)) 
  objKioskMaster.DeviceModel = (drow[KioskMasterDBFields.DeviceModel] != DBNull.Value ? Convert.ToString(drow[KioskMasterDBFields.DeviceModel]) : string.Empty); 
if (drow.Table.Columns.Contains(KioskMasterDBFields.StatusId)) 
  objKioskMaster.StatusId = (drow[KioskMasterDBFields.StatusId] != DBNull.Value ? Convert.ToByte(drow[KioskMasterDBFields.StatusId]) : (byte)0); 
if (drow.Table.Columns.Contains(KioskMasterDBFields.CreatedDate)) 
  objKioskMaster.CreatedDate = (drow[KioskMasterDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(drow[KioskMasterDBFields.CreatedDate]) : DateTime.Now); 
if (drow.Table.Columns.Contains(KioskMasterDBFields.UpdatedDate)) 
  objKioskMaster.UpdatedDate = (drow[KioskMasterDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(drow[KioskMasterDBFields.UpdatedDate]) : DateTime.Now); 

                        
                    }
                }

            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(DataTable)", ex.Source, ex.Message, ex);
            }

            return objKioskMaster;
        }

    }
}
