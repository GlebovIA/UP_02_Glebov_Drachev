using System.ComponentModel.DataAnnotations.Schema;

namespace UP_02_Glebov_Drachev.Models
{
    [Table("Marks")]
    public class MarksModel : BaseModel
    {
        private int _id;
        private DateTime _date;
        private string _mark;
        private int _lessonId;
        private int _studentId;
        private string _description;

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
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

        public string Mark
        {
            get { return _mark; }
            set
            {
                _mark = value;
                OnPropertyChanged(nameof(Mark));
            }
        }

        public int LessonId
        {
            get { return _lessonId; }
            set
            {
                _lessonId = value;
                OnPropertyChanged(nameof(LessonId));
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

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public virtual LessonsModel Lesson { get; set; }
        public virtual StudentsModel Student { get; set; }
    }
}
