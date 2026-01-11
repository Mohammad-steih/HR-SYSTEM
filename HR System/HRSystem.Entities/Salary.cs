using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.Entities
{

    public class Salary : BaseEntity
    {
        public int EmployeeID { get; set; }
        public decimal BaseSalary { get; set; }
        public decimal Bonus { get; set; }
        public decimal Deduction { get; set; }
        public decimal NetSalary { get; set; }
    }

    public class SalaryViewDTO
    {
        public string EmployeeName { get; set; }
        public decimal BaseSalary { get; set; }
        public decimal Bonus { get; set; }
        public decimal Deduction { get; set; }
        public decimal NetSalary { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    public class SalaryView
    {
        public string EmployeeName { get; set; }
        public decimal BaseSalary { get; set; }
        public decimal Bonus { get; set; }
        public decimal Deduction { get; set; }
        public decimal NetSalary { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    public class SalaryReportDTO
    {
        public string EmployeeName { get; set; }
        public decimal BaseSalary { get; set; }
        public decimal Bonus { get; set; }
        public decimal Deduction { get; set; }
        public decimal NetSalary { get; set; }
        public DateTime CreatedDate { get; set; }
    }


}
