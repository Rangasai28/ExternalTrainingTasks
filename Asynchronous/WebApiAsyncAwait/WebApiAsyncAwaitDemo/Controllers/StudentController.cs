using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAsyncAwaitDemo.Data;
using WebApiAsyncAwaitDemo.Models;
namespace WebApiAsyncAwaitDemo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    readonly ContextClass  studentContext;
    public StudentController(ContextClass context)
    {
        studentContext = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Students>>> GetStudents()
    {
        return await studentContext.Students.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Students>> GetStudent(int id)
    {
        if (studentContext.Students == null)
        {
            return NotFound(); // 404 - preferred to return results in HTTP codes
        }
        var product = await studentContext.Students.FindAsync(id);

        if (product == null)
        {
            return NotFound();
        }

        return product;
    }

    [HttpPost("Add")]
    public async Task<ActionResult<Students>> AddStudent(Students student)
    {
        studentContext.Students.Add(student);
        await studentContext.SaveChangesAsync();

        return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student); 
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateStudent(int id, Students student)
    {
        if (id != student.Id)
        {
            return BadRequest();
        }
        studentContext.Entry(student).State = EntityState.Modified;

        try
        {
            await studentContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!StudentExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteStudent(int id)
    {
        if (studentContext.Students == null)
        {
            return NotFound();
        }

        var product = await studentContext.Students.FindAsync(id);
        if (product == null)
        {
            return NotFound();
        }

        studentContext.Students.Remove(product);
        await studentContext.SaveChangesAsync();

        return NoContent();
    }

    private bool StudentExists(int id)
    {
        return (studentContext.Students?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
