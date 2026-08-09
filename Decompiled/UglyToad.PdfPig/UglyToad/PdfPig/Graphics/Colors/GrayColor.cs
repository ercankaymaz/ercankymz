using System;
using System.Collections.Generic;

namespace UglyToad.PdfPig.Graphics.Colors;

public sealed class GrayColor : IColor, IEquatable<GrayColor>
{
	public static GrayColor Black { get; } = new GrayColor(0.0);

	public static GrayColor White { get; } = new GrayColor(1.0);

	public ColorSpace ColorSpace { get; }

	public double Gray { get; }

	public GrayColor(double gray)
	{
		Gray = gray;
	}

	public (double r, double g, double b) ToRGBValues()
	{
		return (r: Gray, g: Gray, b: Gray);
	}

	public override bool Equals(object? obj)
	{
		if (obj is GrayColor other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(GrayColor? other)
	{
		if ((object)other == null)
		{
			return (object)this == null;
		}
		return Gray == other.Gray;
	}

	public override int GetHashCode()
	{
		return Gray.GetHashCode();
	}

	public static bool operator ==(GrayColor color1, GrayColor color2)
	{
		return EqualityComparer<GrayColor>.Default.Equals(color1, color2);
	}

	public static bool operator !=(GrayColor color1, GrayColor color2)
	{
		return !(color1 == color2);
	}

	public override string ToString()
	{
		return $"Gray: {Gray}";
	}
}
