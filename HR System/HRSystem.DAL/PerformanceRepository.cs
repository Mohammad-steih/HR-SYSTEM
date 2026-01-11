using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRSystem.Entities;
using HRSystem.DAL;
using MySql.Data.MySqlClient;


namespace HRSystem.DAL
{
    public class PerformanceRepository
    {
        public void Add(Performance p)
        {
            using (var conn = DbConnection.GetConnection())
            {
                string q = @"INSERT INTO Performance
        (EmployeeID, WorkQuality, Attendance, Teamwork, FinalScore, Notes, EvaluationDate)
        VALUES
        (@e, @w, @a, @t, @f, @n, @d)";

                var cmd = new MySqlCommand(q, conn);
                cmd.Parameters.AddWithValue("@e", p.EmployeeID);
                cmd.Parameters.AddWithValue("@w", p.WorkQuality);
                cmd.Parameters.AddWithValue("@a", p.Attendance);
                cmd.Parameters.AddWithValue("@t", p.Teamwork);
                cmd.Parameters.AddWithValue("@f", p.FinalScore);
                cmd.Parameters.AddWithValue("@n", p.Notes);
                cmd.Parameters.AddWithValue("@d", DateTime.Now);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }



        public List<Performance> GetAll()
        {
            var list = new List<Performance>();

            using (var conn = DbConnection.GetConnection())
            {
                string q = @"SELECT * FROM Performance";
                var cmd = new MySqlCommand(q, conn);

                conn.Open();
                var r = cmd.ExecuteReader();

                while (r.Read())
                {
                    list.Add(new Performance
                    {
                        ID = Convert.ToInt32(r["PerformanceID"]),
                        EmployeeID = Convert.ToInt32(r["EmployeeID"]),
                        WorkQuality = Convert.ToInt32(r["WorkQuality"]),
                        Attendance = Convert.ToInt32(r["Attendance"]),
                        Teamwork = Convert.ToInt32(r["Teamwork"]),
                        FinalScore = Convert.ToDecimal(r["FinalScore"]),
                        Notes = r["Notes"].ToString(),
                        EvaluationDate = Convert.ToDateTime(r["EvaluationDate"])
                    });
                }
            }
            return list;
        }
        public List<Performance> GetAllWithEmployeeAndDepartment()
        {
            var list = new List<Performance>();

            using (var conn = DbConnection.GetConnection())
            {
                string q = @"
        SELECT 
    p.PerformanceID,
    p.EmployeeID,
    p.WorkQuality,
    p.Attendance,
    p.Teamwork,
    p.FinalScore,
    p.Notes,
    p.EvaluationDate,
    e.DepartmentID,
    CONCAT(e.FirstName,' ',e.LastName) AS EmployeeName,
    d.DepartmentName
FROM Performance p
INNER JOIN Employees e ON p.EmployeeID = e.EmployeeID
INNER JOIN Departments d ON e.DepartmentID = d.DepartmentID
";

                var cmd = new MySqlCommand(q, conn);
                conn.Open();
                var r = cmd.ExecuteReader();

                while (r.Read())
                {
                    list.Add(new Performance
                    {
                        ID = Convert.ToInt32(r["PerformanceID"]),
                        EmployeeID = Convert.ToInt32(r["EmployeeID"]),
                        DepartmentID = Convert.ToInt32(r["DepartmentID"]),
                        EmployeeName = r["EmployeeName"].ToString(),
                        DepartmentName = r["DepartmentName"].ToString(),
                        WorkQuality = Convert.ToInt32(r["WorkQuality"]),
                        Attendance = Convert.ToInt32(r["Attendance"]),
                        Teamwork = Convert.ToInt32(r["Teamwork"]),
                        FinalScore = Convert.ToDecimal(r["FinalScore"]),
                        Notes = r["Notes"].ToString(),
                        EvaluationDate = Convert.ToDateTime(r["EvaluationDate"])
                    });

                }
            }

            return list;
        }







        public bool ExistsForMonth(int employeeId, int month, int year)
        {
            using (var conn = DbConnection.GetConnection())
            {
                string q = @"SELECT COUNT(*) FROM Performance
                     WHERE EmployeeID = @emp
                     AND MONTH(EvaluationDate) = @m
                     AND YEAR(EvaluationDate) = @y";

                var cmd = new MySqlCommand(q, conn);
                cmd.Parameters.AddWithValue("@emp", employeeId);
                cmd.Parameters.AddWithValue("@m", month);
                cmd.Parameters.AddWithValue("@y", year);

                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }              

    }
}

