using Microsoft.EntityFrameworkCore;
using UP_02_Glebov_Drachev.Models;

namespace UP_02_Glebov_Drachev.Contexts
{
    public class DisciplineProgrammsContext : BaseContext
    {
        public DbSet<DisciplineProgramsModel> DisciplineProgramms { get; set; }
        public DisciplineProgrammsContext()
        {
            Database.EnsureCreated();
            DisciplineProgramms.Load();
        }
    }
}
