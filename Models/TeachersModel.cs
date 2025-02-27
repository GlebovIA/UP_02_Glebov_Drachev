using System.ComponentModel.DataAnnotations.Schema;

namespace UP_02_Glebov_Drachev.Models
{
    [Table("Teachers")]
    public class TeachersModel
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public int UserId { get; set; }

        // Конструктор без параметров
        public TeachersModel() { }

        // Конструктор с параметрами
        public TeachersModel(int id, string surname, string name, string lastname, int userId)
        {
            Id = id;
            Surname = surname;
            Name = name;
            Lastname = lastname;
            UserId = userId;
        }

        // Свойство для полного имени
        public string FullName => $"{Surname} {Name} {Lastname}";

        // Навигационное свойство для дисциплин
        public virtual ICollection<DisciplinesModel> Disciplines { get; set; }
    }
}
