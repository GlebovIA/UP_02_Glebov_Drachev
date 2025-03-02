using System.ComponentModel.DataAnnotations.Schema;

namespace UP_02_Glebov_Drachev.Models
{
    [Table("ConsultationResults")]
    public class ConsultationResultsModel : BaseModel
    {
        private int _id;
        private int _consultationId;
        private int _studentId;
        private bool _presence;
        private string _submittedPractice;

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public int ConsultationId
        {
            get { return _consultationId; }
            set
            {
                _consultationId = value;
                OnPropertyChanged(nameof(ConsultationId));
            }
        }

        public int StudentId
        {
            get { return _studentId; }
            set
            {
                _studentId = value;
                OnPropertyChanged(nameof(StudentId));
            }
        }

        public bool Presence
        {
            get { return _presence; }
            set
            {
                _presence = value;
                OnPropertyChanged(nameof(Presence));
            }
        }

        public string SubmittedPractice
        {
            get { return _submittedPractice; }
            set
            {
                _submittedPractice = value;
                OnPropertyChanged(nameof(SubmittedPractice));
            }
        }

        public virtual ConsultationsModel Consultation { get; set; }
        public virtual StudentsModel Student { get; set; }
    }
}
