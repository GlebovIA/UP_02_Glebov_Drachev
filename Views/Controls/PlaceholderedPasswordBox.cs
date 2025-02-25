using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;

namespace UP_02_Glebov_Drachev.Views.Controls
{
    public class PlaceholderedPasswordBox : TextBox
    {
        private TextBlock _placeholderTextBlock;

        public static readonly DependencyProperty RealPasswordProperty =
            DependencyProperty.Register("RealPassword", typeof(string), typeof(PlaceholderedPasswordBox), new PropertyMetadata(string.Empty));

        public string RealPassword
        {
            get { return (string)GetValue(RealPasswordProperty); }
            set { SetValue(RealPasswordProperty, value); }
        }

        public PlaceholderedPasswordBox()
        {
            Loaded += OnLoaded;
            TextChanged += OnTextChanged;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            // Создаем TextBlock для placeholder'а
            _placeholderTextBlock = new TextBlock
            {
                Foreground = Brushes.Gray,
                FontSize = 16,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(12, 0, 0, 0),
                IsHitTestVisible = false
            };

            // Привязываем текст placeholder'а к свойству PlaceHolder
            var binding = new Binding("PlaceHolder")
            {
                Source = this
            };
            _placeholderTextBlock.SetBinding(TextBlock.TextProperty, binding);

            // Добавляем placeholder в AdornerLayer
            var adornerLayer = AdornerLayer.GetAdornerLayer(this);
            if (adornerLayer != null)
            {
                var adorner = new PlaceholderAdorner(this, _placeholderTextBlock);
                adornerLayer.Add(adorner);
            }

            // Обновляем видимость placeholder'а
            UpdatePlaceholderVisibility();
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
            if (Text.Length > RealPassword.Length)
            {
                // Добавляем новый символ в RealPassword
                RealPassword += Text[Text.Length - 1];
            }
            else if (Text.Length < RealPassword.Length)
            {
                // Удаляем последний символ из RealPassword
                RealPassword = RealPassword.Substring(0, Text.Length);
            }

            // Заменяем текст на звездочки
            Text = new string('*', Text.Length);

            // Устанавливаем курсор в конец текста
            CaretIndex = Text.Length;
        }

        private void UpdatePlaceholderVisibility()
        {
            if (_placeholderTextBlock != null)
            {
                _placeholderTextBlock.Visibility = string.IsNullOrEmpty(Text) ? Visibility.Visible : Visibility.Collapsed;
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