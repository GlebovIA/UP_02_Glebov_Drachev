using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using UP_02_Glebov_Drachev.Classes;
using UP_02_Glebov_Drachev.Models;

namespace UP_02_Glebov_Drachev.Contexts
{
    public class DisciplinesContext : DbContext
    {
        public DbSet<DisciplinesModel> Disciplines { get; set; }

        public DisciplinesContext()
        {
            Database.EnsureCreated();
            Disciplines.Load();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(new MySqlConnection(DBConnection.ConnectionString));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DisciplinesModel>()
                .HasOne(d => d.Teacher)
                .WithMany(t => t.Disciplines)
                .HasForeignKey(d => d.TeacherId);
        }
    }
}
