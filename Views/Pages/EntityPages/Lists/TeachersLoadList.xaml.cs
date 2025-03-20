using Microsoft.EntityFrameworkCore;
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
    public partial class TeachersLoadList : Page
    {
        private TeachersLoadContext context = new TeachersLoadContext();

        public TeachersLoadList()
        {
            InitializeComponent();
            LoadTeachersLoads();
        }

        private void LoadTeachersLoads()
        {
            var teachersLoads = context.TeachersLoads
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

        private void AddClick(object sender, MouseButtonEventArgs e)
        {
            GeneralPage.SwapPages(new TeachersLoadPage(context));
        }
    }
}