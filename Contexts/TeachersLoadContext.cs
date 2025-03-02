using Microsoft.EntityFrameworkCore;
using UP_02_Glebov_Drachev.Models;

namespace UP_02_Glebov_Drachev.Contexts
{
    public class TeachersLoadContext : BaseContext
    {
        public DbSet<TeacherLoadsModel> TeachersLoad { get; set; }
        public TeachersLoadContext()
        {
            Database.EnsureCreated();
            TeachersLoad.Load();
        }
    }
}
