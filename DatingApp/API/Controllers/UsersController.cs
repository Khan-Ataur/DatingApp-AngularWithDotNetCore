using System;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")] // api/users
public class UsersController(DataContext context):ControllerBase
{
    // private readonly DataContext _context;
    // public UsersController(DataContext context)
    // {
    //     _context=context;
    // } // in C# 12.0 version this dependency injection make more simple just inject the DbContext in class

    [HttpGet]
    public ActionResult<IEnumerable<AppUser>> GetUsers()
    {
        var users = context.Users.ToList();
        // return Ok(users);
        return users;
    }


    [HttpGet("{id:int}")] // /api/users/3
    public ActionResult<AppUser> GetUser(int id)
    {
        var user = context.Users.Find(id);
        if(user==null)
        {
            return NotFound();
        }      
        return user;
    }


}
