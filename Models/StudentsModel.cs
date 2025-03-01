using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace UP_02_Glebov_Drachev.Models
{
    [Table("Students")]
    public class StudentsModel
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        [Column("StudGroupId")]
        public int StudGroupId { get; set; }
        public DateTime? DateOfRemand { get; set; }
        public int UserId { get; set; }

        public string FullName => $"{Surname} {Name} {Lastname}";

        public StudentsModel(int id, string surname, string name, string lastname, int studGroupId, DateTime? dateOfRemand, int userId)
        {
            Id = id;
            Surname = surname;
            Name = name;
            Lastname = lastname;
            StudGroupId = studGroupId;
            DateOfRemand = dateOfRemand;
            UserId = userId;
        }
        public virtual GroupsModel StudGroup { get; set; }
    }
}
