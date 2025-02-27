using System.ComponentModel.DataAnnotations.Schema;

namespace UP_02_Glebov_Drachev.Models
{
    [Table("Disciplines")]
    public class DisciplinesModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TeacherId { get; set; }

        // Конструктор без параметров
        public DisciplinesModel() { }

        // Конструктор с параметрами
        public DisciplinesModel(int id, string name, int teacherId)
        {
            Id = id;
            Name = name;
            TeacherId = teacherId;
        }

        // Свойство для навигации
        public virtual TeachersModel Teacher { get; set; }
    }
}
