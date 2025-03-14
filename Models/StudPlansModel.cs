using System.ComponentModel.DataAnnotations.Schema;

namespace UP_02_Glebov_Drachev.Models
{
    [Table("StudPlan")]
    public class StudPlanModel : BaseModel
    {
        private int _id;
        private int _teachersLoadId;
        private int _pastLectureHours;
        private int _pastPracticeHours;

        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(nameof(Id)); }
        }

        public int TeachersLoadId
        {
            get { return _teachersLoadId; }
            set { _teachersLoadId = value; OnPropertyChanged(nameof(TeachersLoadId)); }
        }

        public int PastLectureHours
        {
            get { return _pastLectureHours; }
            set { _pastLectureHours = value; OnPropertyChanged(nameof(PastLectureHours)); }
        }

        public int PastPracticeHours
        {
            get { return _pastPracticeHours; }
            set { _pastPracticeHours = value; OnPropertyChanged(nameof(PastPracticeHours)); }
        }

        public virtual TeachersLoadModel TeachersLoad { get; set; }
    }
}