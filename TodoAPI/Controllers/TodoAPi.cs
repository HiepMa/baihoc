using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TodoAPI.Models.Requests;

namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthController _context;
        public AuthController(AuthController context)
        {
            _context = context;
        }
        [HttpPost("Token")]
        public ActionResult Token(LoginRequest request)        {
            if(!String.IsNullOrEmpty(request.username) && !String.IsNullOrEmpty(request.password))
            {
                if(_context.User.ToList().Count ==0)
                {
                    User auser = new User
                    {
                        username
                    }
                }
                if(request.username=="admin" && request.password == "admin")
                {
                    var claimData = new[] { new Claim(ClaimTypes.Name, "username") };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("1234567891234560"));
                var singingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
                var token = new JwtSecurityToken(
                    issuer: "mysite.com",
                    audience: "mysite.com",
                    expires: DateTime.Now.AddMinutes(2),
                    claims: claimData,
                    signingCredentials: singingCredentials
                    );
                var tokenstring = new JwtSecurityTokenHandler().WriteToken(token);
                    return Ok(tokenstring);
                }
                

            }

            return Unauthorized();
        }
    }
}
