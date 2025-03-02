using Microsoft.EntityFrameworkCore;
using UP_02_Glebov_Drachev.Models;

namespace UP_02_Glebov_Drachev.Contexts
{
    public class StudPlansContext : BaseContext
    {
        public DbSet<AbsencesModel> Absences { get; set; }
        public void AbsencesContext()
        {
            Database.EnsureCreated();
            Absences.Load();
        }
    }
}
