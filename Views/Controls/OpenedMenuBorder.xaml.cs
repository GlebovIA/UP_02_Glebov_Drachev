using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace UP_02_Glebov_Drachev.Views.Controls
{
    public partial class OpenedMenuBorder : Border
    {
        public OpenedMenuBorder()
        {
            InitializeComponent();
            BackButton.MouseEnter += OnMouseEnter;
            BackButton.MouseLeave += OnMouseLeave;

            // Получаем данные из базы данных и отображаем их в вкладках
            List<TabItem> tabs = GetDataFromDatabase();
            PopulateTabs(tabs);
        }

        private List<TabItem> GetDataFromDatabase()
        {
            // Имитация запроса данных из базы данных
            List<TabItem> tabs = new List<TabItem>
            {
                new TabItem { Title = "Отсутствия", Content = GetAbsencesData() },
                new TabItem { Title = "Результаты консультаций", Content = GetConsultationResultsData() },
                new TabItem { Title = "Консультации", Content = GetConsultationsData() },
                new TabItem { Title = "Программы дисциплин", Content = GetDisciplineProgramsData() },
                new TabItem { Title = "Дисциплины", Content = GetDisciplinesData() },
                new TabItem { Title = "Группы", Content = GetGroupsData() },
                new TabItem { Title = "Типы занятий", Content = GetLessonTypesData() },
                new TabItem { Title = "Оценки", Content = GetMarksData() },
                new TabItem { Title = "Роли", Content = GetRolesData() },
                new TabItem { Title = "Студенты", Content = GetStudentsData() },
                new TabItem { Title = "Учебные планы", Content = GetStudPlansData() },
                new TabItem { Title = "Нагрузка преподавателей", Content = GetTeachersLoadData() },
                new TabItem { Title = "Преподаватели", Content = GetTeachersData() }
            };
            return tabs;
        }

        // Пример данных для каждой вкладки
        private string GetAbsencesData() => "Список отсутствующих студентов...";
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

        private void PopulateTabs(List<TabItem> tabs)
        {
            foreach (var tab in tabs)
            {
                // Создание кнопки для каждой вкладки
                Button tabButton = new Button
                {
                    Content = tab.Title,
                    Background = new SolidColorBrush(Colors.LightGray),
                    BorderBrush = Brushes.DarkGray,
                    BorderThickness = new System.Windows.Thickness(1),
                    Margin = new System.Windows.Thickness(5),
                    Padding = new System.Windows.Thickness(10)
                };

                tabButton.Click += (sender, e) => ShowTabContent(tab);

                TabParent.Children.Add(tabButton);
            }
        }

        private void ShowTabContent(TabItem tab)
        {
            // Отображаем данные для выбранной вкладки
            MessageBox.Show($"Содержимое вкладки {tab.Title}: {tab.Content}");
        }

        private void OnMouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            BackButton.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 0, 96, 172));
        }

        private void OnMouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            BackButton.BorderBrush = Brushes.DarkGray;
        }

        public event MouseButtonEventHandler OnClick
        {
            add { BackButton.MouseLeftButtonDown += value; }
            remove { BackButton.MouseLeftButtonDown -= value; }
        }
    }

    public class TabItem
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
