using Microsoft.AspNetCore.Mvc;
using SOneWeb.Api.DTOs;
using SOneWeb.Application.Services;
using SOneWeb.Domain.Entities;

namespace SOneWeb.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly BaseService<UserCreateDto, UserEntity> _userService;

        public UserController(BaseService<UserCreateDto, UserEntity> userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserCreateDto userDto)
        {
            var created = await _userService.AddAsync(userDto);
            return Ok(created);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }
    }
}
