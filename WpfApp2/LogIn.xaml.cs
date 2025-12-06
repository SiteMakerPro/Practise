using Microsoft.Win32;
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
using System.Windows.Shapes;
using WpfApp2.Models;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        public LogIn()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Close();
        }

        private void loginInput_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (loginInput.Text == "Логин")
            {
                loginInput.Text = "";
            }
            if (passwordInput.Password == "")
            {
                passwordInput.Password = "Пароль";
            }
        }

        private void passwordInput_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (passwordInput.Password == "Пароль")
            {
                passwordInput.Password = "";
            }
            if (loginInput.Text == "")
            {
                loginInput.Text = "Логин";
            }
        }

        private void Border_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            string login = loginInput.Text.Trim();
            string password = passwordInput.Password;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите логин и пароль");
                return;
            }

            // Вызываем метод аутентификации из сервиса базы данных
            // DbService.AuthenticateUser проверяет логин/пароль в базе данных
            var user = DbService.AuthenticateUser(login, password);

            // Проверяем результат аутентификации
            if (user != null)
            {
                // Если пользователь найден (аутентификация успешна):

                // Открываем окно, соответствующее роли пользователя
                OpenRoleWindow(user);
                // скрываем, но не уничтожаем
                // Окно невидимо, но продолжает существовать в памяти
                // Можно вернуться к нему позже (например, при разлогине)
                this.Hide();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }
        private void OpenRoleWindow(users user)
        {
            Window roleWindow = null; // Переменная для хранения ссылки на окно

            // Определяем какое окно открыть на основе роли пользователя
            switch (user.IdR)
            {
                case 1:
                    // Для администратора открываем AdminWindow
                    roleWindow = new Admin(user);
                    break;

                case 3:
                    // Для редактора открываем EditorWindow
                    roleWindow = new PVZ(user);
                    break;

                default: // user или любая другая роль
                    // Для обычного пользователя открываем UserWindow
                    roleWindow = new User(user);
                    break;
            }

            // Если окно успешно создано
            if (roleWindow != null)
            {
                // Отображаем окно (не модально, позволяет работать с другими окнами)
                roleWindow.Show();

                // Подписываемся на событие закрытия окна роли
                roleWindow.Closed += (s, args) => this.Close();
                // Когда окно роли закрывается, закрывается и главное окно (и приложение)
                // Лямбда-выражение создает обработчик события, который вызывает Close() для MainWindow
            }
        }
    }
}
