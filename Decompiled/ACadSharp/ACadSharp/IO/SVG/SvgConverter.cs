using System.ComponentModel;
using System.Globalization;
using ACadSharp.Types.Units;
using CSMath;

namespace ACadSharp.IO.SVG;

internal static class SvgConverter
{
	public static string ToSvg(this double value)
	{
		return value.ToString(CultureInfo.InvariantCulture);
	}

	public static string ToSvg(this double value, UnitsType units)
	{
		string text = string.Empty;
		switch (units)
		{
		case UnitsType.Centimeters:
			text = "cm";
			break;
		case UnitsType.Millimeters:
			text = "mm";
			break;
		case UnitsType.Inches:
			text = "in";
			break;
		}
		return value.ToString(CultureInfo.InvariantCulture) + text;
	}

	public static string ToSvg<T>(this T vector) where T : IVector
	{
		return vector[0].ToSvg() + "," + vector[1].ToSvg();
	}

	public static string ToSvg<T>(this T vector, UnitsType units) where T : IVector
	{
		return vector[0].ToSvg(units) + "," + vector[1].ToSvg(units);
	}

	public static double ToPixelSize(this double value, UnitsType units)
	{
		return units switch
		{
			UnitsType.Inches => value * 96.0, 
			UnitsType.Millimeters => value * 96.0 / 25.4, 
			UnitsType.Unitless => value, 
			_ => throw new InvalidEnumArgumentException("units", (int)units, units.GetType()), 
		};
	}

	public static T ToPixelSize<T>(this T value, UnitsType units) where T : IVector
	{
		for (int i = 0; i < value.Dimension; i++)
		{
			value[i] = value[i].ToPixelSize(units);
		}
		return value;
	}
}
