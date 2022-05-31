using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Model;

namespace UserManagement.Repository
{
    public interface IUserRepository
    {
        bool IsUserNameExists(string user);
        bool AuthenticateUser(string username, string pwd);
        User AddNewUser(User user);
        bool DeleteUser(int userId);
    }
}
