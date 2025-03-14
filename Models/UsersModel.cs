using System.ComponentModel.DataAnnotations.Schema;

namespace UP_02_Glebov_Drachev.Models
{
    [Table("Users")]
    public class UsersModel
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }

        public UsersModel(int id, string login, string password, int roleId)
        {
            Id = id;
            Login = login;
            Password = password;
            RoleId = roleId;
        }
        public virtual RolesModel Role { get; set; }
    }

}
