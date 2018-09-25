using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TodoAPI.Models;
using TodoAPI.Models.Requests;

namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly TodoContext _context;
        public AuthController(TodoContext context)
        {
            _context = context;
        }
        [HttpPost("Token")]
        public ActionResult Token(LoginRequest request)        {
            if(!String.IsNullOrEmpty(request.username) && !String.IsNullOrEmpty(request.password))
            {
                var user = _context.users.Where(x => x.username == request.username &&
                x.pwd == getHash(request.password)).SingleOrDefault();

                if(user != null)
                {
                    var claimData = new[] { new Claim(ClaimTypes.Name,request.username) };
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
        private string getHash(string text)
        {
            byte[] salt = new byte[128 / 8];
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: text, salt: salt, prf: KeyDerivationPrf.HMACSHA1, iterationCount: 10000, numBytesRequested: 256 / 8
                ));
            return hashed;
        }
    }
}
