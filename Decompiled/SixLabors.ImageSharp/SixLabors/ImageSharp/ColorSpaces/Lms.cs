using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace SixLabors.ImageSharp.ColorSpaces;

public readonly struct Lms : IEquatable<Lms>
{
	public float L { get; }

	public float M { get; }

	public float S { get; }

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public Lms(float l, float m, float s)
		: this(new Vector3(l, m, s))
	{
	}//IL_0004: Unknown result type (might be due to invalid IL or missing references)


	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public Lms(Vector3 vector)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		L = vector.X;
		M = vector.Y;
		S = vector.Z;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(Lms left, Lms right)
	{
		return left.Equals(right);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(Lms left, Lms right)
	{
		return !left.Equals(right);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public Vector3 ToVector3()
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		return new Vector3(L, M, S);
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(L, M, S);
	}

	public override string ToString()
	{
		return FormattableString.Invariant($"Lms({L:#0.##}, {M:#0.##}, {S:#0.##})");
	}

	public override bool Equals(object? obj)
	{
		if (obj is Lms other)
		{
			return Equals(other);
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool Equals(Lms other)
	{
		if (L.Equals(other.L) && M.Equals(other.M))
		{
			return S.Equals(other.S);
		}
		return false;
	}
}
