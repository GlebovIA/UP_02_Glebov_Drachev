using Microsoft.EntityFrameworkCore;
using UP_02_Glebov_Drachev.Models;

namespace UP_02_Glebov_Drachev.Contexts
{
    public class LessonsContext : BaseContext
    {
        public DbSet<LessonModel> Lessons { get; set; }
        public LessonsContext()
        {
            Database.Migrate();
            Lessons.Load();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LessonModel>()
                .HasOne(a => a.DisciplineProgram)
                .WithMany()
                .HasForeignKey(a => a.DisciplineProgramId);

            modelBuilder.Entity<LessonModel>()
                .HasOne(a => a.StudGroup)
                .WithMany()
                .HasForeignKey(a => a.StudGroupId);
        }
    }
}
