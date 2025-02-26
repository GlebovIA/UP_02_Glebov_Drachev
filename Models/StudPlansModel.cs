namespace UP_02_Glebov_Drachev.Models
{
    public class StudPlansModel
    {
        public int Id { get; set; }
        public int TeachersLoadId { get; set; }
        public int PastLectureHours { get; set; }
        public int PastPracticeHours { get; set; }

        public StudPlansModel(int id, int teachersLoadId, int pastLectureHours, int pastPracticeHours)
        {
            Id = id;
            TeachersLoadId = teachersLoadId;
            PastLectureHours = pastLectureHours;
            PastPracticeHours = pastPracticeHours;
        }
    }
}
