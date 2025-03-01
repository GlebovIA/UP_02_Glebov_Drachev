using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace UP_02_Glebov_Drachev.Models
{
    [Table("Consultations")]
    public class ConsultationsModel : BaseModel
    {
        private int _id;
        private int _disciplineId;
        private DateTime _date;

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public int DisciplineId
        {
            get { return _disciplineId; }
            set
            {
                _disciplineId = value;
                OnPropertyChanged(nameof(DisciplineId));
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

        public virtual DisciplinesModel Discipline { get; set; }
    }
}
