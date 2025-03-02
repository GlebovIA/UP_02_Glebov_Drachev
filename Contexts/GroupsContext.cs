using Microsoft.EntityFrameworkCore;
using UP_02_Glebov_Drachev.Models;

namespace UP_02_Glebov_Drachev.Contexts
{
    public class GroupsContext : BaseContext
    {
        public DbSet<GroupsModel> Groups { get; set; }
        public GroupsContext()
        {
            Database.MigrateAsync();
            Groups.Load();
        }
    }
}
