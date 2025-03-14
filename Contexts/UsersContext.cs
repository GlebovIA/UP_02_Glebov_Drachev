using Microsoft.EntityFrameworkCore;
using UP_02_Glebov_Drachev.Models;

namespace UP_02_Glebov_Drachev.Contexts
{
    public class UsersContext : BaseContext
    {
        public DbSet<UsersModel> Users { get; set; }
        public UsersContext()
        {
            Database.Migrate();
            Users.Load();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsersModel>()
                .HasOne(a => a.Role)
                .WithMany()
                .HasForeignKey(a => a.RoleId);
        }
    }
}
