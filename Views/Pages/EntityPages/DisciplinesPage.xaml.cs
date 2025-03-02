using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using UP_02_Glebov_Drachev.Contexts;
using UP_02_Glebov_Drachev.Models;
using UP_02_Glebov_Drachev.Views.Pages.EntityPages;

namespace UP_02_Glebov_Drachev.Views.Pages
{
    public partial class DisciplinesPage : Page
    {
        private DisciplinesContext Context { get; set; }
        private TeachersContext TeachersContext = new TeachersContext();
        private DisciplinesModel Model { get; set; }
        private bool IsUpdate { get; set; }

        public DisciplinesPage(DisciplinesContext context, DisciplinesModel model = null)
        {
            InitializeComponent();
            Context = context;
            if (model != null)
            {
                Model = model;
                IsUpdate = true;
            }
            else
            {
                Model = new DisciplinesModel();
            }

            Teachers.SetBinding(ComboBox.ItemsSourceProperty, new Binding() { Source = new ObservableCollection<TeachersModel>(TeachersContext.Teachers) });
            DataContext = Model;
        }

        private void Accept(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                if (!IsUpdate) Context.Disciplines.Add(Model);
                Context.SaveChanges();
                GeneralPage.SwapPages(new DisciplinesList());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Cancel(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            GeneralPage.SwapPages(new DisciplinesList());
        }
    }
}
