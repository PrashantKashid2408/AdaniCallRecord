using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Diagnostics;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace AdaniCall.Business.DataAccess.DataAccessLayer
{
    public class dbClass
    {
        private static IConfiguration Configuration;

        private static void setConfigurations()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false);
            Configuration = builder.Build();
        }

        public static long SqlConnectionCounter = 0;
        public static long OleDbConnectionCounter = 0;
        public static string ConnectString()
        {
            setConfigurations();

            string sConnectString = "";
            sConnectString = Configuration.GetValue<string>("ConnectionStrings:ConnString");
            return sConnectString;
        }

        public static string SqlConnectString()
        {
            setConfigurations();

            string sConnectString = "";
            sConnectString = Configuration.GetValue<string>("ConnectionStrings:ConnString");
            return sConnectString;
        }

        public static SqlConnection GetConnection()
        {
            SqlConnection dbConnection = new SqlConnection();
            dbConnection.ConnectionString = dbClass.ConnectString();
            dbConnection.Open();
            SqlConnectionCounter++;
            Debug.Print("Sql Connection Number - " + SqlConnectionCounter);
            return dbConnection;
        }

        public static SqlConnection GetConnectionSqlConnection()
        {
            SqlConnection dbConnection = new SqlConnection();

            dbConnection.ConnectionString = dbClass.SqlConnectString();
            dbConnection.Open();
            SqlConnectionCounter++;
            Debug.Print("Sql Connection Number - " + SqlConnectionCounter);
            return dbConnection;
        }

        public static SqlConnection GetSqlConnection()
        {
            SqlConnection dbConnection = new SqlConnection();

            dbConnection.ConnectionString = dbClass.SqlConnectString();
            dbConnection.Open();
            SqlConnectionCounter++;
            Debug.Print("Sql Connection Number - " + SqlConnectionCounter);
            return dbConnection;
        }



        public static void GetSqlConnection(ref SqlConnection dbConnection)
        {
            dbConnection = new SqlConnection();

            dbConnection.ConnectionString = dbClass.SqlConnectString();
            dbConnection.Open();
            SqlConnectionCounter++;
            Debug.Print("Sql Connection Number - " + SqlConnectionCounter);
        }

        public static void CloseSqlConnection(ref SqlConnection dbConnection)
        {
            if (dbConnection != null)
            {
                if (dbConnection.State == ConnectionState.Open)
                {
                    dbConnection.Close();
                }
                dbConnection.Dispose();
                dbConnection = null;
                System.GC.Collect();
                SqlConnectionCounter--;
            }
        }
    }
}