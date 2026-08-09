using System;
using System.Text;
using System.Threading;

namespace CSMath;

public struct Matrix3
{
	public static readonly Matrix3 Zero;

	public static readonly Matrix3 Identity;

	public double M00;

	public double M01;

	public double M02;

	public double M10;

	public double M11;

	public double M12;

	public double M20;

	public double M21;

	public double M22;

	public double this[int index]
	{
		get
		{
			return index switch
			{
				0 => M00, 
				1 => M01, 
				2 => M02, 
				3 => M10, 
				4 => M11, 
				5 => M12, 
				6 => M20, 
				7 => M21, 
				8 => M22, 
				_ => throw new IndexOutOfRangeException(), 
			};
		}
		set
		{
			switch (index)
			{
			case 0:
				M00 = value;
				break;
			case 1:
				M01 = value;
				break;
			case 2:
				M02 = value;
				break;
			case 3:
				M10 = value;
				break;
			case 4:
				M11 = value;
				break;
			case 5:
				M12 = value;
				break;
			case 6:
				M20 = value;
				break;
			case 7:
				M21 = value;
				break;
			case 8:
				M22 = value;
				break;
			default:
				throw new IndexOutOfRangeException();
			}
		}
	}

	public double this[int column, int row]
	{
		get
		{
			return this[column * 3 + row];
		}
		set
		{
			this[column * 3 + row] = value;
		}
	}

	public Matrix3(double m00, double m10, double m20, double m01, double m11, double m21, double m02, double m12, double m22)
	{
		M00 = m00;
		M01 = m01;
		M02 = m02;
		M10 = m10;
		M11 = m11;
		M12 = m12;
		M20 = m20;
		M21 = m21;
		M22 = m22;
	}

	public Matrix3(Matrix4 matrix)
	{
		M00 = matrix.M00;
		M01 = matrix.M01;
		M02 = matrix.M02;
		M10 = matrix.M10;
		M11 = matrix.M11;
		M12 = matrix.M12;
		M20 = matrix.M20;
		M21 = matrix.M21;
		M22 = matrix.M22;
	}

	public Matrix3 Transpose()
	{
		return new Matrix3(M00, M10, M20, M01, M11, M21, M02, M12, M22);
	}

	public static Matrix3 ArbitraryAxis(XYZ zAxis)
	{
		zAxis.Normalize();
		if (zAxis.Equals(XYZ.AxisZ))
		{
			return Identity;
		}
		XYZ axisY = XYZ.AxisY;
		XYZ axisZ = XYZ.AxisZ;
		XYZ xYZ = ((!(Math.Abs(zAxis.X) < 1.0 / 64.0) || !(Math.Abs(zAxis.Y) < 1.0 / 64.0)) ? XYZ.Cross(axisZ, zAxis) : XYZ.Cross(axisY, zAxis));
		xYZ.Normalize();
		XYZ vector = XYZ.Cross(zAxis, xYZ);
		vector.Normalize();
		return new Matrix3(xYZ.X, vector.X, zAxis.X, xYZ.Y, vector.Y, zAxis.Y, xYZ.Z, vector.Z, zAxis.Z);
	}

	public static Matrix3 RotationZ(double angle)
	{
		double num = Math.Cos(angle);
		double num2 = Math.Sin(angle);
		return new Matrix3(num, 0.0 - num2, 0.0, num2, num, 0.0, 0.0, 0.0, 1.0);
	}

	public override string ToString()
	{
		string listSeparator = Thread.CurrentThread.CurrentCulture.TextInfo.ListSeparator;
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(string.Format("|{0}{3} {1}{3} {2}|" + Environment.NewLine, M00, M01, M02, listSeparator));
		stringBuilder.Append(string.Format("|{0}{3} {1}{3} {2}|" + Environment.NewLine, M10, M11, M12, listSeparator));
		stringBuilder.Append(string.Format("|{0}{3} {1}{3} {2}|", M20, M21, M22, listSeparator));
		return stringBuilder.ToString();
	}

	public static XYZ operator *(Matrix3 matrix, XYZ value)
	{
		return new XYZ(matrix.M00 * value.X + matrix.M01 * value.Y + matrix.M02 * value.Z, matrix.M10 * value.X + matrix.M11 * value.Y + matrix.M12 * value.Z, matrix.M20 * value.X + matrix.M21 * value.Y + matrix.M22 * value.Z);
	}

	public static Matrix3 operator *(Matrix3 a, Matrix3 b)
	{
		return new Matrix3(a.M00 * b.M00 + a.M01 * b.M10 + a.M02 * b.M20, a.M00 * b.M01 + a.M01 * b.M11 + a.M02 * b.M21, a.M00 * b.M02 + a.M01 * b.M12 + a.M02 * b.M22, a.M10 * b.M00 + a.M11 * b.M10 + a.M12 * b.M20, a.M10 * b.M01 + a.M11 * b.M11 + a.M12 * b.M21, a.M10 * b.M02 + a.M11 * b.M12 + a.M12 * b.M22, a.M20 * b.M00 + a.M21 * b.M10 + a.M22 * b.M20, a.M20 * b.M01 + a.M21 * b.M11 + a.M22 * b.M21, a.M20 * b.M02 + a.M21 * b.M12 + a.M22 * b.M22);
	}

	static Matrix3()
	{
		Zero = new Matrix3(0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);
		Identity = new Matrix3(1.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 1.0);
	}
}
