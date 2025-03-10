using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using UP_02_Glebov_Drachev.Contexts;
using UP_02_Glebov_Drachev.Models;
using UP_02_Glebov_Drachev.Views.Elements;

namespace UP_02_Glebov_Drachev.Views.Pages.EntityPages.Lists
{
    /// <summary>
    /// Логика взаимодействия для MarksList.xaml
    /// </summary>
    public partial class MarksList : Page
    {
        MarksContext context = new MarksContext();
        public MarksList()
        {
            InitializeComponent();
            IEnumerable<MarksModel> marks = context.Marks.Include(a => a.Student)
                                  .ThenInclude(s => s.StudGroup)
                                  .Include(a => a.Lesson);
            ObservableCollection<MarksElement> elements = new ObservableCollection<MarksElement>();
            foreach (MarksModel model in marks)
            {
                elements.Add(new MarksElement(model, context));
            }
            List.ItemsSource = elements;
        }
    }
}
