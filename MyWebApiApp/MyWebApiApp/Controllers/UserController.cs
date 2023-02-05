using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyWebApiApp.Data;
using MyWebApiApp.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MyDBContext _context;
        private readonly AppSetting _appSettings;

        public UserController(MyDBContext context , IOptionsMonitor<AppSetting> optionsMonitor)
        {
                _context = context;
            _appSettings = optionsMonitor.CurrentValue;
            }
        [HttpPost("Login")]
        public  IActionResult Validate (LoginModel model)
        {
            var user  = _context.Users.SingleOrDefault(p => p.UserName == model.UserName &&
            p.Password == model.Password) ;
            if(user == null) // Không đúng người dùng
            {
                return Ok(new ApiResponse
                {
                  Success =    false,
                  Message ="Invalid username/password"
                      
                });
            }
            // Cấp token
            return Ok(new ApiResponse
            {
                Success = true,
                Message = "Authenticate success",
                Data = GenerateToken(user)
            }) ;
        }
        private string GenerateToken(User user)

        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKeyBytes = Encoding.UTF8.GetBytes(_appSettings.SecretKey);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Fullname),
                     new Claim(ClaimTypes.Email, user.Email),
                    new Claim("Username" , user.UserName),
                     new Claim("Id" , user.Id.ToString()),

                     // roles
                     new Claim("TokenId" , Guid.NewGuid().ToString())

                }),
                Expires = DateTime.UtcNow.AddMinutes(1),
              SigningCredentials  = new SigningCredentials(new SymmetricSecurityKey
              (secretKeyBytes), SecurityAlgorithms.HmacSha512Signature)
            };
            var token = jwtTokenHandler.CreateToken(tokenDescription);

            return jwtTokenHandler.WriteToken(token);

        }
             
    }
}
