using Microsoft.EntityFrameworkCore;
using UP_02_Glebov_Drachev.Classes;
using UP_02_Glebov_Drachev.Models;

namespace UP_02_Glebov_Drachev.Contexts
{
    public class DisciplinesContext : DbContext
    {
        public DbSet<DisciplinesModel> Disciplines { get; set; }
        public DisciplinesContext()
        {
            Database.EnsureCreated();
            Disciplines.Load();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            DBConnection.CloseConnection();
            optionsBuilder.UseMySQL(DBConnection.OpenConnection());
        }
    }
}
