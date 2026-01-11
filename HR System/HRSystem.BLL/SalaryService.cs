using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRSystem.DAL;
using HRSystem.Entities;

namespace HRSystem.BLL
{
    public class SalaryService
    {
        private readonly SalaryRepository _repo = new SalaryRepository();

        public void AddSalary(Salary s)
        {
            bool exists = _repo.ExistsForMonth(
                s.EmployeeID,
                DateTime.Now.Year,
                DateTime.Now.Month
            );

            if (exists)
                throw new Exception("Salary for this employee already exists for this month");

            s.CreatedDate = DateTime.Now;
            _repo.Add(s);
        }
        public List<SalaryReportDTO> GetSalaryReport(int? employeeId)
        {
            return _repo.GetReport(employeeId);
        }


        public List<SalaryView> GetAll()
        {
            return _repo.GetAllWithEmployeeName();
        }
    }

}
