using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using UP_02_Glebov_Drachev.Contexts;
using UP_02_Glebov_Drachev.Models;
using UP_02_Glebov_Drachev.Views.Elements;

namespace UP_02_Glebov_Drachev.Views.Pages.EntityPages
{
    /// <summary>
    /// Логика взаимодействия для ConsultationResultsList.xaml
    /// </summary>
    public partial class ConsultationResultsList : Page
    {
        ConsultationResultsContext context = new ConsultationResultsContext();
        public ConsultationResultsList()
        {
            InitializeComponent();
            IEnumerable<ConsultationResultsModel> consultations = context.ConsultationsResults.Include(a => a.Consultation)
                                  .ThenInclude(s => s.Discipline).ThenInclude(w => w.Teacher)
                                  .Include(a => a.Student);
            ObservableCollection<ConsultationResultsElement> elements = new ObservableCollection<ConsultationResultsElement>();
            foreach (ConsultationResultsModel model in consultations)
            {
                elements.Add(new ConsultationResultsElement(model, context));
            }
            List.ItemsSource = elements;
        }
    }
}
