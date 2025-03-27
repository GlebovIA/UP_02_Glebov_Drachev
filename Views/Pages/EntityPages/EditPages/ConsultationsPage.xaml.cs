using Microsoft.EntityFrameworkCore;
using System;
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

            // Инициализация модели
            if (model != null)
            {
                Model = model;
                IsUpdate = true;
            }
            else
            {
                // Устанавливаем текущую дату по умолчанию для новой записи
                Model = new ConsultationsModel { Date = DateTime.Today };
            }

            // Привязка данных для ComboBox с дисциплинами
            DisciplinesComboBox.SetBinding(ComboBox.ItemsSourceProperty,
                new Binding() { Source = new ObservableCollection<DisciplinesModel>(DisciplinesContext.Disciplines) });

            // Установка DataContext для привязки данных
            DataContext = Model;
        }

        private void Accept(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                // Валидация: проверяем, выбрана ли дата
                if (Model.Date == DateTime.MinValue)
                {
                    MessageBox.Show("Пожалуйста, выберите дату.");
                    return;
                }

                // Валидация: проверяем, выбрана ли дисциплина
                if (Model.DisciplineId == 0)
                {
                    MessageBox.Show("Пожалуйста, выберите дисциплину.");
                    return;
                }

                // Если это обновление, проверяем состояние модели
                if (IsUpdate)
                {
                    var entry = Context.Entry(Model);
                    if (entry.State == EntityState.Detached)
                    {
                        Context.Attach(Model);
                        entry.State = EntityState.Modified;
                    }
                }
                else
                {
                    // Добавляем новую запись
                    Context.Consultations.Add(Model);
                }

                // Сохраняем изменения
                Context.SaveChanges();

                // Переходим к списку консультаций
                GeneralPage.SwapPages(new ConsultationsList());
            }
            catch (Exception ex)
            {
                // Улучшенная обработка ошибок с выводом внутреннего исключения
                MessageBox.Show($"Ошибка: {ex.InnerException?.Message ?? ex.Message}");
            }
        }

        private void Cancel(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Отменяем изменения и возвращаемся к списку консультаций
            GeneralPage.SwapPages(new ConsultationsList());
        }
    }
}