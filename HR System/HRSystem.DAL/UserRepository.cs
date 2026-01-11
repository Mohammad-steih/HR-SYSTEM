using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRSystem.Entities;
using MySql.Data.MySqlClient;

namespace HRSystem.DAL
{
    public class UserRepository
    {
        public User Login(string username, string password)
        {
            using (var conn = DbConnection.GetConnection())
            {
                string q = @"SELECT * FROM Employees
                             WHERE Username=@u AND Password=@p";

                var cmd = new MySqlCommand(q, conn);
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@p", password);

                conn.Open();
                var r = cmd.ExecuteReader();

                if (r.Read())
                {
                    return new User
                    {
                        EmployeeID = (int)r["EmployeeID"],
                        Username = r["Username"].ToString(),
                        Role = r["Role"].ToString()
                    };
                }
            }
            return null;
        }

        public bool UsernameExists(string username)
        {
            using (var conn = DbConnection.GetConnection())
            {
                string q = "SELECT COUNT(*) FROM Users WHERE Username = @u";
                var cmd = new MySqlCommand(q, conn);
                cmd.Parameters.AddWithValue("@u", username);

                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }
        public bool ExistsByEmployeeId(int empId)
        {
            using (var conn = DbConnection.GetConnection())
            {
                string q = "SELECT COUNT(*) FROM Users WHERE EmployeeID = @id";
                var cmd = new MySqlCommand(q, conn);
                cmd.Parameters.AddWithValue("@id", empId);

                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }
        public User GetByUsernameAndPassword(string username, string password)
        {
            using (var conn = DbConnection.GetConnection())
            {
                string q = @"SELECT * FROM Users 
                     WHERE Username=@u AND Password=@p";

                var cmd = new MySqlCommand(q, conn);
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@p", password);

                conn.Open();
                var r = cmd.ExecuteReader();

                if (r.Read())
                {
                    return new User
                    {
                        ID = Convert.ToInt32(r["UserID"]),
                        EmployeeID = Convert.ToInt32(r["EmployeeID"]),
                        Username = r["Username"].ToString(),
                        Role = r["Role"].ToString()
                    };
                }
            }
            return null;
        }

        public void Add(User u)
        {
            using (var conn = DbConnection.GetConnection())
            {
                string q = @"INSERT INTO Users
        (EmployeeID, Username, Password, Role, CreatedDate)
        VALUES (@e,@u,@p,@r,@c)";

                var cmd = new MySqlCommand(q, conn);
                cmd.Parameters.AddWithValue("@e", u.EmployeeID);
                cmd.Parameters.AddWithValue("@u", u.Username);
                cmd.Parameters.AddWithValue("@p", u.Password);
                cmd.Parameters.AddWithValue("@r", u.Role);
                cmd.Parameters.AddWithValue("@c", u.CreatedDate);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}
