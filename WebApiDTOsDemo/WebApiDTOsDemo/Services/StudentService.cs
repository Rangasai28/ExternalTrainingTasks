using Microsoft.EntityFrameworkCore;
using WebApiDTOsDemo.Data;
using WebApiDTOsDemo.Repository;
using WebApiDTOsDemo.Models;


namespace WebApiDTOsDemo.Services;

public class StudentService : IStudentService
{
    private readonly ContextDb ContextClass;

    public StudentService(ContextDb context)
    {
        ContextClass = context;
    }

    async Task<Student> IStudentService.GetByIdAsync(int id)
    {
        return await ContextClass.Students.FindAsync(id);
    }
    async Task<Student> IStudentService.AddAsync(Student student)
    {
        ContextClass.Students.Add(student);
        await ContextClass.SaveChangesAsync();
        return student;
    }

    async Task<bool> IStudentService.DeleteAsync(int Id)
    {
        if (ContextClass.Students == null)
        {
            return false;
        }
        var product = await ContextClass.Students.FindAsync(Id);
        if (product == null)
        {
            return false;
        }
        ContextClass.Students.Remove(product);
        await ContextClass.SaveChangesAsync();
        return true;
    }


    async Task<bool> IStudentService.UpdateAsync(Student student)
    {
        ContextClass.Entry(student).State = EntityState.Modified;
        try
        {
            await ContextClass.SaveChangesAsync();
            return true;
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!StudentExists(student.Id))
            {
                return false;
            }
            else
            {
                throw;
            }
        }

    }
    public bool StudentExists(int id)
    {
        return (ContextClass.Students?.Any(e => e.Id == id)).GetValueOrDefault();
    }

    async Task<IEnumerable<StudentDtoGet>> IStudentService.GetAllAsync()
    {
        var studentDtos = await ContextClass.Students.Select(s => new StudentDtoGet
        {
            FullName = s.FullName,
            Phone = s.Phone,
            CollegeName = s.CollegeName,
            IsActive = s.IsActive
        }).ToListAsync();
        return studentDtos;
    }
}
