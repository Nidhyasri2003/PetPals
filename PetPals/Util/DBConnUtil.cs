using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace PetPals.Util
{
    public class DBConnUtil
    {
        public static SqlConnection GetConnection(string fileName)
        {
            string connStr = DBPropertyUtil.GetConnectionString(fileName); 
            return new SqlConnection(connStr);
        }
    }
}