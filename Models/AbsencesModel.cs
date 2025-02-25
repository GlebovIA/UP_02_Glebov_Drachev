using System;

namespace UP_02_Glebov_Drachev.Models
{
    public class AbsencesModel
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int DisciplineId { get; set; }
        public DateTime Date { get; set; }
        public int DelayMinutes { get; set; }
        public string ExplanatoryNote { get; set; }


    }

}
