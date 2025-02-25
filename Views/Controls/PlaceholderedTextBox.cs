using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace UP_02_Glebov_Drachev.Views.Controls
{
    public class PlaceholderedTextBox : TextBox
    {
        public PlaceholderedTextBox()
        {
            Loaded += delegate
            {
                TextBlock placetext = new TextBlock() { Foreground = SystemColors.GrayTextBrush, Margin = new Thickness(2,0,0,0) };
                Binding bind = new Binding("PlaceHolder");
                bind.Source = this;
                placetext.SetBinding(TextBlock.TextProperty, bind);

                ContentControl? host = Template.FindName("PART_ContentHost", this) as ContentControl;
                FrameworkElement? tbw = host?.Content as FrameworkElement;

                Grid grid = new Grid();
#pragma warning disable CS8602
                host.Content = grid;
#pragma warning restore CS8602
                grid.Children.Add(placetext);
                grid.Children.Add(tbw);

                this.TextChanged += delegate
                {
                    placetext.Opacity = string.IsNullOrWhiteSpace(Text) ? 1 : 0;
                };
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