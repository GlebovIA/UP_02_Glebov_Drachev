﻿using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using UP_02_Glebov_Drachev.Contexts;
using UP_02_Glebov_Drachev.Models;
using UP_02_Glebov_Drachev.Views.Elements;

namespace UP_02_Glebov_Drachev.Views.Pages.EntityPages.Lists
{
    public partial class AbsencesList : Page
    {
        private AbsencesContext context = new AbsencesContext();

        public AbsencesList()
        {
            InitializeComponent();
            LoadAbsences();
        }

        private void LoadAbsences()
        {
            var absences = context.Absences
                .Include(a => a.Student)
                .ThenInclude(s => s.StudGroup)
                .Include(a => a.Discipline).OrderByDescending(x => x.Date);
            ObservableCollection<AbsencesElement> elements = new ObservableCollection<AbsencesElement>();
            foreach (AbsencesModel model in absences)
            {
                elements.Add(new AbsencesElement(model, context));
            }
            List.ItemsSource = elements;
        }

        private void AddClick(object sender, MouseButtonEventArgs e)
        {
            GeneralPage.SwapPages(new EntityPages.EditPages.AbsencesPage(context));
        }
    }
}