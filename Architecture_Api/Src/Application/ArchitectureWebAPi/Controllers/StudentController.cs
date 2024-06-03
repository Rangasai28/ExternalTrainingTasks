using ArchitectureWebApi.Core.Contracts.IRepositories;
using ArchitectureWebApi.Core.DTOs;
using ArchitectureWebApi.Core.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;


namespace ArchitectureWebAPi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IPersonRepository<Student> _repo;
    private readonly IMapper mapper;
    public StudentController(IPersonRepository<Student> repo, IMapper map)
    {
        _repo = repo;
        mapper = map;
    }



    [HttpGet]
    public async Task<IActionResult> GetStdDetails()
    {
        var stu = await _repo.GetStdDetails();
        return Ok(stu);
    }


    [HttpGet("{stdid}")]
    public async Task<IActionResult> GetStudentById(int stdid)
    {
        var student = await _repo.GetStdDetailsById(stdid);
        if (student == null)
        {
            return NotFound();
        }
        return Ok(student);
    }

    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> Create(StudentDto std)
    {
        if (std == null)
        {
            return BadRequest();
        }
        try
        {
            var student = mapper.Map<StudentDto, Student>(std);
            var result = await _repo.Create(student);
            if (result.Item1)
            {
                return Ok(new { Message = result.Item2 });
            }
            else
            {
                return BadRequest(new { Error = result.Item2 });
            }
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                Error = $"An error occurred:{ex.Message}"
            });
        }
    }


    [HttpPut]
    [Route("Update")]
    public async Task<IActionResult> Update(StudentDto std, int id)
    {
        if (std == null)
        {
            return BadRequest();
        }
        try
        {
            var result = await _repo.PersonExists(id);
           
            if (result.Item1)
            {
               result.Item2.Name = std.Name;
               result.Item2.Address = std.Address;
                result.Item2.Phone = std.Phone;
                result.Item2.Branch = std.Branch;
                var updateResult = await _repo.Update(result.Item2);
                if (updateResult.Item1)
                {
                    return Ok(new { Message = updateResult.Item2 });
                }
                else
                {
                    return BadRequest(new { Error = updateResult.Item2 });
                }
            }
            else
            {
                return BadRequest(new { Error = result.Item2 });
            }
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                Error = $"An error occurred:{ ex.Message}"});
        }
    }

    [HttpDelete("{stdid}")]
    public async Task<IActionResult> Delete(int stdid)
    {
        var result = await _repo.Delete(stdid);
        if (result.Item1)
        {
            return Ok(new { message = "Student deleted successfully" });
        }
        else
        {
            return BadRequest(new { message = result.Item2 });
        }
    }

}
