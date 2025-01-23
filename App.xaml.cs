using Microsoft.Extensions.DependencyInjection;
using System;
using System.Configuration;
using System.Data;
using System.Runtime.CompilerServices;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.UserSecrets;
using SteamDesktop.Context;
using SteamDesktop.Contracts;
using SteamDesktop.Interfaces;
using SteamDesktop.Interfaces.Services;
using SteamDesktop.Reposiotory;
using SteamDesktop.Services;

namespace SteamDesktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IServiceProvider _serviceProvider;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Настройка конфигурации
            var configuration = new ConfigurationBuilder()
                .AddUserSecrets<App>()
                .Build();

            // Настройка DI контейнера
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection, configuration);
            _serviceProvider = serviceCollection.BuildServiceProvider();

            // Запуск главного окна
            var mainWindow = _serviceProvider.GetRequiredService<AuthorizationWindow>();
            mainWindow.Show();
        }

        private void ConfigureServices(ServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<WpfContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            services.AddScoped<IUserServices, UserServices>();
            services.AddSingleton<MainWindow>();
            services.AddSingleton<AuthorizationWindow>();
        }
    }
}
