using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using UP_02_Glebov_Drachev.Contexts;
using UP_02_Glebov_Drachev.Models;
using UP_02_Glebov_Drachev.Views.Pages.EntityPages;

namespace UP_02_Glebov_Drachev.Views.Pages
{
    public partial class ConsultationsPage : Page
    {
        public IEnumerable<ConsultationsModel> ConsultationsData { get; set; }
        public ConsultationsContext ConsultationsContext = new ConsultationsContext();
        public DisciplinesContext DisciplinesContext = new DisciplinesContext();
        public ObservableCollection<DisciplinesModel> AllDisciplines { get; set; }
        private ConsultationsModel Model { get; set; }
        private bool IsUpdate { get; set; }

        public ConsultationsPage(ConsultationsModel consultationsModel = null)
        {
            InitializeComponent();
            AllDisciplines = new ObservableCollection<DisciplinesModel>(DisciplinesContext.Disciplines.ToList());

            if (consultationsModel != null)
            {
                Model = ConsultationsContext.Consultations
                    .Include(c => c.Discipline)  // Включаем связанную сущность Discipline
                    .FirstOrDefault(x => x.Id == consultationsModel.Id);
                IsUpdate = true;
            }
            else
            {
                Model = new ConsultationsModel();
            }

            Disciplines.SetBinding(ComboBox.ItemsSourceProperty, new Binding() { Source = AllDisciplines });
            DataContext = Model;
        }

        private void Accept(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                ConsultationsContext.SaveChanges();
                GeneralPage.SwapPages(new ConsultationsList());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Cancel(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            GeneralPage.SwapPages(new ConsultationsList());
        }
    }
}
