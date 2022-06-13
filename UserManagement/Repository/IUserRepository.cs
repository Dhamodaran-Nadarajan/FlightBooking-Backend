using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Model;

namespace UserManagement.Repository
{
    public interface IUserRepository
    {
        Task<bool> IsUserNameExists(string user);
        Task<User> AddNewUser(User user);
        Task<User> GetUser(string username);
        bool DeleteUser(int userId);
    }
}
