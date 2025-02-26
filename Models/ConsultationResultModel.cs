namespace UP_02_Glebov_Drachev.Models
{
    public class ConsultationResultsModel
    {
        public int Id { get; set; }
        public int ConsultationId { get; set; }
        public int StudentId { get; set; }
        public bool Presence { get; set; }
        public string SubmittedPractice { get; set; }

        public ConsultationResultsModel(int id, int consultationId, int studentId, bool presence, string submittedPractice)
        {
            Id = id;
            ConsultationId = consultationId;
            StudentId = studentId;
            Presence = presence;
            SubmittedPractice = submittedPractice;
        }
    }

}
