using System;
using System.Drawing;
using System.Globalization;

namespace ModuleWorks;

public class RenderedVector : IComparable<RenderedVector>, IComparable
{
	public float X;

	public float Y;

	public float Z;

	public Color Color;

	public float Length => (float)Math.Sqrt(X * X + Y * Y + Z * Z);

	public float LengthSq => X * X + Y * Y + Z * Z;

	public float this[int x]
	{
		get
		{
			return x switch
			{
				0 => X, 
				1 => Y, 
				2 => Z, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (x)
			{
			case 0:
				X = value;
				break;
			case 1:
				Y = value;
				break;
			case 2:
				Z = value;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	public RenderedVector()
	{
		X = (Y = (Z = 0f));
	}

	public RenderedVector(float x, float y, float z)
	{
		X = x;
		Y = y;
		Z = z;
	}

	public RenderedVector(RenderedVector other)
	{
		X = other.X;
		Y = other.Y;
		Z = other.Z;
	}

	public static RenderedVector operator +(RenderedVector v1, RenderedVector v2)
	{
		return new RenderedVector(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
	}

	public static RenderedVector operator -(RenderedVector v1, RenderedVector v2)
	{
		return new RenderedVector(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
	}

	public static RenderedVector operator -(RenderedVector v)
	{
		return new RenderedVector(0f - v.X, 0f - v.Y, 0f - v.Z);
	}

	public static RenderedVector operator %(RenderedVector v1, RenderedVector v2)
	{
		float x = v1.X;
		float y = v1.Y;
		float z = v1.Z;
		float x2 = v2.X;
		float y2 = v2.Y;
		float z2 = v2.Z;
		return new RenderedVector(y * z2 - z * y2, z * x2 - x * z2, x * y2 - y * x2);
	}

	public static float operator ~(RenderedVector v)
	{
		return v.Length;
	}

	public static float operator *(RenderedVector v1, RenderedVector v2)
	{
		return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
	}

	public static RenderedVector operator *(RenderedVector v, float factor)
	{
		return new RenderedVector(v.X * factor, v.Y * factor, v.Z * factor);
	}

	public static RenderedVector operator *(float factor, RenderedVector v)
	{
		return v * factor;
	}

	public static RenderedVector operator /(RenderedVector v, float factor)
	{
		return v * (1f / factor);
	}

	public static RenderedVector CrossProduct(RenderedVector v1, RenderedVector v2)
	{
		float x = v1.X;
		float y = v1.Y;
		float z = v1.Z;
		float x2 = v2.X;
		float y2 = v2.Y;
		float z2 = v2.Z;
		return new RenderedVector(y * z2 - z * y2, z * x2 - x * z2, x * y2 - y * x2);
	}

	public void Normalize()
	{
		float lengthSq = LengthSq;
		if (lengthSq > float.Epsilon && (lengthSq > 1.0001f || lengthSq < 0.9999f))
		{
			float num = 1f / (float)Math.Sqrt(lengthSq);
			X *= num;
			Y *= num;
			Z *= num;
		}
	}

	public RenderedVector Normalized()
	{
		float lengthSq = LengthSq;
		if (lengthSq > float.Epsilon)
		{
			lengthSq = (float)(1.0 / Math.Sqrt(lengthSq));
			return new RenderedVector(X * lengthSq, Y * lengthSq, Z * lengthSq);
		}
		return new RenderedVector(X, Y, Z);
	}

	public void AddThis(RenderedVector v)
	{
		X += v.X;
		Y += v.Y;
		Z += v.Z;
	}

	public void MultiplyThis(float scalar)
	{
		X *= scalar;
		Y *= scalar;
		Z *= scalar;
	}

	public unsafe byte[] Serialize()
	{
		byte[] array = new byte[12];
		fixed (float* x = &X)
		{
			byte* ptr = (byte*)x;
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = ptr[i];
			}
		}
		return array;
	}

	public override bool Equals(object obj)
	{
		bool result = false;
		if (obj is RenderedVector renderedVector)
		{
			result = Math.Abs(X - renderedVector.X) < 0.0001f && Math.Abs(Y - renderedVector.Y) < 0.0001f && Math.Abs(Z - renderedVector.Z) < 0.0001f;
		}
		return result;
	}

	public override int GetHashCode()
	{
		double num = Math.Round(X, 4);
		double num2 = Math.Round(Y, 4);
		double num3 = Math.Round(Z, 4);
		return (int)(num * 73201.0 + num2 * -32031.0 + num3 * 31.0);
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "{0:0.000}; {1:0.000}; {2:0.000};", X, Y, Z);
	}

	public int CompareTo(RenderedVector other)
	{
		if (Math.Abs(X - other.X) > 0.001f)
		{
			if (!(X > other.X))
			{
				return -1;
			}
			return 1;
		}
		if (Math.Abs(Y - other.Y) > 0.001f)
		{
			if (!(Y > other.Y))
			{
				return -1;
			}
			return 1;
		}
		if (Math.Abs(Z - other.Z) > 0.001f)
		{
			if (!(Z > other.Z))
			{
				return -1;
			}
			return 1;
		}
		return 0;
	}

	public int CompareTo(object obj)
	{
		return CompareTo((RenderedVector)obj);
	}
}
