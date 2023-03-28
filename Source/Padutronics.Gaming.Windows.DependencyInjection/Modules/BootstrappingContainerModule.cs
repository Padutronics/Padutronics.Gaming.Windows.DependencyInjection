using Padutronics.DependencyInjection;
using Padutronics.Gaming.Bootstrapping;
using Padutronics.Gaming.Windows.Bootstrapping;

namespace Padutronics.Gaming.Windows.DependencyInjection.Modules;

internal sealed class BootstrappingContainerModule : IContainerModule
{
    public void Load(IContainerBuilder containerBuilder)
    {
        RegisterBootstrapper<RenderViewBootstrapper>(containerBuilder);
    }

    private void RegisterBootstrapper<TBootstrapper>(IContainerBuilder containerBuilder)
        where TBootstrapper : class, IBootstrapper
    {
        containerBuilder.For<IBootstrapper>().Use<TBootstrapper>().SingleInstance();
    }
}