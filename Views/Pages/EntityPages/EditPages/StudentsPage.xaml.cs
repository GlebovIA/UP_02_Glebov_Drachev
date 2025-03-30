using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using UP_02_Glebov_Drachev.Contexts;
using UP_02_Glebov_Drachev.Models;
using UP_02_Glebov_Drachev.Views.Pages.EntityPages.Lists;

namespace UP_02_Glebov_Drachev.Views.Pages.EntityPages.EditPages
{
    public partial class StudentsPage : Page
    {
        private StudentsContext Context { get; set; }
        private GroupsContext StudGroupsContext = new GroupsContext();
        private UsersContext UsersContext = new UsersContext();
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
                Model = new StudentsModel() { DateOfRemand = DateTime.Today };

            // Исправлено: Group -> StudGroupsComboBox
            StudGroupsComboBox.SetBinding(ComboBox.ItemsSourceProperty,
                new Binding() { Source = new ObservableCollection<GroupsModel>(StudGroupsContext.Groups) });
            UsersComboBox.SetBinding(ComboBox.ItemsSourceProperty,
                new Binding() { Source = new ObservableCollection<UsersModel>(UsersContext.Users) });
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