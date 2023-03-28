using Padutronics.Conversion.Converters;
using Padutronics.DependencyInjection;
using Padutronics.Gaming.Graphics;
using Padutronics.Gaming.Graphics.Resources.Brushes;
using Padutronics.Gaming.Graphics.Resources.Geometries;
using Padutronics.Gaming.Graphics.Resources.Strokes;
using Padutronics.Gaming.Graphics.Resources.Text;
using Padutronics.Gaming.Windows.Conversion.Converters;
using Padutronics.Geometry;
using Padutronics.Mathematics.Matrices;
using Padutronics.Windows.Win32.Api.D2D1;
using Padutronics.Windows.Win32.Api.DCommon;
using Padutronics.Windows.Win32.Api.DWrite;
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
        RegisterConverter<FontStretch, DWRITE_FONT_STRETCH, FontStretchToDWRITE_FONT_STRETCHConverter>(containerBuilder);
        RegisterConverter<FontStyle, DWRITE_FONT_STYLE, FontStyleToDWRITE_FONT_STYLEConverter>(containerBuilder);
        RegisterConverter<FontWeight, DWRITE_FONT_WEIGHT, FontWeightToDWRITE_FONT_WEIGHTConverter>(containerBuilder);
        RegisterConverter<LineJoin, D2D1_LINE_JOIN, LineJoinToD2D1_LINE_JOINConverter>(containerBuilder);
        RegisterConverter<Matrix3x2F, D2D_MATRIX_3X2_F, Matrix3x2FToD2D_MATRIX_3X2_FConverter>(containerBuilder);
        RegisterConverter<Offset2F, D2D_POINT_2F, Offset2FToD2D_POINT_2FConverter>(containerBuilder);
        RegisterConverter<Point2F, D2D_POINT_2F, Point2FToD2D_POINT_2FConverter>(containerBuilder);
        RegisterConverter<RectangleF, D2D_RECT_F, RectangleFToD2D_RECT_FConverter>(containerBuilder);
    }

    private void RegisterConverter<TFrom, TTo, TConverter>(IContainerBuilder containerBuilder)
        where TConverter : class, IConverter<TFrom, TTo>
    {
        containerBuilder.For<IConverter<TFrom, TTo>>().Use<TConverter>().InstancePerDependency();
    }
}