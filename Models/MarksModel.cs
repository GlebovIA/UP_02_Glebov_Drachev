using System;

namespace UP_02_Glebov_Drachev.Models
{
    public class MarksModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string MarkValue { get; set; }
        public int DisciplineProgramId { get; set; }
        public int StudentId { get; set; }
        public string Description { get; set; }

    }

}
