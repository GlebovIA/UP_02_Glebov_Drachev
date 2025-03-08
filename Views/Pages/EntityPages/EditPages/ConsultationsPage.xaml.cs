using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using UP_02_Glebov_Drachev.Contexts;
using UP_02_Glebov_Drachev.Models;
using UP_02_Glebov_Drachev.Views.Pages.EntityPages.Lists;

namespace UP_02_Glebov_Drachev.Views.Pages.EntityPages.EditPages
{
    public partial class ConsultationsPage : Page
    {
        public ConsultationsContext Context { get; set; }
        public DisciplinesContext DisciplinesContext = new DisciplinesContext();
        private ConsultationsModel Model { get; set; }
        private bool IsUpdate = false;

        public ConsultationsPage(ConsultationsContext context, ConsultationsModel model = null)
        {
            InitializeComponent();
            Context = context;
            if (model != null)
            {
                Model = model;
                IsUpdate = true;
            }
            else
            {
                Model = new ConsultationsModel();
            }

            // Привязка дисциплин к ComboBox
            Disciplines.SetBinding(ComboBox.ItemsSourceProperty, new Binding() { Source = new ObservableCollection<DisciplinesModel>(DisciplinesContext.Disciplines) });
            DataContext = Model;
        }

        private void Accept(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                if (IsUpdate) Context.Consultations.Add(Model);
                // Сохраняем изменения
                Context.SaveChanges();
                GeneralPage.SwapPages(new ConsultationsList());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Cancel(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Отменяем изменения и возвращаемся к списку консультаций
            GeneralPage.SwapPages(new ConsultationsList());
        }
    }
}
