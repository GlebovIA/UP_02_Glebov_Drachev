using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using UP_02_Glebov_Drachev.Contexts;
using UP_02_Glebov_Drachev.Models;
using UP_02_Glebov_Drachev.Views.Pages.EntityPages.Lists;

namespace UP_02_Glebov_Drachev.Views.Pages.EntityPages.EditPages
{
    public partial class StudPlanPage : Page
    {
        private StudPlanContext Context { get; set; }
        private TeachersLoadContext TeachersLoadContext = new TeachersLoadContext();
        private StudPlanModel Model { get; set; }
        private bool IsUpdate = false;

        public StudPlanPage(StudPlanContext context, StudPlanModel model = null)
        {
            InitializeComponent();
            Context = context;
            if (model != null)
            {
                Model = model;
                IsUpdate = true;
            }
            else
                Model = new StudPlanModel();

            // Исправлено: Используем TeachersLoadComboBox вместо TeachersLoad
            TeachersLoadComboBox.SetBinding(ComboBox.ItemsSourceProperty,
                new Binding() { Source = new ObservableCollection<TeachersLoadModel>(TeachersLoadContext.TeachersLoads.Include(a => a.Discipline).ThenInclude(b => b.Teacher).Include(a => a.StudGroup)) });
            DataContext = Model;
        }

        private void Acept(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                if (!IsUpdate) Context.StudPlans.Add(Model);
                Context.SaveChanges();
                GeneralPage.SwapPages(new StudPlanList());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Cancel(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            GeneralPage.SwapPages(new StudPlanList());
        }
    }
}