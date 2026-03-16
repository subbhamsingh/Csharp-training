using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    [HttpGet("login")]
    public async Task<IActionResult> Login()
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, "DemoUser")
        };

        var identity = new ClaimsIdentity(claims, "DemoScheme");
        var principal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync("DemoScheme", principal);

        return Ok("Logged in");
    }
}
