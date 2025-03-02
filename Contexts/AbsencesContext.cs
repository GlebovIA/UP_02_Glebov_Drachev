using Microsoft.EntityFrameworkCore;
using UP_02_Glebov_Drachev.Models;

namespace UP_02_Glebov_Drachev.Contexts
{
    public class AbsencesContext : BaseContext
    {
        public DbSet<AbsencesModel> Absences { get; set; }
        public AbsencesContext()
        {
            Database.Migrate();
            Absences.Load();
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
