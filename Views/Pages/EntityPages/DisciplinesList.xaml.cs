using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Windows.Controls;
using UP_02_Glebov_Drachev.Contexts;
using UP_02_Glebov_Drachev.Models;

namespace UP_02_Glebov_Drachev.Views.Pages.EntityPages
{
    public partial class DisciplinesList : Page
    {
        public DisciplinesList()
        {
            InitializeComponent();
            var disciplines = new DisciplinesContext().Disciplines.Include(d => d.Teacher).ToList();
            List.ItemsSource = disciplines;
        }
    }
}
