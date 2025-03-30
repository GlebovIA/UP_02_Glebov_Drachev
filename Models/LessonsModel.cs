using System.ComponentModel.DataAnnotations.Schema;
using System.Windows;

namespace UP_02_Glebov_Drachev.Models
{
    [Table("Lessons")]
    public class LessonsModel : BaseModel
    {
        private int _id;
        private int _disciplineProgramId;
        private int _studGroupId;
        private DateTime _date;
        private TimeSpan _time;

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public int DisciplineProgramId
        {
            get { return _disciplineProgramId; }
            set
            {
                _disciplineProgramId = value;
                OnPropertyChanged(nameof(DisciplineProgramId));
            }
        }

        public int StudGroupId
        {
            get { return _studGroupId; }
            set
            {
                _studGroupId = value;
                OnPropertyChanged(nameof(StudGroupId));
            }
        }

        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChanged(nameof(Date));
            }
        }

        public TimeSpan Time
        {
            get { return _time; }
            set
            {
                _time = value;
                OnPropertyChanged(nameof(Time));
            }
        }

        public virtual DisciplineProgramsModel DisciplineProgram { get; set; }
        public virtual GroupsModel StudGroup { get; set; }

        [NotMapped]
        public DateTime FullInfo
        {
            get { return Date + Time; }
        }
        [NotMapped]
        public String TimeString
        {
            set
            {
                try
                {
                    _time = TimeSpan.Parse(value);
                    OnPropertyChanged(nameof(Time));
                }
                catch
                {
                    MessageBox.Show("Неверно указано время");
                }
            }
            get
            {
                return _time.ToString();
            }
        }
    }
}
