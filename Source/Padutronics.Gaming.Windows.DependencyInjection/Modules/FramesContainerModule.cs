using Padutronics.DependencyInjection;
using Padutronics.Gaming.Frames.Runners;
using Padutronics.Gaming.Windows.Frames.Runners;

namespace Padutronics.Gaming.Windows.DependencyInjection.Modules;

internal sealed class FramesContainerModule : IContainerModule
{
    public void Load(IContainerBuilder containerBuilder)
    {
        RegisterFrameRunner<MessagePumpFrameRunner>(containerBuilder);
    }

    private void RegisterFrameRunner<TFrameRunner>(IContainerBuilder containerBuilder)
        where TFrameRunner : class, IFrameRunner
    {
        containerBuilder.For<IFrameRunner>().Use<TFrameRunner>().SingleInstance();
    }
}