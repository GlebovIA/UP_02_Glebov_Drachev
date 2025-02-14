using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UP_02_Glebov_Drachev.Models
{
    public class Marks
    {
        private int id;
        private DateTime date;
        private string mark;
        private int discipline;
        private int teacher;
        private int student;
        private string description;

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
        public string Mark
        {
            get { return mark; }
            set { mark = value; }
        }
        public int Discipline
        {
            get { return discipline; }
            set { discipline = value; }
        }
        public int Teacher
        {
            get { return teacher; }
            set { teacher = value; }
        }
        public int Student
        {
            get { return student; }
            set { student = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
    }
}
