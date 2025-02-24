using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace UP_02_Glebov_Drachev.Views.Дерьмо
{
    public partial class RoundButton : Border
    {
        // Свойство для текста кнопки
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(RoundButton), new PropertyMetadata(string.Empty));

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Событие Click
        public event RoutedEventHandler OnClick
        {
            add { BackButton.Click += value; }
            remove { BackButton.Click -= value; }
        }

        // Событие MouseEnter
        public event MouseEventHandler OnEnter
        {
            add { BackButton.MouseEnter += value; }
            remove { BackButton.MouseEnter -= value; }
        }

        // Событие MouseLeave
        public event MouseEventHandler OnLeave
        {
            add { BackButton.MouseLeave += value; }
            remove { BackButton.MouseLeave -= value; }
        }

        public RoundButton()
        {
            InitializeComponent();
        }

        // Обработчик нажатия на кнопку
        private void Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(ClickEvent, this));
        }

        // Обработчик наведения мыши
        private void MouseEnterHandler(object sender, MouseEventArgs e)
        {
            RaiseEvent(new MouseEventArgs(Mouse.PrimaryDevice, e.Timestamp) { RoutedEvent = EnterEvent });
        }

        // Обработчик вывода мыши
        private void MouseLeaveHandler(object sender, MouseEventArgs e)
        {
            RaiseEvent(new MouseEventArgs(Mouse.PrimaryDevice, e.Timestamp) { RoutedEvent = LeaveEvent });
        }

        // Регистрация события Click
        public static readonly RoutedEvent ClickEvent =
            EventManager.RegisterRoutedEvent("OnClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(RoundButton));

        // Регистрация события MouseEnter
        public static readonly RoutedEvent EnterEvent =
            EventManager.RegisterRoutedEvent("OnEnter", RoutingStrategy.Bubble, typeof(MouseEventHandler), typeof(RoundButton));

        // Регистрация события MouseLeave
        public static readonly RoutedEvent LeaveEvent =
            EventManager.RegisterRoutedEvent("OnLeave", RoutingStrategy.Bubble, typeof(MouseEventHandler), typeof(RoundButton));
    }
}