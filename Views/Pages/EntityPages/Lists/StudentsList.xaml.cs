﻿using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using UP_02_Glebov_Drachev.Contexts;
using UP_02_Glebov_Drachev.Models;
using UP_02_Glebov_Drachev.Views.Elements;
using UP_02_Glebov_Drachev.Views.Pages.EntityPages.EditPages;

namespace UP_02_Glebov_Drachev.Views.Pages.EntityPages.Lists
{
    public partial class StudentsList : Page
    {
        private StudentsContext context = new StudentsContext();

        public StudentsList()
        {
            InitializeComponent();
            LoadStudents();
        }

        private void LoadStudents()
        {
            var students = context.Students.Include(a => a.StudGroup).OrderBy(x => x.Surname);
            ObservableCollection<StudentsElement> elements = new ObservableCollection<StudentsElement>();
            foreach (StudentsModel model in students)
            {
                elements.Add(new StudentsElement(model, context));
            }
            List.ItemsSource = elements;
        }

        private void AddClick(object sender, MouseButtonEventArgs e)
        {
            GeneralPage.SwapPages(new StudentsPage(context));
        }
    }
}