﻿using System.Windows.Controls;
using System.Windows.Input;
using UP_02_Glebov_Drachev.Contexts;
using UP_02_Glebov_Drachev.Models;
using UP_02_Glebov_Drachev.Views.Pages;
using UP_02_Glebov_Drachev.Views.Pages.EntityPages.EditPages;
using UP_02_Glebov_Drachev.Views.Pages.EntityPages.Lists;

namespace UP_02_Glebov_Drachev.Views.Elements
{
    public partial class TeachersElement : UserControl
    {
        public TeachersModel Model { get; set; }
        public TeachersContext Context { get; set; }

        public TeachersElement(TeachersModel model, TeachersContext context)
        {
            InitializeComponent();
            Model = model;
            Context = context;
            DataContext = Model;
        }

        private void RedacClick(object sender, MouseButtonEventArgs e)
        {
            GeneralPage.SwapPages(new TeachersPage(Context, Model));
        }

        private void DeleteClick(object sender, MouseButtonEventArgs e)
        {
            Context.Remove(Model);
            GeneralPage.SwapPages(new TeachersList());
        }
    }
}