using Padutronics.DependencyInjection;
using Padutronics.Gaming.Inputs;
using Padutronics.Gaming.Inputs.Keyboards;
using Padutronics.Gaming.Inputs.Mouses;
using Padutronics.Gaming.Windows.Messages;

namespace Padutronics.Gaming.Windows.DependencyInjection.Modules;

internal sealed class MessagesContainerModule : IContainerModule
{
    public void Load(IContainerBuilder containerBuilder)
    {
        containerBuilder.For<IMessageHandler>().Use<DestroyMessageHandler>().SingleInstance();
        containerBuilder.For<IMessageHandler, IInputDeviceMonitor<KeyboardState>>().Use<KeyboardMessageHandler>().SingleInstance();
        containerBuilder.For<IMessageHandler, IInputDeviceMonitor<MouseState>>().Use<MouseMessageHandler>().SingleInstance();
    }
}