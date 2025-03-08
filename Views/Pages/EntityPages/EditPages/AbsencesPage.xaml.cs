using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using UP_02_Glebov_Drachev.Contexts;
using UP_02_Glebov_Drachev.Models;
using UP_02_Glebov_Drachev.Views.Pages.EntityPages.Lists;

namespace UP_02_Glebov_Drachev.Views.Pages.EntityPages.EditPages
{
    public partial class AbsencesPage : Page
    {
        private AbsencesContext Context { get; set; }
        private StudentsContext StudentsContext = new StudentsContext();
        private DisciplinesContext DisciplinesContext = new DisciplinesContext();
        private AbsencesModel Model { get; set; }
        private bool IsUpdate = false;

        public AbsencesPage(AbsencesContext context, AbsencesModel model = null)
        {
            InitializeComponent();
            Context = context;
            if (model != null)
            {
                Model = model;
                IsUpdate = true;
            }
            else
                Model = new AbsencesModel();

            Students.SetBinding(ComboBox.ItemsSourceProperty, new Binding() { Source = new ObservableCollection<StudentsModel>(StudentsContext.Students) });
            Disciplines.SetBinding(ComboBox.ItemsSourceProperty, new Binding() { Source = new ObservableCollection<DisciplinesModel>(DisciplinesContext.Disciplines) });
            DataContext = Model;
        }

        private void Acept(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Вывод значений для отладки
            MessageBox.Show($"DelayMinutes: {Model.DelayMinutes}, ExplanatoryNote: {Model.ExplanatoryNote}");

            try
            {
                if (!IsUpdate) Context.Absences.Add(Model);
                Context.SaveChanges();
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
