using System;
using System.Collections.Generic;

namespace UglyToad.PdfPig.Graphics.Colors;

public sealed class CMYKColor : IColor, IEquatable<CMYKColor>
{
	public static IColor Black { get; } = new CMYKColor(0.0, 0.0, 0.0, 1.0);

	public static IColor White { get; } = new CMYKColor(0.0, 0.0, 0.0, 0.0);

	public ColorSpace ColorSpace { get; } = ColorSpace.DeviceCMYK;

	public double C { get; }

	public double M { get; }

	public double Y { get; }

	public double K { get; }

	public CMYKColor(double c, double m, double y, double k)
	{
		C = c;
		M = m;
		Y = y;
		K = k;
	}

	public (double r, double g, double b) ToRGBValues()
	{
		return (r: (1.0 - C) * (1.0 - K), g: (1.0 - M) * (1.0 - K), b: (1.0 - Y) * (1.0 - K));
	}

	public override bool Equals(object? obj)
	{
		if (obj is CMYKColor other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(CMYKColor? other)
	{
		if ((object)other == null)
		{
			return (object)this == null;
		}
		if (C == other.C && M == other.M && Y == other.Y)
		{
			return K == other.K;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(C, M, Y, K);
	}

	public static bool operator ==(CMYKColor color1, CMYKColor color2)
	{
		return EqualityComparer<CMYKColor>.Default.Equals(color1, color2);
	}

	public static bool operator !=(CMYKColor color1, CMYKColor color2)
	{
		return !(color1 == color2);
	}

	public override string ToString()
	{
		return $"CMYK: ({C}, {M}, {Y}, {K})";
	}
}
