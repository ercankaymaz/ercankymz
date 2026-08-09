using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace SixLabors.ImageSharp.ColorSpaces;

public readonly struct YCbCr : IEquatable<YCbCr>
{
	private static readonly Vector3 Min = Vector3.Zero;

	private static readonly Vector3 Max = new Vector3(255f);

	public float Y { get; }

	public float Cb { get; }

	public float Cr { get; }

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public YCbCr(float y, float cb, float cr)
		: this(new Vector3(y, cb, cr))
	{
	}//IL_0004: Unknown result type (might be due to invalid IL or missing references)


	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public YCbCr(Vector3 vector)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		vector = Vector3.Clamp(vector, Min, Max);
		Y = vector.X;
		Cb = vector.Y;
		Cr = vector.Z;
	}

	public static bool operator ==(YCbCr left, YCbCr right)
	{
		return left.Equals(right);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(YCbCr left, YCbCr right)
	{
		return !left.Equals(right);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public override int GetHashCode()
	{
		return HashCode.Combine(Y, Cb, Cr);
	}

	public override string ToString()
	{
		return FormattableString.Invariant($"YCbCr({Y}, {Cb}, {Cr})");
	}

	public override bool Equals(object? obj)
	{
		if (obj is YCbCr other)
		{
			return Equals(other);
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool Equals(YCbCr other)
	{
		if (Y.Equals(other.Y) && Cb.Equals(other.Cb))
		{
			return Cr.Equals(other.Cr);
		}
		return false;
	}
}
