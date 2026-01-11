using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRSystem.DAL;
using HRSystem.Entities;



namespace HRSystem.BLL
{
    public class DepartmentService
    {
        private DepartmentRepository _repo = new DepartmentRepository();
        public List<Department> GetAllDepartments()
        {
            return _repo.GetAll();
        }

        public void AddDepartment(Department d)
        {
            _repo.Add(d);
        }

        public void UpdateDepartment(Department d)
        {
            _repo.Update(d);
        }

        public void DeleteDepartment(int id)
        {
            _repo.Delete(id);
        }
        public List<Department> GetAll()
        {
            return _repo.GetAll();
        }

        public void Add(Department d)
        {
            _repo.Add(d);
        }

        public void Update(Department d)
        {
            _repo.Update(d);
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }
    }
}
