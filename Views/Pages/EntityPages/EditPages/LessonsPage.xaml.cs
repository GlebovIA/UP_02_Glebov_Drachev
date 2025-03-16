using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using UP_02_Glebov_Drachev.Contexts;
using UP_02_Glebov_Drachev.Models;
using UP_02_Glebov_Drachev.Views.Pages.EntityPages.Lists;

namespace UP_02_Glebov_Drachev.Views.Pages.EntityPages.EditPages
{
    public partial class LessonsPage : Page
    {
        private LessonsContext Context { get; set; }
        private GroupsContext GroupsContext = new GroupsContext();
        private DisciplineProgramsContext DisciplineProgramsContext = new DisciplineProgramsContext();
        private LessonsModel Model { get; set; }
        private bool IsUpdate = false;

        public LessonsPage(LessonsContext context, LessonsModel model = null)
        {
            InitializeComponent();
            Context = context;
            if (model != null)
            {
                Model = model;
                IsUpdate = true;
            }
            else
                Model = new LessonsModel();

            GroupsComboBox.SetBinding(ComboBox.ItemsSourceProperty, new Binding() { Source = new ObservableCollection<GroupsModel>(GroupsContext.Groups) });
            DisciplineProgramsComboBox.SetBinding(ComboBox.ItemsSourceProperty, new Binding() { Source = new ObservableCollection<DisciplineProgramsModel>(DisciplineProgramsContext.DisciplinePrograms) });
            DataContext = Model;
        }

        private void Accept(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                if (!IsUpdate) Context.Lessons.Add(Model);
                Context.SaveChanges();
                GeneralPage.SwapPages(new LessonsList());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Cancel(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            GeneralPage.SwapPages(new LessonsList());
        }
    }
}