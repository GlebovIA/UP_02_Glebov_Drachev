using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using UP_02_Glebov_Drachev.Classes;
using UP_02_Glebov_Drachev.Models;

namespace UP_02_Glebov_Drachev.Contexts
{
    public class TeachersLoadContext : DbContext
    {
        public DbSet<TeacherLoadsModel> TeachersLoad { get; set; }
        public TeachersLoadContext()
        {
            Database.EnsureCreated();
            TeachersLoad.Load();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(new MySqlConnection(DBConnection.ConnectionString));
        }
    }
}
