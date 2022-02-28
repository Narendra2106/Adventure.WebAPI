using Adventure.Infrastructure.AdventureContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Infrastructure.RepositoryBase
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected PlayerAdventureContext _applicationContext { get; set; }

        public RepositoryBase(PlayerAdventureContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public async Task<List<T>> ListAsync()
        {
            return await _applicationContext.Set<T>().ToListAsync();
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _applicationContext.Set<T>().FindAsync(id);
        }
        public async Task<T> CreateAsync(T entity)
        {
            await _applicationContext.Set<T>().AddAsync(entity);
            await _applicationContext.SaveChangesAsync();

            return entity;
        }
        public async Task UpdateAsync(T entity)
        {
            _applicationContext.Entry(entity).State = EntityState.Modified;
            await _applicationContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _applicationContext.Set<T>().Remove(entity);
            await _applicationContext.SaveChangesAsync();
        }
    }
}
