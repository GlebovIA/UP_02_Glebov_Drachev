using System;
using System.Collections.Generic;
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

        private void OnMouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            BackButton.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 0, 96, 172));
        }

        private void OnMouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            BackButton.BorderBrush = Brushes.DarkGray;
        }

        public event MouseButtonEventHandler OnClick
        {
            add { BackButton.MouseLeftButtonDown += value; }
            remove { BackButton.MouseLeftButtonDown -= value; }
        }
    }
}
