using DomainLayer.Contracts;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using PersistenceLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceLayer.Repositories
{
    public class GenericRepository<TEntity, TKey>(StoreDbContext _context)
        : IGenericRepository<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
    {
        public async Task AddAsync(TEntity entity)
            => await _context.Set<TEntity>().AddAsync(entity);

        public async Task<IEnumerable<TEntity>> GetAllAsync()
            => await _context.Set<TEntity>().ToListAsync();
        
        public async Task<TEntity?> GetByIdAsync(TKey id)
            => await _context.Set<TEntity>().FindAsync(id);
        
        public void Remove(TEntity entity)
            => _context.Set<TEntity>().Remove(entity);

        public void Update(TEntity entity)
            => _context.Set<TEntity>().Update(entity);
    }
}
