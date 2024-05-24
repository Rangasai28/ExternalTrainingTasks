using AutoMapper;
using WebApiDTOsDemo.Models;

namespace WebApiDTOsDemo.Config
{
    public class MapperConfig
    {
        public static IMapper IntializeMapper()
        {
            var mapper = new MapperConfiguration(cnfg =>
            {
                cnfg.CreateMap<StudentDtoPost, Student>();
                cnfg.CreateMap<StudentDtoPut, Student>();


            });

            return mapper.CreateMapper();




        }
    }
}
