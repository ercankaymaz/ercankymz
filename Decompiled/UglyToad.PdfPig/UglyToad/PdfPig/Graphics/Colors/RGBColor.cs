using System;
using System.Collections.Generic;

namespace UglyToad.PdfPig.Graphics.Colors;

public sealed class RGBColor : IColor, IEquatable<RGBColor>
{
	public static RGBColor Black = new RGBColor(0.0, 0.0, 0.0);

	public static RGBColor White = new RGBColor(1.0, 1.0, 1.0);

	public ColorSpace ColorSpace { get; } = ColorSpace.DeviceRGB;

	public double R { get; }

	public double G { get; }

	public double B { get; }

	public RGBColor(double r, double g, double b)
	{
		R = r;
		G = g;
		B = b;
	}

	public (double r, double g, double b) ToRGBValues()
	{
		return (r: R, g: G, b: B);
	}

	public override bool Equals(object? obj)
	{
		if (obj is RGBColor other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(RGBColor? other)
	{
		if ((object)other == null)
		{
			return (object)this == null;
		}
		if (R == other.R && G == other.G)
		{
			return B == other.B;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (R, G, B).GetHashCode();
	}

	public static bool operator ==(RGBColor color1, RGBColor color2)
	{
		return EqualityComparer<RGBColor>.Default.Equals(color1, color2);
	}

	public static bool operator !=(RGBColor color1, RGBColor color2)
	{
		return !(color1 == color2);
	}

	public override string ToString()
	{
		return $"RGB: ({R}, {G}, {B})";
	}
}
