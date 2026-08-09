using System;

namespace ModuleWorks;

[Serializable]
public class Vector2i : Point2d<int>
{
	public int LengthSq => this * this;

	public static Vector2i Max => new Vector2i(int.MaxValue, int.MaxValue);

	public static Vector2i Min => new Vector2i(int.MinValue, int.MinValue);

	public Vector2i()
	{
	}

	public Vector2i(int x, int y)
		: base(x, y)
	{
	}

	public Vector2i(Point2d<int> other)
		: base(other)
	{
	}

	public bool IsAxis(Axis axis)
	{
		bool result = false;
		float num = 0.0001f;
		switch (axis)
		{
		case Axis.X:
			result = Math.Abs((double)base.X - 1.0) < (double)num && (float)Math.Abs(base.Y) < num;
			break;
		case Axis.Y:
			result = (float)Math.Abs(base.X) < num && Math.Abs((double)base.Y - 1.0) < (double)num;
			break;
		}
		return result;
	}

	public unsafe int Load(byte[] array, int index)
	{
		fixed (byte* ptr = &array[0])
		{
			base.X = *(int*)(ptr + index);
			index += 4;
			base.Y = *(int*)(ptr + index);
			index += 4;
		}
		return index;
	}

	public unsafe int Serialize(byte[] array, int index)
	{
		fixed (byte* ptr = &array[0])
		{
			*(int*)(ptr + index) = base.X;
			index += 4;
			*(int*)(ptr + index) = base.Y;
			index += 4;
		}
		return index;
	}

	public static Vector2i operator +(Vector2i v1, Vector2i v2)
	{
		return new Vector2i(v1.X + v2.X, v1.Y + v2.Y);
	}

	public static Vector2i operator -(Vector2i v1, Vector2i v2)
	{
		return new Vector2i(v1.X - v2.X, v1.Y - v2.Y);
	}

	public static Vector2i operator -(Vector2i v)
	{
		return new Vector2i(-v.X, -v.Y);
	}

	public static int operator *(Vector2i v1, Vector2i v2)
	{
		return v1.X * v2.X + v1.Y * v2.Y;
	}

	public static Vector2i operator *(Vector2i v, int factor)
	{
		return new Vector2i(v.X * factor, v.Y * factor);
	}

	public static Vector2i operator *(int factor, Vector2i v)
	{
		return v * factor;
	}

	public void AddThis(Vector2i v)
	{
		base.X += v.X;
		base.Y += v.Y;
	}

	public void MultiplyThis(int scalar)
	{
		base.X *= scalar;
		base.Y *= scalar;
	}

	public override bool Equals(object obj)
	{
		if (!(obj is Vector2i vector2i))
		{
			return false;
		}
		if ((float)Math.Abs(base.X - vector2i.X) < 0.0001f)
		{
			return (float)Math.Abs(base.Y - vector2i.Y) < 0.0001f;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return base.X * -7919 + base.Y * 4447;
	}
}
