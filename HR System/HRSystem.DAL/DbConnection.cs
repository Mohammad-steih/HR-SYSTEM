using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace HRSystem.DAL
{
    public class DbConnection
    {
        private static string connectionString =
            "Server=172.21.54.253;Database=26_132430122;User ID=26_132430122;Password=İnif123.;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
