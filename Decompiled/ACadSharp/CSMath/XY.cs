using System;

namespace CSMath;

public struct XY : IVector, IEquatable<XY>
{
	public static readonly XY AxisX = new XY(1.0, 0.0);

	public static readonly XY AxisY = new XY(0.0, 1.0);

	public static readonly XY NaN = new XY(double.NaN);

	public static readonly XY Zero = new XY(0.0, 0.0);

	public uint Dimension => 2u;

	public double X { get; set; }

	public double Y { get; set; }

	public double this[int index]
	{
		get
		{
			return index switch
			{
				0 => X, 
				1 => Y, 
				_ => throw new IndexOutOfRangeException($"The index must be between 0 and {Dimension}."), 
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
				throw new IndexOutOfRangeException($"The index must be between 0 and {Dimension}.");
			}
		}
	}

	public static XY operator +(XY left, XY right)
	{
		return left.Add(right);
	}

	public static XY operator -(XY left, XY right)
	{
		return left.Subtract(right);
	}

	public static XY operator *(XY left, XY right)
	{
		return left.Multiply(right);
	}

	public static XY operator *(XY left, double scalar)
	{
		return left * new XY(scalar);
	}

	public static XY operator *(double scalar, XY vector)
	{
		return new XY(scalar) * vector;
	}

	public static XY operator /(XY left, XY right)
	{
		return left.Divide(right);
	}

	public static XY operator /(XY XY, float value)
	{
		float num = 1f / value;
		return new XY(XY.X * (double)num, XY.Y * (double)num);
	}

	public static XY operator /(XY XY, double value)
	{
		double num = 1.0 / value;
		return new XY(XY.X * num, XY.Y * num);
	}

	public static XY operator -(XY value)
	{
		return Zero.Subtract(value);
	}

	public static bool operator ==(XY left, XY right)
	{
		if (left.X == right.X)
		{
			return left.Y == right.Y;
		}
		return false;
	}

	public static bool operator !=(XY left, XY right)
	{
		if (left.X == right.X)
		{
			return left.Y != right.Y;
		}
		return true;
	}

	public static explicit operator XY(XYZ xyz)
	{
		return new XY(xyz.X, xyz.Y);
	}

	public XY(double x, double y)
	{
		X = x;
		Y = y;
	}

	public XY(double value)
		: this(value, value)
	{
	}

	public static double Cross(XY xy1, XY xy2)
	{
		return xy1.X * xy2.Y - xy1.Y * xy2.X;
	}

	public static XY Polar(XY u, double distance, double angle)
	{
		XY xY = new XY(Math.Cos(angle), Math.Sin(angle));
		return u + xY * distance;
	}

	public static XY Rotate(XY value, double angle)
	{
		double num = Math.Sin(angle);
		double num2 = Math.Cos(angle);
		return new XY(value.X * num2 - value.Y * num, value.X * num + value.Y * num2);
	}

	public override bool Equals(object? obj)
	{
		if (!(obj is XY other))
		{
			return false;
		}
		return Equals(other);
	}

	public bool Equals(XY other, int digits)
	{
		return other.IsEqual(this, digits);
	}

	public bool Equals(XY other)
	{
		if (X == other.X)
		{
			return Y == other.Y;
		}
		return false;
	}

	public double GetAngle()
	{
		return Math.Atan2(Y, X);
	}

	public double GetAngle(XY v)
	{
		return (v - this).GetAngle();
	}

	public override int GetHashCode()
	{
		return X.GetHashCode() ^ Y.GetHashCode();
	}

	public XY Perpendicular()
	{
		return new XY(0.0 - Y, X);
	}

	public XY Polar(double distance, double angle)
	{
		XY xY = new XY(Math.Cos(angle), Math.Sin(angle));
		return this + xY * distance;
	}

	public override string ToString()
	{
		return $"{X},{Y}";
	}

	public string ToString(IFormatProvider? cultureInfo)
	{
		return X.ToString(cultureInfo) + "," + Y.ToString(cultureInfo);
	}
}
