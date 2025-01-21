using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SteamDesktop.Context;
using SteamDesktop.Contracts;
using SteamDesktop.Interfaces;
using SteamDesktop.Models;

namespace SteamDesktop.Reposiotory
{
    public class GenericRepository<T>: IGenericRepository<T> where T : class
    {
        private readonly WpfContext _context;

        public GenericRepository(WpfContext context)
        {
            _context = context;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public IQueryable<T> GetQueryable()
        {
            return _context.Set<T>();
        }

        public async Task<T> GetByIdAsync(IdContract idContract)
        {
            throw new NotImplementedException();
        }

        public Task<T> CreateAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> DeleteAsync(IdContract idContract)
        {
            throw new NotImplementedException();
        }
    }
}
