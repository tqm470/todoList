using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Domain.Entity;
using TodoApp.Domain.Repository;

namespace TodoApp.Api.Controllers
{
    [Route("api/[controller]")]
    public class ItemController : BaseController
    {
        private readonly IItemRepository _repo;
        public ItemController(IItemRepository repo) => _repo = repo;

        
        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            return Ok(await _repo.SelectAll());
        }
        
        [HttpPost]
        public async Task<IActionResult> createItem([FromBody] Item data)
        {
            await _repo.Insert(data);
            await _repo.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> updateItem([FromBody] Item data, Guid id)
        {
            Item entry = await _repo.Select(id);
            entry = data;
            await _repo.SaveChanges();
            return Ok();
        }

    }
}