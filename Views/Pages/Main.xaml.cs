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
using UP_02_Glebov_Drachev.Views.Elements;

namespace UP_02_Glebov_Drachev.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Click_Absences(object sender, RoutedEventArgs e)
        {
            frame_main.Navigate(new AbsencesElement());
        }

        private void Click_Consultations(object sender, RoutedEventArgs e)
        {
            frame_main.Navigate(new ConsultationsElement());
        }

        private void Click_DisciplineProgramms(object sender, RoutedEventArgs e)
        {
            frame_main.Navigate(new DisciplineProgrammsElement());
        }

        private void Click_Disciplines(object sender, RoutedEventArgs e)
        {
            frame_main.Navigate(new DisciplinesElement());
        }

        private void Click_Groups(object sender, RoutedEventArgs e)
        {
            frame_main.Navigate(new GroupsElement());
        }

        private void Click_Marks(object sender, RoutedEventArgs e)
        {
            frame_main.Navigate(new MarksElement());
        }

        private void Click_Students(object sender, RoutedEventArgs e)
        {
            frame_main.Navigate(new StudentsElement());
        }

        private void Click_Teachers(object sender, RoutedEventArgs e)
        {
            frame_main.Navigate(new TeachersElement());
        }

        private void Click_TeachersLoad(object sender, RoutedEventArgs e)
        {
            frame_main.Navigate(new TeachersLoadElement());
        }
    }
}
