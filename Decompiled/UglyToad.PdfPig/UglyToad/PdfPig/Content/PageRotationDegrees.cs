using System;
using System.Globalization;

namespace UglyToad.PdfPig.Content;

public readonly struct PageRotationDegrees : IEquatable<PageRotationDegrees>
{
	public int Value { get; }

	public bool SwapsAxis
	{
		get
		{
			if (Value != 90)
			{
				return Value == 270;
			}
			return true;
		}
	}

	public double Radians => Value switch
	{
		0 => 0.0, 
		90 => -Math.PI / 2.0, 
		180 => -Math.PI, 
		270 => -4.71238898038469, 
		_ => throw new InvalidOperationException($"Invalid value for rotation: {Value}."), 
	};

	public PageRotationDegrees(int rotation)
	{
		if (rotation < 0)
		{
			rotation = 360 + rotation;
		}
		while (rotation >= 360)
		{
			rotation -= 360;
		}
		if (rotation != 0 && rotation != 90 && rotation != 180 && rotation != 270)
		{
			throw new ArgumentOutOfRangeException("rotation", $"Rotation must be 0, 90, 180 or 270. Got: {rotation}.");
		}
		Value = rotation;
	}

	public override int GetHashCode()
	{
		return Value.GetHashCode();
	}

	public override string ToString()
	{
		return Value.ToString(CultureInfo.InvariantCulture);
	}

	public override bool Equals(object? obj)
	{
		if (obj is PageRotationDegrees other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(PageRotationDegrees other)
	{
		return Value == other.Value;
	}

	public static bool operator ==(PageRotationDegrees degrees1, PageRotationDegrees degrees2)
	{
		return degrees1.Equals(degrees2);
	}

	public static bool operator !=(PageRotationDegrees degrees1, PageRotationDegrees degrees2)
	{
		return !(degrees1 == degrees2);
	}
}
