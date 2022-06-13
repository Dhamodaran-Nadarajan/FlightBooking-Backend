using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Model;

namespace UserManagement.Repository
{
    public class UserRepository : IUserRepository
    {
        #region Private Fields & Constructor

        private readonly UserDBContext _context;
        public UserRepository(UserDBContext context)
        {
            this._context = context;
        }

        #endregion


        #region Public Methods

        public async Task<User> GetUser(string username)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.UserName.Equals(username));
        }

        public async Task<User> AddNewUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public bool DeleteUser(int userId)
        {
            bool result = false;
            User user = _context.Users.FirstOrDefault(users => users.UserId.Equals(userId));
            if(user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
                result = true;
            }
            return result;
        }

        public async Task<bool> IsUserNameExists(string username)
        {
            return await _context.Users.AnyAsync( users => users.UserName.ToLower().Equals(username.ToLower()));
        }

        #endregion
    }
}
