using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using UP_02_Glebov_Drachev.Contexts;
using UP_02_Glebov_Drachev.Models;
using UP_02_Glebov_Drachev.Views.Pages.EntityPages.Lists;

namespace UP_02_Glebov_Drachev.Views.Pages.EntityPages.EditPages
{
    /// <summary>
    /// Логика взаимодействия для ConsultationResultsPAge.xaml
    /// </summary>
    public partial class ConsultationResultsPage : Page
    {
        private ConsultationResultsContext Context { get; set; }
        private StudentsContext StudentsContext = new StudentsContext();
        private ConsultationsContext ConsultationsContext = new ConsultationsContext();
        private ConsultationResultsModel Model { get; set; }
        private bool IsUpdate = false;

        public ConsultationResultsPage(ConsultationResultsContext context, ConsultationResultsModel model = null)
        {
            InitializeComponent();
            Context = context;
            if (model != null)
            {
                Model = model;
                IsUpdate = true;
            }
            else
                Model = new ConsultationResultsModel();

            Students.SetBinding(ComboBox.ItemsSourceProperty, new Binding() { Source = new ObservableCollection<StudentsModel>(StudentsContext.Students) });
            Consultation.SetBinding(ComboBox.ItemsSourceProperty, new Binding() { Source = new ObservableCollection<ConsultationsModel>(ConsultationsContext.Consultations) });
            DataContext = Model;
        }

        private void Acept(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                if (!IsUpdate) Context.ConsultationsResults.Add(Model);
                Context.SaveChanges();
                GeneralPage.SwapPages(new ConsultationResultsList());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void Cancel(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            GeneralPage.SwapPages(new ConsultationResultsList());
        }
    }
}
