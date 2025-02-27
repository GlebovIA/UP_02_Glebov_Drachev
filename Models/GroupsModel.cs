using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UP_02_Glebov_Drachev.Models
{
    [Table("StudGroups")]
    public class GroupsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public GroupsModel(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
