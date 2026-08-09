using System;

namespace SixLabors.ImageSharp.ColorSpaces.Conversion;

public readonly struct RgbPrimariesChromaticityCoordinates(CieXyChromaticityCoordinates r, CieXyChromaticityCoordinates g, CieXyChromaticityCoordinates b) : IEquatable<RgbPrimariesChromaticityCoordinates>
{
	public CieXyChromaticityCoordinates R { get; } = r;

	public CieXyChromaticityCoordinates G { get; } = g;

	public CieXyChromaticityCoordinates B { get; } = b;

	public static bool operator ==(RgbPrimariesChromaticityCoordinates left, RgbPrimariesChromaticityCoordinates right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(RgbPrimariesChromaticityCoordinates left, RgbPrimariesChromaticityCoordinates right)
	{
		return !left.Equals(right);
	}

	public override bool Equals(object? obj)
	{
		if (obj is RgbPrimariesChromaticityCoordinates other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(RgbPrimariesChromaticityCoordinates other)
	{
		if (R.Equals(other.R) && G.Equals(other.G))
		{
			return B.Equals(other.B);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(R, G, B);
	}
}
