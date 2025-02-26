namespace UP_02_Glebov_Drachev.Models
{
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
