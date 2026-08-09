using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using SixLabors.ImageSharp.ColorSpaces.Conversion;
using SixLabors.ImageSharp.PixelFormats;

namespace SixLabors.ImageSharp.ColorSpaces;

public readonly struct Rgb : IEquatable<Rgb>
{
	public static readonly RgbWorkingSpace DefaultWorkingSpace = RgbWorkingSpaces.SRgb;

	private static readonly Vector3 Min = Vector3.Zero;

	private static readonly Vector3 Max = Vector3.One;

	public float R { get; }

	public float G { get; }

	public float B { get; }

	public RgbWorkingSpace WorkingSpace { get; }

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public Rgb(float r, float g, float b)
		: this(r, g, b, DefaultWorkingSpace)
	{
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public Rgb(float r, float g, float b, RgbWorkingSpace workingSpace)
		: this(new Vector3(r, g, b), workingSpace)
	{
	}//IL_0004: Unknown result type (might be due to invalid IL or missing references)


	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public Rgb(Vector3 vector)
		: this(vector, DefaultWorkingSpace)
	{
	}//IL_0001: Unknown result type (might be due to invalid IL or missing references)


	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public Rgb(Vector3 vector, RgbWorkingSpace workingSpace)
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
		R = vector.X;
		G = vector.Y;
		B = vector.Z;
		WorkingSpace = workingSpace;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static implicit operator Rgb(Rgb24 color)
	{
		return new Rgb((float)(int)color.R / 255f, (float)(int)color.G / 255f, (float)(int)color.B / 255f);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static implicit operator Rgb(Rgba32 color)
	{
		return new Rgb((float)(int)color.R / 255f, (float)(int)color.G / 255f, (float)(int)color.B / 255f);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(Rgb left, Rgb right)
	{
		return left.Equals(right);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(Rgb left, Rgb right)
	{
		return !left.Equals(right);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public Vector3 ToVector3()
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		return new Vector3(R, G, B);
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(R, G, B);
	}

	public override string ToString()
	{
		return FormattableString.Invariant($"Rgb({R:#0.##}, {G:#0.##}, {B:#0.##})");
	}

	public override bool Equals(object? obj)
	{
		if (obj is Rgb other)
		{
			return Equals(other);
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool Equals(Rgb other)
	{
		if (R.Equals(other.R) && G.Equals(other.G))
		{
			return B.Equals(other.B);
		}
		return false;
	}
}
