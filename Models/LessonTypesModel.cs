namespace UP_02_Glebov_Drachev.Models
{
    public class LessonTypesModel
    {
        public int Id { get; set; }
        public string TypeName { get; set; }

        public LessonTypesModel(int id, string typeName)
        {
            Id = id;
            TypeName = typeName;
        }
    }

}
