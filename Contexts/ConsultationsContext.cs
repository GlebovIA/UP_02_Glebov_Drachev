using Microsoft.EntityFrameworkCore;
using UP_02_Glebov_Drachev.Models;

namespace UP_02_Glebov_Drachev.Contexts
{
    public class ConsultationsContext : BaseContext
    {
        public DbSet<ConsultationsModel> Consultations { get; set; }

        public ConsultationsContext()
        {
            Database.EnsureCreated();
            Consultations.Load();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConsultationsModel>()
                .HasOne(c => c.Discipline)
                .WithMany()
                .HasForeignKey(c => c.DisciplineId)
                .IsRequired();
        }
    }
}
