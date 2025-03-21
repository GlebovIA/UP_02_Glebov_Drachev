using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Globalization;
using System.Windows.Data;
using UP_02_Glebov_Drachev.Contexts;
using UP_02_Glebov_Drachev.Models;
using UP_02_Glebov_Drachev.Reporting;

namespace UP_02_Glebov_Drachev.Views.Pages
{
    public partial class AttendanceSummaryPage : Page
    {
        private readonly StudentsContext _studentsContext;
        private const string AllStudentsOption = "Все";

        public AttendanceSummaryPage()
        {
            InitializeComponent();
            _studentsContext = new StudentsContext();
            LoadStudents();
        }

        private void LoadStudents()
        {
            var students = _studentsContext.Students.ToList();
            var studentOptions = new List<object> { AllStudentsOption };
            studentOptions.AddRange(students);
            StudentComboBox.ItemsSource = studentOptions;
        }

        private void GenerateButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var generator = new DocumentGenerator();

            if (StudentComboBox.SelectedItem is string selectedOption && selectedOption == AllStudentsOption)
            {
                generator.GenerateAttendanceSummaryForAllStudents();
            }
            else if (StudentComboBox.SelectedItem is StudentsModel selectedStudent)
            {
                generator.GenerateAttendanceSummary(selectedStudent.Id);
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите студента или 'Все'.");
            }
        }

        private void CancelButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService?.Navigate(new GeneralPage());
        }
    }

    // Конвертер для отображения текста в ComboBox
    public class StudentConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] is string str)
                return str;
            if (values[0] is StudentsModel student)
                return $"{student.Surname} {student.Name} {student.Lastname ?? ""}";
            return string.Empty;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}