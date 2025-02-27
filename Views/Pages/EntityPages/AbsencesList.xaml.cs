using Microsoft.EntityFrameworkCore;
using System.Windows.Controls;
using UP_02_Glebov_Drachev.Contexts;
using UP_02_Glebov_Drachev.Models;

namespace UP_02_Glebov_Drachev.Views.Pages.EntityPages
{
    /// <summary>
    /// Логика взаимодействия для ListPage.xaml
    /// </summary>
    public partial class AbsencesList : Page
    {
        public AbsencesList()
        {
            InitializeComponent();
            IEnumerable<AbsencesModel> absences = new AbsencesContext().Absences.Include(a => a.Student)
                                  .ThenInclude(s => s.StudGroup)
                                  .Include(a => a.Discipline);
            List.ItemsSource = absences;
        }
    }
}
