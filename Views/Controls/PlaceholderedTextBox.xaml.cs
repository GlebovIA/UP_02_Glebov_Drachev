using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace UP_02_Glebov_Drachev.Views.Controls
{
    public partial class PlaceholderedTextBox : Border
    {
        public PlaceholderedTextBox()
        {
            InitializeComponent();
            TextBlock placetext = Placeholder;
            Binding bind = new Binding("PlaceHolder");
            bind.Source = this;
            placetext.SetBinding(TextBlock.TextProperty, bind);

            Text.TextChanged += delegate
            {
                placetext.Opacity = string.IsNullOrWhiteSpace(Text.Text) ? 1 : 0;
            };
        }

        public string PlaceHolder
        {
            get { return (string)GetValue(PlaceHolderProperty); }
            set { SetValue(PlaceHolderProperty, value); }
        }

        public static readonly DependencyProperty PlaceHolderProperty =
            DependencyProperty.Register("PlaceHolder", typeof(string), typeof(PlaceholderedTextBox), new PropertyMetadata(null));
    }
}