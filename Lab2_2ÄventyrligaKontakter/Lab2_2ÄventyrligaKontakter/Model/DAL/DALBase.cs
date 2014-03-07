using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Lab2_2ÄventyrligaKontakter.Model.DAL
{
    public abstract class DALBase
    {
        private static string _connectionString;

        static DALBase() 
        {
            _connectionString = WebConfigurationManager.ConnectionStrings["ContactConnectionString"].ConnectionString;
        }

        protected SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }


    }
}