using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Domain.Repository;

namespace TodoApp.Api.Controllers
{
    public class ItemController : BaseController
    {
        private readonly IItemRepository _repo;
        public ItemController(IItemRepository repo) => _repo = repo;

        [Route("api/[controller]")]
        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            return Ok(await _repo.SelectAll());
        }

    }
}