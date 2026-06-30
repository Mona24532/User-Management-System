using AutoMapper;
using Backend.Exceptions;
using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Diagnostics;

namespace Backend
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


       public async Task<Employee> GetEmpByEmail(EmployeeLoginDto dto)
        {
            return await _config.Employees.FirstOrDefaultAsync(e => e.Email == dto.Email);
        }


        public async Task<string> login(EmployeeLoginDto dto)
        {
            var user = await GetEmpByEmail(dto);
            if (user == null)
            {
                throw new NotFoundException("Nincs ilyen felhasználó email cím!");
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
            var emp = await _config.Employees.ToListAsync();
            if (emp == null)
            {
                throw new NotFoundException("Nincsenek felhasználók az adatbázisban!");
            }
            return _mapper.Map<List<EmployeeDto>>(emp);
        }
        public async Task<Employee> put(int id,EmployeeDto emp1)
        {
            if (emp1.Role!="Admin")
            {
                throw new UnauthorizedException("Admin jogosultság szükséges a frissítéshez");
            }
            var emp = await _config.Employees.FirstOrDefaultAsync(e => e.Id == id);
            if (emp == null)
            {
                throw new NotFoundException("A keresett felhasználó nem található az adatbázisban!");
            }

            
            _mapper.Map(emp1, emp);
            await _config.SaveChangesAsync();

            return emp;
        }

        public async Task<Employee> delete(int id,string role)
        {

            if (role!="Admin")
            {
                throw new UnauthorizedException("Admin jogosultság szükséges a törléshez!");
            }
            var old_emp = await _config.Employees.FirstOrDefaultAsync(e => e.Id == id);  
            if (old_emp == null)
            {
                throw new NotFoundException("Nincs ilyen felhasználó!");
            }
            _config.Employees.Remove(old_emp);
            await _config.SaveChangesAsync();
            return old_emp;

        }
    }
}
