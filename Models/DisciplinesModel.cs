﻿using System.ComponentModel.DataAnnotations.Schema;

namespace UP_02_Glebov_Drachev.Models
{
    [Table("Disciplines")]
    public class DisciplinesModel : BaseModel
    {
        private string _name;
        private int _teacherId;

        public int Id { get; set; }  // Ensure this property is present if not inherited from BaseModel

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
