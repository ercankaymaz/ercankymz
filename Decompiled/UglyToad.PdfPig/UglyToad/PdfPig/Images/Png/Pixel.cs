using System;

namespace UglyToad.PdfPig.Images.Png;

internal readonly struct Pixel : IEquatable<Pixel>
{
	public byte R { get; }

	public byte G { get; }

	public byte B { get; }

	public byte A { get; }

	public bool IsGrayscale { get; }

	public Pixel(byte r, byte g, byte b, byte a, bool isGrayscale)
	{
		R = r;
		G = g;
		B = b;
		A = a;
		IsGrayscale = isGrayscale;
	}

	public Pixel(byte r, byte g, byte b)
	{
		R = r;
		G = g;
		B = b;
		A = byte.MaxValue;
		IsGrayscale = false;
	}

	public Pixel(byte grayscale)
	{
		R = grayscale;
		G = grayscale;
		B = grayscale;
		A = byte.MaxValue;
		IsGrayscale = true;
	}

	public override bool Equals(object? obj)
	{
		if (obj is Pixel other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(Pixel other)
	{
		if (R == other.R && G == other.G && B == other.B && A == other.A)
		{
			return IsGrayscale == other.IsGrayscale;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(R, G, B, A, IsGrayscale);
	}

	public override string ToString()
	{
		return $"({R}, {G}, {B}, {A})";
	}

	public static bool operator ==(Pixel left, Pixel right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(Pixel left, Pixel right)
	{
		return !(left == right);
	}
}
