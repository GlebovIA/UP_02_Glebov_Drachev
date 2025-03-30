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
    public partial class TeachersList : Page
    {
        private TeachersContext context = new TeachersContext();

        public TeachersList()
        {
            InitializeComponent();
            LoadTeachers();
        }

        private void LoadTeachers()
        {
            var teachers = context.Teachers.Include(t => t.User).OrderBy(x => x.Surname);
            ObservableCollection<TeachersElement> elements = new ObservableCollection<TeachersElement>();
            foreach (TeachersModel model in teachers)
            {
                elements.Add(new TeachersElement(model, context));
            }
            List.ItemsSource = elements;
        }

        private void AddClick(object sender, MouseButtonEventArgs e)
        {
            GeneralPage.SwapPages(new TeachersPage(context));
        }
    }
}