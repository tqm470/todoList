using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.Domain.Entity;

namespace TodoApp.Domain.Repository
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task Insert(T dt);
        void Update(T dt);
        Task Remove(Guid id);
        Task<T> Select(Guid id);
        Task<IList<T>> SelectAll();
    }
}