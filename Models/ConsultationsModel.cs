namespace UP_02_Glebov_Drachev.Models
{

    public class ConsultationsModel
    {
        public int Id { get; set; }
        public int DisciplineId { get; set; }
        public DateTime Date { get; set; }

        public ConsultationsModel(int id, int disciplineId, DateTime date)
        {
            Id = id;
            DisciplineId = disciplineId;
            Date = date;
        }
    }

}
