using System.Windows.Controls;
using System.Windows.Input;
using UP_02_Glebov_Drachev.Views.Pages;

namespace UP_02_Glebov_Drachev.Views.Elements
{
    /// <summary>
    /// Логика взаимодействия для AbsenceElement.xaml
    /// </summary>
    public partial class AbsencesElement : UserControl
    {
        public AbsencesElement()
        {
            InitializeComponent();
        }

        private void RedacClick(object sender, MouseButtonEventArgs e)
        {
            GeneralPage.SwapPages(new AbsencesPage());
        }

        private void DeleteClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
