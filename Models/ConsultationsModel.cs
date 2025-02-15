using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UP_02_Glebov_Drachev.Models
{
    public class ConsultationsModel
    {
        private int id;
        private int teacher;
        private int student;
        private int disciplin;
        private int group;
        private DateTime date;
        private bool presence;
        private string submittedPractics;

        public int Id
        {
            get { return id; }
            set { id = value; }
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
        public int Disciplin
        {
            get { return disciplin; }
            set { disciplin = value; }
        }
        public int Group
        {
            get { return group; }
            set { group = value; }
        }
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        public bool Presence
        {
            get { return presence; }
            set { presence = value; }
        }
        public string SubmittedPractics
        {
            get { return submittedPractics; }
            set { submittedPractics = value; }
        }
    }
}
