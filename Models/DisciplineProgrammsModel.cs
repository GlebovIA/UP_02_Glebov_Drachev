namespace UP_02_Glebov_Drachev.Models
{
    public class DisciplineProgramsModel
    {
        public int Id { get; set; }
        public int DisciplineId { get; set; }
        public string Theme { get; set; }
        public int LessonTypeId { get; set; }
        public int HoursCount { get; set; }

        public DisciplineProgramsModel(int id, int disciplineId, string theme, int lessonTypeId, int hoursCount)
        {
            Id = id;
            DisciplineId = disciplineId;
            Theme = theme;
            LessonTypeId = lessonTypeId;
            HoursCount = hoursCount;
        }
    }

}
