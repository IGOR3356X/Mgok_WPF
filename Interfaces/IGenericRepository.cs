using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SteamDesktop.Contracts;
using SteamDesktop.Models;

namespace SteamDesktop.Interfaces
{
    interface IGenericRepository<T> where T : class
    {
        public Task<List<T>> GetAllAsync();
        public Task<T> GetByIdAsync(IdContract id);
        public Task<T> CreateAsync();
        public Task<T> UpdateAsync();
        public Task<T> DeleteAsync(IdContract id);
        public IQueryable<T> GetQueryable();
    }
}
