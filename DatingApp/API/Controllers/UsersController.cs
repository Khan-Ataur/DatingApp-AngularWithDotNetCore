using System;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[Authorize]
public class UsersController(IUserRepository userRepository, IMapper mapper) : BaseApiController
{
    // private readonly DataContext _context;
    // public UsersController(DataContext context)
    // {
    //     _context=context;
    // } // in C# 12.0 version this dependency injection make more simple just inject the DbContext in class


    [HttpGet]
    public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
    {
        var users = await userRepository.GetUsersAsync();

        var userToReturn = mapper.Map<IEnumerable<MemberDto>>(users);
        return Ok(userToReturn);
    }


    [HttpGet("{username}")] // /api/users/3
    public async Task<ActionResult<MemberDto>> GetUser(string username)
    {
        var user = await userRepository.GetUserByUsernameAsync(username);
        if (user == null)
        {
            return NotFound();
        }
        var userToReturn = mapper.Map<MemberDto>(user);
        return userToReturn;
    }


}
