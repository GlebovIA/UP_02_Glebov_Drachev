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

namespace UP_02_Glebov_Drachev.Views.Controls
{
    /// <summary>
    /// Логика взаимодействия для PlaceholderedPasswordBox.xaml
    /// </summary>
    public partial class PlaceholderedPasswordBox : Border
    {

        public static readonly DependencyProperty RealPasswordProperty =
            DependencyProperty.Register("RealPassword", typeof(string), typeof(PlaceholderedPasswordBox), new PropertyMetadata(string.Empty));

        public string RealPassword
        {
            get { return (string)GetValue(RealPasswordProperty); }
            set { SetValue(RealPasswordProperty, value); }
        }

        public PlaceholderedPasswordBox()
        {
            InitializeComponent();
            // Привязываем текст placeholder'а к свойству PlaceHolder
            var binding = new Binding("PlaceHolder")
            {
                Source = this
            };
            Placeholder.SetBinding(TextBlock.TextProperty, binding);

            // Добавляем placeholder в AdornerLayer
            var adornerLayer = AdornerLayer.GetAdornerLayer(this);
            if (adornerLayer != null)
            {
                var adorner = new PlaceholderAdorner(this, Placeholder);
                adornerLayer.Add(adorner);
            }
            UpdatePlaceholderVisibility();
            Password.TextChanged += OnTextChanged;
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            // Маскируем текст
            MaskText();

            // Обновляем видимость placeholder'а
            UpdatePlaceholderVisibility();
        }

        private void MaskText()
        {
            // Если текст изменился, обновляем RealPassword
            if (Password.Text.Length > RealPassword.Length)
            {
                // Добавляем новый символ в RealPassword
                RealPassword += Password.Text[Password.Text.Length - 1];
            }
            else if (Password.Text.Length < RealPassword.Length)
            {
                // Удаляем последний символ из RealPassword
                RealPassword = RealPassword.Substring(0, Password.Text.Length);
            }

            // Заменяем текст на звездочки
            Password.Text = new string('*', Password.Text.Length);

            // Устанавливаем курсор в конец текста
            Password.CaretIndex = Password.Text.Length;
        }

        private void UpdatePlaceholderVisibility()
        {
            if (Placeholder != null)
            {
                Placeholder.Visibility = string.IsNullOrEmpty(Password.Text) ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        // Свойство PlaceHolder
        public string PlaceHolder
        {
            get { return (string)GetValue(PlaceHolderProperty); }
            set { SetValue(PlaceHolderProperty, value); }
        }

        // Регистрация свойства зависимости PlaceHolder
        public static readonly DependencyProperty PlaceHolderProperty =
            DependencyProperty.Register("PlaceHolder", typeof(string), typeof(PlaceholderedPasswordBox), new PropertyMetadata(string.Empty));
    }

    // Класс для отображения placeholder'а в AdornerLayer
    public class PlaceholderAdorner : Adorner
    {
        private readonly TextBlock _placeholderTextBlock;

        public PlaceholderAdorner(UIElement adornedElement, TextBlock placeholderTextBlock)
            : base(adornedElement)
        {
            _placeholderTextBlock = placeholderTextBlock;
            AddVisualChild(_placeholderTextBlock);
        }

        protected override int VisualChildrenCount => 1;

        protected override Visual GetVisualChild(int index)
        {
            return _placeholderTextBlock;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            _placeholderTextBlock.Arrange(new Rect(finalSize));
            return finalSize;
        }
    }
}
