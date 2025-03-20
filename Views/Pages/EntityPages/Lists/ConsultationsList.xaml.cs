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
    public partial class ConsultationsList : Page
    {
        private ConsultationsContext context = new ConsultationsContext();

        public ConsultationsList()
        {
            InitializeComponent();
            LoadConsultations();
        }

        private void LoadConsultations()
        {
            var consultations = context.Consultations
                .Include(c => c.Discipline);
            ObservableCollection<ConsultationsElement> elements = new ObservableCollection<ConsultationsElement>();
            foreach (var consultation in consultations)
            {
                elements.Add(new ConsultationsElement(consultation, context));
            }
            List.ItemsSource = elements;
        }

        private void AddClick(object sender, MouseButtonEventArgs e)
        {
            GeneralPage.SwapPages(new ConsultationsPage(context));
        }
    }
}