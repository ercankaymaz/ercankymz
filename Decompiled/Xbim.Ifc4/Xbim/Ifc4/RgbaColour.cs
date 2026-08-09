using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4;

public struct RgbaColour
{
	public double Red { get; set; }

	public double Green { get; set; }

	public double Blue { get; set; }

	public double Alpha { get; set; }

	public static RgbaColour Empty { get; private set; }

	public RgbaColour(double r, double g, double b, double a)
	{
		this = default(RgbaColour);
		Red = r;
		Green = g;
		Blue = b;
		Alpha = a;
	}

	public RgbaColour(IIfcColourRgb colour, IfcNormalisedRatioMeasure? transparency = null)
	{
		this = default(RgbaColour);
		Red = colour.Red;
		Green = colour.Green;
		Blue = colour.Blue;
		Alpha = 1.0 - (double)(transparency ?? ((IfcNormalisedRatioMeasure)0.0));
	}

	static RgbaColour()
	{
		Empty = default(RgbaColour);
	}

	public static RgbaColour operator *(RgbaColour rgba, double ratio)
	{
		return new RgbaColour(rgba.Red * ratio, rgba.Green * ratio, rgba.Blue * ratio, rgba.Alpha);
	}
}
