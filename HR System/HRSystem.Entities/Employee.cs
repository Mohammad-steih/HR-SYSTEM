using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.Entities
{

    public class Employee : BaseEntity
    {
        public string NationalID { get; set; }  
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int DepartmentID { get; set; }
        public decimal Salary { get; set; }
        public int RemainingLeaveDays { get; set; }
        public string DepartmentName { get; set; }   

        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
    }
}
