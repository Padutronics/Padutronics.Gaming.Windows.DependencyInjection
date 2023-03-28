using Padutronics.DependencyInjection;
using Padutronics.Gaming.Graphics;
using Padutronics.Gaming.Graphics.Resources;
using Padutronics.Gaming.Graphics.Resources.Brushes;
using Padutronics.Gaming.Windows.Graphics;
using Padutronics.Gaming.Windows.Graphics.Resources.Brushes;
using Padutronics.Gaming.Windows.Graphics.Resources.Geometries;
using Padutronics.Gaming.Windows.Graphics.Resources.Strokes;
using Padutronics.Gaming.Windows.Graphics.Resources.Text;
using Padutronics.Gaming.Windows.Graphics.Resources.Textures;

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
        RegisterNativeResource<LinearGradientBrushResource>(containerBuilder);
        RegisterNativeResource<RadialGradientBrushResource>(containerBuilder);
        RegisterNativeResource<SolidColorBrushResource>(containerBuilder);
        RegisterNativeResource<StrokeStyleResource>(containerBuilder);
        RegisterNativeResource<TextFormatResource>(containerBuilder);
        RegisterNativeResource<TextureResource>(containerBuilder);

        RegisterNativeResourceFactory<IBrushResourceFactory>(containerBuilder);
        RegisterNativeResourceFactory<IGeometryResourceFactory>(containerBuilder);
        RegisterNativeResourceFactory<IStrokeStyleResourceFactory>(containerBuilder);
        RegisterNativeResourceFactory<ITextFormatResourceFactory>(containerBuilder);
        RegisterNativeResourceFactory<ITextureResourceFactory>(containerBuilder);

        RegisterResourceFactory<IBrushFactory, BrushFactory>(containerBuilder);
    }

    private void RegisterNativeResource<TResource>(IContainerBuilder containerBuilder)
        where TResource : class, IResource
    {
        containerBuilder.For<TResource>().UseSelf().InstancePerDependency();
    }

    private void RegisterNativeResourceFactory<TFactory>(IContainerBuilder containerBuilder)
        where TFactory : class
    {
        containerBuilder.For<TFactory>().UseFactory();
    }

    private void RegisterResourceFactory<TFactoryInterface, TFactoryImplementation>(IContainerBuilder containerBuilder)
        where TFactoryInterface : class
        where TFactoryImplementation : class, TFactoryInterface
    {
        containerBuilder.For<TFactoryInterface>().Use<TFactoryImplementation>().SingleInstance();
    }
}