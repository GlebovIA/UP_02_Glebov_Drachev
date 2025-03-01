using System;

namespace UP_02_Glebov_Drachev.Models
{
    public class ConsultationsModel
    {
        public int Id { get; set; }
        public int DisciplineId { get; set; }  // Внешний ключ

        public DateTime Date { get; set; }

        // Навигационное свойство для загрузки данных Discipline
        public DisciplinesModel Discipline { get; set; }
    }
}
