using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UP_02_Glebov_Drachev.Models
{
    public class DisciplineProgrammsModel
    {
        private int id;
        private int discipline;
        private string theme;
        private string lessonType;
        private int hoursCount;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public int Discipline
        {
            get { return discipline; }
            set { discipline = value; }
        }
        public string Theme
        {
            get { return theme; }
            set { theme = value; }
        }
        public string LessonType
        {
            get { return lessonType; }
            set { lessonType = value; }
        }
        public int HoursCount
        {
            get { return hoursCount; }
            set { hoursCount = value; }
        }
    }
}
