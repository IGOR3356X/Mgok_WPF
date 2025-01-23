using SteamDesktop.Contracts;
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
using SteamDesktop.Interfaces.Services;

namespace SteamDesktop
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        private readonly IUserServices _userServices;
        public AuthorizationWindow(IUserServices userServices)
        {
            _userServices = userServices;
            InitializeComponent();
        }

        private async void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TxbLogin.Text) && !string.IsNullOrWhiteSpace(TxbPassword.Text))
            {
                AuthorizationContract contract = new AuthorizationContract(TxbLogin.Text, TxbPassword.Text);
                bool isAuthorizeUser = await _userServices.AuthorizeUser(contract);
                if (isAuthorizeUser)
                {
                    MessageBox.Show("Вы успешно авторизовались"
                        , "Ура"
                        , MessageBoxButton.OK);
                    MainWindow main = new MainWindow(_userServices);
                    main.Show();
                }
                else
                {
                    MessageBox.Show("Вы ввели неправильный логин или пароль"
                        , "Ошибка авторизации"
                        , MessageBoxButton.OK
                        , MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Вы не ввели логин или пароль"
                    , "Ошибка логина или пароля", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }
    }
}
