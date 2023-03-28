using Padutronics.Conversion.Converters;
using Padutronics.DependencyInjection;
using Padutronics.Gaming.Graphics;
using Padutronics.Gaming.Graphics.Resources.Brushes;
using Padutronics.Gaming.Graphics.Resources.Geometries;
using Padutronics.Gaming.Graphics.Resources.Strokes;
using Padutronics.Gaming.Windows.Conversion.Converters;
using Padutronics.Geometry;
using Padutronics.Windows.Win32.Api.D2D1;
using Padutronics.Windows.Win32.Api.DxgiType;

namespace Padutronics.Gaming.Windows.DependencyInjection.Modules;

internal sealed class ConversionContainerModule : IContainerModule
{
    public void Load(IContainerBuilder containerBuilder)
    {
        RegisterConverter<CapStyle, D2D1_CAP_STYLE, CapStyleToD2D1_CAP_STYLEConverter>(containerBuilder);
        RegisterConverter<Color, D3DCOLORVALUE, ColorToD3DCOLORVALUEConverter>(containerBuilder);
        RegisterConverter<CombineMode, D2D1_COMBINE_MODE, CombineModeToD2D1_COMBINE_MODEConverter>(containerBuilder);
        RegisterConverter<DashStyle, D2D1_DASH_STYLE, DashStyleToD2D1_DASH_STYLEConverter>(containerBuilder);
        RegisterConverter<EllipseF, D2D1_ELLIPSE, EllipseFToD2D1_ELLIPSEConverter>(containerBuilder);
        RegisterConverter<ExtendMode, D2D1_EXTEND_MODE, ExtendModeToD2D1_EXTEND_MODEConverter>(containerBuilder);
    }

    private void RegisterConverter<TFrom, TTo, TConverter>(IContainerBuilder containerBuilder)
        where TConverter : class, IConverter<TFrom, TTo>
    {
        containerBuilder.For<IConverter<TFrom, TTo>>().Use<TConverter>().InstancePerDependency();
    }
}