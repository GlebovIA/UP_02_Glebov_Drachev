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
    public partial class ConsultationResultsList : Page
    {
        private ConsultationResultsContext context = new ConsultationResultsContext();

        public ConsultationResultsList()
        {
            InitializeComponent();
            LoadConsultationResults();
        }

        private void LoadConsultationResults()
        {
            var consultations = context.ConsultationsResults
                .Include(a => a.Consultation)
                .ThenInclude(s => s.Discipline)
                .ThenInclude(w => w.Teacher)
                .Include(a => a.Student);
            ObservableCollection<ConsultationResultsElement> elements = new ObservableCollection<ConsultationResultsElement>();
            foreach (ConsultationResultsModel model in consultations)
            {
                elements.Add(new ConsultationResultsElement(model, context));
            }
            List.ItemsSource = elements;
        }

        private void AddClick(object sender, MouseButtonEventArgs e)
        {
            GeneralPage.SwapPages(new ConsultationResultsPage(context));
        }
    }
}