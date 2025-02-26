namespace UP_02_Glebov_Drachev.Models
{
    public class TeacherLoadsModel
    {
        public int Id { get; set; }
        public int Discipline { get; set; }
        public int StudGroup { get; set; }
        public int LectureHours { get; set; }
        public int PracticeHours { get; set; }
        public int ExamHours { get; set; }

        public TeacherLoadsModel(int id, int discipline, int studGroup, int lectureHours, int practiceHours, int examHours)
        {
            Id = id;
            Discipline = discipline;
            StudGroup = studGroup;
            LectureHours = lectureHours;
            PracticeHours = practiceHours;
            ExamHours = examHours;
        }
    }
}
