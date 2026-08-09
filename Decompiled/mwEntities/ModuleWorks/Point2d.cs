using System;
using System.Globalization;

namespace ModuleWorks;

[Serializable]
public class Point2d<T>
{
	public T X { get; set; }

	public T Y { get; set; }

	public T this[int index]
	{
		get
		{
			return index switch
			{
				0 => X, 
				1 => Y, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (index)
			{
			case 0:
				X = value;
				break;
			case 1:
				Y = value;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	public Point2d()
	{
		X = default(T);
		Y = default(T);
	}

	public Point2d(T x, T y)
	{
		X = x;
		Y = y;
	}

	public Point2d(Point2d<T> other)
	{
		X = other.X;
		Y = other.Y;
	}

	public override int GetHashCode()
	{
		if (typeof(T) == typeof(double))
		{
			Point2d<double> point2d = (Point2d<double>)(object)this;
			return (int)(point2d.X * 10000.0) * -7919 + (int)(point2d.Y * 10000.0) * 4447;
		}
		if (typeof(T) == typeof(float))
		{
			Point2d<float> point2d2 = (Point2d<float>)(object)this;
			return (int)((double)point2d2.X * 10000.0) * -7919 + (int)((double)point2d2.Y * 10000.0) * 4447;
		}
		return base.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (typeof(T) == typeof(double))
		{
			Point2d<double> point2d = (Point2d<double>)(object)this;
			Point2d<double> point2d2 = (Point2d<double>)obj;
			if (Math.Abs(point2d.X - point2d2.X) < 1E-06)
			{
				return Math.Abs(point2d.Y - point2d2.Y) < 1E-06;
			}
			return false;
		}
		if (typeof(T) == typeof(float))
		{
			Point2d<float> point2d3 = (Point2d<float>)(object)this;
			Point2d<float> point2d4 = (Point2d<float>)obj;
			if ((double)Math.Abs(point2d3.X - point2d4.X) < 0.0001)
			{
				return (double)Math.Abs(point2d3.Y - point2d4.Y) < 0.0001;
			}
			return false;
		}
		return base.Equals(obj);
	}

	public override string ToString()
	{
		return ToString(CultureInfo.InvariantCulture);
	}

	public string ToString(CultureInfo culture)
	{
		return string.Format(culture, "{0:0.0000##############}; {1:0.0000##############}", X, Y);
	}
}
