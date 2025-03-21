﻿using Microsoft.EntityFrameworkCore;
using UP_02_Glebov_Drachev.Models;

namespace UP_02_Glebov_Drachev.Contexts
{
    public class TeachersContext : BaseContext
    {
        public DbSet<TeachersModel> Teachers { get; set; }

        public TeachersContext()
        {
            Database.Migrate();
            Teachers.Load();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeachersModel>()
                .HasOne(t => t.User)
                .WithMany()
                .HasForeignKey(t => t.UserId);
        }
    }
}