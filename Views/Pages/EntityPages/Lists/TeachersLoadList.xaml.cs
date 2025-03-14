using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using UP_02_Glebov_Drachev.Contexts;
using UP_02_Glebov_Drachev.Models;
using UP_02_Glebov_Drachev.Views.Elements;

namespace UP_02_Glebov_Drachev.Views.Pages.EntityPages.Lists
{
    public partial class TeachersLoadList : Page
    {
        TeachersLoadContext context = new TeachersLoadContext();

        public TeachersLoadList()
        {
            InitializeComponent();
            IEnumerable<TeachersLoadModel> teachersLoads = context.TeachersLoads
                .Include(tl => tl.Teacher)
                .Include(tl => tl.Discipline)
                .Include(tl => tl.StudGroup);
            ObservableCollection<TeachersLoadElement> elements = new ObservableCollection<TeachersLoadElement>();
            foreach (TeachersLoadModel model in teachersLoads)
            {
                elements.Add(new TeachersLoadElement(model, context));
            }
            List.ItemsSource = elements;
        }
    }
}