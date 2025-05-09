﻿using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using UP_02_Glebov_Drachev.Contexts;
using UP_02_Glebov_Drachev.Models;
using UP_02_Glebov_Drachev.Views.Elements;
using UP_02_Glebov_Drachev.Views.Pages.EntityPages.EditPages;

namespace UP_02_Glebov_Drachev.Views.Pages.EntityPages.Lists
{
    public partial class GroupsList : Page
    {
        private GroupsContext context = new GroupsContext();

        public GroupsList()
        {
            InitializeComponent();
            LoadGroups();
        }

        private void LoadGroups()
        {
            var groups = context.Groups.OrderBy(x => x.Name);
            ObservableCollection<GroupsElement> elements = new ObservableCollection<GroupsElement>();
            foreach (GroupsModel model in groups)
            {
                elements.Add(new GroupsElement(model, context));
            }
            List.ItemsSource = elements;
        }

        private void AddClick(object sender, MouseButtonEventArgs e)
        {
            GeneralPage.SwapPages(new GroupsPage(context));
        }
    }
}