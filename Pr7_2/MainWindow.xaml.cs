using System;
using System.Windows;

namespace Rot13App
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик нажатия кнопки ROT13. Выполняет преобразование введённого текста.
        /// </summary>
        private void TransformButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string input = InputTextBox.Text;
                string output = Rot13Cipher.Encrypt(input);
                OutputTextBox.Text = output;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка",
                                MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}