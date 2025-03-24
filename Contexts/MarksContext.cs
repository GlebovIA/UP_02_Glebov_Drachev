using Microsoft.EntityFrameworkCore;
using UP_02_Glebov_Drachev.Models;

namespace UP_02_Glebov_Drachev.Contexts
{
    public class MarksContext : BaseContext
    {
        public DbSet<MarksModel> Marks { get; set; }

        public MarksContext()
        {
            Database.Migrate();
            Marks.Include(m => m.Lesson).ThenInclude(l => l.DisciplineProgram).Load();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MarksModel>()
                .HasOne(a => a.Student)
                .WithMany()
                .HasForeignKey(a => a.StudentId);

            modelBuilder.Entity<MarksModel>()
                .HasOne(a => a.Lesson)
                .WithMany()
                .HasForeignKey(a => a.LessonId);
        }
    }
}