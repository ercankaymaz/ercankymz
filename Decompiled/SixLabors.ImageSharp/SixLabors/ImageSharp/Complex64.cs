using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace SixLabors.ImageSharp;

internal readonly struct Complex64(float real, float imaginary) : IEquatable<Complex64>
{
	public readonly float Real = real;

	public readonly float Imaginary = imaginary;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Complex64 operator *(Complex64 value, float scalar)
	{
		return new Complex64(value.Real * scalar, value.Imaginary * scalar);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ComplexVector4 operator *(Complex64 value, Vector4 vector)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		return new ComplexVector4
		{
			Real = vector * value.Real,
			Imaginary = vector * value.Imaginary
		};
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ComplexVector4 operator *(Complex64 value, ComplexVector4 vector)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		Vector4 real = value.Real * vector.Real - value.Imaginary * vector.Imaginary;
		Vector4 imaginary = value.Real * vector.Imaginary + value.Imaginary * vector.Real;
		return new ComplexVector4
		{
			Real = real,
			Imaginary = imaginary
		};
	}

	public bool Equals(Complex64 other)
	{
		if (Real.Equals(other.Real))
		{
			return Imaginary.Equals(other.Imaginary);
		}
		return false;
	}

	public override bool Equals(object? obj)
	{
		if (obj is Complex64 other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (Real.GetHashCode() * 397) ^ Imaginary.GetHashCode();
	}

	public override string ToString()
	{
		return $"{Real}{((Imaginary >= 0f) ? "+" : string.Empty)}{Imaginary}j";
	}
}
