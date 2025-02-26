namespace UP_02_Glebov_Drachev.Models
{
    public class StudPlansModel
    {
        public int Id { get; set; }
        public int TeachersLoad { get; set; }
        public int PastLectureHours { get; set; }
        public int PastPracticeHours { get; set; }

        public StudPlansModel(int id, int teachersLoad, int pastLectureHours, int pastPracticeHours)
        {
            Id = id;
            TeachersLoad = teachersLoad;
            PastLectureHours = pastLectureHours;
            PastPracticeHours = pastPracticeHours;
        }
    }
}
