using Microsoft.AspNetCore.Mvc;
using Site_Cafeteria.Entities;
using Site_Cafeteria.Repositories;

namespace Site_Cafeteria.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpPost]
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
}
