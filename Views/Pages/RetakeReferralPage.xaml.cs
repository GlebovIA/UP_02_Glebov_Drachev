using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input; // Добавлено для MouseButtonEventArgs
using UP_02_Glebov_Drachev.Contexts;
using UP_02_Glebov_Drachev.Models;
using UP_02_Glebov_Drachev.Reporting;

namespace UP_02_Glebov_Drachev.Views.Pages
{
    public partial class RetakeReferralPage : Page
    {
        private readonly StudentsContext _studentsContext;
        private readonly DisciplinesContext _disciplinesContext;

        public RetakeReferralPage()
        {
            InitializeComponent();
            _studentsContext = new StudentsContext();
            _disciplinesContext = new DisciplinesContext();
            LoadComboBoxes();
        }

        private void LoadComboBoxes()
        {
            var students = _studentsContext.Students.ToList();
            var disciplines = _disciplinesContext.Disciplines.ToList();

            if (students.Any())
            {
                StudentComboBox.ItemsSource = students;
            }
            else
            {
                MessageBox.Show("Не удалось загрузить список студентов. Проверьте подключение к базе данных.");
            }

            if (disciplines.Any())
            {
                DisciplineComboBox.ItemsSource = disciplines;
            }
            else
            {
                MessageBox.Show("Не удалось загрузить список дисциплин. Проверьте подключение к базе данных.");
            }
        }

        private void GenerateButton_Click(object sender, MouseButtonEventArgs e)
        {
            if (StudentComboBox.SelectedItem is StudentsModel selectedStudent &&
                DisciplineComboBox.SelectedItem is DisciplinesModel selectedDiscipline)
            {
                var generator = new DocumentGenerator();
                generator.GenerateRetakeReferral(selectedStudent.Id, selectedDiscipline.Id);
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите студента и дисциплину.");
            }
        }

        private void CancelButton_Click(object sender, MouseButtonEventArgs e)
        {
            if (NavigationService != null)
            {
                NavigationService.Navigate(new GeneralPage());
            }
        }
    }
}