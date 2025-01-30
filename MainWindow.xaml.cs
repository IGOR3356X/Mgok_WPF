using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using SteamDesktop.Context;
using SteamDesktop.Interfaces;
using SteamDesktop.Interfaces.Services;
using SteamDesktop.Models;
using SteamDesktop.RedisConnector;

namespace SteamDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IUserServices _userServices;
        private IRedisConnection _redisConnect;
        public MainWindow(IUserServices userServices, IRedisConnection redisConnect)
        {
            _userServices = userServices;
            _redisConnect = redisConnect;
            InitializeComponent();
        }

        private async void ButtonGey_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataGridGay.ItemsSource = await _userServices.GetAllAsync();
                //sb.Append($"Id = {baybay.Id}, TelephoneNumber= {baybay.TelephonNumber}, Name= {baybay.Name}, RoleId= {baybay.RoleId}, Name= {baybay.Username}");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private async void BtnGetRedis(object sender, RoutedEventArgs e)
        {
            // await _redisConnect.getConnection().StringSetAsync("myKey", "Hello, Redis!");
            var value = await _redisConnect.getConnection().StringGetAsync("myKey");
            MessageBox.Show(value);
        }
    }
}