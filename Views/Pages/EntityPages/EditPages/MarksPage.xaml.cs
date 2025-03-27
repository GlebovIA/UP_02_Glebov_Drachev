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
    public partial class MarksPage : Page
    {
        private MarksContext Context { get; set; }
        private StudentsContext StudentsContext = new StudentsContext();
        private LessonsContext LessonsContext = new LessonsContext();
        private MarksModel Model { get; set; }
        private bool IsUpdate = false;

        public MarksPage(MarksContext context, MarksModel model = null)
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
                // Устанавливаем текущую дату по умолчанию для новой записи
                Model = new MarksModel { Date = DateTime.Today };
            }

            // Привязка данных для ComboBox
            StudentsComboBox.SetBinding(ComboBox.ItemsSourceProperty,
                new Binding() { Source = new ObservableCollection<StudentsModel>(StudentsContext.Students) });
            ThemsComboBox.SetBinding(ComboBox.ItemsSourceProperty,
                new Binding() { Source = new ObservableCollection<LessonsModel>(LessonsContext.Lessons.Include(a => a.DisciplineProgram)) });

            DataContext = Model;
        }

        private void Acept(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                // Валидация данных
                if (Model.Date == DateTime.MinValue)
                {
                    MessageBox.Show("Пожалуйста, выберите дату.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(Model.Mark))
                {
                    MessageBox.Show("Пожалуйста, укажите оценку.");
                    return;
                }

                if (Model.LessonId == 0)
                {
                    MessageBox.Show("Пожалуйста, выберите занятие.");
                    return;
                }

                if (Model.StudentId == 0)
                {
                    MessageBox.Show("Пожалуйста, выберите студента.");
                    return;
                }

                // Добавление или обновление записи
                if (IsUpdate)
                {
                    // Проверяем, отслеживается ли модель
                    var entry = Context.Entry(Model);
                    if (entry.State == EntityState.Detached)
                    {
                        Context.Attach(Model);
                        entry.State = EntityState.Modified;
                    }
                }
                else
                {
                    Context.Marks.Add(Model);
                }

                Context.SaveChanges();
                GeneralPage.SwapPages(new MarksList());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.InnerException?.Message ?? ex.Message}");
            }
        }

        private void Cancel(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            GeneralPage.SwapPages(new MarksList());
        }
    }
}