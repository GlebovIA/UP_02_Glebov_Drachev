using Microsoft.EntityFrameworkCore;
using UP_02_Glebov_Drachev.Models;

namespace UP_02_Glebov_Drachev.Contexts
{
    public class DisciplinesContext : BaseContext
    {
        public DbSet<DisciplinesModel> Disciplines { get; set; }
        public DbSet<TeachersModel> Teachers { get; set; }  // Добавьте эту строку

        public DisciplinesContext()
        {
            Database.EnsureCreated();
            Disciplines.Load();
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
