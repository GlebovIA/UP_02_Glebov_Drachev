using System.Windows.Controls;
using System.Windows.Input;
using UP_02_Glebov_Drachev.Models;
using UP_02_Glebov_Drachev.Views.Pages;

namespace UP_02_Glebov_Drachev.Views.Elements
{
    public partial class DisciplinesElement : UserControl
    {
        public DisciplinesElement()
        {
            InitializeComponent();
        }

        private void RedacClick(object sender, MouseButtonEventArgs e)
        {
            GeneralPage.SwapPages(new DisciplinesPage(DataContext as DisciplinesModel));
        }

        private void DeleteClick(object sender, MouseButtonEventArgs e)
        {
            // Логика удаления дисциплины
        }
    }
}
