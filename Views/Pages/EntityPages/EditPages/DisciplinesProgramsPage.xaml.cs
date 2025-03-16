using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using UP_02_Glebov_Drachev.Contexts;
using UP_02_Glebov_Drachev.Models;
using UP_02_Glebov_Drachev.Views.Pages.EntityPages.Lists;

namespace UP_02_Glebov_Drachev.Views.Pages.EntityPages.EditPages
{
    public partial class DisciplineProgramsPage : Page // Исправлено имя класса
    {
        private DisciplineProgramsContext Context { get; set; }
        private DisciplinesContext DisciplinesContext = new DisciplinesContext();
        private LessonTypesContext LessonTypesContext = new LessonTypesContext();
        private DisciplineProgramsModel Model { get; set; }
        private bool IsUpdate = false;

        public DisciplineProgramsPage(DisciplineProgramsContext context, DisciplineProgramsModel model = null)
        {
            InitializeComponent();
            Context = context;
            if (model != null)
            {
                Model = model;
                IsUpdate = true;
            }
            else
                Model = new DisciplineProgramsModel();

            // Исправлено: LessonType -> LessonTypesComboBox, Discipline -> DisciplinesComboBox
            LessonTypesComboBox.SetBinding(ComboBox.ItemsSourceProperty,
                new Binding() { Source = new ObservableCollection<LessonTypesModel>(LessonTypesContext.LessonTypes) });
            DisciplinesComboBox.SetBinding(ComboBox.ItemsSourceProperty,
                new Binding() { Source = new ObservableCollection<DisciplinesModel>(DisciplinesContext.Disciplines) });
            DataContext = Model;
        }

        private void Acept(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                if (!IsUpdate) Context.DisciplinePrograms.Add(Model);
                Context.SaveChanges();
                GeneralPage.SwapPages(new DisciplineProgramsList());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Cancel(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            GeneralPage.SwapPages(new DisciplineProgramsList());
        }
    }
}