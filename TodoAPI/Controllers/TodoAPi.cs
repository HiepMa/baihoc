using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("Token")]
        public ActionResult Token()
        {
            var claimData = new[] { new Claim (ClaimTypes.Name, "username" ) };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("123456789123456"));
            var singingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(
                issuer: "mysite.com",
                audience: "mysite.com",
                expires: DateTime.Now.AddMinutes(2),
                claims: claimData,
                signingCredentials: singingCredentials
                );

            return Ok(token);
        }
    }
}
