namespace UP_02_Glebov_Drachev.Models
{
    public class MarksModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string MarkValue { get; set; }
        public int LessonId { get; set; }
        public int StudentId { get; set; }
        public string Description { get; set; }

        public MarksModel(int id, DateTime date, string markValue, int lessonId, int studentId, string description)
        {
            Id = id;
            Date = date;
            MarkValue = markValue;
            LessonId = lessonId;
            StudentId = studentId;
            Description = description;
        }
    }

}
