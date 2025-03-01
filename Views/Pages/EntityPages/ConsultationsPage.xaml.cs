using Microsoft.EntityFrameworkCore;
using System;
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
        public ConsultationsContext ConsultationsContext { get; set; }
        public DisciplinesContext DisciplinesContext { get; set; }
        public ObservableCollection<DisciplinesModel> AllDisciplines { get; set; }
        private ConsultationsModel Model { get; set; }
        private bool IsUpdate { get; set; }

        public ConsultationsPage(ConsultationsContext context, ConsultationsModel consultationsModel = null)
        {
            InitializeComponent();
            ConsultationsContext = context;
            DisciplinesContext = new DisciplinesContext();
            AllDisciplines = new ObservableCollection<DisciplinesModel>(DisciplinesContext.Disciplines.ToList());

            if (consultationsModel != null)
            {
                // Используем переданный контекст для поиска консультации
                Model = context.Consultations
                    .Include(c => c.Discipline)  // Включаем связанную сущность Discipline
                    .FirstOrDefault(x => x.Id == consultationsModel.Id);
                IsUpdate = true;
            }
            else
            {
                Model = new ConsultationsModel();
            }

            // Привязка дисциплин к ComboBox
            Disciplines.SetBinding(ComboBox.ItemsSourceProperty, new Binding() { Source = AllDisciplines });
            DataContext = Model;
        }

        private void Accept(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                // Сохраняем изменения
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
            // Отменяем изменения и возвращаемся к списку консультаций
            GeneralPage.SwapPages(new ConsultationsList());
        }
    }
}
