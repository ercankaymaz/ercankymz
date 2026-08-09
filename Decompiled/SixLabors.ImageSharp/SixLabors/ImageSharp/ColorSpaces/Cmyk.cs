using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace SixLabors.ImageSharp.ColorSpaces;

public readonly struct Cmyk : IEquatable<Cmyk>
{
	private static readonly Vector4 Min = Vector4.Zero;

	private static readonly Vector4 Max = Vector4.One;

	public float C { get; }

	public float M { get; }

	public float Y { get; }

	public float K { get; }

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public Cmyk(float c, float m, float y, float k)
		: this(new Vector4(c, m, y, k))
	{
	}//IL_0006: Unknown result type (might be due to invalid IL or missing references)


	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public Cmyk(Vector4 vector)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		vector = Numerics.Clamp(vector, Min, Max);
		C = vector.X;
		M = vector.Y;
		Y = vector.Z;
		K = vector.W;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(Cmyk left, Cmyk right)
	{
		return left.Equals(right);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(Cmyk left, Cmyk right)
	{
		return !left.Equals(right);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public override int GetHashCode()
	{
		return HashCode.Combine(C, M, Y, K);
	}

	public override string ToString()
	{
		return FormattableString.Invariant($"Cmyk({C:#0.##}, {M:#0.##}, {Y:#0.##}, {K:#0.##})");
	}

	public override bool Equals(object? obj)
	{
		if (obj is Cmyk other)
		{
			return Equals(other);
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool Equals(Cmyk other)
	{
		if (C.Equals(other.C) && M.Equals(other.M) && Y.Equals(other.Y))
		{
			return K.Equals(other.K);
		}
		return false;
	}
}
