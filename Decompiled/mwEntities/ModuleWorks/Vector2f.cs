using System;

namespace ModuleWorks;

[Serializable]
public class Vector2f : Point2d<float>
{
	public float Length => (float)Math.Sqrt(LengthSq);

	public float LengthSq => this * this;

	public static Vector2f Max => new Vector2f(float.MaxValue, float.MaxValue);

	public static Vector2f Min => new Vector2f(float.MinValue, float.MinValue);

	public Vector2f()
	{
	}

	public Vector2f(float x, float y)
		: base(x, y)
	{
	}

	public Vector2f(Point2d<float> other)
		: base(other)
	{
	}

	public Vector2f(Point2d<double> other)
		: base((float)other.X, (float)other.Y)
	{
	}

	public bool IsAxis(Axis axis)
	{
		bool result = false;
		float num = 0.0001f;
		switch (axis)
		{
		case Axis.X:
			result = Math.Abs((double)base.X - 1.0) < (double)num && Math.Abs(base.Y) < num;
			break;
		case Axis.Y:
			result = Math.Abs(base.X) < num && Math.Abs((double)base.Y - 1.0) < (double)num;
			break;
		}
		return result;
	}

	public unsafe int Load(byte[] array, int index)
	{
		fixed (byte* ptr = &array[0])
		{
			base.X = *(float*)(ptr + index);
			index += 4;
			base.Y = *(float*)(ptr + index);
			index += 4;
		}
		return index;
	}

	public unsafe int Serialize(byte[] array, int index)
	{
		fixed (byte* ptr = &array[0])
		{
			*(float*)(ptr + index) = base.X;
			index += 4;
			*(float*)(ptr + index) = base.Y;
			index += 4;
		}
		return index;
	}

	public static Vector2f operator +(Vector2f v1, Vector2f v2)
	{
		return new Vector2f(v1.X + v2.X, v1.Y + v2.Y);
	}

	public static Vector2f operator -(Vector2f v1, Vector2f v2)
	{
		return new Vector2f(v1.X - v2.X, v1.Y - v2.Y);
	}

	public static Vector2f operator -(Vector2f v)
	{
		return new Vector2f(0f - v.X, 0f - v.Y);
	}

	public static float operator ~(Vector2f v)
	{
		return v.Length;
	}

	public static float operator *(Vector2f v1, Vector2f v2)
	{
		return v1.X * v2.X + v1.Y * v2.Y;
	}

	public static Vector2f operator *(Vector2f v, float factor)
	{
		return new Vector2f(v.X * factor, v.Y * factor);
	}

	public static Vector2f operator *(float factor, Vector2f v)
	{
		return v * factor;
	}

	public static Vector2f operator /(Vector2f v, float factor)
	{
		return v * (1f / factor);
	}

	public void Normalize()
	{
		float lengthSq = LengthSq;
		if (lengthSq <= float.Epsilon)
		{
			throw new Exception();
		}
		if (lengthSq > 1.0001f || lengthSq < 0.9999f)
		{
			float num = 1f / (float)Math.Sqrt(lengthSq);
			base.X *= num;
			base.Y *= num;
		}
	}

	public Vector2f Normalized()
	{
		Vector2f vector2f = new Vector2f(this);
		vector2f.Normalize();
		return vector2f;
	}

	public void AddThis(Vector2f v)
	{
		base.X += v.X;
		base.Y += v.Y;
	}

	public void MultiplyThis(float scalar)
	{
		base.X *= scalar;
		base.Y *= scalar;
	}

	public override bool Equals(object obj)
	{
		if (!(obj is Vector2f vector2f))
		{
			return false;
		}
		if (Math.Abs(base.X - vector2f.X) < 0.0001f)
		{
			return Math.Abs(base.Y - vector2f.Y) < 0.0001f;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (int)((double)base.X * 10000.0) * -7919 + (int)((double)base.Y * 10000.0) * 4447;
	}

	[Obsolete("Deprecated since Release 2017.04. Please use constructor Vector2f(Vector2d other) instead!")]
	public static Vector2f Convert(Point2d<double> point)
	{
		return new Vector2f((float)point.X, (float)point.Y);
	}
}
