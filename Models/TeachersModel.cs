namespace UP_02_Glebov_Drachev.Models
{
    public class TeachersModel
    {
        private int id;
        private string surname;
        private string name;
        private string lastname;
        private string login;
        private string password;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }
        public string Login
        {
            get { return login; }
            set { login = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}
