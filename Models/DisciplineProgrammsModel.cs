namespace UP_02_Glebov_Drachev.Models
{
    public class DisciplineProgramsModel
    {
        public int Id { get; set; }
        public int Discipline { get; set; }
        public string Theme { get; set; }
        public int LessonType { get; set; }
        public int HoursCount { get; set; }

        public DisciplineProgramsModel(int id, int discipline, string theme, int lessonType, int hoursCount)
        {
            Id = id;
            Discipline = discipline;
            Theme = theme;
            LessonType = lessonType;
            HoursCount = hoursCount;
        }
    }

}
