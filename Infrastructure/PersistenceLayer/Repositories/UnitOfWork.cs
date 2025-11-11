using DomainLayer.Contracts;
using DomainLayer.Models;
using PersistenceLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceLayer.Repositories
{
    public class UnitOfWork(StoreDbContext _context) : IUnitOfWork
    {
        private readonly Dictionary<string, object> _repositories = [];
        public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
            // Get Type Name
            var typeName = typeof(TEntity).Name;

            // Dic<strig,object> --> product , object from GenericRpo of product

            //if(_repositories.ContainsKey(typeName)) 
            //    return (IGenericRepository < TEntity, TKey>)_repositories[typeName] ;

            if (_repositories.TryGetValue(typeName , out object? value))
                return (IGenericRepository<TEntity, TKey>) value;
            else
            {
                //Create Object

                var repo = new GenericRepository<TEntity, TKey>(_context);
                //_repositories[typeName] = repo ; //store repo in dictionary   
                _repositories.Add(typeName, repo);
                return repo ;
            }
        }

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
