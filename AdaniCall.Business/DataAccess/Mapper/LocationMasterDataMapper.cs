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
    public class LocationMasterDataMapper
    {
        private static readonly string _module = "AdaniCall.Business.DataAccess.Mapper.LocationMasterDataMapper";
        private LocationMaster objLocationMaster = null;

        public LocationMaster GetDetails(SqlDataReader sqlDataReader)
        {
            try
            {
                objLocationMaster = new LocationMaster();
               
			   if (sqlDataReader.HasColumn(LocationMasterDBFields.ID))
   objLocationMaster.ID = (sqlDataReader[LocationMasterDBFields.ID] != DBNull.Value ? Convert.ToInt32(sqlDataReader[LocationMasterDBFields.ID]) : 0); 
if (sqlDataReader.HasColumn(LocationMasterDBFields.LocationName))
   objLocationMaster.LocationName = (sqlDataReader[LocationMasterDBFields.LocationName] != DBNull.Value ? Convert.ToString(sqlDataReader[LocationMasterDBFields.LocationName]) : string.Empty); 
if (sqlDataReader.HasColumn(LocationMasterDBFields.LocationType))
   objLocationMaster.LocationType = (sqlDataReader[LocationMasterDBFields.LocationType] != DBNull.Value ? Convert.ToByte(sqlDataReader[LocationMasterDBFields.LocationType]) : (byte)0); 
if (sqlDataReader.HasColumn(LocationMasterDBFields.StatusId))
   objLocationMaster.StatusId = (sqlDataReader[LocationMasterDBFields.StatusId] != DBNull.Value ? Convert.ToByte(sqlDataReader[LocationMasterDBFields.StatusId]) : (byte)0); 
if (sqlDataReader.HasColumn(LocationMasterDBFields.CreatedDate))
   objLocationMaster.CreatedDate = (sqlDataReader[LocationMasterDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(sqlDataReader[LocationMasterDBFields.CreatedDate]) : DateTime.Now); 
if (sqlDataReader.HasColumn(LocationMasterDBFields.UpdatedDate))
   objLocationMaster.UpdatedDate = (sqlDataReader[LocationMasterDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(sqlDataReader[LocationMasterDBFields.UpdatedDate]) : DateTime.Now); 

            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(sqlDataReader)", ex.Source, ex.Message, ex);
            }
            return objLocationMaster;
        }
		
		public List<LocationMaster> GetDetailsList(SqlDataReader sqlDataReader)
        {
            List<LocationMaster> list = new List<LocationMaster>();
            try
            {
                while (sqlDataReader.Read())
                {
                    objLocationMaster = GetDetails(sqlDataReader);
                    list.Add(objLocationMaster);
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetailsList(sqlDataReader)", ex.Source, ex.Message, ex);
            }
            return list;
        }

        public List<LocationMaster> GetDetails(DataSet dataSet)
        {
            List<LocationMaster> LocationMasters = new List<LocationMaster>();

            try
            {
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drow in dataSet.Tables[0].Rows)
                    {
                        objLocationMaster = new LocationMaster();
                       
						if (drow.Table.Columns.Contains(LocationMasterDBFields.ID)) 
  objLocationMaster.ID = (drow[LocationMasterDBFields.ID] != DBNull.Value ? Convert.ToInt32(drow[LocationMasterDBFields.ID]) : 0); 
if (drow.Table.Columns.Contains(LocationMasterDBFields.LocationName)) 
  objLocationMaster.LocationName = (drow[LocationMasterDBFields.LocationName] != DBNull.Value ? Convert.ToString(drow[LocationMasterDBFields.LocationName]) : string.Empty); 
if (drow.Table.Columns.Contains(LocationMasterDBFields.LocationType)) 
  objLocationMaster.LocationType = (drow[LocationMasterDBFields.LocationType] != DBNull.Value ? Convert.ToByte(drow[LocationMasterDBFields.LocationType]) : (byte)0); 
if (drow.Table.Columns.Contains(LocationMasterDBFields.StatusId)) 
  objLocationMaster.StatusId = (drow[LocationMasterDBFields.StatusId] != DBNull.Value ? Convert.ToByte(drow[LocationMasterDBFields.StatusId]) : (byte)0); 
if (drow.Table.Columns.Contains(LocationMasterDBFields.CreatedDate)) 
  objLocationMaster.CreatedDate = (drow[LocationMasterDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(drow[LocationMasterDBFields.CreatedDate]) : DateTime.Now); 
if (drow.Table.Columns.Contains(LocationMasterDBFields.UpdatedDate)) 
  objLocationMaster.UpdatedDate = (drow[LocationMasterDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(drow[LocationMasterDBFields.UpdatedDate]) : DateTime.Now); 


                        LocationMasters.Add(objLocationMaster);
                    }
                }

            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(dataSet)", ex.Source, ex.Message, ex);
            }

            return LocationMasters;
        }
		
		public LocationMaster GetDetailsobj(DataSet dataSet)
        {
            LocationMaster objLocationMaster = new LocationMaster();

            try
            {
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drow in dataSet.Tables[0].Rows)
                    {
                        objLocationMaster = new LocationMaster();
                      
						if (drow.Table.Columns.Contains(LocationMasterDBFields.ID)) 
  objLocationMaster.ID = (drow[LocationMasterDBFields.ID] != DBNull.Value ? Convert.ToInt32(drow[LocationMasterDBFields.ID]) : 0); 
if (drow.Table.Columns.Contains(LocationMasterDBFields.LocationName)) 
  objLocationMaster.LocationName = (drow[LocationMasterDBFields.LocationName] != DBNull.Value ? Convert.ToString(drow[LocationMasterDBFields.LocationName]) : string.Empty); 
if (drow.Table.Columns.Contains(LocationMasterDBFields.LocationType)) 
  objLocationMaster.LocationType = (drow[LocationMasterDBFields.LocationType] != DBNull.Value ? Convert.ToByte(drow[LocationMasterDBFields.LocationType]) : (byte)0); 
if (drow.Table.Columns.Contains(LocationMasterDBFields.StatusId)) 
  objLocationMaster.StatusId = (drow[LocationMasterDBFields.StatusId] != DBNull.Value ? Convert.ToByte(drow[LocationMasterDBFields.StatusId]) : (byte)0); 
if (drow.Table.Columns.Contains(LocationMasterDBFields.CreatedDate)) 
  objLocationMaster.CreatedDate = (drow[LocationMasterDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(drow[LocationMasterDBFields.CreatedDate]) : DateTime.Now); 
if (drow.Table.Columns.Contains(LocationMasterDBFields.UpdatedDate)) 
  objLocationMaster.UpdatedDate = (drow[LocationMasterDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(drow[LocationMasterDBFields.UpdatedDate]) : DateTime.Now); 

                        
                    }
                }

            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(dataSet)", ex.Source, ex.Message, ex);
            }

            return objLocationMaster;
        }
		
		public LocationMaster GetDetails(DataTable dataTable)
        {
            LocationMaster objLocationMaster = new LocationMaster();

            try
            {
                if (dataTable != null &&  dataTable.Rows.Count > 0)
                {
                    foreach (DataRow drow in dataTable.Rows)
                    {
                        objLocationMaster = new LocationMaster();
                      
						if (drow.Table.Columns.Contains(LocationMasterDBFields.ID)) 
  objLocationMaster.ID = (drow[LocationMasterDBFields.ID] != DBNull.Value ? Convert.ToInt32(drow[LocationMasterDBFields.ID]) : 0); 
if (drow.Table.Columns.Contains(LocationMasterDBFields.LocationName)) 
  objLocationMaster.LocationName = (drow[LocationMasterDBFields.LocationName] != DBNull.Value ? Convert.ToString(drow[LocationMasterDBFields.LocationName]) : string.Empty); 
if (drow.Table.Columns.Contains(LocationMasterDBFields.LocationType)) 
  objLocationMaster.LocationType = (drow[LocationMasterDBFields.LocationType] != DBNull.Value ? Convert.ToByte(drow[LocationMasterDBFields.LocationType]) : (byte)0); 
if (drow.Table.Columns.Contains(LocationMasterDBFields.StatusId)) 
  objLocationMaster.StatusId = (drow[LocationMasterDBFields.StatusId] != DBNull.Value ? Convert.ToByte(drow[LocationMasterDBFields.StatusId]) : (byte)0); 
if (drow.Table.Columns.Contains(LocationMasterDBFields.CreatedDate)) 
  objLocationMaster.CreatedDate = (drow[LocationMasterDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(drow[LocationMasterDBFields.CreatedDate]) : DateTime.Now); 
if (drow.Table.Columns.Contains(LocationMasterDBFields.UpdatedDate)) 
  objLocationMaster.UpdatedDate = (drow[LocationMasterDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(drow[LocationMasterDBFields.UpdatedDate]) : DateTime.Now); 

                        
                    }
                }

            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(DataTable)", ex.Source, ex.Message, ex);
            }

            return objLocationMaster;
        }

    }
}
