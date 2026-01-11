using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.Entities
{
    public class Performance : BaseEntity
    {
        public int DepartmentID { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string DepartmentName { get; set; }
        public int WorkQuality { get; set; }
        public int Attendance { get; set; }
        public int Teamwork { get; set; }
        public decimal FinalScore { get; set; }
        public string Notes { get; set; }
        public DateTime EvaluationDate { get; set; }
    }
    


}
