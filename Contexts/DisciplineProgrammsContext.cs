﻿using Microsoft.EntityFrameworkCore;
using UP_02_Glebov_Drachev.Classes;
using UP_02_Glebov_Drachev.Models;

namespace UP_02_Glebov_Drachev.Contexts
{
    public class DisciplineProgrammsContext : DbContext
    {
        public DbSet<DisciplineProgrammsModel> DisciplineProgramms { get; set; }
        public DisciplineProgrammsContext()
        {
            Database.EnsureCreated();
            DisciplineProgramms.Load();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(DBConnection.OpenConnection());
        }
    }
}
