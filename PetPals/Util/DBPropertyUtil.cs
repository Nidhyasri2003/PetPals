using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;

namespace PetPals.Util
{
    public class DBPropertyUtil
    {
        public static string GetConnectionString(string _)
        {

            return "Data Source= JAYASRI;Initial Catalog=PetPalsDB;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";

        }
    }
}
