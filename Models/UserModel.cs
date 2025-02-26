namespace UP_02_Glebov_Drachev.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }

        public UserModel(int id, string login, string password, int role)
        {
            Id = id;
            Login = login;
            Password = password;
            Role = role;
        }
    }

}
