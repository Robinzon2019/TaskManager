﻿using Microsoft.EntityFrameworkCore;

namespace TaskManager.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<TaskManager.Models.Task> Tasks { get; set; }
    }
}
