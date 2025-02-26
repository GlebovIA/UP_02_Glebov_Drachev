namespace UP_02_Glebov_Drachev.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }

        public UserModel(int id, string login, string password, int roleId)
        {
            Id = id;
            Login = login;
            Password = password;
            RoleId = roleId;
        }
    }

}
