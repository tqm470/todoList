using System.Threading.Tasks;
using TodoApp.Domain.Entity;
using TodoApp.Domain.Repository;

namespace TodoApp.Infra.Repository
{
    public class ItemRepository : BaseRepository<Item>, IItemRepository
    {
        public ItemRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public Task SaveChanges()
        {
            return _context.SaveChangesAsync();
        }
    }
}