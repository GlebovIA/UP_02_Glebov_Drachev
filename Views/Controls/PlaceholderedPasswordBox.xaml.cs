using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace UP_02_Glebov_Drachev.Views.Controls
{
    public partial class PlaceholderedPasswordBox : Border
    {
        public static readonly DependencyProperty RealPasswordProperty =
            DependencyProperty.Register("RealPassword", typeof(string), typeof(PlaceholderedPasswordBox), new PropertyMetadata(string.Empty));

        public string RealPassword
        {
            get { return (string)GetValue(RealPasswordProperty); }
            set { SetValue(RealPasswordProperty, value); }
        }

        public PlaceholderedPasswordBox()
        {
            InitializeComponent();
            var binding = new Binding("PlaceHolder") { Source = this };
            Placeholder.SetBinding(TextBlock.TextProperty, binding);

            var adornerLayer = AdornerLayer.GetAdornerLayer(this);
            if (adornerLayer != null)
            {
                var adorner = new PlaceholderAdorner(this, Placeholder);
                adornerLayer.Add(adorner);
            }
            UpdatePlaceholderVisibility();
            Password.TextChanged += OnTextChanged;

            MouseEnter += (s, e) => BorderBrush = new SolidColorBrush(Color.FromArgb(255, 0, 96, 172));
            MouseLeave += (s, e) => BorderBrush = new SolidColorBrush(Color.FromArgb(255, 217, 217, 217));
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            MaskText();
            UpdatePlaceholderVisibility();
        }

        private void MaskText()
        {
            if (Password.Text.Length > RealPassword.Length)
                RealPassword += Password.Text[Password.Text.Length - 1];
            else if (Password.Text.Length < RealPassword.Length)
                RealPassword = RealPassword.Substring(0, Password.Text.Length);

            Password.Text = new string('*', Password.Text.Length);
            Password.CaretIndex = Password.Text.Length;
        }

        private void UpdatePlaceholderVisibility()
        {
            if (Placeholder != null)
            {
                DoubleAnimation fadeAnimation = new DoubleAnimation(string.IsNullOrEmpty(Password.Text) ? 0 : 1, string.IsNullOrEmpty(Password.Text) ? 1 : 0, TimeSpan.FromSeconds(0.2));
                Placeholder.BeginAnimation(OpacityProperty, fadeAnimation);
            }
        }

        public string PlaceHolder
        {
            get { return (string)GetValue(PlaceHolderProperty); }
            set { SetValue(PlaceHolderProperty, value); }
        }

        public static readonly DependencyProperty PlaceHolderProperty =
            DependencyProperty.Register("PlaceHolder", typeof(string), typeof(PlaceholderedPasswordBox), new PropertyMetadata(string.Empty));

        public class PlaceholderAdorner : Adorner
        {
            private readonly TextBlock _placeholderTextBlock;

            public PlaceholderAdorner(UIElement adornedElement, TextBlock placeholderTextBlock) : base(adornedElement)
            {
                _placeholderTextBlock = placeholderTextBlock;
                AddVisualChild(_placeholderTextBlock);
            }

            protected override int VisualChildrenCount => 1;

            protected override Visual GetVisualChild(int index) => _placeholderTextBlock;

            protected override Size ArrangeOverride(Size finalSize)
            {
                _placeholderTextBlock.Arrange(new Rect(finalSize));
                return finalSize;
            }
        }
    }
}