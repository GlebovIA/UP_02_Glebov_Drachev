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
    public partial class DisciplinesList : Page
    {
        private DisciplinesContext context = new DisciplinesContext();

        public DisciplinesList()
        {
            InitializeComponent();
            LoadDisciplines();
        }

        private void LoadDisciplines()
        {
            var disciplines = context.Disciplines.Include(a => a.Teacher);
            ObservableCollection<DisciplinesElement> elements = new ObservableCollection<DisciplinesElement>();
            foreach (DisciplinesModel model in disciplines)
            {
                elements.Add(new DisciplinesElement(model, context));
            }
            List.ItemsSource = elements;
        }

        private void AddClick(object sender, MouseButtonEventArgs e)
        {
            GeneralPage.SwapPages(new DisciplinesPage(context));
        }
    }
}