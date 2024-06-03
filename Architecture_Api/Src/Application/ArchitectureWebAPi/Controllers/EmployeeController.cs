using ArchitectureWebApi.Core.Contracts.IRepositories;
using ArchitectureWebApi.Core.DTOs;
using ArchitectureWebApi.Core.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ArchitectureWebAPi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IPersonRepository<Employee> _repo;
    private readonly IMapper mapper;
    public EmployeeController(IPersonRepository<Employee> repo, IMapper map)
    {
        _repo = repo;
        mapper = map;
    }



    [HttpGet]
    public async Task<IActionResult> GetEmpDetails()
    {
        var emp = await _repo.GetStdDetails();
        return Ok(emp);
    }

    [HttpGet("{empid}")]
    public async Task<IActionResult> GetEmployeeById(int empid)
    {
        var employee = await _repo.GetStdDetailsById(empid);
        if (employee == null)
        {
            return NotFound();
        }
        return Ok(employee);
    }

    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> Create(EmployeeDto emp)
    {
        if (emp == null)
        {
            return BadRequest();
        }
        try
        {
            var employee = mapper.Map<EmployeeDto, Employee>(emp);
            var result = await _repo.Create(employee);
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
    public async Task<IActionResult> Update(EmployeeDto emp, int id)
    {
        if (emp == null)
        {
            return BadRequest();
        }
        try
        {
            var result = await _repo.PersonExists(id);

            if (result.Item1)
            {
                result.Item2.Name = emp.Name;
                result.Item2.Address = emp.Address;
                result.Item2.Phone = emp.Phone;
                result.Item2.Department = emp.Department;
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
                Error = $"An error occurred:{ex.Message}"
            });
        }
    }

    [HttpDelete("{empid}")]
    public async Task<IActionResult> Delete(int empid)
    {
        var result = await _repo.Delete(empid);
        if (result.Item1)
        {
            return Ok(new { message = "Employee deleted successfully" });
        }
        else
        {
            return BadRequest(new { message = result.Item2 });
        }
    }
}
