using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRSystem.DAL;
using HRSystem.Entities;

namespace HRSystem.BLL
{
    public class UserService
    {
        private readonly UserRepository _repo = new UserRepository();

        public User Login(string username, string password)
        {
            return _repo.GetByUsernameAndPassword(username, password);
        }
    }
}
