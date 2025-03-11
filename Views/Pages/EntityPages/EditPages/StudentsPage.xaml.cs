using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using UP_02_Glebov_Drachev.Contexts;
using UP_02_Glebov_Drachev.Models;
using UP_02_Glebov_Drachev.Views.Pages.EntityPages.Lists;

namespace UP_02_Glebov_Drachev.Views.Pages.EntityPages.EditPages
{
    /// <summary>
    /// Логика взаимодействия для StudentsPage.xaml
    /// </summary>
    public partial class StudentsPage : Page
    {
        private StudentsContext Context { get; set; }
        private GroupsContext GroupsContext = new GroupsContext();
        private StudentsModel Model { get; set; }
        private bool IsUpdate = false;

        public StudentsPage(StudentsContext context, StudentsModel model = null)
        {
            InitializeComponent();
            Context = context;
            if (model != null)
            {
                Model = model;
                IsUpdate = true;
            }
            else
                Model = new StudentsModel();

            Group.SetBinding(ComboBox.ItemsSourceProperty, new Binding() { Source = new ObservableCollection<GroupsModel>(GroupsContext.Groups) });
            DataContext = Model;
        }

        private void Acept(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                if (!IsUpdate) Context.Students.Add(Model);
                Context.SaveChanges();
                GeneralPage.SwapPages(new StudentsList());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Cancel(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            GeneralPage.SwapPages(new StudentsList());
        }
    }
}
