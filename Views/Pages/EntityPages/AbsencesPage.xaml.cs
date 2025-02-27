using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using UP_02_Glebov_Drachev.Contexts;
using UP_02_Glebov_Drachev.Models;
using UP_02_Glebov_Drachev.Views.Pages.EntityPages;

namespace UP_02_Glebov_Drachev.Views.Pages
{
    public partial class AbsencesPage : Page
    {
        public IEnumerable<AbsencesModel> AbsencesData { get; set; }
        public AbsencesContext AbsencesContext = new AbsencesContext();
        public StudentsContext StudentsContext = new StudentsContext();
        public DisciplinesContext DisciplinesContext = new DisciplinesContext();
        public ObservableCollection<StudentsModel> AllStudents { get; set; }
        public ObservableCollection<DisciplinesModel> AllDisciplines { get; set; }
        private AbsencesModel Model { get; set; }
        private bool IsUpdate { get; set; }

        public AbsencesPage(AbsencesModel absencesModel = null)
        {
            InitializeComponent();
            AllStudents = new ObservableCollection<StudentsModel>(StudentsContext.Students.ToList());
            AllDisciplines = new ObservableCollection<DisciplinesModel>(DisciplinesContext.Disciplines.ToList());

            if (absencesModel != null)
            {
                Model = AbsencesContext.Absences.Include(a => a.Student)
                                  .ThenInclude(s => s.StudGroup)
                                  .Include(a => a.Discipline).FirstOrDefault(x => x.Id == absencesModel.Id);
                IsUpdate = true;
            }
            else Model = new AbsencesModel();
            Students.SetBinding(ComboBox.ItemsSourceProperty, new Binding() { Source = AllStudents });
            Disciplines.SetBinding(ComboBox.ItemsSourceProperty, new Binding() { Source = AllDisciplines });
            DataContext = Model;

        }

        private void Acept(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                AbsencesContext.SaveChanges();
                GeneralPage.SwapPages(new AbsencesList());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Cancel(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            GeneralPage.SwapPages(new AbsencesList());
        }
    }
}
