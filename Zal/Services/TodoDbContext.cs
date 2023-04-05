using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zal.Controllers;

namespace Zal.Services
{
    public class TodoDbContext : DbContext
    {
        public DbSet<ToDoModel> ToDoModels { get; set; }

        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}