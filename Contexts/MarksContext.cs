using Microsoft.EntityFrameworkCore;
using UP_02_Glebov_Drachev.Classes;
using UP_02_Glebov_Drachev.Models;

namespace UP_02_Glebov_Drachev.Contexts
{
    public class MarksContext : DbContext
    {
        public DbSet<MarksModel> Marks { get; set; }
        public MarksContext()
        {
            Database.EnsureCreated();
            Marks.Load();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(DBConnection.OpenConnection());
        }
    }
}
