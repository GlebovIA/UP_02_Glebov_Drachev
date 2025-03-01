using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using UP_02_Glebov_Drachev.Contexts;
using UP_02_Glebov_Drachev.Models;
using UP_02_Glebov_Drachev.Views.Elements;

namespace UP_02_Glebov_Drachev.Views.Pages.EntityPages
{
    public partial class DisciplinesList : Page
    {
        private DisciplinesContext _context = new DisciplinesContext();

        public DisciplinesList()
        {
            InitializeComponent();

            // Загружаем дисциплины, включая информацию о преподавателе
            var disciplines = _context.Disciplines
                                      .Include(d => d.Teacher) // Включаем информацию о преподавателе
                                      .ToList();

            // Создаем коллекцию для отображения дисциплин
            ObservableCollection<DisciplinesModel> disciplinesList = new ObservableCollection<DisciplinesModel>(disciplines);
            List.ItemsSource = disciplinesList;
        }
    }
}
