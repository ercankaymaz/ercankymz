using System;
using System.ComponentModel;
using System.Globalization;
using devDept.Eyeshot;
using devDept.Geometry.Converters;
using devDept.Serialization;

namespace devDept.Geometry;

[Serializable]
[TypeConverter(typeof(QuaternionConverter))]
public class Quaternion : ICloneable
{
	public double X;

	public double Y;

	public double Z;

	public double W;

	public static Quaternion Identity => new Quaternion(0.0, 0.0, 0.0, 1.0);

	public Quaternion(double x, double y, double z, double w)
	{
		X = x;
		Y = y;
		Z = z;
		W = w;
	}

	public Quaternion(Vector3D rotAxis, double rotAngleInDegrees)
	{
		FromAxisAngle(rotAxis, rotAngleInDegrees);
	}

	public Quaternion(double[,] rotMatrix)
	{
		double num = rotMatrix[0, 0];
		double num2 = rotMatrix[0, 1];
		double num3 = rotMatrix[0, 2];
		double num4 = rotMatrix[1, 0];
		double num5 = rotMatrix[1, 1];
		double num6 = rotMatrix[1, 2];
		double num7 = rotMatrix[2, 0];
		double num8 = rotMatrix[2, 1];
		double num9 = rotMatrix[2, 2];
		double num10 = num + num5 + num9;
		if (num10 > 0.0)
		{
			double num11 = Math.Sqrt(num10 + 1.0) * 2.0;
			W = 0.25 * num11;
			X = (num8 - num6) / num11;
			Y = (num3 - num7) / num11;
			Z = (num4 - num2) / num11;
		}
		else if (num > num5 && num > num9)
		{
			double num12 = Math.Sqrt(1.0 + num - num5 - num9) * 2.0;
			W = (num8 - num6) / num12;
			X = 0.25 * num12;
			Y = (num2 + num4) / num12;
			Z = (num3 + num7) / num12;
		}
		else if (num5 > num9)
		{
			double num13 = Math.Sqrt(1.0 + num5 - num - num9) * 2.0;
			W = (num3 - num7) / num13;
			X = (num2 + num4) / num13;
			Y = 0.25 * num13;
			Z = (num6 + num8) / num13;
		}
		else
		{
			double num14 = Math.Sqrt(1.0 + num9 - num - num5) * 2.0;
			W = (num4 - num2) / num14;
			X = (num3 + num7) / num14;
			Y = (num6 + num8) / num14;
			Z = 0.25 * num14;
		}
	}

	public Quaternion(double yaw, double pitch, double roll)
	{
		double num = roll / 2.0;
		double num2 = Math.Cos(num);
		double num3 = Math.Sin(num);
		double num4 = pitch / 2.0;
		double num5 = Math.Cos(num4);
		double num6 = Math.Sin(num4);
		double num7 = yaw / 2.0;
		double num8 = Math.Cos(num7);
		double num9 = Math.Sin(num7);
		W = num2 * num5 * num8 + num3 * num6 * num9;
		X = num3 * num5 * num8 - num2 * num6 * num9;
		Y = num2 * num6 * num8 + num3 * num5 * num9;
		Z = num2 * num5 * num9 - num3 * num6 * num8;
	}

	protected Quaternion(Quaternion another)
	{
		X = another.X;
		Y = another.Y;
		Z = another.Z;
		W = another.W;
	}

	public void ToEulerAngles(out double yaw, out double pitch, out double roll)
	{
		double num = Y * Y;
		double y = 2.0 * (W * X + Y * Z);
		double x = 1.0 - 2.0 * (X * X + num);
		roll = Math.Atan2(y, x);
		double num2 = 2.0 * (W * Y - Z * X);
		num2 = ((num2 > 1.0) ? 1.0 : num2);
		num2 = ((num2 < -1.0) ? (-1.0) : num2);
		pitch = Math.Asin(num2);
		double y2 = 2.0 * (W * Z + X * Y);
		double x2 = 1.0 - 2.0 * (num + Z * Z);
		yaw = Math.Atan2(y2, x2);
	}

	public virtual object Clone()
	{
		return new Quaternion(this);
	}

	public virtual QuaternionSurrogate ConvertToSurrogate()
	{
		return new QuaternionSurrogate(this);
	}

	public void FromAxisAngle(Vector3D rotAxis, double rotAngleInDegrees)
	{
		if (rotAxis.IsZero)
		{
			X = (Y = (Z = 0.0));
			W = 1.0;
			return;
		}
		double num = Utility.DegToRad(rotAngleInDegrees) / 2.0;
		W = Math.Cos(num);
		double num2 = Math.Sin(num);
		X = rotAxis.X * num2;
		Y = rotAxis.Y * num2;
		Z = rotAxis.Z * num2;
		Normalize();
	}

