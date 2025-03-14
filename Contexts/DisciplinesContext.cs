using Microsoft.EntityFrameworkCore;
using UP_02_Glebov_Drachev.Models;

namespace UP_02_Glebov_Drachev.Contexts
{
    public class DisciplinesContext : BaseContext
    {
        public DbSet<DisciplinesModel> Disciplines { get; set; }

        public DisciplinesContext()
        {
            Database.EnsureCreated();
            Disciplines.Load();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DisciplinesModel>()
                .HasOne(d => d.Teacher)
                .WithMany()
                .HasForeignKey(d => d.TeacherId);
        }
    }
}
