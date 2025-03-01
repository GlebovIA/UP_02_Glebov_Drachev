﻿using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using UP_02_Glebov_Drachev.Classes;
using UP_02_Glebov_Drachev.Models;

namespace UP_02_Glebov_Drachev.Contexts
{
    public class ConsultationsContext : DbContext
    {
        public DbSet<ConsultationsModel> Consultations { get; set; }

        public ConsultationsContext()
        {
            Database.EnsureCreated();
            Consultations.Load();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(new MySqlConnection(DBConnection.ConnectionString));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConsultationsModel>()
                .HasOne(c => c.Discipline)
                .WithMany()
                .HasForeignKey(c => c.DisciplineId)
                .IsRequired();
        }
    }
}
