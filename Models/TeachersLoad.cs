using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UP_02_Glebov_Drachev.Models
{
    public class TeachersLoad
    {
        private int id;
        private int teacher;
        private int discipline;
        private int group;
        private int lectureHours;
        private int practiceHours;
        private int consultationHours;
        private int courceProjectHours;
        private int examHours;

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
        public int Discipline
        {
            get { return discipline; }
            set { discipline = value; }
        }
        public int Group
        {
            get { return group; }
            set { group = value; }
        }
        public int LectureHours
        {
            get { return lectureHours; }
            set { lectureHours = value; }
        }
        public int PracticeHours
        {
            get { return practiceHours; }
            set { practiceHours = value; }
        }
        public int ConsultationHours
        {
            get { return consultationHours; }
            set { consultationHours = value; }
        }
        public int CourceProjectHours
        {
            get { return courceProjectHours; }
            set { courceProjectHours = value; }
        }
        public int ExamHours
        {
            get { return examHours; }
            set { examHours = value; }
        }
    }
}
