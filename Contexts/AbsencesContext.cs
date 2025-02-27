using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using UP_02_Glebov_Drachev.Classes;
using UP_02_Glebov_Drachev.Models;

namespace UP_02_Glebov_Drachev.Contexts
{
    public class AbsencesContext : DbContext
    {
        public DbSet<AbsencesModel> Absences { get; set; }
        public AbsencesContext()
        {
            Database.EnsureCreated();
            Absences.Load();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            DBConnection.CloseConnection();
            optionsBuilder.UseMySQL(DBConnection.OpenConnection());
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<AbsencesModel>()
            .HasOne(a => a.Student)
            .WithMany()
            .HasForeignKey(a => a.StudentId);

        modelBuilder.Entity<AbsencesModel>()
            .HasOne(a => a.Discipline)
            .WithMany()
            .HasForeignKey(a => a.DisciplineId);
        }
    }
}
