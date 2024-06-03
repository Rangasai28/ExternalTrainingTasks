using AutoMapper;
using ArchitectureWebApi.Core.Models;
using ArchitectureWebApi.Core.DTOs;
namespace ArchitectureWebAPi.Helpers.Mappings
{
    public class MapperConfig
    {
        public static IMapper IntializeMapper()
        {
            var mapper = new MapperConfiguration(cnfg =>
            {
                cnfg.CreateMap<StudentDto, Student>();
                cnfg.CreateMap<EmployeeDto, Employee>();
            });

            return mapper.CreateMapper();

        }
    }
}