	public void ToAxisAngle(out Vector3D rotAxis, out double rotAngleInDegrees)
	{
		double num = Math.Acos(W);
		double num2 = Math.Sin(num);
		rotAxis = Vector3D.AxisZ;
		if (num2 == 0.0)
		{
			rotAngleInDegrees = 0.0;
			rotAxis = Vector3D.AxisZ;
			return;
		}
		rotAngleInDegrees = Utility.RadToDeg(num * 2.0);
		rotAxis.X = X / num2;
		rotAxis.Y = Y / num2;
		rotAxis.Z = Z / num2;
		rotAxis.Normalize();
	}

	public void ToMatrix(out double[,] matrix)
	{
		matrix = new double[4, 4];
		matrix[0, 0] = 1.0 - 2.0 * (Y * Y + Z * Z);
		matrix[0, 1] = 2.0 * (X * Y - W * Z);
		matrix[0, 2] = 2.0 * (X * Z + W * Y);
		matrix[1, 0] = 2.0 * (X * Y + W * Z);
		matrix[1, 1] = 1.0 - 2.0 * (X * X + Z * Z);
		matrix[1, 2] = 2.0 * (Y * Z - W * X);
		matrix[2, 0] = 2.0 * (X * Z - W * Y);
		matrix[2, 1] = 2.0 * (Y * Z + W * X);
		matrix[2, 2] = 1.0 - 2.0 * (X * X + Y * Y);
		matrix[3, 3] = 1.0;
	}

	public void ToMatrixInverse(out double[,] matrix)
	{
		matrix = new double[4, 4];
		ToMatrix(out var matrix2);
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				matrix[i, j] = matrix2[j, i];
			}
		}
	}

	public bool Normalize()
	{
		double num = Math.Sqrt(X * X + Y * Y + Z * Z + W * W);
		if (num > 2.220446049250313E-16)
		{
			X /= num;
			Y /= num;
			Z /= num;
			W /= num;
			Utility.LimitRange(-1.0, ref W, 1.0);
			Utility.LimitRange(-1.0, ref X, 1.0);
			Utility.LimitRange(-1.0, ref Y, 1.0);
			Utility.LimitRange(-1.0, ref Z, 1.0);
			return true;
		}
		return false;
	}

	public static Quaternion operator *(Quaternion left, Quaternion right)
	{
		double w = right.W * left.W - right.X * left.X - right.Y * left.Y - right.Z * left.Z;
		double x = right.W * left.X + right.X * left.W + right.Y * left.Z - right.Z * left.Y;
		double y = right.W * left.Y + right.Y * left.W + right.Z * left.X - right.X * left.Z;
		double z = right.W * left.Z + right.Z * left.W + right.X * left.Y - right.Y * left.X;
		return new Quaternion(x, y, z, w);
	}

	public static Quaternion operator *(Quaternion left, double s)
	{
		return new Quaternion(s * left.X, s * left.Y, s * left.Z, s * left.W);
	}

	public static Quaternion operator *(double s, Quaternion right)
	{
		return new Quaternion(s * right.X, s * right.Y, s * right.Z, s * right.W);
	}

	public static Quaternion operator +(Quaternion left, Quaternion right)
	{
		return new Quaternion(left.X + right.X, left.Y + right.Y, left.Z + right.Z, left.W + right.W);
	}

	public override string ToString()
	{
		return X.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994676), CultureInfo.InvariantCulture.NumberFormat) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908108) + Y.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994676), CultureInfo.InvariantCulture.NumberFormat) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908108) + Z.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994676), CultureInfo.InvariantCulture.NumberFormat) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302660027) + W.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994676), CultureInfo.InvariantCulture.NumberFormat);
	}

	public bool Equals(Quaternion other)
	{
		if ((object)other == null)
		{
			return false;
		}
		if ((object)this == other)
		{
			return true;
		}
		if (Utility.Compare(other.X, X) == 0 && Utility.Compare(other.Y, Y) == 0 && Utility.Compare(other.Z, Z) == 0)
		{
			return Utility.Compare(other.W, W) == 0;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (this == obj)
		{
			return true;
		}
		if (obj.GetType() != typeof(Quaternion))
		{
			return false;
		}
		return Equals((Quaternion)obj);
	}

	public override int GetHashCode()
	{
		return (((((X.GetHashCode() * 397) ^ Y.GetHashCode()) * 397) ^ Z.GetHashCode()) * 397) ^ W.GetHashCode();
	}

	public static bool operator ==(Quaternion left, Quaternion right)
	{
		return object.Equals(left, right);
	}

	public static bool operator !=(Quaternion left, Quaternion right)
	{
		return !object.Equals(left, right);
	}

	public static implicit operator Quaternion(viewType view)
	{
		return Camera.GetViewRotation(view);
	}
}
