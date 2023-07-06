using Padutronics.Conversion.Converters;
using Padutronics.DependencyInjection;
using Padutronics.Gaming.Graphics;
using Padutronics.Gaming.Graphics.Resources.Brushes;
using Padutronics.Gaming.Graphics.Resources.Geometries;
using Padutronics.Gaming.Graphics.Resources.Pens;
using Padutronics.Gaming.Graphics.Resources.Text;
using Padutronics.Gaming.Inputs.Keyboards;
using Padutronics.Gaming.Windows.Conversion.Converters;
using Padutronics.Geometry;
using Padutronics.Mathematics.Matrices;
using Padutronics.Windows.Win32.Api.D2D1;
using Padutronics.Windows.Win32.Api.DCommon;
using Padutronics.Windows.Win32.Api.DWrite;
using Padutronics.Windows.Win32.Api.DxgiType;
using Padutronics.Windows.Win32.Api.WinUser;

namespace Padutronics.Gaming.Windows.DependencyInjection.Modules;

internal sealed class ConversionContainerModule : IContainerModule
{
    public void Load(IContainerBuilder containerBuilder)
    {
        RegisterConverter<CapStyle, D2D1_CAP_STYLE, CapStyleToD2D1_CAP_STYLEConverter>(containerBuilder);
        RegisterConverter<Color, D3DCOLORVALUE, ColorToD3DCOLORVALUEConverter>(containerBuilder);
        RegisterConverter<CombineMode, D2D1_COMBINE_MODE, CombineModeToD2D1_COMBINE_MODEConverter>(containerBuilder);
        RegisterConverter<DashStyle, D2D1_DASH_STYLE, DashStyleToD2D1_DASH_STYLEConverter>(containerBuilder);
        RegisterConverter<Ellipse<double>, D2D1_ELLIPSE, EllipseDoubleToD2D1_ELLIPSEConverter>(containerBuilder);
        RegisterConverter<FontStretch, DWRITE_FONT_STRETCH, FontStretchToDWRITE_FONT_STRETCHConverter>(containerBuilder);
        RegisterConverter<FontStyle, DWRITE_FONT_STYLE, FontStyleToDWRITE_FONT_STYLEConverter>(containerBuilder);
        RegisterConverter<FontWeight, DWRITE_FONT_WEIGHT, FontWeightToDWRITE_FONT_WEIGHTConverter>(containerBuilder);
        RegisterConverter<GradientSpreadMethod, D2D1_EXTEND_MODE, GradientSpreadMethodToD2D1_EXTEND_MODEConverter>(containerBuilder);
        RegisterConverter<LineJoin, D2D1_LINE_JOIN, LineJoinToD2D1_LINE_JOINConverter>(containerBuilder);
        RegisterConverter<Matrix3x2<double>, D2D_MATRIX_3X2_F, Matrix3x2DoubleToD2D_MATRIX_3X2_FConverter>(containerBuilder);
        RegisterConverter<Offset2<double>, D2D_POINT_2F, Offset2DoubleToD2D_POINT_2FConverter>(containerBuilder);
        RegisterConverter<Point2<double>, D2D_POINT_2F, Point2DoubleToD2D_POINT_2FConverter>(containerBuilder);
        RegisterConverter<Rectangle<double>, D2D_RECT_F, RectangleDoubleToD2D_RECT_FConverter>(containerBuilder);
        RegisterConverter<Size<double>, D2D_SIZE_F, SizeDoubleToD2D_SIZE_FConverter>(containerBuilder);
        RegisterConverter<TileMode, D2D1_EXTEND_MODE, TileModeToD2D1_EXTEND_MODEConverter>(containerBuilder);
        RegisterConverter<UniformRoundedRectangle<double>, D2D1_ROUNDED_RECT, UniformRoundedRectangleDoubleToD2D1_ROUNDED_RECTConverter>(containerBuilder);

        RegisterConverter<D3DCOLORVALUE, Color, D3DCOLORVALUEToColorConverter>(containerBuilder);
        RegisterConverter<D2D_MATRIX_3X2_F, Matrix3x2<double>, D2D_MATRIX_3X2_FToMatrix3x2DoubleConverter>(containerBuilder);
        RegisterConverter<VK, Key, VKToKeyConverter>(containerBuilder);
    }

    private void RegisterBidirectionalConverter<TFrom, TTo, TConverter>(IContainerBuilder containerBuilder)
        where TConverter : class, IBidirectionalConverter<TFrom, TTo>
    {
        containerBuilder.For<IBidirectionalConverter<TFrom, TTo>>().Use<TConverter>().InstancePerDependency();
    }

    private void RegisterConverter<TFrom, TTo, TConverter>(IContainerBuilder containerBuilder)
        where TConverter : class, IConverter<TFrom, TTo>
    {
        containerBuilder.For<IConverter<TFrom, TTo>>().Use<TConverter>().InstancePerDependency();
    }
}