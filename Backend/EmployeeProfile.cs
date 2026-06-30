using AutoMapper;
using Backend.Models;

namespace Backend
{
    public class EmployeeProfile:Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Employee, EmployeeLoginDto>().ReverseMap();
         
        }
    }
}
