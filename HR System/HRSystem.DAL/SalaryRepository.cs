using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRSystem.Entities;
using MySql.Data.MySqlClient;

namespace HRSystem.DAL
{
    public class SalaryRepository
    {
        public void Add(Salary s)
        {
            using (var conn = DbConnection.GetConnection())
            {
                string q = @"
                INSERT INTO Salary
                (EmployeeID, BaseSalary, Bonus, Deduction, NetSalary, CreatedDate)
                VALUES
                (@emp, @base, @bonus, @ded, @net, @date)";

                var cmd = new MySqlCommand(q, conn);
                cmd.Parameters.AddWithValue("@emp", s.EmployeeID);
                cmd.Parameters.AddWithValue("@base", s.BaseSalary);
                cmd.Parameters.AddWithValue("@bonus", s.Bonus);
                cmd.Parameters.AddWithValue("@ded", s.Deduction);
                cmd.Parameters.AddWithValue("@net", s.NetSalary);
                cmd.Parameters.AddWithValue("@date", DateTime.Now);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<SalaryView> GetAllWithEmployeeName()
        {
            var list = new List<SalaryView>();

            using (var conn = DbConnection.GetConnection())
            {
                string q = @"
                SELECT 
                    CONCAT(e.FirstName,' ',e.LastName) AS EmployeeName,
                    s.BaseSalary,
                    s.Bonus,
                    s.Deduction,
                    s.NetSalary,
                    s.CreatedDate
                FROM Salary s
                INNER JOIN Employees e ON s.EmployeeID = e.EmployeeID
                ORDER BY s.CreatedDate DESC";

                var cmd = new MySqlCommand(q, conn);
                conn.Open();
                var r = cmd.ExecuteReader();

                while (r.Read())
                {
                    list.Add(new SalaryView
                    {
                        EmployeeName = r["EmployeeName"].ToString(),
                        BaseSalary = Convert.ToDecimal(r["BaseSalary"]),
                        Bonus = Convert.ToDecimal(r["Bonus"]),
                        Deduction = Convert.ToDecimal(r["Deduction"]),
                        NetSalary = Convert.ToDecimal(r["NetSalary"]),
                        CreatedDate = Convert.ToDateTime(r["CreatedDate"])
                    });
                }
            }

            return list;
        }
        public bool ExistsForMonth(int empId, int year, int month)
        {
            using (var conn = DbConnection.GetConnection())
            {
                string q = @"
        SELECT COUNT(*) FROM Salary
        WHERE EmployeeID = @empId
        AND YEAR(CreatedDate) = @y
        AND MONTH(CreatedDate) = @m";

                var cmd = new MySqlCommand(q, conn);
                cmd.Parameters.AddWithValue("@empId", empId);
                cmd.Parameters.AddWithValue("@y", year);
                cmd.Parameters.AddWithValue("@m", month);

                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }
        public List<SalaryReportDTO> GetReport(int? employeeId)
        {
            var list = new List<SalaryReportDTO>();

            using (var conn = DbConnection.GetConnection())
            {
                string q = @"
        SELECT 
            CONCAT(e.FirstName,' ',e.LastName) AS EmployeeName,
            s.BaseSalary,
            s.Bonus,
            s.Deduction,
            s.NetSalary,
            s.CreatedDate
        FROM Salary s
        JOIN Employees e ON s.EmployeeID = e.EmployeeID
        WHERE (@empId IS NULL OR s.EmployeeID = @empId)";

                var cmd = new MySqlCommand(q, conn);
                cmd.Parameters.AddWithValue("@empId", employeeId);

                conn.Open();
                var r = cmd.ExecuteReader();

                while (r.Read())
                {
                    list.Add(new SalaryReportDTO
                    {
                        EmployeeName = r["EmployeeName"].ToString(),
                        BaseSalary = Convert.ToDecimal(r["BaseSalary"]),
                        Bonus = Convert.ToDecimal(r["Bonus"]),
                        Deduction = Convert.ToDecimal(r["Deduction"]),
                        NetSalary = Convert.ToDecimal(r["NetSalary"]),
                        CreatedDate = Convert.ToDateTime(r["CreatedDate"])
                    });
                }
            }

            return list;
        }

    }
}