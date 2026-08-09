using System;
using System.Runtime.CompilerServices;

namespace SixLabors.ImageSharp.ColorSpaces.Conversion;

public readonly struct CieXyChromaticityCoordinates(float x, float y) : IEquatable<CieXyChromaticityCoordinates>
{
	public float X { get; } = x;

	public float Y { get; } = y;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(CieXyChromaticityCoordinates left, CieXyChromaticityCoordinates right)
	{
		return left.Equals(right);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(CieXyChromaticityCoordinates left, CieXyChromaticityCoordinates right)
	{
		return !left.Equals(right);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public override int GetHashCode()
	{
		return HashCode.Combine(X, Y);
	}

	public override string ToString()
	{
		return FormattableString.Invariant($"CieXyChromaticityCoordinates({X:#0.##}, {Y:#0.##})");
	}

	public override bool Equals(object? obj)
	{
		if (obj is CieXyChromaticityCoordinates other)
		{
			return Equals(other);
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool Equals(CieXyChromaticityCoordinates other)
	{
		if (X.Equals(other.X))
		{
			return Y.Equals(other.Y);
		}
		return false;
	}
}
