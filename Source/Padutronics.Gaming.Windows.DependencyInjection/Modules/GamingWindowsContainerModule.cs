using Padutronics.DependencyInjection;

namespace Padutronics.Gaming.Windows.DependencyInjection.Modules;

public sealed class GamingWindowsContainerModule : IContainerModule
{
    public void Load(IContainerBuilder containerBuilder)
    {
        containerBuilder
            .IncludeModule<BootstrappingContainerModule>()
            .IncludeModule<ConversionContainerModule>()
            .IncludeModule<FramesContainerModule>()
            .IncludeModule<GraphicsContainerModule>()
            .IncludeModule<MessagesContainerModule>();
    }
}