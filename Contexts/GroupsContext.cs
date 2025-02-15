using Microsoft.EntityFrameworkCore;
using UP_02_Glebov_Drachev.Classes;
using UP_02_Glebov_Drachev.Models;

namespace UP_02_Glebov_Drachev.Contexts
{
    public class GroupsContext : DbContext
    {
        public DbSet<GroupsModel> Groups { get; set; }
        public GroupsContext()
        {
            Database.EnsureCreated();
            Groups.Load();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(DBConnection.OpenConnection());
        }
    }
}
