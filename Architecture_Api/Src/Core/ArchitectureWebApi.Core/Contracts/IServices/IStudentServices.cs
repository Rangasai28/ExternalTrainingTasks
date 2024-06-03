using ArchitectureWebApi.Core.DTOs;
namespace ArchitectureWebApi.Core.Contracts.IServices;

public  interface IStudentServices
{
    Task<(bool, String)> CreateAndUpdate(EmployeeDto std, int id);
    Task<List<EmployeeDto>> GetStdDetails();
    Task<EmployeeDto> GetStdDetailsById(int id);
    Task<(bool, string)> Delete(int id);
}
