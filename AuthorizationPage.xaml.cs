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
using SteamDesktop.Interfaces.Services;

namespace SteamDesktop
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        private readonly IUserServices _userServices;
        public AuthorizationPage(IUserServices userServices)
        {
            _userServices = userServices;
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TxbLogin.Text) && !string.IsNullOrWhiteSpace(TxbPassword.Text))
            {

            }
            else
            {
                MessageBox.Show("Вы не ввели логин или пароль"
                    ,"Ошибка логина или пароля",MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }
    }
}
