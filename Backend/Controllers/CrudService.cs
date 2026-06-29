using AutoMapper;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    public class CrudService
    {
        private readonly DBConfig _config;
        private readonly IMapper _mapper;
        private readonly JWTService _jwtservice;

        public CrudService(DBConfig config,IMapper mapper,JWTService jwtservice)
        {
            _config = config;
            _mapper = mapper;
            _jwtservice = jwtservice;
        }


       public async Task<Employee> GetEmpByEmail(EmployeeDto dto)
        {
            return await _config.Employees.FirstOrDefaultAsync(e => e.Email == dto.Email);
        }


        public async Task<string> login(EmployeeDto dto)
        {
            var user = await GetEmpByEmail(dto);
            if (user == null)
            {
                 throw new Exception();
            }
            return _jwtservice.GenerateToken();
        }

        public async Task<Employee> store(EmployeeDto dto)
        {
            Employee emp = _mapper.Map<Employee>(dto);
            _config.Employees.Add(emp);
            await _config.SaveChangesAsync();

            return emp;

        }

        public async Task<List<EmployeeDto>> Get()
        {
            var emp = _config.Employees.ToListAsync();
            return _mapper.Map<List<EmployeeDto>>(emp);
        }
    }
}
