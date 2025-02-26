namespace UP_02_Glebov_Drachev.Models
{
    public class StudentsModel
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public int StudGroupId { get; set; }
        public DateTime? DateOfRemand { get; set; }
        public int UserId { get; set; }

        public StudentsModel(int id, string surname, string name, string lastname, int studGroupId, DateTime? dateOfRemand, int userId)
        {
            Id = id;
            Surname = surname;
            Name = name;
            Lastname = lastname;
            StudGroupId = studGroupId;
            DateOfRemand = dateOfRemand;
            UserId = userId;
        }
    }
}
