using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using UP_02_Glebov_Drachev.Contexts;
using UP_02_Glebov_Drachev.Models;
using UP_02_Glebov_Drachev.Views.Pages.EntityPages.Lists;

namespace UP_02_Glebov_Drachev.Views.Pages.EntityPages.EditPages
{
    public partial class TeachersPage : Page
    {
        private TeachersContext Context { get; set; }
        private UsersContext UsersContext = new UsersContext();
        private TeachersModel Model { get; set; }
        private bool IsUpdate = false;

        public TeachersPage(TeachersContext context, TeachersModel model = null)
        {
            InitializeComponent();
            Context = context;
            if (model != null)
            {
                Model = model;
                IsUpdate = true;
            }
            else
                Model = new TeachersModel();

            // Исправлено: Users -> UsersComboBox
            UsersComboBox.SetBinding(ComboBox.ItemsSourceProperty,
                new Binding() { Source = new ObservableCollection<UsersModel>(UsersContext.Users) });
            DataContext = Model;
        }

        private void Acept(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                if (!IsUpdate) Context.Teachers.Add(Model);
                Context.SaveChanges();
                GeneralPage.SwapPages(new TeachersList());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Cancel(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            GeneralPage.SwapPages(new TeachersList());
        }
    }
}