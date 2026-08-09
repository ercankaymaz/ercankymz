using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace SixLabors.ImageSharp.ColorSpaces;

public readonly struct HunterLab : IEquatable<HunterLab>
{
	public static readonly CieXyz DefaultWhitePoint = Illuminants.C;

	public float L { get; }

	public float A { get; }

	public float B { get; }

	public CieXyz WhitePoint { get; }

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HunterLab(float l, float a, float b)
		: this(new Vector3(l, a, b), DefaultWhitePoint)
	{
	}//IL_0004: Unknown result type (might be due to invalid IL or missing references)


	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HunterLab(float l, float a, float b, CieXyz whitePoint)
		: this(new Vector3(l, a, b), whitePoint)
	{
	}//IL_0004: Unknown result type (might be due to invalid IL or missing references)


	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HunterLab(Vector3 vector)
		: this(vector, DefaultWhitePoint)
	{
	}//IL_0001: Unknown result type (might be due to invalid IL or missing references)


	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public HunterLab(Vector3 vector, CieXyz whitePoint)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		L = vector.X;
		A = vector.Y;
		B = vector.Z;
		WhitePoint = whitePoint;
	}

	public static bool operator ==(HunterLab left, HunterLab right)
	{
		return left.Equals(right);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HunterLab left, HunterLab right)
	{
		return !left.Equals(right);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public override int GetHashCode()
	{
		return HashCode.Combine(L, A, B, WhitePoint);
	}

	public override string ToString()
	{
		return FormattableString.Invariant($"HunterLab({L:#0.##}, {A:#0.##}, {B:#0.##})");
	}

	public override bool Equals(object? obj)
	{
		if (obj is HunterLab other)
		{
			return Equals(other);
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool Equals(HunterLab other)
	{
		if (L.Equals(other.L) && A.Equals(other.A) && B.Equals(other.B))
		{
			return WhitePoint.Equals(other.WhitePoint);
		}
		return false;
	}
}
