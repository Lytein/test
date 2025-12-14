using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using store_management_WebAPI;
using store_management_WebAPI.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace store_management_WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly AppDbContext _context;

    public CategoryController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/category
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Category>>> GetAll()
    {
        return await _context.Categories.ToListAsync();
    }

    // GET: api/category/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Category>> GetById(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category == null) return NotFound();
        return category;
    }

    // POST: api/category
    [HttpPost]
    public async Task<ActionResult<Category>> Create(Category category)
    {
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = category.category_id }, category);
    }

    // PUT: api/category/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Category category)
    {
        if (id != category.category_id) return BadRequest();
        _context.Entry(category).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Categories.Any(e => e.category_id == id)) return NotFound();
            throw;
        }

        return NoContent();
    }

    // DELETE: api/category/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category == null) return NotFound();
        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
