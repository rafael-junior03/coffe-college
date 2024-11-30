using Microsoft.AspNetCore.Mvc;
using Site_Cafeteria.Entities;
using Site_Cafeteria.Repositories;

namespace Site_Cafeteria.Controllers;

[ApiController]
[Route("user")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Post([FromBody] User user)
    {
        try
        {
            await _userRepository.Create(user);
            return Ok(
                
            );
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] Login dto)
    {
        try
        {
            var result = await _userRepository.Login(dto);

            if(!result) return StatusCode(401);

            return Ok(
                
            );
        }
        catch (Exception ex)
        {
            return StatusCode(401, ex.Message);
        }
    }
}
