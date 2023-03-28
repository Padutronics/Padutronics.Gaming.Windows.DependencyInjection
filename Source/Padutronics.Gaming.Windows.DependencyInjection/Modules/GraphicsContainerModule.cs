using Padutronics.DependencyInjection;
using Padutronics.Gaming.Graphics;
using Padutronics.Gaming.Graphics.Resources;
using Padutronics.Gaming.Windows.Graphics;
using Padutronics.Gaming.Windows.Graphics.Resources.Brushes;
using Padutronics.Gaming.Windows.Graphics.Resources.Geometries;

namespace Padutronics.Gaming.Windows.DependencyInjection.Modules;

internal sealed class GraphicsContainerModule : IContainerModule
{
    public void Load(IContainerBuilder containerBuilder)
    {
        containerBuilder.For<IRenderPipeline>().Use<RenderPipeline>().SingleInstance();
        containerBuilder.For<IRenderView, IRenderViewInitializer, IWindowHandleProvider>().Use<RenderView>().SingleInstance();
        containerBuilder.For<IRenderer>().Use<Renderer>().SingleInstance();

        containerBuilder.For<IDeviceFactoryProvider>().Use<DeviceFactoryProvider>().SingleInstance();
        containerBuilder.For<IDeviceResourceProvider, ISwapChainPresenter>().Use<DeviceResourceProvider>().SingleInstance();

        RegisterNativeResource<BitmapBrushResource>(containerBuilder);
        RegisterNativeResource<GeometryResource>(containerBuilder);
    }

    private void RegisterNativeResource<TResource>(IContainerBuilder containerBuilder)
        where TResource : class, IResource
    {
        containerBuilder.For<TResource>().UseSelf().InstancePerDependency();
    }
}