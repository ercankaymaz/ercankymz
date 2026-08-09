using System;
using System.Globalization;

namespace ModuleWorks;

[Serializable]
public class Point3d<T>
{
	public T X { get; set; }

	public T Y { get; set; }

	public T Z { get; set; }

	public T this[int index]
	{
		get
		{
			return index switch
			{
				0 => X, 
				1 => Y, 
				2 => Z, 
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
			case 2:
				Z = value;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	public Point3d()
	{
		X = default(T);
		Y = default(T);
		Z = default(T);
	}

	public Point3d(T x, T y, T z)
	{
		X = x;
		Y = y;
		Z = z;
	}

	public Point3d(Point3d<T> other)
	{
		X = other.X;
		Y = other.Y;
		Z = other.Z;
	}

	public override int GetHashCode()
	{
		if (typeof(T) == typeof(double))
		{
			Point3d<double> point3d = (Point3d<double>)(object)this;
			return (int)(point3d.X * 10000.0) * -7919 + (int)(point3d.Y * 10000.0) * 4447 + (int)(point3d.Z * 10000.0) * 6569;
		}
		if (typeof(T) == typeof(float))
		{
			Point3d<float> point3d2 = (Point3d<float>)(object)this;
			return (int)((double)point3d2.X * 10000.0) * -7919 + (int)((double)point3d2.Y * 10000.0) * 4447 + (int)((double)point3d2.Z * 10000.0) * 6569;
		}
		return base.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (typeof(T) == typeof(double))
		{
			Point3d<double> point3d = (Point3d<double>)(object)this;
			Point3d<double> point3d2 = (Point3d<double>)obj;
			if (Math.Abs(point3d.X - point3d2.X) < 1E-06 && Math.Abs(point3d.Y - point3d2.Y) < 1E-06)
			{
				return Math.Abs(point3d.Z - point3d2.Z) < 1E-06;
			}
			return false;
		}
		if (typeof(T) == typeof(float))
		{
			Point3d<float> point3d3 = (Point3d<float>)(object)this;
			Point3d<float> point3d4 = (Point3d<float>)obj;
			if ((double)Math.Abs(point3d3.X - point3d4.X) < 0.0001 && (double)Math.Abs(point3d3.Y - point3d4.Y) < 0.0001)
			{
				return (double)Math.Abs(point3d3.Z - point3d4.Z) < 0.0001;
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
		return string.Format(culture, "{0:0.0000##############}; {1:0.0000##############}; {2:0.0000##############}", X, Y, Z);
	}
}
