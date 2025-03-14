using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace UP_02_Glebov_Drachev.Views.Controls
{
    public partial class PlaceholderedTextBox : Border
    {
        public PlaceholderedTextBox()
        {
            InitializeComponent();
            TextBlock placetext = Placeholder;
            Binding placeholderBinding = new Binding("PlaceHolder") { Source = this };
            placetext.SetBinding(TextBlock.TextProperty, placeholderBinding);

            // Привязываем свойство TextBox.Text к свойству Text
            Binding textBinding = new Binding("Text") { Source = this, Mode = BindingMode.TwoWay, UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged };
            TextBox.SetBinding(TextBox.TextProperty, textBinding);

            TextBox.TextChanged += delegate
            {
                DoubleAnimation fadeAnimation = new DoubleAnimation(
                    string.IsNullOrWhiteSpace(TextBox.Text) ? 0 : 1,
                    string.IsNullOrWhiteSpace(TextBox.Text) ? 1 : 0,
                    TimeSpan.FromSeconds(0.2));
                placetext.BeginAnimation(OpacityProperty, fadeAnimation);
            };

            MouseEnter += (s, e) => BorderBrush = new SolidColorBrush(Color.FromArgb(255, 0, 96, 172));
            MouseLeave += (s, e) => BorderBrush = new SolidColorBrush(Color.FromArgb(255, 217, 217, 217));
        }

        // Свойство PlaceHolder
        public string PlaceHolder
        {
            get { return (string)GetValue(PlaceHolderProperty); }
            set { SetValue(PlaceHolderProperty, value); }
        }

        public static readonly DependencyProperty PlaceHolderProperty =
            DependencyProperty.Register("PlaceHolder", typeof(string), typeof(PlaceholderedTextBox), new PropertyMetadata(null));

        // Свойство Text
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(PlaceholderedTextBox), new PropertyMetadata(string.Empty));
    }
}