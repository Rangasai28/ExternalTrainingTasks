using WebApiDTOsDemo.Models;
namespace WebApiDTOsDemo.Repository;

public interface IStudentService
{
    Task<IEnumerable<StudentDtoGet>> GetAllAsync();
    Task<Student> GetByIdAsync(int id);
    Task<Student> AddAsync(Student student);
    Task<bool> UpdateAsync(Student student);
    Task<bool> DeleteAsync(int id);
    
    bool StudentExists(int id);
}
