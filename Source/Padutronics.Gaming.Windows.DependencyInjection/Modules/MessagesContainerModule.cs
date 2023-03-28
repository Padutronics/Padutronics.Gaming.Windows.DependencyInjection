using Padutronics.DependencyInjection;
using Padutronics.Gaming.Windows.Messages;

namespace Padutronics.Gaming.Windows.DependencyInjection.Modules;

internal sealed class MessagesContainerModule : IContainerModule
{
    public void Load(IContainerBuilder containerBuilder)
    {
        containerBuilder.For<IMessageHandler>().Use<DestroyMessageHandler>().SingleInstance();
    }
}