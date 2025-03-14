using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using UP_02_Glebov_Drachev.Contexts;
using UP_02_Glebov_Drachev.Models;
using UP_02_Glebov_Drachev.Views.Elements;

namespace UP_02_Glebov_Drachev.Views.Pages.EntityPages.Lists
{
    /// <summary>
    /// Логика взаимодействия для StudPlanList.xaml
    /// </summary>
    public partial class StudPlanList : Page
    {
        StudPlanContext context = new StudPlanContext();
        public StudPlanList()
        {
            InitializeComponent();
            IEnumerable<StudPlanModel> studPlans = context.StudPlans.Include(a => a.TeachersLoad);
            ObservableCollection<StudPlanElement> elements = new ObservableCollection<StudPlanElement>();
            foreach (StudPlanModel model in studPlans)
            {
                elements.Add(new StudPlanElement(model, context));
            }
            List.ItemsSource = elements;
        }
    }
}
