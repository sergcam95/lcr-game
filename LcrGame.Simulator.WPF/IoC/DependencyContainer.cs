using LcrGame.Simulator.Application.Interfaces;
using LcrGame.Simulator.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LcrGame.Simulator.WPF.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IRandomNumberGenerator, RandomNumberGenerator>();
            services.AddSingleton<ILcrGameSimulator, LcrGameSimulator>();
        }
    }
}
