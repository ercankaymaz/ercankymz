using System;

namespace SixLabors.ImageSharp.Metadata.Profiles.Icc;

internal readonly struct IccScreeningChannel(float frequency, float angle, IccScreeningSpotType spotShape) : IEquatable<IccScreeningChannel>
{
	public float Frequency { get; } = frequency;

	public float Angle { get; } = angle;

	public IccScreeningSpotType SpotShape { get; } = spotShape;

	public static bool operator ==(IccScreeningChannel left, IccScreeningChannel right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(IccScreeningChannel left, IccScreeningChannel right)
	{
		return !left.Equals(right);
	}

	public bool Equals(IccScreeningChannel other)
	{
		if (Frequency == other.Frequency && Angle == other.Angle)
		{
			return SpotShape == other.SpotShape;
		}
		return false;
	}

	public override bool Equals(object? obj)
	{
		if (obj is IccScreeningChannel other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(Frequency, Angle, SpotShape);
	}

	public override string ToString()
	{
		return $"{Frequency}Hz; {Angle}°; {SpotShape}";
	}
}
