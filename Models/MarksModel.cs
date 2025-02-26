namespace UP_02_Glebov_Drachev.Models
{
    public class MarksModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string MarkValue { get; set; }
        public int Lesson { get; set; }
        public int Student { get; set; }
        public string Description { get; set; }

        public MarksModel(int id, DateTime date, string markValue, int lesson, int student, string description)
        {
            Id = id;
            Date = date;
            MarkValue = markValue;
            Lesson = lesson;
            Student = student;
            Description = description;
        }
    }

}
