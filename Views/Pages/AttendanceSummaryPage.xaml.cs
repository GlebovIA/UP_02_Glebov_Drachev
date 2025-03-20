using System.Linq;
using System.Windows;
using System.Windows.Controls;
using UP_02_Glebov_Drachev.Contexts;
using UP_02_Glebov_Drachev.Models;
using UP_02_Glebov_Drachev.Reporting;

namespace UP_02_Glebov_Drachev.Views.Pages
{
    public partial class AttendanceSummaryPage : Page
    {
        private readonly StudentsContext _studentsContext;

        public AttendanceSummaryPage()
        {
            InitializeComponent();
            _studentsContext = new StudentsContext();

            // Заполняем выпадающий список данными
            StudentComboBox.ItemsSource = _studentsContext.Students.ToList();
        }

        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            if (StudentComboBox.SelectedItem is StudentsModel selectedStudent)
            {
                var generator = new DocumentGenerator();
                generator.GenerateAttendanceSummary(selectedStudent.Id);
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите студента.");
            }
        }
    }
}