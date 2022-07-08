using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProductionPracticeGUAP.API.Enums;
using ProductionPracticeGUAP.API.Infrastructure;
using ProductionPracticeGUAP.API.Models.Requests;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ProductionPracticeGUAP.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : Controller
{
    [HttpPost]
    public string Login([FromBody] OwnerLoginRequest request)
    {
        if (request == default || request.Email == default) return string.Empty;
        var roleClaim = new Claim(ClaimTypes.Role, (request.Email == "q@qq.qq" ? RoleEnum.Admin : RoleEnum.Owner).ToString());
        var claims = new List<Claim> { new Claim(ClaimTypes.Name, request.Email), roleClaim };
        var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromDays(1)), 
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }
}
