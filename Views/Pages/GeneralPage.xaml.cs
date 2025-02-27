using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;
using UP_02_Glebov_Drachev.Contexts;
using UP_02_Glebov_Drachev.Models;
using UP_02_Glebov_Drachev.Views.Controls;
using UP_02_Glebov_Drachev.Views.Elements;

namespace UP_02_Glebov_Drachev.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для GeneralPage.xaml
    /// </summary>
    public partial class GeneralPage : Page
    {
        public GeneralPage()
        {
            InitializeComponent();
            SetAbsencesElement();
            BurgerMenu.OnClick += (s, a) =>
            {
                BurgerMenu.Opacity = 0;
                DoubleAnimation borderAnimation = new DoubleAnimation();
                borderAnimation.From = OpenedMeny.ActualWidth;
                borderAnimation.To = 300;
                borderAnimation.Duration = TimeSpan.FromSeconds(0.15);
                OpenedMeny.BeginAnimation(Border.WidthProperty, borderAnimation);
            };
            OpenedMeny.OnClick += (s, a) =>
            {
                BurgerMenu.Opacity = 1;
                DoubleAnimation borderAnimation = new DoubleAnimation();
                borderAnimation.From = OpenedMeny.ActualWidth;
                borderAnimation.To = 0;
                borderAnimation.Duration = TimeSpan.FromSeconds(0.15);
                OpenedMeny.BeginAnimation(Border.WidthProperty, borderAnimation);
            };
            OpenedMeny.SetItems(GetDataFromDatabase());
        }

        private ObservableCollection<TabElement> GetDataFromDatabase()
        {
            ObservableCollection<TabElement> tabs = new ObservableCollection<TabElement>
    {
        new TabElement(new TabModel() { Title = "Пропуски занятий", Content = "", IsFirst = true }) {  },
        new TabElement(new TabModel() { Title = "Результаты консультаций", Content = GetConsultationResultsData() }),
        new TabElement(new TabModel() { Title = "Консультации", Content = GetConsultationsData() }),
        new TabElement(new TabModel() { Title = "Программы дисциплин", Content = GetDisciplineProgramsData() }),
        new TabElement(new TabModel() { Title = "Дисциплины", Content = GetDisciplinesData() }),
        new TabElement(new TabModel() { Title = "Группы", Content = GetGroupsData() }),
        new TabElement(new TabModel() { Title = "Типы занятий", Content = GetLessonTypesData() }),
        new TabElement(new TabModel() { Title = "Оценки", Content = GetMarksData() }),
        new TabElement(new TabModel() { Title = "Роли", Content = GetRolesData() }),
        new TabElement(new TabModel() { Title = "Студенты", Content = GetStudentsData() }),
        new TabElement(new TabModel() { Title = "Учебные планы", Content = GetStudPlansData() }),
        new TabElement(new TabModel() { Title = "Преподавательские нагрузки", Content = GetTeachersLoadData() }),
        new TabElement(new TabModel() { Title = "Преподаватели", Content = GetTeachersData() })
    };
            return tabs;
        }

        private string GetConsultationResultsData() => "Результаты консультаций...";
        private string GetConsultationsData() => "Данные по консультациям...";
        private string GetDisciplineProgramsData() => "Программы дисциплин...";
        private string GetDisciplinesData() => "Список дисциплин...";
        private string GetGroupsData() => "Список групп...";
        private string GetLessonTypesData() => "Типы занятий...";
        private string GetMarksData() => "Список оценок...";
        private string GetRolesData() => "Роли пользователей...";
        private string GetStudentsData() => "Список студентов...";
        private string GetStudPlansData() => "Учебные планы...";
        private string GetTeachersLoadData() => "Данные о нагрузке преподавателей...";
        private string GetTeachersData() => "Список преподавателей...";

        private void SetAbsencesElement()
        {
            var absences = new AbsencesContext().Absences.Include(a => a.Student)
                                              .ThenInclude(s => s.StudGroup)
                                              .Include(a => a.Discipline)
                                              .ToList();
            List.ItemsSource = absences;
        }


    }
}
