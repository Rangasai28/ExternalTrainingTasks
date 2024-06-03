using ArchitectureWebApi.Core.Contracts.IServices;
using ArchitectureWebApi.Core.DTOs;
using ArchitectureWebApi.Core.Contracts.IRepositories;
using ArchitectureWebApi.Core.Models;
using AutoMapper;

namespace ArchitectureWebApi.Infrastructure.Services;

public class StudentService : IStudentServices
{
    readonly IPersonRepository<Student> _repository;
    readonly IMapper mapper;
    public StudentService(IPersonRepository<Student> studentRepository,IMapper map)
    {
        _repository = studentRepository;
        mapper = map;
    }

    public Task<(bool, string)> CreateAndUpdate(EmployeeDto std, int id)
    {
        throw new NotImplementedException();
    }

    public Task<(bool, string)> Delete(int id)
    {
        throw new NotImplementedException();
    }

    Task<List<EmployeeDto>> IStudentServices.GetStdDetails()
    {
        throw new NotImplementedException();
    }

    Task<EmployeeDto> IStudentServices.GetStdDetailsById(int id)
    {
        throw new NotImplementedException();
    }
}
