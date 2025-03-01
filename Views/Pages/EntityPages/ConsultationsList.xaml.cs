using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Windows.Controls;
using UP_02_Glebov_Drachev.Contexts;
using UP_02_Glebov_Drachev.Models;
using UP_02_Glebov_Drachev.Views.Elements;
using System.Collections.ObjectModel;

namespace UP_02_Glebov_Drachev.Views.Pages.EntityPages
{
    public partial class ConsultationsList : Page
    {
        ConsultationsContext context = new ConsultationsContext();
        public ConsultationsList()
        {
            InitializeComponent();
            var consultations = context.Consultations
                .Include(c => c.Discipline)
                .ToList();
            ObservableCollection<ConsultationsElement> elements = new ObservableCollection<ConsultationsElement>();
            foreach (ConsultationsModel model in consultations)
            {
                elements.Add(new ConsultationsElement(model, context));
            }
            List.ItemsSource = elements;
        }

    }
}
