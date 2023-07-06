using Padutronics.DependencyInjection;
using Padutronics.Gaming.Graphics;
using Padutronics.Gaming.Graphics.Resources;
using Padutronics.Gaming.Graphics.Resources.Brushes;
using Padutronics.Gaming.Graphics.Resources.Geometries;
using Padutronics.Gaming.Graphics.Resources.Text;
using Padutronics.Gaming.Windows.Graphics;
using Padutronics.Gaming.Windows.Graphics.Resources.Brushes;
using Padutronics.Gaming.Windows.Graphics.Resources.Geometries;
using Padutronics.Gaming.Windows.Graphics.Resources.Images;
using Padutronics.Gaming.Windows.Graphics.Resources.Pens;
using Padutronics.Gaming.Windows.Graphics.Resources.Text;

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

        containerBuilder.For<ITextMeasurer>().Use<TextMeasurer>().SingleInstance();

        RegisterNativeResource<BitmapResource>(containerBuilder);
        RegisterNativeResource<EllipseGeometryResource>(containerBuilder);
        RegisterNativeResource<ImageBrushResource>(containerBuilder);
        RegisterNativeResource<LinearGradientBrushResource>(containerBuilder);
        RegisterNativeResource<PathGeometryResource>(containerBuilder);
        RegisterNativeResource<PenResource>(containerBuilder);
        RegisterNativeResource<RadialGradientBrushResource>(containerBuilder);
        RegisterNativeResource<RectangleGeometryResource>(containerBuilder);
        RegisterNativeResource<RoundedRectangleGeometryResource>(containerBuilder);
        RegisterNativeResource<SolidColorBrushResource>(containerBuilder);
        RegisterNativeResource<TextFormatResource>(containerBuilder);

        RegisterNativeResourceFactory<IBrushResourceFactory>(containerBuilder);
        RegisterNativeResourceFactory<IGeometryResourceFactory>(containerBuilder);
        RegisterNativeResourceFactory<IImageResourceFactory>(containerBuilder);
        RegisterNativeResourceFactory<IPenResourceFactory>(containerBuilder);
        RegisterNativeResourceFactory<ITextFormatResourceFactory>(containerBuilder);

        RegisterResourceFactory<IBrushFactory, BrushFactory>(containerBuilder);
        RegisterResourceFactory<IGeometryFactory, GeometryFactory>(containerBuilder);
        RegisterResourceFactory<ITextFormatFactory, TextFormatFactory>(containerBuilder);
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