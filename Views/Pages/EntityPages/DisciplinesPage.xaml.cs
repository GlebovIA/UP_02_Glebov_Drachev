using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using UP_02_Glebov_Drachev.Contexts;
using UP_02_Glebov_Drachev.Models;
using UP_02_Glebov_Drachev.Views.Elements;

namespace UP_02_Glebov_Drachev.Views.Pages
{
    public partial class DisciplinesPage : Page
    {
        private DisciplinesContext DisciplinesContext { get; set; }
        private ObservableCollection<DisciplinesModel> AllDisciplines { get; set; }
        private DisciplinesModel Model { get; set; }
        private bool IsUpdate { get; set; }

        public DisciplinesPage(DisciplinesContext context, DisciplinesModel disciplinesModel = null)
        {
            InitializeComponent();
            DisciplinesContext = context;
            AllDisciplines = new ObservableCollection<DisciplinesModel>(DisciplinesContext.Disciplines.ToList());

            if (disciplinesModel != null)
            {
                Model = DisciplinesContext.Disciplines.FirstOrDefault(x => x.Id == disciplinesModel.Id);
                IsUpdate = true;
            }
            else
            {
                Model = new DisciplinesModel();
            }

            // Binding teacher data
            Teachers.SetBinding(ComboBox.ItemsSourceProperty, new Binding() { Source = GetTeachersData() });
            DataContext = Model;
        }

        private ObservableCollection<TeachersModel> GetTeachersData()
        {
            // Assume you have a TeachersContext to load the teachers
            return new ObservableCollection<TeachersModel>(new TeachersContext().Teachers.ToList());
        }

        private void Accept(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                DisciplinesContext.SaveChanges();
                // Navigate to another page after saving changes
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Cancel(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Cancel the changes
        }
    }
}
