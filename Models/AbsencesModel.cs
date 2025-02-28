using System.ComponentModel.DataAnnotations.Schema;

namespace UP_02_Glebov_Drachev.Models
{
    [Table("Absences")]
    public class AbsencesModel : BaseModel
    {
        private int _id;
        private int _studentId;
        private int _disciplineId;
        private DateTime _date;
        private int _delayMinutes;
        private string _explanatoryNote;
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
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
        public int DisciplineId
        {
            get { return _disciplineId; }
            set
            {
                _disciplineId = value;
                OnPropertyChanged(nameof(DisciplineId));
            }
        }
        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChanged(nameof(Date));
            }
        }
        public int DelayMinutes
        {
            get { return _delayMinutes; }
            set
            {
                _delayMinutes = value;
                OnPropertyChanged(nameof(DelayMinutes));
            }
        }
        public string ExplanatoryNote
        {
            get { return _explanatoryNote; }
            set
            {
                _explanatoryNote = value;
                OnPropertyChanged(nameof(ExplanatoryNote));
            }
        }

        public virtual StudentsModel Student { get; set; }
        public virtual DisciplinesModel Discipline { get; set; }
    }

}
