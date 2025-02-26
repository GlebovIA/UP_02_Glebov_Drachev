namespace UP_02_Glebov_Drachev.Models
{
    public class RolesModel
    {
        public int Id { get; set; }
        public string RoleName { get; set; }

        public RolesModel(int id, string roleName)
        {
            Id = id;
            RoleName = roleName;
        }
    }
}
