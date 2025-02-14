using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UP_02_Glebov_Drachev.Models
{
    public class Students
    {
        private int id;
        private string surname;
        private string name;
        private string lastname;
        private int group;
        private DateTime dateOfRemand;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }
        public int Group
        {
            get { return group; }
            set { group = value; }
        }
        public DateTime DateOfRemand
        {
            get { return dateOfRemand; }
            set { dateOfRemand = value; }
        }
    }
}
