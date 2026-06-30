using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Login(EmployeeDto dto)
        {
            var login = _service.login(dto);
            return Ok(login);
        }
        [HttpPost("Post")]

        public async Task<IActionResult> Post(EmployeeDto dto)
        {
            var post = _service.store(dto);
            return Ok(post);
        }
        [Authorize]
        [HttpGet("Get")]

        public async Task<IActionResult> Get()
        {
            var list = _service.Get();
            return Ok(list);
        }
    }
}
