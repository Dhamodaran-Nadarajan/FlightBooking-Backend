using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Model;

namespace UserManagement.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
