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
        /// Обработчик кнопки «Зашифровать» – вызывает Rot13Cipher.Encrypt.
        /// </summary>
        private void EncryptButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string input = InputTextBox.Text;
                string output = Rot13Cipher.Encrypt(input);
                OutputTextBox.Text = output;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при шифровании: {ex.Message}", "Ошибка",
                                MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Обработчик кнопки «Расшифровать» – вызывает Rot13Cipher.Decrypt.
        /// </summary>
        private void DecryptButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string input = InputTextBox.Text;
                string output = Rot13Cipher.Decrypt(input);
                OutputTextBox.Text = output;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при расшифровании: {ex.Message}", "Ошибка",
                                MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}