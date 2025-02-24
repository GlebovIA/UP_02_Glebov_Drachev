using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace UP_02_Glebov_Drachev.Views.Дерьмо
{
    public partial class MenuBorder : Border
    {
        public MenuBorder()
        {
            MouseEnter += OnMouseEnter;
            MouseLeave += OnMouseLeave;
            MouseLeftButtonDown += OnMouseDown;

        }

        private void OnMouseEnter(object sender, MouseEventArgs e)
        {
            Width = 50;
            Cursor = Cursors.Hand;
        }

        private void OnMouseLeave(object sender, MouseEventArgs e)
        {
            Width = 40;
            Cursor = Cursors.Arrow;
        }

        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            Background = new SolidColorBrush(Colors.DarkGray);
        }
    }
}