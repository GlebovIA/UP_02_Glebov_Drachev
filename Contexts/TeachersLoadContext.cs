using Microsoft.EntityFrameworkCore;
using UP_02_Glebov_Drachev.Models;

namespace UP_02_Glebov_Drachev.Contexts
{
    public class TeachersLoadContext : BaseContext
    {
        public DbSet<TeachersLoadModel> TeachersLoads { get; set; }

        public TeachersLoadContext()
        {
            Database.Migrate();
            TeachersLoads.Load();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeachersLoadModel>()
                .HasOne(tl => tl.Teacher)
                .WithMany()
                .HasForeignKey(tl => tl.TeacherId);

            modelBuilder.Entity<TeachersLoadModel>()
                .HasOne(tl => tl.Discipline)
                .WithMany()
                .HasForeignKey(tl => tl.DisciplineId);

            modelBuilder.Entity<TeachersLoadModel>()
                .HasOne(tl => tl.StudGroup)
                .WithMany()
                .HasForeignKey(tl => tl.StudGroupId);
        }
    }
}