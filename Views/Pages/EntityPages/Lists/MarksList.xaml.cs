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
    public partial class MarksList : Page
    {
        private MarksContext context = new MarksContext();

        public MarksList()
        {
            InitializeComponent();
            LoadMarks();
        }

        private void LoadMarks()
        {
            var marks = context.Marks
                .Include(a => a.Student)
                .ThenInclude(s => s.StudGroup)
                .Include(a => a.Lesson).OrderByDescending(x => x.Lesson.Date).ThenByDescending(x => x.Lesson.Time).ThenBy(x => x.Student.Surname);
            ObservableCollection<MarksElement> elements = new ObservableCollection<MarksElement>();
            foreach (MarksModel model in marks)
            {
                elements.Add(new MarksElement(model, context));
            }
            List.ItemsSource = elements;
        }

        private void AddClick(object sender, MouseButtonEventArgs e)
        {
            GeneralPage.SwapPages(new MarksPage(context));
        }
    }
}