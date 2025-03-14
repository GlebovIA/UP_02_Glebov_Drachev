using Microsoft.EntityFrameworkCore;
using UP_02_Glebov_Drachev.Models;

namespace UP_02_Glebov_Drachev.Contexts
{
    public class LessonTypesContext : BaseContext
    {
        public DbSet<LessonTypesModel> LessonTypes { get; set; }

        public LessonTypesContext()
        {
            Database.Migrate();
            LessonTypes.Load();
        }
    }
}