using System.Linq;
using System.Windows;
using System.Windows.Controls;
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

            // Заполняем выпадающие списки данными
            StudentComboBox.ItemsSource = _studentsContext.Students.ToList();
            DisciplineComboBox.ItemsSource = _disciplinesContext.Disciplines.ToList();
        }

        private void GenerateButton_Click(object sender, RoutedEventArgs e)
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
    }
}