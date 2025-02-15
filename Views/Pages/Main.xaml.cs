using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using UP_02_Glebov_Drachev.Views.Elements;

namespace UP_02_Glebov_Drachev.Views.Pages
{
    public partial class Main : Page
    {
        public Main()
        {
            InitializeComponent();
        }

        // Обработчик события для прокрутки колесиком мыши
        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            var scrollViewer = sender as ScrollViewer;
            if (scrollViewer != null)
            {
                if (e.Delta > 0)
                {
                    scrollViewer.LineLeft(); // Прокрутка влево
                }
                else
                {
                    scrollViewer.LineRight(); // Прокрутка вправо
                }
                e.Handled = true; // Предотвращаем дальнейшую обработку события
            }
        }

        // Обработчики событий для вкладок
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