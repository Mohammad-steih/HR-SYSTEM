using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.Entities
{
    public class Leave : BaseEntity
    {
        public int EmployeeID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TotalDays { get; set; }
        public string Reason { get; set; }   
        public string Status { get; set; }
    }
    public class LeaveApprovalDTO
    {
        public int LeaveID { get; set; }     
        public int EmployeeID { get; set; }  
        public string EmployeeName { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TotalDays { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    public class LeaveReportDTO
    {
        public string EmployeeName { get; set; }
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int TotalDays { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
    }

}
