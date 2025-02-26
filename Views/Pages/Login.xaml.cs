using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using UP_02_Glebov_Drachev.Classes;

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
        private void SignInClick(object sender, MouseButtonEventArgs e)
        {
            if (!string.IsNullOrEmpty(LoginTextBox.Text.Text) || !string.IsNullOrEmpty(PasswordTextBox.RealPassword))
            {
                if (DBConnection.CreateConnection(LoginTextBox.Text.Text, PasswordTextBox.RealPassword) == null)
                {
                    return;
                }
                else
                {
                    MainWindow.OpenPages(new Pages.GeneralPage());
                }
            }
            else
            {
                MessageBox.Show("Поля логин и пароль должны быть заполнены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void RegInClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
