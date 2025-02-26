using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UP_02_Glebov_Drachev.Models;

namespace UP_02_Glebov_Drachev.Views.Controls
{
    /// <summary>
    /// Логика взаимодействия для TabElement.xaml
    /// </summary>
    public partial class TabElement : Border
    {
        private TabModel Model { get; set; }
        public TabElement(TabModel model)
        {
            InitializeComponent();
            Model = model;
            Title.Text = Model.Title;
            Title.ToolTip = Model.Content;
            MouseEnter += OnMouseEnter;
            MouseLeave += OnMouseLeave;

        }

        private void OnMouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Title.Foreground = new SolidColorBrush(Color.FromArgb(255, 228, 22, 19));
            Title.FontWeight = FontWeights.Bold;
            Background = new SolidColorBrush(Color.FromArgb(255, 193, 193, 193));
        }

        private void OnMouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Title.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 96, 172));
            Title.FontWeight = FontWeights.Normal;
            Background = Brushes.White;
        }
        private void ShowTabContent(object sender, MouseButtonEventArgs e)
        {
            // Отображаем данные для выбранной вкладки
            MessageBox.Show($"Содержимое вкладки {Model.Title}: {Model.Content}");
        }
    }
}
