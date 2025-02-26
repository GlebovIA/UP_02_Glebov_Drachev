namespace UP_02_Glebov_Drachev.Models
{
    public class ConsultationResultsModel
    {
        public int Id { get; set; }
        public int Consultation { get; set; }
        public int Student { get; set; }
        public bool Presence { get; set; }
        public string SubmittedPractice { get; set; }

        public ConsultationResultsModel(int id, int consultation, int student, bool presence, string submittedPractice)
        {
            Id = id;
            Consultation = consultation;
            Student = student;
            Presence = presence;
            SubmittedPractice = submittedPractice;
        }
    }

}
