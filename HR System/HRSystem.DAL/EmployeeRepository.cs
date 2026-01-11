using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRSystem.Entities;
using MySql.Data.MySqlClient;

namespace HRSystem.DAL
{
    public class EmployeeRepository
    {

        public int Add(Employee e)
        {
            using (var conn = DbConnection.GetConnection())
            {
                string q = @"INSERT INTO Employees
(NationalID, FirstName, LastName, Email, Phone, DepartmentID, Salary, RemainingLeaveDays, CreatedDate)
VALUES (@n,@f,@l,@email,@phone,@d,@s,@r,@c);
SELECT LAST_INSERT_ID();";

                var cmd = new MySqlCommand(q, conn);
                cmd.Parameters.AddWithValue("@n", e.NationalID);
                cmd.Parameters.AddWithValue("@f", e.FirstName);
                cmd.Parameters.AddWithValue("@l", e.LastName);
                cmd.Parameters.AddWithValue("@d", e.DepartmentID);
                cmd.Parameters.AddWithValue("@s", e.Salary);
                cmd.Parameters.AddWithValue("@email", e.Email);
                cmd.Parameters.AddWithValue("@phone", e.Phone);
                cmd.Parameters.AddWithValue("@r", e.RemainingLeaveDays);
                cmd.Parameters.AddWithValue("@c", DateTime.Now);

                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }


        public void Update(Employee e)
        {
            using (var conn = DbConnection.GetConnection())
            {
                string q = @"UPDATE Employees SET
NationalID=@n,
FirstName=@f,
LastName=@l,
Email=@email,
Phone=@phone,
DepartmentID=@d,
Salary=@s,
RemainingLeaveDays=@r
WHERE EmployeeID=@id
";

                var cmd = new MySqlCommand(q, conn);
                cmd.Parameters.AddWithValue("@id", e.ID);
                cmd.Parameters.AddWithValue("@n", e.NationalID);
                cmd.Parameters.AddWithValue("@f", e.FirstName);
                cmd.Parameters.AddWithValue("@l", e.LastName);
                cmd.Parameters.AddWithValue("@d", e.DepartmentID);
                cmd.Parameters.AddWithValue("@s", e.Salary);
                cmd.Parameters.AddWithValue("@email", e.Email);
                cmd.Parameters.AddWithValue("@phone", e.Phone);
                cmd.Parameters.AddWithValue("@r", e.RemainingLeaveDays);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var conn = DbConnection.GetConnection())
            {
                string q = "DELETE FROM Employees WHERE EmployeeID=@id";
                var cmd = new MySqlCommand(q, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        

        public List<Employee> GetAll()
        {
            var list = new List<Employee>();

            using (var conn = DbConnection.GetConnection())
            {
                string q = @"SELECT e.*, d.DepartmentName
             FROM Employees e
             INNER JOIN Departments d ON e.DepartmentID = d.DepartmentID";

                var cmd = new MySqlCommand(q, conn);
                conn.Open();
                var r = cmd.ExecuteReader();

                while (r.Read())
                {
                    list.Add(new Employee
                    {
                        ID = Convert.ToInt32(r["EmployeeID"]),
                        NationalID = r["NationalID"].ToString(),
                        FirstName = r["FirstName"].ToString(),
                        LastName = r["LastName"].ToString(),
                        Email = r["Email"].ToString(),
                        Phone = r["Phone"].ToString(),
                        DepartmentID = Convert.ToInt32(r["DepartmentID"]),
                        DepartmentName = r["DepartmentName"].ToString(),
                        Salary = Convert.ToDecimal(r["Salary"]),
                        RemainingLeaveDays = Convert.ToInt32(r["RemainingLeaveDays"]),
                        CreatedDate = Convert.ToDateTime(r["CreatedDate"])
                    });
                }
            }
            return list;
        }
        public Employee GetById(int id)
        {
            using (var conn = DbConnection.GetConnection())
            {
                string q = "SELECT * FROM Employees WHERE EmployeeID = @id";
                var cmd = new MySqlCommand(q, conn);
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                var r = cmd.ExecuteReader();

                if (r.Read())
                {
                    return new Employee
                    {
                        ID = Convert.ToInt32(r["EmployeeID"]),
                        FirstName = r["FirstName"].ToString(),
                        LastName = r["LastName"].ToString(),
                        DepartmentID = Convert.ToInt32(r["DepartmentID"]),
                        Salary = Convert.ToDecimal(r["Salary"]),
                        RemainingLeaveDays = Convert.ToInt32(r["RemainingLeaveDays"])
                    };
                }
            }
            return null;
        }
    }
}
