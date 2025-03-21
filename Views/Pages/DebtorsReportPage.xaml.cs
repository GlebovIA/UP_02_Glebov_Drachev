using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using UP_02_Glebov_Drachev.Reporting;

namespace UP_02_Glebov_Drachev.Views.Pages
{
    public partial class DebtorsReportPage : Page
    {
        public DebtorsReportPage()
        {
            InitializeComponent();
        }

        private void GenerateButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var generator = new DocumentGenerator();
            generator.GenerateAbsenceReport();
        }

        private void CancelButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService?.Navigate(new GeneralPage());
        }
    }
}