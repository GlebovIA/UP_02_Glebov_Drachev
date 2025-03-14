using System.Collections.ObjectModel;
using System.Windows.Controls;
using UP_02_Glebov_Drachev.Contexts;
using UP_02_Glebov_Drachev.Models;
using UP_02_Glebov_Drachev.Views.Elements;

namespace UP_02_Glebov_Drachev.Views.Pages.EntityPages.Lists
{
    public partial class LessonTypesList : Page
    {
        LessonTypesContext context = new LessonTypesContext();

        public LessonTypesList()
        {
            InitializeComponent();
            IEnumerable<LessonTypesModel> lessonTypes = context.LessonTypes;
            ObservableCollection<LessonTypesElement> elements = new ObservableCollection<LessonTypesElement>();
            foreach (LessonTypesModel model in lessonTypes)
            {
                elements.Add(new LessonTypesElement(model, context));
            }
            List.ItemsSource = elements;
        }
    }
}