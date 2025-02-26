namespace UP_02_Glebov_Drachev.Models
{
    public class TeachersModel
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public int UserId { get; set; }

        public TeachersModel(int id, string surname, string name, string lastname, int userId)
        {
            Id = id;
            Surname = surname;
            Name = name;
            Lastname = lastname;
            UserId = userId;
        }
    }

}
