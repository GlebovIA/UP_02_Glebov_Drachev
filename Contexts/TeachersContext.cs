using Microsoft.EntityFrameworkCore;
using UP_02_Glebov_Drachev.Models;

namespace UP_02_Glebov_Drachev.Contexts
{
    public class TeachersContext : BaseContext
    {
        public DbSet<TeachersModel> Teachers { get; set; }
        public TeachersContext()
        {
            Database.EnsureCreated();
            Teachers.Load();
        }
    }
}
