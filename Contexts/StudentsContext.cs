using Microsoft.EntityFrameworkCore;
using UP_02_Glebov_Drachev.Models;

namespace UP_02_Glebov_Drachev.Contexts
{
    public class StudentsContext : BaseContext
    {
        public DbSet<StudentsModel> Students { get; set; }
        public StudentsContext()
        {
            Database.MigrateAsync();
            Students.Load();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentsModel>()
                .HasOne(a => a.StudGroup)
                .WithMany()
                .HasForeignKey(a => a.StudGroupId);
        }
    }
}
