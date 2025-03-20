using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using UP_02_Glebov_Drachev.Contexts;
using UP_02_Glebov_Drachev.Models;
using UP_02_Glebov_Drachev.Views.Elements;
using UP_02_Glebov_Drachev.Views.Pages;
using UP_02_Glebov_Drachev.Views.Pages.EntityPages.EditPages;

namespace UP_02_Glebov_Drachev.Views.Pages.EntityPages.Lists
{
    public partial class LessonTypesList : Page
    {
        private LessonTypesContext context = new LessonTypesContext();

        public LessonTypesList()
        {
            InitializeComponent();
            LoadLessonTypes();
        }

        private void LoadLessonTypes()
        {
            var lessonTypes = context.LessonTypes;
            ObservableCollection<LessonTypesElement> elements = new ObservableCollection<LessonTypesElement>();
            foreach (LessonTypesModel model in lessonTypes)
            {
                elements.Add(new LessonTypesElement(model, context));
            }
            List.ItemsSource = elements;
        }

        private void AddClick(object sender, MouseButtonEventArgs e)
        {
            GeneralPage.SwapPages(new LessonTypesPage(context));
        }
    }
}