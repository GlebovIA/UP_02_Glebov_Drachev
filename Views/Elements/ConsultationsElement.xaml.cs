using System.Windows.Controls;
using System.Windows.Input;
using UP_02_Glebov_Drachev.Models;
using UP_02_Glebov_Drachev.Views.Pages;

namespace UP_02_Glebov_Drachev.Views.Elements
{
    public partial class ConsultationsElement : UserControl
    {
        public ConsultationsElement()
        {
            InitializeComponent();
        }

        private void RedacClick(object sender, MouseButtonEventArgs e)
        {
            GeneralPage.SwapPages(new ConsultationsPage(DataContext as ConsultationsModel));
        }

        private void DeleteClick(object sender, MouseButtonEventArgs e)
        {
            // Логика удаления консультации
        }
    }
}
