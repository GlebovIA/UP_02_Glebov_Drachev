using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace UP_02_Glebov_Drachev.Views.Controls
{
    public partial class RoundButton : Border
    {
        // Свойство для текста кнопки
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
        }

        private void OnMouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            BackButton.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 96, 172));
            BackButton.FontWeight = FontWeights.Bold;
            Background = new SolidColorBrush(Color.FromArgb(255, 193, 193, 193));
        }

        private void OnMouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            BackButton.Foreground = Brushes.White;
            BackButton.FontWeight = FontWeights.Normal;
            Background = new SolidColorBrush(Color.FromArgb(255, 228, 22, 19));
        }
    }
}