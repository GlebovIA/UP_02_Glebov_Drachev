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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UP_02_Glebov_Drachev.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для GeneralPage.xaml
    /// </summary>
    public partial class GeneralPage : Page
    {
        public GeneralPage()
        {
            InitializeComponent();
            BurgerMenu.OnClick += (s, a) =>
            {
                BurgerMenu.Opacity = 0;
                DoubleAnimation borderAnimation = new DoubleAnimation();
                borderAnimation.From = OpenedMeny.ActualWidth;
                borderAnimation.To = 200;
                borderAnimation.Duration = TimeSpan.FromSeconds(0.1);
                OpenedMeny.BeginAnimation(Border.WidthProperty, borderAnimation);
            };
            OpenedMeny.OnClick += (s, a) =>
            {
                BurgerMenu.Opacity = 1;
                DoubleAnimation borderAnimation = new DoubleAnimation();
                borderAnimation.From = OpenedMeny.ActualWidth;
                borderAnimation.To = 0;
                borderAnimation.Duration = TimeSpan.FromSeconds(0.1);
                OpenedMeny.BeginAnimation(Border.WidthProperty, borderAnimation);
            };
        }
    }
}
