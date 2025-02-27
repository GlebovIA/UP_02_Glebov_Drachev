using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Windows.Controls;
using UP_02_Glebov_Drachev.Contexts;
using UP_02_Glebov_Drachev.Models;

namespace UP_02_Glebov_Drachev.Views.Pages.EntityPages
{
    public partial class ConsultationsList : Page
    {
        public ConsultationsList()
        {
            InitializeComponent();
            using (var consultationsContext = new ConsultationsContext())
            {
                var consultations = consultationsContext.Consultations
                    .Include(c => c.Discipline)
                    .ToList();
                List.ItemsSource = consultations;
            }
        }

    }
}
