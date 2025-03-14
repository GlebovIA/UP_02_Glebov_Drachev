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
    public partial class TeachersLoadPage : Page
    {
        private TeachersLoadContext Context { get; set; }
        private TeachersContext TeachersContext = new TeachersContext();
        private DisciplinesContext DisciplinesContext = new DisciplinesContext();
        private GroupsContext StudGroupsContext = new GroupsContext();
        private TeachersLoadModel Model { get; set; }
        private bool IsUpdate = false;

        public TeachersLoadPage(TeachersLoadContext context, TeachersLoadModel model = null)
        {
            InitializeComponent();
            Context = context;
            if (model != null)
            {
                Model = model;
                IsUpdate = true;
            }
            else
                Model = new TeachersLoadModel();

            // Исправлено: Teachers -> TeachersComboBox, Disciplines -> DisciplinesComboBox, StudGroups -> StudGroupsComboBox
            TeachersComboBox.SetBinding(ComboBox.ItemsSourceProperty,
                new Binding() { Source = new ObservableCollection<TeachersModel>(TeachersContext.Teachers) });
            DisciplinesComboBox.SetBinding(ComboBox.ItemsSourceProperty,
                new Binding() { Source = new ObservableCollection<DisciplinesModel>(DisciplinesContext.Disciplines) });
            StudGroupsComboBox.SetBinding(ComboBox.ItemsSourceProperty,
                new Binding() { Source = new ObservableCollection<GroupsModel>(StudGroupsContext.Groups) });
            DataContext = Model;
        }

        private void Acept(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                if (!IsUpdate) Context.TeachersLoads.Add(Model);
                Context.SaveChanges();
                GeneralPage.SwapPages(new TeachersLoadList());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Cancel(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            GeneralPage.SwapPages(new TeachersLoadList());
        }
    }
}