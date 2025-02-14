using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UP_02_Glebov_Drachev.Models
{
    public class Absences
    {
        private int id;
        private DateTime date;
        private int discipline;
        private int minutes;
        private byte[] explanatoryNote;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        public int Discipline
        {
            get { return discipline; }
            set { discipline = value; }
        }
        public int Minutes
        {
            get { return minutes; }
            set { minutes = value; }
        }
        public byte[] ExplanatoryNote
        {
            get { return explanatoryNote; }
            set { explanatoryNote = value; }
        }
    }
}
