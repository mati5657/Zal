using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zal.Controllers;
using Zal.Entities;

namespace Zal.Services
{
    public class TodoDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ToDoModel> ToDoModels { get; set; }
        public DbSet<ApplicationUser> users { get; set; }

        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}