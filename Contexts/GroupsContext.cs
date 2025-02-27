using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using UP_02_Glebov_Drachev.Classes;
using UP_02_Glebov_Drachev.Models;

namespace UP_02_Glebov_Drachev.Contexts
{
    public class GroupsContext : DbContext
    {
        public DbSet<GroupsModel> Groups { get; set; }
        public GroupsContext()
        {
            Database.MigrateAsync();
            Groups.Load();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(new MySqlConnection(DBConnection.ConnectionString));
        }
    }
}
