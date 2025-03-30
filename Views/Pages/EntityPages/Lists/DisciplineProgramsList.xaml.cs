using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using UP_02_Glebov_Drachev.Contexts;
using UP_02_Glebov_Drachev.Models;
using UP_02_Glebov_Drachev.Views.Elements;
using UP_02_Glebov_Drachev.Views.Pages.EntityPages.EditPages;

namespace UP_02_Glebov_Drachev.Views.Pages.EntityPages.Lists
{
    public partial class DisciplineProgramsList : Page
    {
        private DisciplineProgramsContext context = new DisciplineProgramsContext();

        public DisciplineProgramsList()
        {
            InitializeComponent();
            LoadDisciplinePrograms();
        }

        private void LoadDisciplinePrograms()
        {
            var disciplinePrograms = context.DisciplinePrograms
                .Include(a => a.Discipline)
                .Include(a => a.LessonType).OrderBy(x => x.Discipline);
            ObservableCollection<DisciplineProgramsElement> elements = new ObservableCollection<DisciplineProgramsElement>();
            foreach (DisciplineProgramsModel model in disciplinePrograms)
            {
                elements.Add(new DisciplineProgramsElement(model, context));
            }
            List.ItemsSource = elements;
        }

        private void AddClick(object sender, MouseButtonEventArgs e)
        {
            GeneralPage.SwapPages(new DisciplineProgramsPage(context));
        }
    }
}