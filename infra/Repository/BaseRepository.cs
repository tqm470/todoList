using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoApp.Domain.Entity;
using TodoApp.Domain.Repository;

namespace TodoApp.Infra.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext _context;
        public BaseRepository(AppDbContext appDbContext) => _context = appDbContext;
        public virtual async Task Insert(T obj)
        {
            await _context.Set<T>().AddAsync(obj);
        }

        public virtual async Task Remove(Guid id)
        {
            _context.Set<T>().Remove( await Select(id) );
        }

        public virtual async Task<T> Select(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual async Task<IList<T>> SelectAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual void Update(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
        }
    }
}