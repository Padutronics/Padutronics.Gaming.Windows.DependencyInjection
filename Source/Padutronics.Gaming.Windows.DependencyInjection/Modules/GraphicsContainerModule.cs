using Padutronics.DependencyInjection;
using Padutronics.Gaming.Graphics;
using Padutronics.Gaming.Windows.Graphics;

namespace Padutronics.Gaming.Windows.DependencyInjection.Modules;

internal sealed class GraphicsContainerModule : IContainerModule
{
    public void Load(IContainerBuilder containerBuilder)
    {
        containerBuilder.For<IRenderPipeline>().Use<RenderPipeline>().SingleInstance();
    }
}