using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace UP_02_Glebov_Drachev.Views.Controls
{
    public partial class RoundButton : Border
    {
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(RoundButton), new PropertyMetadata(string.Empty));

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public RoundButton()
        {
            InitializeComponent();
            MouseEnter += OnMouseEnter;
            MouseLeave += OnMouseLeave;
            MouseDown += OnMouseDown;
            MouseUp += OnMouseUp;
        }

        private void OnMouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Background = new SolidColorBrush(Color.FromArgb(255, 200, 20, 17)); // Темнее красного
            DoubleAnimation scaleAnimation = new DoubleAnimation(1, 1.05, TimeSpan.FromSeconds(0.2));
            BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnimation);
            BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnimation);
        }

        private void OnMouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Background = new SolidColorBrush(Color.FromArgb(255, 228, 22, 19));
            DoubleAnimation scaleAnimation = new DoubleAnimation(1.05, 1, TimeSpan.FromSeconds(0.2));
            BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnimation);
            BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnimation);
        }

        private void OnMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Background = new SolidColorBrush(Color.FromArgb(255, 180, 15, 13)); // Еще темнее при нажатии
        }

        private void OnMouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Background = new SolidColorBrush(Color.FromArgb(255, 200, 20, 17));
        }
    }
}