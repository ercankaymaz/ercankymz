using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CSMath;

public struct Matrix4
{
	public static readonly Matrix4 Identity = new Matrix4(1.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0);

	public static readonly Matrix4 Zero = new Matrix4(0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);

	public double M00;

	public double M01;

	public double M02;

	public double M03;

	public double M10;

	public double M11;

	public double M12;

	public double M13;

	public double M20;

	public double M21;

	public double M22;

	public double M23;

	public double M30;

	public double M31;

	public double M32;

	public double M33;

	public double this[int index]
	{
		get
		{
			return index switch
			{
				0 => M00, 
				1 => M01, 
				2 => M02, 
				3 => M03, 
				4 => M10, 
				5 => M11, 
				6 => M12, 
				7 => M13, 
				8 => M20, 
				9 => M21, 
				10 => M22, 
				11 => M23, 
				12 => M30, 
				13 => M31, 
				14 => M32, 
				15 => M33, 
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
				M03 = value;
				break;
			case 4:
				M10 = value;
				break;
			case 5:
				M11 = value;
				break;
			case 6:
				M12 = value;
				break;
			case 7:
				M13 = value;
				break;
			case 8:
				M20 = value;
				break;
			case 9:
				M21 = value;
				break;
			case 10:
				M22 = value;
				break;
			case 11:
				M23 = value;
				break;
			case 12:
				M30 = value;
				break;
			case 13:
				M31 = value;
				break;
			case 14:
				M32 = value;
				break;
			case 15:
				M33 = value;
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
			return this[column * 4 + row];
		}
		set
		{
			this[column * 4 + row] = value;
		}
	}

	public Matrix4(double m00, double m10, double m20, double m30, double m01, double m11, double m21, double m31, double m02, double m12, double m22, double m32, double m03, double m13, double m23, double m33)
	{
		M00 = m00;
		M01 = m01;
		M02 = m02;
		M03 = m03;
		M10 = m10;
		M11 = m11;
		M12 = m12;
		M13 = m13;
		M20 = m20;
		M21 = m21;
		M22 = m22;
		M23 = m23;
		M30 = m30;
		M31 = m31;
		M32 = m32;
		M33 = m33;
	}

	public Matrix4(double[] elements)
		: this(elements[0], elements[1], elements[2], elements[3], elements[4], elements[5], elements[6], elements[7], elements[8], elements[9], elements[10], elements[11], elements[12], elements[13], elements[14], elements[15])
	{
	}

	public static Matrix4 CreateFromAxisAngle(XYZ axis, double angle)
	{
		axis = axis.Normalize();
		double x = axis.X;
		double y = axis.Y;
		double z = axis.Z;
		double num = Math.Sin(angle);
		double num2 = Math.Cos(angle);
		double num3 = x * x;
		double num4 = y * y;
		double num5 = z * z;
		double num6 = x * y;
		double num7 = x * z;
		double num8 = y * z;
		return new Matrix4
		{
			M00 = num3 + num2 * (1.0 - num3),
			M01 = num6 - num2 * num6 + num * z,
			M02 = num7 - num2 * num7 - num * y,
			M03 = 0.0,
			M10 = num6 - num2 * num6 - num * z,
			M11 = num4 + num2 * (1.0 - num4),
			M12 = num8 - num2 * num8 + num * x,
			M13 = 0.0,
			M20 = num7 - num2 * num7 + num * y,
			M21 = num8 - num2 * num8 - num * x,
			M22 = num5 + num2 * (1.0 - num5),
			M23 = 0.0,
			M30 = 0.0,
			M31 = 0.0,
			M32 = 0.0,
			M33 = 1.0
		};
	}

	public static Matrix4 CreateFromQuaternion(Quaternion quaternion)
	{
		double num = quaternion.X * quaternion.X;
		double num2 = quaternion.Y * quaternion.Y;
		double num3 = quaternion.Z * quaternion.Z;
		double num4 = quaternion.X * quaternion.Y;
		double num5 = quaternion.Z * quaternion.W;
		double num6 = quaternion.Z * quaternion.X;
		double num7 = quaternion.Y * quaternion.W;
		double num8 = quaternion.Y * quaternion.Z;
		double num9 = quaternion.X * quaternion.W;
		Matrix4 result = default(Matrix4);
		result.M00 = 1.0 - 2.0 * (num2 + num3);
		result.M01 = 2.0 * (num4 + num5);
		result.M02 = 2.0 * (num6 - num7);
		result.M03 = 0.0;
		result.M10 = 2.0 * (num4 - num5);
		result.M11 = 1.0 - 2.0 * (num3 + num);
		result.M12 = 2.0 * (num8 + num9);
		result.M13 = 0.0;
		result.M20 = 2.0 * (num6 + num7);
		result.M21 = 2.0 * (num8 - num9);
		result.M22 = 1.0 - 2.0 * (num2 + num);
		result.M23 = 0.0;
		result.M30 = 0.0;
		result.M31 = 0.0;
		result.M32 = 0.0;
		result.M33 = 1.0;
		return result;
	}

	public static Matrix4 CreateRotationMatrix(XYZ angles)
	{
		return CreateRotationMatrix(angles.X, angles.Y, angles.Z);
	}

	public static Matrix4 CreateRotationMatrix(double x, double y, double z)
	{
		double num = Math.Cos(x);
		double num2 = Math.Cos(y);
		double num3 = Math.Cos(z);
		double num4 = Math.Sin(x);
		double num5 = Math.Sin(y);
		double num6 = Math.Sin(z);
		Matrix4 matrix = new Matrix4(1.0, 0.0, 0.0, 0.0, 0.0, num, num4, 0.0, 0.0, 0.0 - num4, num, 0.0, 0.0, 0.0, 0.0, 1.0);
		Matrix4 matrix2 = new Matrix4(num2, 0.0, 0.0 - num5, 0.0, 0.0, 1.0, 0.0, 0.0, num5, 0.0, num2, 0.0, 0.0, 0.0, 0.0, 1.0);
		Matrix4 matrix3 = new Matrix4(num3, 0.0 - num6, 0.0, 0.0, num6, num3, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0);
		return matrix * matrix2 * matrix3;
	}

	public static Matrix4 CreateScale(XYZ scale)
	{
		return CreateScale(scale, XYZ.Zero);
	}

	public static Matrix4 CreateScale(XYZ scale, XYZ centerPoint)
	{
		double m = centerPoint.X * (1.0 - scale.X);
		double m2 = centerPoint.Y * (1.0 - scale.Y);
		double m3 = centerPoint.Z * (1.0 - scale.Z);
		Matrix4 result = default(Matrix4);
		result.M00 = scale.X;
		result.M01 = 0.0;
		result.M02 = 0.0;
		result.M03 = 0.0;
		result.M10 = 0.0;
		result.M11 = scale.Y;
		result.M12 = 0.0;
		result.M13 = 0.0;
		result.M20 = 0.0;
		result.M21 = 0.0;
		result.M22 = scale.Z;
		result.M23 = 0.0;
		result.M30 = m;
		result.M31 = m2;
		result.M32 = m3;
		result.M33 = 1.0;
		return result;
	}

	public static Matrix4 CreateScale(double scale)
	{
		return CreateScale(scale, XYZ.Zero);
	}

	public static Matrix4 CreateScale(double scale, XYZ centerPoint)
	{
		return CreateScale(new XYZ(scale), centerPoint);
	}

	public static Matrix4 CreateScalingMatrix(double x, double y, double z)
	{
		return new Matrix4(x, 0.0, 0.0, 0.0, 0.0, y, 0.0, 0.0, 0.0, 0.0, z, 0.0, 0.0, 0.0, 0.0, 1.0);
	}

	public static Matrix4 CreateTranslation(XYZ position)
	{
		return CreateTranslation(position.X, position.Y, position.Z);
	}

	public static Matrix4 CreateTranslation(double xPosition, double yPosition, double zPosition)
	{
		Matrix4 result = default(Matrix4);
		result.M00 = 1.0;
		result.M01 = 0.0;
		result.M02 = 0.0;
		result.M03 = 0.0;
		result.M10 = 0.0;
		result.M11 = 1.0;
		result.M12 = 0.0;
		result.M13 = 0.0;
		result.M20 = 0.0;
		result.M21 = 0.0;
		result.M22 = 1.0;
		result.M23 = 0.0;
		result.M30 = xPosition;
		result.M31 = yPosition;
		result.M32 = zPosition;
		result.M33 = 1.0;
		return result;
	}

	public static Matrix4 GetArbitraryAxis(XYZ zaxis)
	{
		zaxis = zaxis.Normalize();
		if (zaxis.Equals(XYZ.AxisZ))
		{
			return Identity;
		}
		if (zaxis.Equals(-XYZ.AxisZ))
		{
			return GetArbitraryAxis(-XYZ.AxisX, zaxis);
		}
		XYZ vector = ((!(Math.Abs(zaxis.X) < 0.0) || !(Math.Abs(zaxis.Y) < 0.0)) ? XYZ.Cross(XYZ.AxisZ, zaxis) : XYZ.Cross(XYZ.AxisY, zaxis));
		vector = vector.Normalize();
		return GetArbitraryAxis(vector, zaxis);
	}

	public static Matrix4 GetArbitraryAxis(XYZ xaxis, XYZ zaxis)
	{
		XYZ xYZ = XYZ.Cross(zaxis, xaxis);
		return new Matrix4(xaxis.X, xYZ.X, zaxis.X, 0.0, xaxis.Y, xYZ.Y, zaxis.Y, 0.0, xaxis.Z, xYZ.Z, zaxis.Z, 0.0, 0.0, 0.0, 0.0, 1.0);
	}

	public static bool Inverse(Matrix4 matrix, out Matrix4 result)
	{
		double m = matrix.M00;
		double m2 = matrix.M01;
		double m3 = matrix.M02;
		double m4 = matrix.M03;
		double m5 = matrix.M10;
		double m6 = matrix.M11;
		double m7 = matrix.M12;
		double m8 = matrix.M13;
		double m9 = matrix.M20;
		double m10 = matrix.M21;
		double m11 = matrix.M22;
		double m12 = matrix.M23;
		double m13 = matrix.M30;
		double m14 = matrix.M31;
		double m15 = matrix.M32;
		double m16 = matrix.M33;
		double num = m11 * m16 - m12 * m15;
		double num2 = m10 * m16 - m12 * m14;
		double num3 = m10 * m15 - m11 * m14;
		double num4 = m9 * m16 - m12 * m13;
		double num5 = m9 * m15 - m11 * m13;
		double num6 = m9 * m14 - m10 * m13;
		double num7 = m6 * num - m7 * num2 + m8 * num3;
		double num8 = 0.0 - (m5 * num - m7 * num4 + m8 * num5);
		double num9 = m5 * num2 - m6 * num4 + m8 * num6;
		double num10 = 0.0 - (m5 * num3 - m6 * num5 + m7 * num6);
		double num11 = m * num7 + m2 * num8 + m3 * num9 + m4 * num10;
		if (Math.Abs(num11) < double.Epsilon)
		{
			result = new Matrix4(double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN);
			return false;
		}
		double num12 = 1.0 / num11;
		result.M00 = num7 * num12;
		result.M10 = num8 * num12;
		result.M20 = num9 * num12;
		result.M30 = num10 * num12;
		result.M01 = (0.0 - (m2 * num - m3 * num2 + m4 * num3)) * num12;
		result.M11 = (m * num - m3 * num4 + m4 * num5) * num12;
		result.M21 = (0.0 - (m * num2 - m2 * num4 + m4 * num6)) * num12;
		result.M31 = (m * num3 - m2 * num5 + m3 * num6) * num12;
		double num13 = m7 * m16 - m8 * m15;
		double num14 = m6 * m16 - m8 * m14;
		double num15 = m6 * m15 - m7 * m14;
		double num16 = m5 * m16 - m8 * m13;
		double num17 = m5 * m15 - m7 * m13;
		double num18 = m5 * m14 - m6 * m13;
		result.M02 = (m2 * num13 - m3 * num14 + m4 * num15) * num12;
		result.M12 = (0.0 - (m * num13 - m3 * num16 + m4 * num17)) * num12;
		result.M22 = (m * num14 - m2 * num16 + m4 * num18) * num12;
		result.M32 = (0.0 - (m * num15 - m2 * num17 + m3 * num18)) * num12;
		double num19 = m7 * m12 - m8 * m11;
		double num20 = m6 * m12 - m8 * m10;
		double num21 = m6 * m11 - m7 * m10;
		double num22 = m5 * m12 - m8 * m9;
		double num23 = m5 * m11 - m7 * m9;
		double num24 = m5 * m10 - m6 * m9;
		result.M03 = (0.0 - (m2 * num19 - m3 * num20 + m4 * num21)) * num12;
		result.M13 = (m * num19 - m3 * num22 + m4 * num23) * num12;
		result.M23 = (0.0 - (m * num20 - m2 * num22 + m4 * num24)) * num12;
		result.M33 = (m * num21 - m2 * num23 + m3 * num24) * num12;
		return true;
	}

	public override bool Equals(object obj)
	{
		if (!(obj is Matrix4 matrix))
		{
			return false;
		}
		if (M00 == matrix.M00 && M11 == matrix.M11 && M22 == matrix.M22 && M33 == matrix.M33 && M01 == matrix.M01 && M02 == matrix.M02 && M03 == matrix.M03 && M10 == matrix.M10 && M12 == matrix.M12 && M13 == matrix.M13 && M20 == matrix.M20 && M21 == matrix.M21 && M23 == matrix.M23 && M30 == matrix.M30 && M31 == matrix.M31)
		{
			return M32 == matrix.M32;
		}
		return false;
	}

	public List<XYZM> GetCols()
	{
		return new List<XYZM>
		{
			new XYZM(M00, M01, M02, M03),
			new XYZM(M10, M11, M12, M13),
			new XYZM(M20, M21, M22, M23),
			new XYZM(M30, M31, M32, M33)
		};
	}

	public double GetDeterminant()
	{
		double m = M00;
		double m2 = M10;
		double m3 = M20;
		double m4 = M30;
		double m5 = M01;
		double m6 = M11;
		double m7 = M21;
		double m8 = M31;
		double m9 = M02;
		double m10 = M12;
		double m11 = M22;
		double m12 = M32;
		double m13 = M03;
		double m14 = M13;
		double m15 = M23;
		double m16 = M33;
		double num = m11 * m16 - m12 * m15;
		double num2 = m10 * m16 - m12 * m14;
		double num3 = m10 * m15 - m11 * m14;
		double num4 = m9 * m16 - m12 * m13;
		double num5 = m9 * m15 - m11 * m13;
		double num6 = m9 * m14 - m10 * m13;
		return m * (m6 * num - m7 * num2 + m8 * num3) - m2 * (m5 * num - m7 * num4 + m8 * num5) + m3 * (m5 * num2 - m6 * num4 + m8 * num6) - m4 * (m5 * num3 - m6 * num5 + m7 * num6);
	}

	public override int GetHashCode()
	{
		return M00.GetHashCode() + M01.GetHashCode() + M02.GetHashCode() + M03.GetHashCode() + M10.GetHashCode() + M11.GetHashCode() + M12.GetHashCode() + M13.GetHashCode() + M20.GetHashCode() + M21.GetHashCode() + M22.GetHashCode() + M23.GetHashCode() + M30.GetHashCode() + M31.GetHashCode() + M32.GetHashCode() + M33.GetHashCode();
	}

	public List<XYZM> GetRows()
	{
		return new List<XYZM>
		{
			new XYZM(M00, M10, M20, M30),
			new XYZM(M01, M11, M21, M31),
			new XYZM(M02, M12, M22, M32),
			new XYZM(M03, M13, M23, M33)
		};
	}

	public override string ToString()
	{
		string listSeparator = Thread.CurrentThread.CurrentCulture.TextInfo.ListSeparator;
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(string.Format("|{0}{4} {1}{4} {2}{4} {3}|" + Environment.NewLine, M00, M01, M02, M03, listSeparator));
		stringBuilder.Append(string.Format("|{0}{4} {1}{4} {2}{4} {3}|" + Environment.NewLine, M10, M11, M12, M13, listSeparator));
		stringBuilder.Append(string.Format("|{0}{4} {1}{4} {2}{4} {3}|" + Environment.NewLine, M20, M21, M22, M23, listSeparator));
		stringBuilder.Append(string.Format("|{0}{4} {1}{4} {2}{4} {3}|", M30, M31, M32, M33, listSeparator));
		return stringBuilder.ToString();
	}

	public Matrix4 Transpose()
	{
		Matrix4 result = default(Matrix4);
		result.M00 = M00;
		result.M01 = M10;
		result.M02 = M20;
		result.M03 = M30;
		result.M10 = M01;
		result.M11 = M11;
		result.M12 = M21;
		result.M13 = M31;
		result.M20 = M02;
		result.M21 = M12;
		result.M22 = M22;
		result.M23 = M32;
		result.M30 = M03;
		result.M31 = M13;
		result.M32 = M23;
		result.M33 = M33;
		return result;
	}

	public static Matrix4 Multiply(Matrix4 a, Matrix4 b)
	{
		Matrix4 result = default(Matrix4);
		List<XYZM> rows = a.GetRows();
		List<XYZM> cols = b.GetCols();
		result.M00 = rows[0].Dot(cols[0]);
		result.M10 = rows[0].Dot(cols[1]);
		result.M20 = rows[0].Dot(cols[2]);
		result.M30 = rows[0].Dot(cols[3]);
		result.M01 = rows[1].Dot(cols[0]);
		result.M11 = rows[1].Dot(cols[1]);
		result.M21 = rows[1].Dot(cols[2]);
		result.M31 = rows[1].Dot(cols[3]);
		result.M02 = rows[2].Dot(cols[0]);
		result.M12 = rows[2].Dot(cols[1]);
		result.M22 = rows[2].Dot(cols[2]);
		result.M32 = rows[2].Dot(cols[3]);
		result.M03 = rows[3].Dot(cols[0]);
		result.M13 = rows[3].Dot(cols[1]);
		result.M23 = rows[3].Dot(cols[2]);
		result.M33 = rows[3].Dot(cols[3]);
		return result;
	}

	public static Matrix4 operator *(Matrix4 a, Matrix4 b)
	{
		return Multiply(a, b);
	}

	public static XYZ operator *(Matrix4 matrix, XYZ value)
	{
		XYZM right = new XYZM(value.X, value.Y, value.Z, 1.0);
		List<XYZM> rows = matrix.GetRows();
		return new XYZ
		{
			X = rows[0].Dot(right),
			Y = rows[1].Dot(right),
			Z = rows[2].Dot(right)
		};
	}

	public static XYZM operator *(Matrix4 matrix, XYZM v)
	{
		return new XYZM(matrix.M00 * v.X + matrix.M10 * v.Y + matrix.M20 * v.Z + matrix.M30 * v.M, matrix.M01 * v.X + matrix.M11 * v.Y + matrix.M21 * v.Z + matrix.M31 * v.M, matrix.M02 * v.X + matrix.M12 * v.Y + matrix.M22 * v.Z + matrix.M32 * v.M, matrix.M03 * v.X + matrix.M13 * v.Y + matrix.M23 * v.Z + matrix.M33 * v.M);
	}
}
