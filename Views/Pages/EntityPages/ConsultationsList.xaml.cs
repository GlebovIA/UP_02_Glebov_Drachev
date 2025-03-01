using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using UP_02_Glebov_Drachev.Contexts;
using UP_02_Glebov_Drachev.Models;
using UP_02_Glebov_Drachev.Views.Elements;

namespace UP_02_Glebov_Drachev.Views.Pages.EntityPages
{
    public partial class ConsultationsList : Page
    {
        private ConsultationsContext _context = new ConsultationsContext();

        public ConsultationsList()
        {
            InitializeComponent();

            var consultations = _context.Consultations
                                        .Include(c => c.Discipline)
                                        .ToList();

            ObservableCollection<ConsultationsElement> elements = new ObservableCollection<ConsultationsElement>();
            foreach (var consultation in consultations)
            {
                elements.Add(new ConsultationsElement(consultation, _context));
            }

            List.ItemsSource = elements;
        }
    }
}
