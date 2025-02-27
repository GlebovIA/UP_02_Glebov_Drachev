using System.Collections.ObjectModel;
using System.Windows.Controls;
using UP_02_Glebov_Drachev.Models;
using UP_02_Glebov_Drachev.Contexts;

namespace UP_02_Glebov_Drachev.Views.Pages
{
    public partial class AbsencesPage : Page
    {
        public ObservableCollection<AbsencesModel> AbsencesData { get; set; }

        public AbsencesPage()
        {
            InitializeComponent();
            LoadAbsencesData();
            this.DataContext = this;
        }

        private void LoadAbsencesData()
        {
            // Загружаем данные о пропусках из базы данных
            using (var context = new AbsencesContext())
            {
                var absences = context.Absences.ToList();
                AbsencesData = new ObservableCollection<AbsencesModel>(absences);
            }
        }
    }
}
