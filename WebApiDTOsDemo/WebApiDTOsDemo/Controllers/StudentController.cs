using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiDTOsDemo.Data;
using WebApiDTOsDemo.Models;

namespace WebApiDTOsDemo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly ContextDb studentContext;
    private readonly IMapper mapper;
    public StudentController(ContextDb context,IMapper map) 
    {
        studentContext = context;
        mapper = map;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<StudentDtoGet>>> GetStudents()
    {
        var studentDtos = studentContext.Students.Select(s => new StudentDtoGet
        {
            FullName = s.FullName,
            Phone = s.Phone,
            CollegeName = s.CollegeName,
            IsActive = s.IsActive
        }).ToList();
        return Ok(studentDtos);
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<StudentDtoGet>> GetById(int Id)
    {
        if (studentContext.Students == null)
        {
            return NotFound(); // 404 - preferred to return results in HTTP codes
        }
        var student = await studentContext.Students.FindAsync(Id);

        if (student == null)
        {
            return NotFound();
        }
        var studentDtoGet = new StudentDtoGet
        {
            FullName = student.FullName,
            Phone = student.Phone,
            CollegeName = student.CollegeName,
            IsActive = student.IsActive
        };
        return Ok(studentDtoGet);
    }

    [HttpPost]
    public async Task<ActionResult<StudentDtoGet>> AddStudent(StudentDtoPost studentDtoPost)
    {
        
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

   var student =     mapper.Map<StudentDtoPost, Student>(studentDtoPost);
        //var student = new Student()
        //{
        //    FirstName = studentDtoPost.FirstName,
        //    MiddleName = studentDtoPost.MiddleName,
        //    LastName = studentDtoPost.LastName,
        //    FullName = studentDtoPost.FullName,
        //    Gender = studentDtoPost.Gender,
        //    DateOfBirth = DateOnly.Parse(studentDtoPost.DateOfBirth),
        //    Address = studentDtoPost.Address,
        //    Phone = studentDtoPost.Phone,
        //    GuardianName = studentDtoPost.GuardianName,
        //};
        studentContext.Students.Add(student);
        await studentContext.SaveChangesAsync();

        var studentGet = new StudentDtoGet
        {
            FullName = student.FirstName,
            Phone = student.Phone,
            CollegeName = student.CollegeName,
            IsActive = student.IsActive,
        };
        return CreatedAtAction(nameof(GetById), new { id = student.Id }, studentGet);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateStudent(StudentDtoPut studentDtoPut,int Id)
    { 
        var student = await studentContext.Students.FindAsync(Id);

        student.Address = studentDtoPut.Address;
        student.Phone = studentDtoPut.Phone;
        student.IsActive = studentDtoPut.IsActive;
        student.UpdatedDate = DateTime.Now;
        studentContext.Entry(student).State = EntityState.Modified;
        try
        {
            await studentContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!StudentExists(Id))
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
    public async Task<ActionResult> DeleteStudent(int Id)
    {
        if (studentContext.Students == null)
        {
            return NotFound();
        }

        var student = await studentContext.Students.FindAsync(Id);
        if (student == null)
        {
            return NotFound();
        }

        studentContext.Students.Remove(student);
        await studentContext.SaveChangesAsync();

        return NoContent();
    }
    private bool StudentExists(int id)
    {
        return (studentContext.Students?.Any(e => e.Id == id)).GetValueOrDefault();
    }

}
