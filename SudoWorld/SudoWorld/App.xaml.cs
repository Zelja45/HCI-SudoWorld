using Microsoft.Extensions.DependencyInjection;
using SudoWorld.Services;
using SudoWorld.View;
using SudoWorld.ViewModel;
using SudoWorld.ViewModel.Core;
using System.Configuration;
using System.Data;
using System.Windows;

namespace SudoWorld
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ServiceProvider _serviceProvider;

        public App()
        {

            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<MainWindow>(provider => new MainWindow
            {
                DataContext = provider.GetRequiredService<MainViewModel>()
            });
           

            services.AddSingleton<MainViewModel>();
            services.AddSingleton<HomeViewModel>();
            services.AddSingleton<RegisterViewModel>();
            services.AddSingleton<SudokuGameViewModel>();
            services.AddSingleton<INavigationService, NavigationServices>();

            services.AddSingleton<Func<Type,BaseViewModel>>(provider=>viewModelType=>(BaseViewModel)provider.GetRequiredService(viewModelType));//function for getting specific viewmodel

            _serviceProvider =services.BuildServiceProvider();

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow= _serviceProvider.GetRequiredService<MainWindow>();
            _serviceProvider.GetRequiredService<INavigationService>().NavigateTo<HomeViewModel>();
            mainWindow.Show();
            base.OnStartup(e);

        }
    }

}
