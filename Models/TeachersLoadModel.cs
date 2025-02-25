namespace UP_02_Glebov_Drachev.Models
{
    public class TeacherLoadsModel
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public int DisciplineId { get; set; }
        public int StudGroupId { get; set; }
        public int LectureHours { get; set; }
        public int PracticeHours { get; set; }
        public int ExamHours { get; set; }


    }

}
