using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using UP_02_Glebov_Drachev.Contexts;
using UP_02_Glebov_Drachev.Models;
using UP_02_Glebov_Drachev.Views.Elements;

namespace UP_02_Glebov_Drachev.Views.Pages.EntityPages.Lists
{
    /// <summary>
    /// Логика взаимодействия для DisciplineProgramsList.xaml
    /// </summary>
    public partial class DisciplineProgramsList : Page
    {
        DisciplineProgramsContext context = new DisciplineProgramsContext();
        public DisciplineProgramsList()
        {
            InitializeComponent();
            IEnumerable<DisciplineProgramsModel> disciplinePrograms = context.DisciplinePrograms.Include(a => a.Discipline)
                                  .Include(a => a.LessonType);
            ObservableCollection<DisciplineProgramsElement> elements = new ObservableCollection<DisciplineProgramsElement>();
            foreach (DisciplineProgramsModel model in disciplinePrograms)
            {
                elements.Add(new DisciplineProgramsElement(model, context));
            }
            List.ItemsSource = elements;
        }
    }
}
