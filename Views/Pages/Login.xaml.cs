using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static UP_02_Glebov_Drachev.MainWindow;

namespace UP_02_Glebov_Drachev.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private void ForgotPassword(object sender, MouseButtonEventArgs e)
        {

        }
        private void SignInClick(object sender, RoutedEventArgs e)
        {
            OpenPages(new GeneralPage());
        }
        private void RegInClick(object sender, MouseButtonEventArgs e)
        {

        }
        private void ButtonEnter(object sender, MouseEventArgs e)
        {

        }
        private void ButtonLeave(object sender, MouseEventArgs e)
        {

        }
    }
}
