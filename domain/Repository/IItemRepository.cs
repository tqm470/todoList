using System.Threading.Tasks;
using TodoApp.Domain.Entity;

namespace TodoApp.Domain.Repository
{
    public interface IItemRepository : IBaseRepository<Item>
    {
        Task SaveChanges();    
    }
}