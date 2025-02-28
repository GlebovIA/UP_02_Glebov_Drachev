using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using UP_02_Glebov_Drachev.Contexts;
using UP_02_Glebov_Drachev.Models;
using UP_02_Glebov_Drachev.Views.Elements;

namespace UP_02_Glebov_Drachev.Views.Pages.EntityPages
{
    /// <summary>
    /// Логика взаимодействия для ListPage.xaml
    /// </summary>
    public partial class AbsencesList : Page
    {
        AbsencesContext context = new AbsencesContext();
        public AbsencesList()
        {
            InitializeComponent();
            IEnumerable<AbsencesModel> absences = context.Absences.Include(a => a.Student)
                                  .ThenInclude(s => s.StudGroup)
                                  .Include(a => a.Discipline);
            ObservableCollection<AbsencesElement> elements = new ObservableCollection<AbsencesElement>();
            foreach (AbsencesModel model in absences)
            {
                elements.Add(new AbsencesElement(model, context));
            }
            List.ItemsSource = elements;
        }
    }
}
