using System;

namespace ModuleWorks;

[Serializable]
public class Vector2d : Point2d<double>
{
	public double Length => Math.Sqrt(LengthSq);

	public double LengthSq => this * this;

	public static Vector2d Max => new Vector2d(double.MaxValue, double.MaxValue);

	public static Vector2d Min => new Vector2d(double.MinValue, double.MinValue);

	public Vector2d()
	{
	}

	public Vector2d(double x, double y)
		: base(x, y)
	{
	}

	public Vector2d(Point2d<double> other)
		: base(other)
	{
	}

	public Vector2d(Point2d<float> other)
		: base((double)other.X, (double)other.Y)
	{
	}

	public bool IsAxis(Axis axis)
	{
		bool result = false;
		double num = 0.0001;
		switch (axis)
		{
		case Axis.X:
			result = Math.Abs(base.X - 1.0) < num && Math.Abs(base.Y) < num;
			break;
		case Axis.Y:
			result = Math.Abs(base.X) < num && Math.Abs(base.Y - 1.0) < num;
			break;
		}
		return result;
	}

	public unsafe int Load(byte[] array, int index)
	{
		fixed (byte* ptr = &array[0])
		{
			base.X = *(double*)(ptr + index);
			index += 8;
			base.Y = *(double*)(ptr + index);
			index += 8;
		}
		return index;
	}

	public unsafe int Serialize(byte[] array, int index)
	{
		fixed (byte* ptr = &array[0])
		{
			*(double*)(ptr + index) = base.X;
			index += 8;
			*(double*)(ptr + index) = base.Y;
			index += 8;
		}
		return index;
	}

	public static Vector2d operator +(Vector2d v1, Vector2d v2)
	{
		return new Vector2d(v1.X + v2.X, v1.Y + v2.Y);
	}

	public static Vector2d operator -(Vector2d v1, Vector2d v2)
	{
		return new Vector2d(v1.X - v2.X, v1.Y - v2.Y);
	}

	public static Vector2d operator -(Vector2d v)
	{
		return new Vector2d(0.0 - v.X, 0.0 - v.Y);
	}

	public static double operator ~(Vector2d v)
	{
		return v.Length;
	}

	public static double operator *(Vector2d v1, Vector2d v2)
	{
		return v1.X * v2.X + v1.Y * v2.Y;
	}

	public static Vector2d operator *(Vector2d v, double factor)
	{
		return new Vector2d(v.X * factor, v.Y * factor);
	}

	public static Vector2d operator *(double factor, Vector2d v)
	{
		return v * factor;
	}

	public static Vector2d operator /(Vector2d v, double factor)
	{
		return v * (1.0 / factor);
	}

	public void Normalize()
	{
		double lengthSq = LengthSq;
		if (lengthSq <= double.Epsilon)
		{
			throw new Exception();
		}
		if (lengthSq > 1.0001 || lengthSq < 0.9999)
		{
			double num = 1.0 / Math.Sqrt(lengthSq);
			base.X *= num;
			base.Y *= num;
		}
	}

	public Vector2d Normalized()
	{
		Vector2d vector2d = new Vector2d(this);
		vector2d.Normalize();
		return vector2d;
	}

	public void AddThis(Vector2d v)
	{
		base.X += v.X;
		base.Y += v.Y;
	}

	public void MultiplyThis(double scalar)
	{
		base.X *= scalar;
		base.Y *= scalar;
	}

	public override bool Equals(object obj)
	{
		if (!(obj is Vector2d vector2d))
		{
			return false;
		}
		if (Math.Abs(base.X - vector2d.X) < 0.0001)
		{
			return Math.Abs(base.Y - vector2d.Y) < 0.0001;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (int)(base.X * 10000.0) * -7919 + (int)(base.Y * 10000.0) * 4447;
	}
}
