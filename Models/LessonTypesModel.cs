using System.ComponentModel.DataAnnotations.Schema;

namespace UP_02_Glebov_Drachev.Models
{
    [Table("LessonTypes")]
    public class LessonTypesModel : BaseModel
    {
        private int _id;
        private string _typeName;

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public string TypeName
        {
            get { return _typeName; }
            set
            {
                _typeName = value;
                OnPropertyChanged(nameof(TypeName));
            }
        }
    }
}
