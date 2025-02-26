namespace UP_02_Glebov_Drachev.Models
{
    public class DisciplinesModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Teacher { get; set; }

        public DisciplinesModel(int id, string name, int teacher)
        {
            Id = id;
            Name = name;
            Teacher = teacher;
        }
    }

}
