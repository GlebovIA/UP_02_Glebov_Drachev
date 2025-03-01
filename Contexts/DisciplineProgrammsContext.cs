﻿using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using UP_02_Glebov_Drachev.Classes;
using UP_02_Glebov_Drachev.Models;

namespace UP_02_Glebov_Drachev.Contexts
{
    public class DisciplineProgrammsContext : DbContext
    {
        public DbSet<DisciplineProgramsModel> DisciplineProgramms { get; set; }
        public DisciplineProgrammsContext()
        {
            Database.EnsureCreated();
            DisciplineProgramms.Load();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(new MySqlConnection(DBConnection.ConnectionString));
        }
    }
}
