using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace QLMT.Models
{
    public class DBConnection
    {
        string strCon;
        public DBConnection()
        {
            strCon = ConfigurationManager.ConnectionStrings["DBConnect"].ConnectionString;

        }
        public SqlConnection getConnection()
        {
            return new SqlConnection(strCon);
        }
    }
}