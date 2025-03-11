using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using UP_02_Glebov_Drachev.Contexts;
using UP_02_Glebov_Drachev.Models;
using UP_02_Glebov_Drachev.Views.Elements;

namespace UP_02_Glebov_Drachev.Views.Pages.EntityPages.Lists
{
    /// <summary>
    /// Логика взаимодействия для StudentsList.xaml
    /// </summary>
    public partial class StudentsList : Page
    {
        StudentsContext context = new StudentsContext();
        public StudentsList()
        {
            InitializeComponent();
            IEnumerable<StudentsModel> students = context.Students.Include(a => a.StudGroup);
            ObservableCollection<StudentsElement> elements = new ObservableCollection<StudentsElement>();
            foreach (StudentsModel model in students)
            {
                elements.Add(new StudentsElement(model, context));
            }
            List.ItemsSource = elements;
        }
    }
}
