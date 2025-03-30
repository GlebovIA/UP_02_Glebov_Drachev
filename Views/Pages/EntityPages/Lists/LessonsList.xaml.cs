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
    public partial class LessonsList : Page
    {
        private LessonsContext context = new LessonsContext();

        public LessonsList()
        {
            InitializeComponent();
            LoadLessons();
        }

        private void LoadLessons()
        {
            var lessons = context.Lessons
                .Include(l => l.StudGroup)
                .Include(l => l.DisciplineProgram)
                .ThenInclude(dp => dp.Discipline).OrderByDescending(x => x.Date).ThenByDescending(x => x.Time);
            ObservableCollection<LessonsElement> elements = new ObservableCollection<LessonsElement>();
            foreach (LessonsModel model in lessons) // Убедимся, что используется LessonsModel
            {
                elements.Add(new LessonsElement(model, context));
            }
            List.ItemsSource = elements;
        }

        private void AddClick(object sender, MouseButtonEventArgs e)
        {
            GeneralPage.SwapPages(new LessonsPage(context));
        }
    }
}