using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRSystem.DAL;

namespace HRSystem.BLL
{
    public class AuthService
    {
        private UserRepository _repo = new UserRepository();

        public bool Login(string username, string password)
        {
            var user = _repo.Login(username, password);
            if (user == null) return false;

            Session.EmployeeID = user.EmployeeID;
            Session.Role = user.Role;
            return true;
        }
    }
}
