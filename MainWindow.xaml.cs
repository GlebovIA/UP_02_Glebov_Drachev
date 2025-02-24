using System.Windows;
using System.Windows.Controls;
using UP_02_Glebov_Drachev.Views.Pages;

namespace UP_02_Glebov_Drachev
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Frame MainFrame; 
        public MainWindow()
        {
            InitializeComponent();
            MainFrame = frame_main;
            OpenPages(new Login());
        }

        public static void OpenPages(Page page)
        {
            MainFrame.Navigate(page);
        }
    }
}