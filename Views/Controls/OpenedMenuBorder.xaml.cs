using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace UP_02_Glebov_Drachev.Views.Controls
{
    public partial class OpenedMenuBorder : Border
    {
        private ListView tabParent { get; set; }

        public OpenedMenuBorder()
        {
            InitializeComponent();
            tabParent = TabParent;
            BackButton.MouseEnter += OnMouseEnter;
            BackButton.MouseLeave += OnMouseLeave;
        }

        public void SetItems(ObservableCollection<TabElement> Items)
        {
            tabParent.ItemsSource = Items;
        }

        private void OnMouseEnter(object sender, MouseEventArgs e)
        {
            BackButton.Background = new SolidColorBrush(Color.FromArgb(255, 0, 79, 127));
        }

        private void OnMouseLeave(object sender, MouseEventArgs e)
        {
            BackButton.Background = new SolidColorBrush(Color.FromArgb(255, 0, 96, 172));
        }

        public event MouseButtonEventHandler OnClick
        {
            add { BackButton.MouseLeftButtonDown += value; }
            remove { BackButton.MouseLeftButtonDown -= value; }
        }
    }
}