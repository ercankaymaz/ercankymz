using System;

namespace CSMath;

public struct Quaternion : IVector, IEquatable<Quaternion>
{
	public double X { get; set; }

	public double Y { get; set; }

	public double Z { get; set; }

	public double W { get; set; }

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
				3 => W, 
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
				W = value;
				break;
			default:
				throw new IndexOutOfRangeException($"The index must be between 0 and {Dimension}.");
			}
		}
	}

	public static Quaternion Identity => new Quaternion(0.0, 0.0, 0.0, 1.0);

	public Quaternion(double x, double y, double z, double w)
	{
		X = x;
		Y = y;
		Z = z;
		W = w;
	}

	public Quaternion(XYZ vectorPart, double scalarPart)
	{
		X = vectorPart.X;
		Y = vectorPart.Y;
		Z = vectorPart.Z;
		W = scalarPart;
	}

	public static Quaternion CreateFromYawPitchRoll(XYZ xyz)
	{
		return CreateFromYawPitchRoll(xyz.X, xyz.Y, xyz.Z);
	}

	public XYZ ToEulerAngles()
	{
		Quaternion quaternion = this.Normalize();
		XYZ result = default(XYZ);
		double y = 2.0 * (quaternion.W * quaternion.X + quaternion.Y * quaternion.Z);
		double x = 1.0 - 2.0 * (quaternion.X * quaternion.X + quaternion.Y * quaternion.Y);
		result.X = Math.Atan2(y, x);
		double num = 2.0 * (quaternion.W * quaternion.Y - quaternion.Z * quaternion.X);
		if (Math.Abs(num) >= 1.0)
		{
			result.Y = Math.PI / 2.0 * (double)Math.Sign(num);
		}
		else
		{
			result.Y = Math.Asin(num);
		}
		double y2 = 2.0 * (quaternion.W * quaternion.Z + quaternion.X * quaternion.Y);
		double x2 = 1.0 - 2.0 * (quaternion.Y * quaternion.Y + quaternion.Z * quaternion.Z);
		result.Z = Math.Atan2(y2, x2);
		return result;
	}

	public static Quaternion CreateFromYawPitchRoll(double pitch, double yaw, double roll)
	{
		double num = pitch * 0.5;
		double num2 = Math.Sin(num);
		double num3 = Math.Cos(num);
		double num4 = yaw * 0.5;
		double num5 = Math.Sin(num4);
		double num6 = Math.Cos(num4);
		double num7 = roll * 0.5;
		double num8 = Math.Sin(num7);
		double num9 = Math.Cos(num7);
		return new Quaternion
		{
			X = num6 * num2 * num9 + num5 * num3 * num8,
			Y = num5 * num3 * num9 - num6 * num2 * num8,
			Z = num6 * num3 * num8 - num5 * num2 * num9,
			W = num6 * num3 * num9 + num5 * num2 * num8
		};
	}

	public static Quaternion CreateFromRotationMatrix(Matrix4 matrix)
	{
		double num = matrix.M00 + matrix.M11 + matrix.M22;
		Quaternion result = default(Quaternion);
		if (num > 0.0)
		{
			double num2 = Math.Sqrt(num + 1.0);
			result.W = num2 * 0.5;
			num2 = 0.5 / num2;
			result.X = (matrix.M12 - matrix.M21) * num2;
			result.Y = (matrix.M20 - matrix.M02) * num2;
			result.Z = (matrix.M01 - matrix.M10) * num2;
		}
		else if (matrix.M00 >= matrix.M11 && matrix.M00 >= matrix.M22)
		{
			double num3 = Math.Sqrt(1.0 + matrix.M00 - matrix.M11 - matrix.M22);
			double num4 = 0.5 / num3;
			result.X = 0.5 * num3;
			result.Y = (matrix.M01 + matrix.M10) * num4;
			result.Z = (matrix.M02 + matrix.M20) * num4;
			result.W = (matrix.M12 - matrix.M21) * num4;
		}
		else if (matrix.M11 > matrix.M22)
		{
			double num5 = Math.Sqrt(1.0 + matrix.M11 - matrix.M00 - matrix.M22);
			double num6 = 0.5 / num5;
			result.X = (matrix.M10 + matrix.M01) * num6;
			result.Y = 0.5 * num5;
			result.Z = (matrix.M21 + matrix.M12) * num6;
			result.W = (matrix.M20 - matrix.M02) * num6;
		}
		else
		{
			double num7 = Math.Sqrt(1.0 + matrix.M22 - matrix.M00 - matrix.M11);
			double num8 = 0.5 / num7;
			result.X = (matrix.M20 + matrix.M02) * num8;
			result.Y = (matrix.M21 + matrix.M12) * num8;
			result.Z = 0.5 * num7;
			result.W = (matrix.M01 - matrix.M10) * num8;
		}
		return result;
	}

	public Matrix4 ToMatrix()
	{
		return Matrix4.CreateFromQuaternion(this);
	}

	public override string ToString()
	{
		return $"{X},{Y},{Z},{W}";
	}

	public bool Equals(Quaternion other)
	{
		if (X == other.X && Y == other.Y && Z == other.Z)
		{
			return W == other.W;
		}
		return false;
	}

	public bool Equals(Quaternion other, int ndecimals)
	{
		if (Math.Round(X, ndecimals) == Math.Round(other.X, ndecimals) && Math.Round(Y, ndecimals) == Math.Round(other.Y, ndecimals) && Math.Round(Z, ndecimals) == Math.Round(other.Z, ndecimals))
		{
			return Math.Round(W, ndecimals) == Math.Round(other.W, ndecimals);
		}
		return false;
	}
}
