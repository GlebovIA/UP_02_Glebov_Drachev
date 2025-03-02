using Microsoft.EntityFrameworkCore;
using UP_02_Glebov_Drachev.Models;

namespace UP_02_Glebov_Drachev.Contexts
{
    public class MarksContext : BaseContext
    {
        public DbSet<MarksModel> Marks { get; set; }
        public MarksContext()
        {
            Database.EnsureCreated();
            Marks.Load();
        }
    }
}
