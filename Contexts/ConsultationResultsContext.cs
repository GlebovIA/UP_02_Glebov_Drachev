using Microsoft.EntityFrameworkCore;
using UP_02_Glebov_Drachev.Models;

namespace UP_02_Glebov_Drachev.Contexts
{
    public class ConsultationResultsContext : BaseContext
    {
        public DbSet<ConsultationResultsModel> ConsultationsResults { get; set; }
        public ConsultationResultsContext()
        {
            Database.Migrate();
            ConsultationsResults.Load();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConsultationResultsModel>()
                .HasOne(a => a.Student)
                .WithMany()
                .HasForeignKey(a => a.StudentId);

            modelBuilder.Entity<ConsultationResultsModel>()
                .HasOne(a => a.Consultation)
                .WithMany()
                .HasForeignKey(a => a.ConsultationId);
        }
    }
}
