using System.ComponentModel.DataAnnotations.Schema;

namespace UP_02_Glebov_Drachev.Models
{
    [Table("TeachersLoad")]
    public class TeachersLoadModel
    {
        public int Id { get; set; }
        public int DisciplineId { get; set; }
        public int StudGroupId { get; set; }
        public int LectureHours { get; set; }
        public int PracticeHours { get; set; }
        public int ExamHours { get; set; }

        public TeachersLoadModel(int id, int disciplineId, int studGroupId, int lectureHours, int practiceHours, int examHours)
        {
            Id = id;
            DisciplineId = disciplineId;
            StudGroupId = studGroupId;
            LectureHours = lectureHours;
            PracticeHours = practiceHours;
            ExamHours = examHours;
        }
    }
}
