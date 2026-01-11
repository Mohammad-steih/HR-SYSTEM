using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRSystem.Entities;
using MySql.Data.MySqlClient;

namespace HRSystem.DAL
{
    public class DepartmentRepository
    {
        public void Add(Department d)
        {

            using (var conn = DbConnection.GetConnection())
            {
                string q = @"INSERT INTO Departments (DepartmentName, CreatedDate)
                             VALUES (@n, @c)";
                var cmd = new MySqlCommand(q, conn);
                cmd.Parameters.AddWithValue("@n", d.DepartmentName);
                cmd.Parameters.AddWithValue("@c", DateTime.Now);
                conn.Open();
                cmd.ExecuteNonQuery();
            }

        }

        public void Update(Department d)
        {
            using (var conn = DbConnection.GetConnection())
            {
                string q = @"UPDATE Departments SET DepartmentName=@n
                             WHERE DepartmentID=@id";
                var cmd = new MySqlCommand(q, conn);
                cmd.Parameters.AddWithValue("@id", d.ID);
                cmd.Parameters.AddWithValue("@n", d.DepartmentName);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var conn = DbConnection.GetConnection())
            {
                string q = "DELETE FROM Departments WHERE DepartmentID=@id";
                var cmd = new MySqlCommand(q, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Department> GetAll()
        {
            var list = new List<Department>();
            using (var conn = DbConnection.GetConnection())
            {
                string q = "SELECT * FROM Departments";
                var cmd = new MySqlCommand(q, conn);
                conn.Open();
                var r = cmd.ExecuteReader();

                while (r.Read())
                {
                    list.Add(new Department
                    {
                        ID = Convert.ToInt32(r["DepartmentID"]),
                        DepartmentName = r["DepartmentName"].ToString(),
                        CreatedDate = Convert.ToDateTime(r["CreatedDate"])
                    });
                }
            }
            return list;
        }

    }
}
