using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using UP_02_Glebov_Drachev.Models;

namespace UP_02_Glebov_Drachev.Views.Controls
{
    public partial class TabElement : Border
    {
        private TabModel Model { get; set; }
        public MouseButtonEventHandler OnClick
        {
            set { MouseLeftButtonDown += value; }
        }

        public TabElement(TabModel model, MouseButtonEventHandler onClick)
        {
            InitializeComponent();
            Model = model;
            Title.Text = Model.Title;
            Title.ToolTip = Model.Content;
            MouseEnter += OnMouseEnter;
            MouseLeave += OnMouseLeave;
            OnClick = onClick;
        }

        private void OnMouseEnter(object sender, MouseEventArgs e)
        {
            Background = new SolidColorBrush(Color.FromArgb(255, 230, 230, 230));
            Title.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 79, 127));
            DoubleAnimation scaleAnimation = new DoubleAnimation(1, 1.02, TimeSpan.FromSeconds(0.2));
            BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnimation);
            BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnimation);
        }

        private void OnMouseLeave(object sender, MouseEventArgs e)
        {
            Background = Brushes.White;
            Title.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 96, 172));
            DoubleAnimation scaleAnimation = new DoubleAnimation(1.02, 1, TimeSpan.FromSeconds(0.2));
            BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnimation);
            BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnimation);
        }
    }
}