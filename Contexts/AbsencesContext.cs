using Microsoft.EntityFrameworkCore;
using UP_02_Glebov_Drachev.Classes;
using UP_02_Glebov_Drachev.Models;

namespace UP_02_Glebov_Drachev.Contexts
{
    public class AbsencesContext : DbContext
    {
        public DbSet<AbsencesModel> Absences { get; set; }
        public AbsencesContext()
        {
            Database.EnsureCreated();
            Absences.Load();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(DBConnection.OpenConnection());
        }
    }
}
