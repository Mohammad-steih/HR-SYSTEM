using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRSystem.Entities;
using MySql.Data.MySqlClient;

namespace HRSystem.DAL
{
    public class LeaveRepository
    {
        public void Add(Leave l)
        {
            using (var conn = DbConnection.GetConnection())
            {
                string q = @"INSERT INTO Leaves
                    (EmployeeID, StartDate, EndDate, TotalDays, Reason, Status, CreatedDate)
                     VALUES (@e, @s, @en, @t, @r, @st, @c)";    



                var cmd = new MySqlCommand(q, conn);
                cmd.Parameters.AddWithValue("@e", l.EmployeeID);
                cmd.Parameters.AddWithValue("@s", l.StartDate);
                cmd.Parameters.AddWithValue("@en", l.EndDate);
                cmd.Parameters.AddWithValue("@t", l.TotalDays);
                cmd.Parameters.AddWithValue("@st", l.Status);
                cmd.Parameters.AddWithValue("@r", l.Reason);
                cmd.Parameters.AddWithValue("@c", DateTime.Now);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Leave> GetAll()
        {
            var list = new List<Leave>();
            using (var conn = DbConnection.GetConnection())
            {
                string q = "SELECT * FROM Leaves";
                var cmd = new MySqlCommand(q, conn);
                conn.Open();
                var r = cmd.ExecuteReader();

                while (r.Read())
                {
                    list.Add(new Leave
                    {
                        ID = Convert.ToInt32(r["LeaveID"]),
                        EmployeeID = Convert.ToInt32(r["EmployeeID"]),
                        StartDate = Convert.ToDateTime(r["StartDate"]),
                        EndDate = Convert.ToDateTime(r["EndDate"]),
                        TotalDays = Convert.ToInt32(r["TotalDays"]),
                        Status = r["Status"].ToString(),
                        Reason = r["Reason"].ToString(),
                        CreatedDate = Convert.ToDateTime(r["CreatedDate"])
                    });
                }
            }
            return list;
        }
        public List<LeaveApprovalDTO> GetLeavesForApproval()
        {
            var list = new List<LeaveApprovalDTO>();

            using (var conn = DbConnection.GetConnection())
            {
                string q = @"
        SELECT 
            l.LeaveID,
            l.EmployeeID,
            CONCAT(e.FirstName, ' ', e.LastName) AS EmployeeName,
            l.StartDate,
            l.EndDate,
            l.TotalDays,
            l.Reason,
            l.Status,
            l.CreatedDate
        FROM Leaves l
        INNER JOIN Employees e ON l.EmployeeID = e.EmployeeID";

                var cmd = new MySqlCommand(q, conn);
                conn.Open();
                var r = cmd.ExecuteReader();

                while (r.Read())
                {
                    list.Add(new LeaveApprovalDTO
                    {
                        LeaveID = Convert.ToInt32(r["LeaveID"]),
                        EmployeeID = Convert.ToInt32(r["EmployeeID"]),
                        EmployeeName = r["EmployeeName"].ToString(),
                        StartDate = Convert.ToDateTime(r["StartDate"]),
                        EndDate = Convert.ToDateTime(r["EndDate"]),
                        TotalDays = Convert.ToInt32(r["TotalDays"]),
                        Reason = r["Reason"].ToString(),
                        Status = r["Status"].ToString(),
                        CreatedDate = Convert.ToDateTime(r["CreatedDate"])
                    });
                }
            }
            return list;
        }



        public void UpdateStatus(int leaveId, string status)
        {
            using (var conn = DbConnection.GetConnection())
            {
                string q = "UPDATE Leaves SET Status=@s WHERE LeaveID=@id";
                var cmd = new MySqlCommand(q, conn);
                cmd.Parameters.AddWithValue("@s", status);
                cmd.Parameters.AddWithValue("@id", leaveId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Leave> GetByEmployee(int employeeId)
        {
            var list = new List<Leave>();

            using (var conn = DbConnection.GetConnection())
            {
                string q = "SELECT * FROM Leaves WHERE EmployeeID=@id";
                var cmd = new MySqlCommand(q, conn);
                cmd.Parameters.AddWithValue("@id", employeeId);

                conn.Open();
                var r = cmd.ExecuteReader();

                while (r.Read())
                {
                    list.Add(new Leave
                    {
                        ID = Convert.ToInt32(r["LeaveID"]),
                        EmployeeID = Convert.ToInt32(r["EmployeeID"]),
                        StartDate = Convert.ToDateTime(r["StartDate"]),
                        EndDate = Convert.ToDateTime(r["EndDate"]),
                        TotalDays = Convert.ToInt32(r["TotalDays"]),
                        Reason = r["Reason"].ToString(),   // ✅ مهم
                        Status = r["Status"].ToString(),
                        CreatedDate = Convert.ToDateTime(r["CreatedDate"])
                    });

                }
            }

            return list;
        }
       

        public List<LeaveReportDTO> GetLeaveReport()
        {
            var list = new List<LeaveReportDTO>();

            using (var conn = DbConnection.GetConnection())
            {
                string q = @"
        SELECT 
            CONCAT(e.FirstName, ' ', e.LastName) AS EmployeeName,
            d.DepartmentID,
            d.DepartmentName,
            l.StartDate,
            l.EndDate,
            l.TotalDays,
            l.Status,
            l.CreatedDate,
            l.Reason
        FROM Leaves l
        INNER JOIN Employees e ON l.EmployeeID = e.EmployeeID
        INNER JOIN Departments d ON e.DepartmentID = d.DepartmentID
        ";

                var cmd = new MySqlCommand(q, conn);
                conn.Open();
                var r = cmd.ExecuteReader();

                while (r.Read())
                {
                    list.Add(new LeaveReportDTO
                    {
                        EmployeeName = r["EmployeeName"].ToString(),
                        DepartmentID = Convert.ToInt32(r["DepartmentID"]),
                        DepartmentName = r["DepartmentName"].ToString(),
                        FromDate = Convert.ToDateTime(r["StartDate"]),
                        ToDate = Convert.ToDateTime(r["EndDate"]),
                        TotalDays = Convert.ToInt32(r["TotalDays"]),
                        Reason = r["Reason"].ToString(),
                        Status = r["Status"].ToString(),
                        CreatedDate = Convert.ToDateTime(r["CreatedDate"])
                    });
                }
            }
            return list;
        }



    }
}
