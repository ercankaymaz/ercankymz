using System;

namespace CSMath;

public struct XYZ : IVector, IEquatable<XYZ>
{
	public static readonly XYZ AxisX = new XYZ(1.0, 0.0, 0.0);

	public static readonly XYZ AxisY = new XYZ(0.0, 1.0, 0.0);

	public static readonly XYZ AxisZ = new XYZ(0.0, 0.0, 1.0);

	public static readonly XYZ NaN = new XYZ(double.NaN);

	public static readonly XYZ Zero = new XYZ(0.0, 0.0, 0.0);

	public uint Dimension => 3u;

	public double X { get; set; }

	public double Y { get; set; }

	public double Z { get; set; }

	public double this[int index]
	{
		get
		{
			return index switch
			{
				0 => X, 
				1 => Y, 
				2 => Z, 
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
			case 2:
				Z = value;
				break;
			default:
				throw new IndexOutOfRangeException($"The index must be between 0 and {Dimension}.");
			}
		}
	}

	public static XYZ operator +(XYZ left, XYZ right)
	{
		return left.Add(right);
	}

	public static XYZ operator -(XYZ left, XYZ right)
	{
		return left.Subtract(right);
	}

	public static XYZ operator *(XYZ left, XYZ right)
	{
		return left.Multiply(right);
	}

	public static XYZ operator *(XYZ left, double scalar)
	{
		return left * new XYZ(scalar);
	}

	public static XYZ operator *(double scalar, XYZ vector)
	{
		return new XYZ(scalar) * vector;
	}

	public static XYZ operator /(XYZ left, XYZ right)
	{
		return left.Divide(right);
	}

	public static XYZ operator /(XYZ xyz, float value)
	{
		float num = 1f / value;
		return new XYZ(xyz.X * (double)num, xyz.Y * (double)num, xyz.Z * (double)num);
	}

	public static XYZ operator /(XYZ xyz, double value)
	{
		double num = 1.0 / value;
		return new XYZ(xyz.X * num, xyz.Y * num, xyz.Z * num);
	}

	public static XYZ operator -(XYZ value)
	{
		return Zero.Subtract(value);
	}

	public static bool operator ==(XYZ left, XYZ right)
	{
		if (left.X == right.X && left.Y == right.Y)
		{
			return left.Z == right.Z;
		}
		return false;
	}

	public static bool operator !=(XYZ left, XYZ right)
	{
		if (left.X == right.X && left.Y == right.Y)
		{
			return left.Z != right.Z;
		}
		return true;
	}

	public static explicit operator XYZ(XY xy)
	{
		return new XYZ(xy.X, xy.Y, 0.0);
	}

	public XYZ(double x, double y, double z)
	{
		X = x;
		Y = y;
		Z = z;
	}

	public XYZ(double value)
		: this(value, value, value)
	{
	}

	[Obsolete("Deprecated")]
	public XYZ(double[] components)
		: this(components[0], components[1], components[2])
	{
	}

	[Obsolete("Deprecated")]
	public static XYZ CreateFrom(double[] arr, int offset)
	{
		double[] array = new double[3];
		for (int i = offset; i < arr.Length && i < array.Length + offset; i++)
		{
			array[i] = arr[i];
		}
		return new XYZ(array);
	}

	public static XYZ Cross(XYZ xyz1, XYZ xyz2)
	{
		return new XYZ(xyz1.Y * xyz2.Z - xyz1.Z * xyz2.Y, xyz1.Z * xyz2.X - xyz1.X * xyz2.Z, xyz1.X * xyz2.Y - xyz1.Y * xyz2.X);
	}

	public static XYZ FindNormal(XYZ point1, XYZ point2, XYZ point3)
	{
		XYZ xyz = point2.Subtract(point1);
		XYZ xyz2 = point3.Subtract(point1);
		return Cross(xyz, xyz2).Normalize();
	}

	public override bool Equals(object? obj)
	{
		if (!(obj is XYZ other))
		{
			return false;
		}
		return Equals(other);
	}

	public bool Equals(XYZ other, int digits)
	{
		return other.IsEqual(this, digits);
	}

	public bool Equals(XYZ other)
	{
		if (X == other.X && Y == other.Y)
		{
			return Z == other.Z;
		}
		return false;
	}

	public double GetAngle(XYZ dir)
	{
		double num = this.Dot(dir) / Math.Sqrt(this.GetLengthSquared() * dir.GetLengthSquared());
		if (MathHelper.IsAlmostZero(Math.Abs(num) - 1.0))
		{
			if (!(num > 0.0))
			{
				return Math.PI;
			}
			return 0.0;
		}
		return Math.Acos(num);
	}

	public double GetAngle2(XYZ dir, XYZ normal)
	{
		double num = this.Dot(dir) / Math.Sqrt(this.GetLengthSquared() * dir.GetLengthSquared());
		if (MathHelper.IsAlmostZero(Math.Abs(num) - 1.0))
		{
			if (!(num > 0.0))
			{
				return Math.PI;
			}
			return 0.0;
		}
		double angle = GetAngle(dir);
		if (!(Cross(this, dir).Dot(normal) > 0.0))
		{
			return Math.PI * 2.0 - angle;
		}
		return angle;
	}

	public override int GetHashCode()
	{
		return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();
	}

	public override string ToString()
	{
		return $"{X},{Y},{Z}";
	}

	public string ToString(IFormatProvider? cultureInfo)
	{
		return X.ToString(cultureInfo) + "," + Y.ToString(cultureInfo) + "," + Z.ToString(cultureInfo);
	}
}
