using System.Collections.ObjectModel;
using System.Windows.Controls;
using UP_02_Glebov_Drachev.Contexts;
using UP_02_Glebov_Drachev.Models;
using UP_02_Glebov_Drachev.Views.Elements;

namespace UP_02_Glebov_Drachev.Views.Pages.EntityPages.Lists
{
    /// <summary>
    /// Логика взаимодействия для GroupsPage.xaml
    /// </summary>
    public partial class GroupsList : Page
    {
        GroupsContext context = new GroupsContext();
        public GroupsList()
        {
            InitializeComponent();
            IEnumerable<GroupsModel> groups = context.Groups;
            ObservableCollection<GroupsElement> elements = new ObservableCollection<GroupsElement>();
            foreach (GroupsModel model in groups)
            {
                elements.Add(new GroupsElement(model, context));
            }
            List.ItemsSource = elements;
        }
    }
}
