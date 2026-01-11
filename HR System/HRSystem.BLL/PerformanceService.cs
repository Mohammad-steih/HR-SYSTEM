using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRSystem.Entities;
using HRSystem.DAL;
using MySql.Data.MySqlClient;


namespace HRSystem.BLL
{
    public class PerformanceService
    {
        private readonly PerformanceRepository _repo = new PerformanceRepository();
        

        public void AddPerformance(Performance p)
        {
            int month = p.EvaluationDate.Month;
            int year = p.EvaluationDate.Year;

            if (_repo.ExistsForMonth(p.EmployeeID, month, year))
                throw new Exception("This employee has already been evaluated this month");

            p.FinalScore =
                (p.WorkQuality + p.Attendance + p.Teamwork) / 3m;

            _repo.Add(p);
        }
        public List<Performance> GetAllWithEmployeeAndDepartment()
        {
            return _repo.GetAllWithEmployeeAndDepartment();
        }
        public List<Performance> GetAll()
        {
            return _repo.GetAll();
        }

    }
}
