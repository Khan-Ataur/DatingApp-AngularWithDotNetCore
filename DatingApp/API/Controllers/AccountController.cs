using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
      public class AccountController(DataContext context) : BaseApiController
      {
            [HttpPost("register")] // account/register
            public async Task<ActionResult<AppUser>> Register(RegisterDto registerDto)
            {
                  if (await UserExists(registerDto.Username))
                  {
                        return BadRequest("Username is already exists.");
                  }

                  using var hmac = new HMACSHA512();
                  var user = new AppUser
                  {
                        UserName = registerDto.Username.ToLower(),
                        PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                        PasswordSalt = hmac.Key
                  };

                  context.Users.Add(user);
                  await context.SaveChangesAsync();
                  return Ok(user);
            }

            [HttpPost("login")]
            public async Task<ActionResult<AppUser>> Login(LoginDto loginDto)
            {
                  var user = await context.Users.FirstOrDefaultAsync(x => x.UserName.ToLower() == loginDto.Username.ToLower());
                  if (user == null)
                  {
                        return Unauthorized("Invalid Username");
                  }
                  using var hmac = new HMACSHA512(user.PasswordSalt);
                  var ComputedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));
                  for (int i = 0; i < ComputedHash.Length; i++)
                  {
                        if (ComputedHash[i] != user.PasswordHash[i])
                        {
                              return Unauthorized("Invalid Password");
                        }
                  }
                  return user;
            }
            private async Task<bool> UserExists(string username)
            {
                  return await context.Users.AnyAsync(x => x.UserName.ToLower() == username.ToLower());
            }

      }
}
