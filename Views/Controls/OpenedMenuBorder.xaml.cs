using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Media;
using System.Windows;
using System.Windows.Media.Imaging;

namespace UP_02_Glebov_Drachev.Views.Controls
{
    /// <summary>
    /// Логика взаимодействия для OpenedMenuBorder.xaml
    /// </summary>
    public partial class OpenedMenuBorder : Border
    {
        public event MouseButtonEventHandler OnClick
        {
            add { BackButton.MouseLeftButtonDown += value; }
            remove { BackButton.MouseLeftButtonDown -= value; }
        }
        public OpenedMenuBorder()
        {
            InitializeComponent();
            Image.Source = new BitmapImage(new Uri("pack://application:,,,/UP_02_Glebov_Drachev;component/Images/x.png", UriKind.RelativeOrAbsolute));
            BackButton.MouseEnter += OnMouseEnter;
            BackButton.MouseLeave += OnMouseLeave;
        }

        private void OnMouseEnter(object sender, MouseEventArgs e)
        {
            BackButton.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 0, 96, 172));
        }

        private void OnMouseLeave(object sender, MouseEventArgs e)
        {
            BackButton.BorderBrush = Brushes.DarkGray;
        }

        public static readonly RoutedEvent ClickEvent =
            EventManager.RegisterRoutedEvent("OnClick", RoutingStrategy.Bubble, typeof(Mouse), typeof(OpenedMenuBorder));
    }
}

