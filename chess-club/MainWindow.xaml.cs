using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace chess_club
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
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            string lastName = LastNameTextBox.Text;
            string firstName = FirstNameTextBox.Text;
            string middleName = MiddleNameTextBox.Text;
            string birthDate = BirthDatePicker.SelectedDate?.ToString("dd.MM.yyyy") ?? string.Empty;
            string address = AddressTextBox.Text;
            string phone = PhoneTextBox.Text;

            if (!string.IsNullOrWhiteSpace(lastName) &&
                !string.IsNullOrWhiteSpace(firstName) &&
                !string.IsNullOrWhiteSpace(middleName) &&
                !string.IsNullOrWhiteSpace(birthDate) &&
                !string.IsNullOrWhiteSpace(address) &&
                !string.IsNullOrWhiteSpace(phone))
            {
                MessageBox.Show($"Членство оформлено!\n\nФИО: {lastName} {firstName} {middleName}\nДата рождения: {birthDate}\nАдрес: {address}\nТелефон: {phone}", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                LastNameTextBox.Clear();
                FirstNameTextBox.Clear();
                MiddleNameTextBox.Clear();
                BirthDatePicker.SelectedDate = null; // Сброс даты
                AddressTextBox.Clear();
                PhoneTextBox.Clear();
            } else
            {
                MessageBox.Show("введите корректые данные");
            }
        }

        private void PhoneTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Проверка, что вводимые символы - это цифры
            e.Handled = !Regex.IsMatch(e.Text, @"^[0-9]+$");
        }

        private void PhoneTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            // Разрешить клавиши Backspace и Delete
            if (e.Key == Key.Back || e.Key == Key.Delete)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = !Regex.IsMatch(e.Key.ToString(), @"^D[0-9]$");
            }
        }
    }
}
