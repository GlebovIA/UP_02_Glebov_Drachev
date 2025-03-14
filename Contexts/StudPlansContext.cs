using Microsoft.EntityFrameworkCore;
using UP_02_Glebov_Drachev.Models;

namespace UP_02_Glebov_Drachev.Contexts
{
    public class StudPlanContext : BaseContext
    {
        public DbSet<StudPlanModel> StudPlans { get; set; }

        public StudPlanContext()
        {
            Database.Migrate();
            StudPlans.Load();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudPlanModel>()
                .HasOne(sp => sp.TeachersLoad)
                .WithMany()
                .HasForeignKey(sp => sp.TeachersLoadId);
        }
    }
}