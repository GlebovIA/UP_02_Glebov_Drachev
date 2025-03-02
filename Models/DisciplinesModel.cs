using System.ComponentModel.DataAnnotations.Schema;

namespace UP_02_Glebov_Drachev.Models
{
    [Table("Disciplines")]
    public class DisciplinesModel : BaseModel
    {
        private int _id;
        private string _name;
        private int _teacherId;

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public int TeacherId
        {
            get { return _teacherId; }
            set
            {
                _teacherId = value;
                OnPropertyChanged(nameof(TeacherId));
            }
        }

        public virtual TeachersModel Teacher { get; set; }
    }
}
