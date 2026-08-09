using System;

namespace CSMath;

public struct XYZM : IVector, IEquatable<XYZM>
{
	public static readonly XYZM NaN = new XYZM(double.NaN);

	public static readonly XYZM Zero = new XYZM(0.0, 0.0, 0.0, 0.0);

	public static readonly XYZM AxisX = new XYZM(1.0, 0.0, 0.0, 0.0);

	public static readonly XYZM AxisY = new XYZM(0.0, 1.0, 0.0, 0.0);

	public static readonly XYZM AxisZ = new XYZM(0.0, 0.0, 1.0, 0.0);

	public static readonly XYZM AxisM = new XYZM(0.0, 0.0, 0.0, 1.0);

	public double X { get; set; }

	public double Y { get; set; }

	public double Z { get; set; }

	public double M { get; set; }

	public uint Dimension => 4u;

	public double this[int index]
	{
		get
		{
			return index switch
			{
				0 => X, 
				1 => Y, 
				2 => Z, 
				3 => M, 
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
			case 3:
				M = value;
				break;
			default:
				throw new IndexOutOfRangeException($"The index must be between 0 and {Dimension}.");
			}
		}
	}

	public static XYZM operator +(XYZM left, XYZM right)
	{
		return left.Add(right);
	}

	public static XYZM operator -(XYZM left, XYZM right)
	{
		return left.Subtract(right);
	}

	public static XYZM operator *(XYZM left, XYZM right)
	{
		return left.Multiply(right);
	}

	public static XYZM operator *(XYZM left, double scalar)
	{
		return left * new XYZM(scalar);
	}

	public static XYZM operator *(double scalar, XYZM vector)
	{
		return new XYZM(scalar) * vector;
	}

	public static XYZM operator /(XYZM left, XYZM right)
	{
		return left.Divide(right);
	}

	public static XYZM operator /(XYZM xyzm, double value)
	{
		return xyzm.Divide(new XYZM(value));
	}

	public static XYZM operator -(XYZM value)
	{
		return Zero.Subtract(value);
	}

	public static bool operator ==(XYZM left, XYZM right)
	{
		return left.IsEqual(right);
	}

	public static bool operator !=(XYZM left, XYZM right)
	{
		return !left.IsEqual(right);
	}

	public XYZM(double x, double y, double z, double m)
	{
		X = x;
		Y = y;
		Z = z;
		M = m;
	}

	public XYZM(double value)
		: this(value, value, value, value)
	{
	}

	public override bool Equals(object? obj)
	{
		if (!(obj is XYZM other))
		{
			return false;
		}
		return Equals(other);
	}

	public bool Equals(XYZM other, int digits)
	{
		return other.IsEqual(this, digits);
	}

	public bool Equals(XYZM other)
	{
		if (X == other.X && Y == other.Y && Z == other.Z)
		{
			return M == other.M;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode() ^ M.GetHashCode();
	}

	public override string ToString()
	{
		return $"{X},{Y},{Z},{M}";
	}

	public string ToString(IFormatProvider? cultureInfo)
	{
		return X.ToString(cultureInfo) + "," + Y.ToString(cultureInfo) + "," + Z.ToString(cultureInfo) + "," + M.ToString(cultureInfo);
	}
}
