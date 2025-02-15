using Microsoft.EntityFrameworkCore;
using UP_02_Glebov_Drachev.Classes;
using UP_02_Glebov_Drachev.Models;

namespace UP_02_Glebov_Drachev.Contexts
{
    public class StudentsContext : DbContext
    {
        public DbSet<StudentsModel> Students { get; set; }
        public StudentsContext()
        {
            Database.EnsureCreated();
            Students.Load();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(DBConnection.OpenConnection());
        }
    }
}
