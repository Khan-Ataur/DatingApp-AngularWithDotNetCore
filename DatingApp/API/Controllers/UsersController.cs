using System;
using API.Data;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[Authorize]
public class UsersController(IUserRepository userRepository) : BaseApiController
{
    // private readonly DataContext _context;
    // public UsersController(DataContext context)
    // {
    //     _context=context;
    // } // in C# 12.0 version this dependency injection make more simple just inject the DbContext in class

 
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        var users = await userRepository.GetUsersAsync();
        return Ok(users);       
    }

    
    [HttpGet("{username}")] // /api/users/3
    public async Task<ActionResult<AppUser>> GetUser(string username)
    {
        var user = await userRepository.GetUserByUsernameAsync(username);
        if (user == null)
        {
            return NotFound();
        }
        return user;
    }


}
