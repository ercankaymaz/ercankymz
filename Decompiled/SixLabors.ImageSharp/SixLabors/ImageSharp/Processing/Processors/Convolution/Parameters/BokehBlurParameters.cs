using System;

namespace SixLabors.ImageSharp.Processing.Processors.Convolution.Parameters;

internal readonly struct BokehBlurParameters(int radius, int components) : IEquatable<BokehBlurParameters>
{
	public readonly int Radius = radius;

	public readonly int Components = components;

	public bool Equals(BokehBlurParameters other)
	{
		if (Radius.Equals(other.Radius))
		{
			return Components.Equals(other.Components);
		}
		return false;
	}

	public override bool Equals(object? obj)
	{
		if (obj is BokehBlurParameters other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (Radius.GetHashCode() * 397) ^ Components.GetHashCode();
	}
}
