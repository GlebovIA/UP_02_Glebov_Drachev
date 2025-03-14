using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

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
            Background = new SolidColorBrush(Color.FromArgb(255, 230, 230, 230));
            DoubleAnimation widthAnimation = new DoubleAnimation(60, 70, TimeSpan.FromSeconds(0.2));
            BeginAnimation(Border.WidthProperty, widthAnimation);
        }

        private void OnMouseLeave(object sender, MouseEventArgs e)
        {
            Background = new SolidColorBrush(Color.FromArgb(255, 241, 241, 241));
            DoubleAnimation widthAnimation = new DoubleAnimation(70, 60, TimeSpan.FromSeconds(0.2));
            BeginAnimation(Border.WidthProperty, widthAnimation);
        }

        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            Background = new SolidColorBrush(Color.FromArgb(255, 200, 200, 200));
        }

        private void OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            Background = new SolidColorBrush(Color.FromArgb(255, 230, 230, 230));
        }
    }
}