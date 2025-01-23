using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SteamDesktop.Contracts;
using SteamDesktop.Models;

namespace SteamDesktop.Interfaces.Services
{
    public interface IUserServices
    {
        public Task<List<User>> GetAllAsync();
        public Task<User> GetByIdAsync(IdContract id);
        public Task<bool> AuthorizeUser(AuthorizationContract data);
        public Task<User> CreateAsync();
        public Task<User> UpdateAsync();
        public Task<User> DeleteAsync(IdContract id);
    }
}
