namespace UP_02_Glebov_Drachev.Models
{

    public class ConsultationsModel
    {
        public int Id { get; set; }
        public int Discipline { get; set; }
        public DateTime Date { get; set; }

        public ConsultationsModel(int id, int discipline, DateTime date)
        {
            Id = id;
            Discipline = discipline;
            Date = date;
        }
    }

}
