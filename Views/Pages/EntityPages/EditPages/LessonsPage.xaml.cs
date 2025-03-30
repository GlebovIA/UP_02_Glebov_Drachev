using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using UP_02_Glebov_Drachev.Contexts;
using UP_02_Glebov_Drachev.Models;
using UP_02_Glebov_Drachev.Views.Pages.EntityPages.Lists;

namespace UP_02_Glebov_Drachev.Views.Pages.EntityPages.EditPages
{
    /// <summary>
    /// Логика взаимодействия для LessonsPage.xaml
    /// </summary>
    public partial class LessonsPage : Page
    {
        private LessonsContext Context { get; set; }
        private GroupsContext GroupsContext = new GroupsContext();
        private DisciplineProgramsContext DisciplineProgramsContext = new DisciplineProgramsContext();
        private LessonsModel Model { get; set; }
        private bool IsUpdate = false;

        public LessonsPage(LessonsContext context, LessonsModel model = null)
        {
            InitializeComponent();
            Context = context;
            if (model != null)
            {
                Model = model;
                IsUpdate = true;
            }
            else
                Model = new LessonsModel() { Date = DateTime.Today };

            // Загрузка данных
            GroupsComboBox.ItemsSource = new ObservableCollection<GroupsModel>(GroupsContext.Groups);
            DisciplineProgramsComboBox.ItemsSource = new ObservableCollection<DisciplineProgramsModel>(DisciplineProgramsContext.DisciplinePrograms.Include(dp => dp.Discipline));

            // Проверка данных
            Console.WriteLine($"DisciplinePrograms count: {DisciplineProgramsContext.DisciplinePrograms.Count()}");
            Console.WriteLine($"Selected DisciplineProgramId: {Model.DisciplineProgramId}");

            DataContext = Model;
        }

        private void Accept(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                if (!IsUpdate) Context.Lessons.Add(Model);
                Context.SaveChanges();
                GeneralPage.SwapPages(new LessonsList());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Cancel(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            GeneralPage.SwapPages(new LessonsList());
        }
    }
}