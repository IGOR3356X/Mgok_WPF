using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SteamDesktop.Contracts;
using SteamDesktop.Interfaces;
using SteamDesktop.Interfaces.Services;
using SteamDesktop.Models;
using SteamDesktop.Reposiotory;

namespace SteamDesktop.Services
{
    class UserServices : IUserServices
    {
        private readonly IGenericRepository<User> _repository;
        public UserServices(IGenericRepository<User> repository)
        {
            _repository = repository;
        }
        public async Task<List<User>> GetAllAsync()
        {
            return await _repository.GetQueryable()
                .Include(x => x.Role)
                .ToListAsync();
        }

        public async Task<List<User>> GetAllWithDetails()
        {
            return null;
        }

        public Task<User> GetByIdAsync(IdContract id)
        {
            throw new NotImplementedException();
        }

        public Task<User> CreateAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> DeleteAsync(IdContract id)
        {
            throw new NotImplementedException();
        }
    }
}
