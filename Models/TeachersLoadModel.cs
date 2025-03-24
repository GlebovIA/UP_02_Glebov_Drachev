using System.ComponentModel.DataAnnotations.Schema;

namespace UP_02_Glebov_Drachev.Models
{
    [Table("TeachersLoad")]
    public class TeachersLoadModel : BaseModel
    {
        private int _id;
        private int _teacherId;
        private int _disciplineId;
        private int _studGroupId;
        private int _lectureHours;
        private int _practiceHours;
        private int _examHours;

        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(nameof(Id)); }
        }

        public int TeacherId
        {
            get { return _teacherId; }
            set { _teacherId = value; OnPropertyChanged(nameof(TeacherId)); }
        }

        public int DisciplineId
        {
            get { return _disciplineId; }
            set { _disciplineId = value; OnPropertyChanged(nameof(DisciplineId)); }
        }

        public int StudGroupId
        {
            get { return _studGroupId; }
            set { _studGroupId = value; OnPropertyChanged(nameof(StudGroupId)); }
        }

        public int LectureHours
        {
            get { return _lectureHours; }
            set { _lectureHours = value; OnPropertyChanged(nameof(LectureHours)); }
        }

        public int PracticeHours
        {
            get { return _practiceHours; }
            set { _practiceHours = value; OnPropertyChanged(nameof(PracticeHours)); }
        }

        public int ExamHours
        {
            get { return _examHours; }
            set { _examHours = value; OnPropertyChanged(nameof(ExamHours)); }
        }

        public virtual TeachersModel Teacher { get; set; }
        public virtual DisciplinesModel Discipline { get; set; }
        public virtual GroupsModel StudGroup { get; set; }
        public string Info
        {
            get { return Discipline.FullInfo + ", " + StudGroup.Name; }
        }
    }
}