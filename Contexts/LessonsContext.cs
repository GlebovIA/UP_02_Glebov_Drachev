using Microsoft.EntityFrameworkCore;
using UP_02_Glebov_Drachev.Models;

namespace UP_02_Glebov_Drachev.Contexts
{
    public class LessonsContext : BaseContext
    {
        public DbSet<LessonsModel> Lessons { get; set; }
        public LessonsContext()
        {
            Database.Migrate();
            Lessons.Load();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LessonsModel>()
                .HasOne(a => a.DisciplineProgram)
                .WithMany()
                .HasForeignKey(a => a.DisciplineProgramId);

            modelBuilder.Entity<LessonsModel>()
                .HasOne(a => a.StudGroup)
                .WithMany()
                .HasForeignKey(a => a.StudGroupId);
        }
    }
}
