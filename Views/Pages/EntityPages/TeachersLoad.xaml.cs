using System.Windows.Controls;
using UP_02_Glebov_Drachev.Contexts;

namespace UP_02_Glebov_Drachev.Views.Pages.EntityPages
{
    /// <summary>
    /// Логика взаимодействия для TeachersLoad.xaml
    /// </summary>
    public partial class TeachersLoad : Page
    {
        private DataGrid loadTable;
        DisciplinesContext DisciplinesContext = new DisciplinesContext();
        GroupsContext GroupsContext = new GroupsContext();
        StudPlanContext StudPlansContext = new StudPlanContext();
        TeachersLoadContext TeacherLoadsContext = new TeachersLoadContext();
        public TeachersLoad()
        {
            InitializeComponent();
            loadTable = LoadsTable;
            CreateUI();
        }
        public void CreateUI()
        {

        }
    }
}