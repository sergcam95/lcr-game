using LcrGame.Simulator.WPF.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace LcrGame.Simulator.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IServiceProvider serviceProvider = CreateServiceProvider();


            base.OnStartup(e);
        }

        private IServiceProvider CreateServiceProvider()
        {
            var services = new ServiceCollection();

            DependencyContainer.RegisterServices(services);

            return services.BuildServiceProvider();
        }
    }
}
