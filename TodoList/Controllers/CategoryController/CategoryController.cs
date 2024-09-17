/*
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using SQLitePCL;

namespace TodoList.Controllers.CategoryController;

public class CategoryController: Controller
{
    private object _context;
    [ApiController]
    [Route("api/[controller]")]
    
    public class BooksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BooksController(AppDbContext context)
        {
            _context = context;
        }
    }
    [HttpPost]
    public async Task<ActionResult<Category>> PostCategory(Category book)
    {
        _context.Categories.Add(book);
        await _context.SaveChangesAsync();

        return Ok(book) ;
        
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Category>> GetCategory(int id)
    {
        var Category = await _context.Categories.FindAsync(id);

        if (Category == null)
        {
            return NotFound();
        }

        return Ok(Category);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCategory(int id, Category Category)
    {
        if (id != Category.Id)
        {
            return BadRequest();
        }
        _context.Update(Category);
        _context.SaveChanges();
        return Ok(Category) ;
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        var book = await _context.Categoryes.FindAsync(id);
        if (book == null)
        {
            return NotFound();
        }

        _context.Categoryes.Remove(book);
        await _context.SaveChangesAsync();

        return Ok();
    }
   

}*/
using Data; // اطمینان حاصل کنید که فضای نام AppDbContext را شامل می‌شود
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace TodoList.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return Ok(category);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            if (id != category.id)
            {
                return BadRequest();
            }

            _context.Entry(category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(category);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}