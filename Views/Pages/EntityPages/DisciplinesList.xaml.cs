using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using UP_02_Glebov_Drachev.Contexts;
using UP_02_Glebov_Drachev.Models;
using UP_02_Glebov_Drachev.Views.Elements;

namespace UP_02_Glebov_Drachev.Views.Pages.EntityPages
{
    public partial class DisciplinesList : Page
    {
        private DisciplinesContext context = new DisciplinesContext();

        public DisciplinesList()
        {
            InitializeComponent();
            IEnumerable<DisciplinesModel> disciplines = context.Disciplines.Include(a => a.Teacher);
            ObservableCollection<DisciplinesElement> elements = new ObservableCollection<DisciplinesElement>();
            foreach (DisciplinesModel model in disciplines)
            {
                elements.Add(new DisciplinesElement(model, context));
            }
            List.ItemsSource = elements;
        }
    }
}
