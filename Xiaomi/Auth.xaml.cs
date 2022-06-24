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
using Xiaomi.Entities;

namespace Xiaomi
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Window
    {
        private group_1_is_31Context _dbContext = new group_1_is_31Context();
        private bool _isLogin = false;
        public static User CurrentUser;
        public Auth()
        {
            InitializeComponent();
        }

        private void Login_click(object sender, RoutedEventArgs e)
        {
            try
            {
                User user = _dbContext.Users.Where(
                    (usr) => usr.Login == LoginTextBox.Text && usr.Password == PasswordTextBox.Text
                    ).Single();
                MessageBox.Show($"Привет! СОЛНЫШКо хорошего тебе дня ");
                _isLogin = true;
                CurrentUser = user;
                Close();
            }
            catch
            {
                MessageBox.Show("Ошибка!", "Неверный логин или пароль");
            }
        }

        private void Window_closed(object sender, EventArgs e)
        {
            if (!_isLogin)
                App.Current.Shutdown();
        }
    }
}
