using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace SixLabors.ImageSharp;

internal struct ComplexVector4 : IEquatable<ComplexVector4>
{
	public Vector4 Real;

	public Vector4 Imaginary;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Sum(ComplexVector4 value)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		Real += value.Real;
		Imaginary += value.Imaginary;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public Vector4 WeightedSum(float a, float b)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		return Real * a + Imaginary * b;
	}

	public bool Equals(ComplexVector4 other)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		if (((Vector4)(ref Real)).Equals(other.Real))
		{
			return ((Vector4)(ref Imaginary)).Equals(other.Imaginary);
		}
		return false;
	}

	public override bool Equals(object? obj)
	{
		if (obj is ComplexVector4 other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (((object)Unsafe.As<Vector4, Vector4>(ref Real)/*cast due to constrained. prefix*/).GetHashCode() * 397) ^ ((object)Unsafe.As<Vector4, Vector4>(ref Imaginary)/*cast due to constrained. prefix*/).GetHashCode();
	}
}
