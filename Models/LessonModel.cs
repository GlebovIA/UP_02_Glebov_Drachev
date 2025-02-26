namespace UP_02_Glebov_Drachev.Models
{
    public class LessonModel
    {
        public int Id { get; set; }
        public int DisciplineProgram { get; set; }
        public int StudGroup { get; set; }
        public DateTime Time { get; set; }

        public LessonModel(int id, int disciplineProgram, int studGroup, DateTime time)
        {
            Id = id;
            DisciplineProgram = disciplineProgram;
            StudGroup = studGroup;
            Time = time;
        }
    }
}
