using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UP_02_Glebov_Drachev.Views.Elements;
using UP_02_Glebov_Drachev.Views.Pages;

namespace UP_02_Glebov_Drachev
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Click_Main();
        }

        private void Click_Main()
        {
            frame_main.Navigate(new Main());
        }
    }
}