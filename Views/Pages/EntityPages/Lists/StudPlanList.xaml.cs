using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using UP_02_Glebov_Drachev.Contexts;
using UP_02_Glebov_Drachev.Models;
using UP_02_Glebov_Drachev.Views.Elements;
using UP_02_Glebov_Drachev.Views.Pages;
using UP_02_Glebov_Drachev.Views.Pages.EntityPages.EditPages;

namespace UP_02_Glebov_Drachev.Views.Pages.EntityPages.Lists
{
    public partial class StudPlanList : Page
    {
        private StudPlanContext context = new StudPlanContext();

        public StudPlanList()
        {
            InitializeComponent();
            LoadStudPlans();
        }

        private void LoadStudPlans()
        {
            var studPlans = context.StudPlans.Include(a => a.TeachersLoad);
            ObservableCollection<StudPlanElement> elements = new ObservableCollection<StudPlanElement>();
            foreach (StudPlanModel model in studPlans)
            {
                elements.Add(new StudPlanElement(model, context));
            }
            List.ItemsSource = elements;
        }

        private void AddClick(object sender, MouseButtonEventArgs e)
        {
            GeneralPage.SwapPages(new StudPlanPage(context));
        }
    }
}