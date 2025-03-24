using Microsoft.EntityFrameworkCore;
using UP_02_Glebov_Drachev.Models;

namespace UP_02_Glebov_Drachev.Contexts
{
    public class DisciplineProgramsContext : BaseContext
    {
        public DbSet<DisciplineProgramsModel> DisciplinePrograms { get; set; }
        public DisciplineProgramsContext()
        {
            Database.Migrate();
            DisciplinePrograms.Load();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DisciplineProgramsModel>()
                .HasOne(a => a.LessonType)
                .WithMany()
                .HasForeignKey(a => a.LessonTypeId);

            modelBuilder.Entity<DisciplineProgramsModel>()
                .HasOne(a => a.Discipline)
                .WithMany()
                .HasForeignKey(a => a.DisciplineId);
        }
    }
}
