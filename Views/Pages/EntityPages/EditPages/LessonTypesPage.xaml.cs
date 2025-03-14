using System.Windows;
using System.Windows.Controls;
using UP_02_Glebov_Drachev.Contexts;
using UP_02_Glebov_Drachev.Models;
using UP_02_Glebov_Drachev.Views.Pages.EntityPages.Lists;

namespace UP_02_Glebov_Drachev.Views.Pages.EntityPages.EditPages
{
    public partial class LessonTypesPage : Page
    {
        private LessonTypesContext Context { get; set; }
        private LessonTypesModel Model { get; set; }
        private bool IsUpdate = false;

        public LessonTypesPage(LessonTypesContext context, LessonTypesModel model = null)
        {
            InitializeComponent();
            Context = context;
            if (model != null)
            {
                Model = model;
                IsUpdate = true;
            }
            else
                Model = new LessonTypesModel();

            DataContext = Model;
        }

        private void Acept(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                if (!IsUpdate) Context.LessonTypes.Add(Model);
                Context.SaveChanges();
                GeneralPage.SwapPages(new LessonTypesList());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Cancel(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            GeneralPage.SwapPages(new LessonTypesList());
        }
    }
}