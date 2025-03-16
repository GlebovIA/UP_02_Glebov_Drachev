using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using UP_02_Glebov_Drachev.Models;
using UP_02_Glebov_Drachev.Reporting;
using UP_02_Glebov_Drachev.Views.Controls;
using UP_02_Glebov_Drachev.Views.Pages.EntityPages.Lists;

namespace UP_02_Glebov_Drachev.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для GeneralPage.xaml
    /// </summary>
    public partial class GeneralPage : Page
    {
        private static Frame pagesFrame { get; set; }

        public GeneralPage()
        {
            InitializeComponent();
            pagesFrame = PagesFrame;

            // Обработчик клика по бургер-меню
            BurgerMenu.OnClick += (s, a) =>
            {
                BurgerMenu.Opacity = 0;
                DoubleAnimation borderAnimation = new DoubleAnimation();
                borderAnimation.From = OpenedMeny.ActualWidth;
                borderAnimation.To = 300;
                borderAnimation.Duration = TimeSpan.FromSeconds(0.15);
                OpenedMeny.BeginAnimation(Border.WidthProperty, borderAnimation);
            };

            // Обработчик клика по раскрытому меню
            OpenedMeny.OnClick += (s, a) =>
            {
                BurgerMenu.Opacity = 1;
                DoubleAnimation borderAnimation = new DoubleAnimation();
                borderAnimation.From = OpenedMeny.ActualWidth;
                borderAnimation.To = 0;
                borderAnimation.Duration = TimeSpan.FromSeconds(0.15);
                OpenedMeny.BeginAnimation(Border.WidthProperty, borderAnimation);
            };

            // Устанавливаем элементы меню
            OpenedMeny.SetItems(GetDataFromDatabase());
        }

        public static void SwapPages(Page page)
        {
            pagesFrame.Navigate(page);
        }

        private ObservableCollection<TabElement> GetDataFromDatabase()
        {
            ObservableCollection<TabElement> tabs = new ObservableCollection<TabElement>
            {
                new TabElement(new TabModel() { Title = "Дисциплины", Content = GetDisciplinesData() }, (s, a) => SetDisciplinesElement()),
                new TabElement(new TabModel() { Title = "Программы дисциплин", Content = GetDisciplineProgramsData() }, (s, a) => SetDisciplineProgramsElement()),
                new TabElement(new TabModel() { Title = "Оценки", Content = GetMarksData() }, (s, a) => SetMarksElement()),
                new TabElement(new TabModel() { Title = "Занятия", Content = GetLessonsData() }, (s, a) => SetLessonsElement()),
                new TabElement(new TabModel() { Title = "Пропуски занятий", Content = "", IsFirst = true }, (s, a) => SetAbsencesElement()),
                new TabElement(new TabModel() { Title = "Группы", Content = GetGroupsData() }, (s, a) => SetGroupsElements()),
                new TabElement(new TabModel() { Title = "Студенты", Content = GetStudentsData() }, (s, a) => SetStudentsElement()),
                new TabElement(new TabModel() { Title = "Консультации", Content = GetConsultationsData() }, (s, a) => SetConsultationsElement()),
                new TabElement(new TabModel() { Title = "Результаты консультаций", Content = GetConsultationResultsData() }, (s, a) => SetConsultationResultsElement()),
                new TabElement(new TabModel() { Title = "Учебные планы", Content = GetStudPlansData() }, (s, a) => SetStudPlanElement()),
                new TabElement(new TabModel() { Title = "Типы занятий", Content = GetLessonTypesData() }, (s, a) => SetLessonTypeElement()),
                new TabElement(new TabModel() { Title = "Преподаватели", Content = GetTeachersData() }, (s, a) => SetTeachersElement()),
                new TabElement(new TabModel() { Title = "Преподавательские нагрузки", Content = GetTeachersLoadData() }, (s, a) => SetTeachersLoadElement()),
                new TabElement(new TabModel() { Title = "Отчет по опозданиям", Content = GetTeachersData() }, (s, a) => AbsenceReport.GenerateReport())
            };
            return tabs;
        }

        private string GetConsultationResultsData() => "Результаты консультаций...";
        private string GetLessonsData() => "Занятия...";
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
            SwapPages(new AbsencesList());
        }
        private void SetDisciplinesElement()
        {
            SwapPages(new DisciplinesList());
        }
        private void SetDisciplineProgramsElement()
        {
            SwapPages(new DisciplineProgramsList());
        }
        private void SetConsultationsElement()
        {
            SwapPages(new ConsultationsList());
        }
        private void SetConsultationResultsElement()
        {
            SwapPages(new ConsultationResultsList());
        }
        private void SetMarksElement()
        {
            SwapPages(new MarksList());
        }
        private void SetLessonsElement()
        {
            SwapPages(new LessonsList());
        }
        private void SetGroupsElements()
        {
            SwapPages(new GroupsList());
        }
        private void SetStudentsElement()
        {
            SwapPages(new StudentsList());
        }
        private void SetStudPlanElement()
        {
            SwapPages(new StudPlanList());
        }
        private void SetLessonTypeElement()
        {
            SwapPages(new LessonTypesList());
        }
        private void SetTeachersElement()
        {
            SwapPages(new TeachersList());
        }
        private void SetTeachersLoadElement()
        {
            SwapPages(new TeachersLoadList());
        }
    }
}
