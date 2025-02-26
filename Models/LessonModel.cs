namespace UP_02_Glebov_Drachev.Models
{
    public class LessonModel
    {
        public int Id { get; set; }
        public int DisciplineProgramId { get; set; }
        public int StudGroupId { get; set; }
        public DateTime Time { get; set; }

        public LessonModel(int id, int disciplineProgramId, int studGroupId, DateTime time)
        {
            Id = id;
            DisciplineProgramId = disciplineProgramId;
            StudGroupId = studGroupId;
            Time = time;
        }
    }
}
