using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using UP_02_Glebov_Drachev.Contexts;
using UP_02_Glebov_Drachev.Models;
using UP_02_Glebov_Drachev.Views.Elements;

namespace UP_02_Glebov_Drachev.Views.Pages.EntityPages.Lists
{
    public partial class TeachersList : Page
    {
        TeachersContext context = new TeachersContext();

        public TeachersList()
        {
            InitializeComponent();
            IEnumerable<TeachersModel> teachers = context.Teachers.Include(t => t.User);
            ObservableCollection<TeachersElement> elements = new ObservableCollection<TeachersElement>();
            foreach (TeachersModel model in teachers)
            {
                elements.Add(new TeachersElement(model, context));
            }
            List.ItemsSource = elements;
        }
    }
}