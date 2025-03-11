using System.ComponentModel.DataAnnotations.Schema;

namespace UP_02_Glebov_Drachev.Models
{
    [Table("Students")]
    public class StudentsModel : BaseModel
    {
        private int _id;
        private string _surname;
        private string _name;
        private string _lastname;
        private int _studGroupId;
        private DateTime? _dateOfRemand;
        private int _userId;

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                OnPropertyChanged(nameof(Surname));
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

        public string Lastname
        {
            get { return _lastname; }
            set
            {
                _lastname = value;
                OnPropertyChanged(nameof(Lastname));
            }
        }

        [Column("StudGroupId")]
        public int StudGroupId
        {
            get { return _studGroupId; }
            set
            {
                _studGroupId = value;
                OnPropertyChanged(nameof(StudGroupId));
            }
        }

        public DateTime? DateOfRemand
        {
            get { return _dateOfRemand; }
            set
            {
                _dateOfRemand = value;
                OnPropertyChanged(nameof(DateOfRemand));
            }
        }

        public int UserId
        {
            get { return _userId; }
            set
            {
                _userId = value;
                OnPropertyChanged(nameof(UserId));
            }
        }

        public string FullName => $"{Surname} {Name} {Lastname}";

        public virtual GroupsModel StudGroup { get; set; }
    }
}
