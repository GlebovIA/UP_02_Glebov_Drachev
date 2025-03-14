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
            Marks.Load();
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
