using System;
using System.Security.Cryptography.X509Certificates;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

// public class DataContext : DbContext
// {
//     public DataContext(DbContextOptions options): base(options)
//     {
        
//     }

//     public DbSet<AppUser> users {get;set;}
// }


/// <summary>
/// This is primary constructor of DataContext class. 
/// </summary>
/// <param name="options"></param>
    public class DataContext(DbContextOptions options): DbContext(options)
    {
         public DbSet<AppUser> Users {get;set;}
    }

   
