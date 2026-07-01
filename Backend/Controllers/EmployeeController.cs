using Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly CrudService _service;

        public EmployeeController(CrudService service)
        {
            _service = service;
        }

        [HttpPost("login-Post")]
        public async Task<IActionResult> Login(EmployeeLoginDto dto)
        {
            var login =await _service.login(dto);
            return Ok(login);
        }
        [Authorize]
        [HttpPost("Post")]

        public async Task<IActionResult> Post(EmployeeDto dto)
        {
            var post = await _service.store(dto);
            return Ok(post);
        }
        [Authorize]
        [HttpGet("Get")]

        public async Task<IActionResult> Get()
        {
            var list =await _service.Get();
            return Ok(list);
        }
        [Authorize]
        [HttpPut("Put/{id}")]
        public async Task<IActionResult> Put( int id,EmployeeDto emp)
        {
            var role = User.FindFirst(ClaimTypes.Role)?.Value;
            var emp1 = await _service.put(id,emp,role);
            return Ok(emp1);
        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete(int id)
        {
            var role = User.FindFirst(ClaimTypes.Role)?.Value;
            var delete_emp = await _service.delete(id,role);
            return Ok(delete_emp);
        }
        [HttpPost("admin-Post")]
        public async Task<IActionResult> AdminPost( EmployeeLoginDto dto)
        {
           
           
            var adminlog = await _service.Adminlogin(dto);
            return Ok(adminlog);
        }
       
    }
}
