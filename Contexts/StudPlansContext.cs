using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using UP_02_Glebov_Drachev.Classes;
using UP_02_Glebov_Drachev.Models;

namespace UP_02_Glebov_Drachev.Contexts
{
    public class StudPlansContext : DbContext
    {
        public DbSet<AbsencesModel> Absences { get; set; }
        public void AbsencesContext()
        {
            Database.EnsureCreated();
            Absences.Load();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(new MySqlConnection(DBConnection.ConnectionString));
        }
    }
}
