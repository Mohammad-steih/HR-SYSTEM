using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRSystem.DAL;
using HRSystem.Entities;

namespace HRSystem.BLL
{
    public class EmployeeService
    {
        private readonly EmployeeRepository _employeeRepo = new EmployeeRepository();
        private readonly UserRepository _userRepo = new UserRepository();


        public void AddEmployee(Employee e)
        {
            int newEmployeeId = _employeeRepo.Add(e);

            string role;

            if (e.DepartmentName == "Human Resources")
                role = "HR";
            else if (e.DepartmentName == "Administration")
                role = "Admin";
            else
                role = "Employee";

            string baseUsername = e.FirstName.ToLower();
            string username = baseUsername;
            int counter = 1;

            while (_userRepo.UsernameExists(username))
            {
                username = baseUsername + counter;
                counter++;
            }

            
            var user = new User
            {
                EmployeeID = newEmployeeId,
                Username = username,
                Password = "123",
                Role = role,
                CreatedDate = DateTime.Now
            };

            _userRepo.Add(user);
        }


        public void UpdateEmployee(Employee e)
        {
            _employeeRepo.Update(e);
        }

        public void DeleteEmployee(int id)
        {
            _employeeRepo.Delete(id);
        }

        public List<Employee> GetAllEmployees()
        {
            return _employeeRepo.GetAll();
        }

        public void GenerateUsersForExistingEmployees()
        {
            var employees = _employeeRepo.GetAll();

            foreach (var e in employees)
            {
                if (_userRepo.ExistsByEmployeeId(e.ID))
                    continue;

                string baseUsername = e.FirstName.Substring(0, 3).ToLower();
                string username = baseUsername;
                int counter = 1;

                while (_userRepo.UsernameExists(username))
                {
                    username = baseUsername + counter;
                    counter++;
                }

                _userRepo.Add(new User
                {
                    EmployeeID = e.ID,
                    Username = username,
                    Password = "123",
                    Role = "Employee",
                    CreatedDate = DateTime.Now
                });
            }
        }

    }
}
