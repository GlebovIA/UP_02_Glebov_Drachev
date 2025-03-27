using System.ComponentModel.DataAnnotations.Schema;

namespace UP_02_Glebov_Drachev.Models
{
    [Table("DisciplinePrograms")]
    public class DisciplineProgramsModel : BaseModel
    {
        private int _id;
        private int _disciplineId;
        private string _theme;
        private int _lessonTypeId;
        private int _hoursCount;
        private bool _completed;

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
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

        public string Theme
        {
            get { return _theme; }
            set
            {
                _theme = value;
                OnPropertyChanged(nameof(Theme));
            }
        }

        public int LessonTypeId
        {
            get { return _lessonTypeId; }
            set
            {
                _lessonTypeId = value;
                OnPropertyChanged(nameof(LessonTypeId));
            }
        }

        public int HoursCount
        {
            get { return _hoursCount; }
            set
            {
                _hoursCount = value;
                OnPropertyChanged(nameof(HoursCount));
            }
        }

        public bool Completed
        {
            get { return _completed; }
            set
            {
                _completed = value;
                OnPropertyChanged(nameof(Completed));
            }
        }
        public virtual DisciplinesModel Discipline { get; set; }
        public virtual LessonTypesModel LessonType { get; set; }
    }
}
