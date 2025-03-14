using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using UP_02_Glebov_Drachev.Models;

namespace UP_02_Glebov_Drachev.Views.Controls
{
    /// <summary>
    /// Логика взаимодействия для TabElement.xaml
    /// </summary>
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
    }
}
