using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task.Entities
{
    public class TaskDbContext : DbContext
    {
        private readonly IConfiguration _config;

        public TaskDbContext(DbContextOptions options, IConfiguration config) : base(options)
        {
            _config = config;
        }

        public DbSet<User> User { get; set; }
        public DbSet<Message> Message { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("TaskConnectionString"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            
        }

    }


}
