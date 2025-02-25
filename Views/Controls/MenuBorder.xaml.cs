using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace UP_02_Glebov_Drachev.Views.Controls
{
    public partial class MenuBorder : Border
    {
        public event MouseButtonEventHandler OnClick
        {
            add { MouseLeftButtonDown += value; }
            remove { MouseLeftButtonDown -= value; }
        }
        public MenuBorder()
        {
            InitializeComponent();
            MouseEnter += OnMouseEnter;
            MouseLeave += OnMouseLeave;
            MouseLeftButtonDown += OnMouseDown;
            MouseLeftButtonUp += OnMouseUp;
        }

        private void OnMouseEnter(object sender, MouseEventArgs e)
        {
            DoubleAnimation borderAnimation = new DoubleAnimation();
            borderAnimation.From = ActualWidth;
            borderAnimation.To = 50;
            borderAnimation.Duration = TimeSpan.FromSeconds(0.1);
            BeginAnimation(Border.WidthProperty, borderAnimation);
        }

        private void OnMouseLeave(object sender, MouseEventArgs e)
        {
            DoubleAnimation borderAnimation = new DoubleAnimation();
            borderAnimation.From = ActualWidth;
            borderAnimation.To = 40;
            borderAnimation.Duration = TimeSpan.FromSeconds(0.1);
            BeginAnimation(Border.WidthProperty, borderAnimation);
        }

        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            Background = new SolidColorBrush(Colors.DarkGray);
        }

        private void OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            Background = new SolidColorBrush(Color.FromArgb(255, 193, 193, 193));
        }

        public static readonly RoutedEvent ClickEvent =
            EventManager.RegisterRoutedEvent("OnClick", RoutingStrategy.Bubble, typeof(Mouse), typeof(MenuBorder));
    }
}