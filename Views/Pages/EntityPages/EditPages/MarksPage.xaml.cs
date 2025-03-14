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
                Model = new MarksModel();

            // Исправлено: Student -> StudentsComboBox, Lesson -> LessonsComboBox
            StudentsComboBox.SetBinding(ComboBox.ItemsSourceProperty,
                new Binding() { Source = new ObservableCollection<StudentsModel>(StudentsContext.Students) });
            LessonsComboBox.SetBinding(ComboBox.ItemsSourceProperty,
                new Binding() { Source = new ObservableCollection<LessonModel>(LessonsContext.Lessons) });
            DataContext = Model;
        }

        private void Acept(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                if (!IsUpdate) Context.Marks.Add(Model);
                Context.SaveChanges();
                GeneralPage.SwapPages(new MarksList());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Cancel(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            GeneralPage.SwapPages(new MarksList());
        }
    }
}