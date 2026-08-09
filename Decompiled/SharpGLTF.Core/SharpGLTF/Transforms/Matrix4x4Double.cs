using System;
using System.Diagnostics;
using System.Numerics;
using SharpGLTF.Diagnostics;

namespace SharpGLTF.Transforms;

[DebuggerTypeProxy(typeof(_Matrix4x4DoubleProxy))]
public struct Matrix4x4Double : IEquatable<Matrix4x4Double>
{
	private static readonly Matrix4x4Double _identity;

	public double M11;

	public double M12;

	public double M13;

	public double M14;

	public double M21;

	public double M22;

	public double M23;

	public double M24;

	public double M31;

	public double M32;

	public double M33;

	public double M34;

	public double M41;

	public double M42;

	public double M43;

	public double M44;

	public static Matrix4x4Double Identity => _identity;

	public (double x, double y, double z) Translation
	{
		get
		{
			return (x: M41, y: M42, z: M43);
		}
		set
		{
			(M41, M42, M43) = value;
		}
	}

	public Matrix4x4Double(double m11, double m12, double m13, double m14, double m21, double m22, double m23, double m24, double m31, double m32, double m33, double m34, double m41, double m42, double m43, double m44)
	{
		M11 = m11;
		M12 = m12;
		M13 = m13;
		M14 = m14;
		M21 = m21;
		M22 = m22;
		M23 = m23;
		M24 = m24;
		M31 = m31;
		M32 = m32;
		M33 = m33;
		M34 = m34;
		M41 = m41;
		M42 = m42;
		M43 = m43;
		M44 = m44;
	}

	public Matrix4x4Double(Matrix4x4 other)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		M11 = other.M11;
		M12 = other.M12;
		M13 = other.M13;
		M14 = other.M14;
		M21 = other.M21;
		M22 = other.M22;
		M23 = other.M23;
		M24 = other.M24;
		M31 = other.M31;
		M32 = other.M32;
		M33 = other.M33;
		M34 = other.M34;
		M41 = other.M41;
		M42 = other.M42;
		M43 = other.M43;
		M44 = other.M44;
	}

	public static Matrix4x4Double CreateTranslation(double xPosition, double yPosition, double zPosition)
	{
		Matrix4x4Double result = default(Matrix4x4Double);
		result.M11 = 1.0;
		result.M12 = 0.0;
		result.M13 = 0.0;
		result.M14 = 0.0;
		result.M21 = 0.0;
		result.M22 = 1.0;
		result.M23 = 0.0;
		result.M24 = 0.0;
		result.M31 = 0.0;
		result.M32 = 0.0;
		result.M33 = 1.0;
		result.M34 = 0.0;
		result.M41 = xPosition;
		result.M42 = yPosition;
		result.M43 = zPosition;
		result.M44 = 1.0;
		return result;
	}

	public static Matrix4x4Double CreateScale(double xScale, double yScale, double zScale)
	{
		Matrix4x4Double result = default(Matrix4x4Double);
		result.M11 = xScale;
		result.M12 = 0.0;
		result.M13 = 0.0;
		result.M14 = 0.0;
		result.M21 = 0.0;
		result.M22 = yScale;
		result.M23 = 0.0;
		result.M24 = 0.0;
		result.M31 = 0.0;
		result.M32 = 0.0;
		result.M33 = zScale;
		result.M34 = 0.0;
		result.M41 = 0.0;
		result.M42 = 0.0;
		result.M43 = 0.0;
		result.M44 = 1.0;
		return result;
	}

	public static Matrix4x4Double CreateFromQuaternion(Quaternion quaternion)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		double num = quaternion.X;
		double num2 = quaternion.Y;
		double num3 = quaternion.Z;
		double num4 = quaternion.W;
		double num5 = num * num;
		double num6 = num2 * num2;
		double num7 = num3 * num3;
		double num8 = num * num2;
		double num9 = num3 * num4;
		double num10 = num3 * num;
		double num11 = num2 * num4;
		double num12 = num2 * num3;
		double num13 = num * num4;
		Matrix4x4Double result = default(Matrix4x4Double);
		result.M11 = 1.0 - 2.0 * (num6 + num7);
		result.M12 = 2.0 * (num8 + num9);
		result.M13 = 2.0 * (num10 - num11);
		result.M14 = 0.0;
		result.M21 = 2.0 * (num8 - num9);
		result.M22 = 1.0 - 2.0 * (num7 + num5);
		result.M23 = 2.0 * (num12 + num13);
		result.M24 = 0.0;
		result.M31 = 2.0 * (num10 + num11);
		result.M32 = 2.0 * (num12 - num13);
		result.M33 = 1.0 - 2.0 * (num6 + num5);
		result.M34 = 0.0;
		result.M41 = 0.0;
		result.M42 = 0.0;
		result.M43 = 0.0;
		result.M44 = 1.0;
		return result;
	}

	public static explicit operator Matrix4x4(Matrix4x4Double mat)
	{
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		return new Matrix4x4((float)mat.M11, (float)mat.M12, (float)mat.M13, (float)mat.M14, (float)mat.M21, (float)mat.M22, (float)mat.M23, (float)mat.M24, (float)mat.M31, (float)mat.M32, (float)mat.M33, (float)mat.M34, (float)mat.M41, (float)mat.M42, (float)mat.M43, (float)mat.M44);
	}

	public static implicit operator Matrix4x4Double(Matrix4x4 mat)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		return new Matrix4x4Double(mat.M11, mat.M12, mat.M13, mat.M14, mat.M21, mat.M22, mat.M23, mat.M24, mat.M31, mat.M32, mat.M33, mat.M34, mat.M41, mat.M42, mat.M43, mat.M44);
	}

	public override readonly int GetHashCode()
	{
		double m = M11;
		int hashCode = m.GetHashCode();
		m = M12;
		int num = hashCode + m.GetHashCode();
		m = M13;
		int num2 = num + m.GetHashCode();
		m = M14;
		int num3 = num2 + m.GetHashCode();
		m = M21;
		int num4 = num3 + m.GetHashCode();
		m = M22;
		int num5 = num4 + m.GetHashCode();
		m = M23;
		int num6 = num5 + m.GetHashCode();
		m = M24;
		int num7 = num6 + m.GetHashCode();
		m = M31;
		int num8 = num7 + m.GetHashCode();
		m = M32;
		int num9 = num8 + m.GetHashCode();
		m = M33;
		int num10 = num9 + m.GetHashCode();
		m = M34;
		int num11 = num10 + m.GetHashCode();
		m = M41;
		int num12 = num11 + m.GetHashCode();
		m = M42;
		int num13 = num12 + m.GetHashCode();
		m = M43;
		int num14 = num13 + m.GetHashCode();
		m = M44;
		return num14 + m.GetHashCode();
	}

	public static bool operator ==(Matrix4x4Double value1, Matrix4x4Double value2)
	{
		if (value1.M11 == value2.M11 && value1.M22 == value2.M22 && value1.M33 == value2.M33 && value1.M44 == value2.M44 && value1.M12 == value2.M12 && value1.M13 == value2.M13 && value1.M14 == value2.M14 && value1.M21 == value2.M21 && value1.M23 == value2.M23 && value1.M24 == value2.M24 && value1.M31 == value2.M31 && value1.M32 == value2.M32 && value1.M34 == value2.M34 && value1.M41 == value2.M41 && value1.M42 == value2.M42)
		{
			return value1.M43 == value2.M43;
		}
		return false;
	}

	public static bool operator !=(Matrix4x4Double value1, Matrix4x4Double value2)
	{
		if (value1.M11 == value2.M11 && value1.M12 == value2.M12 && value1.M13 == value2.M13 && value1.M14 == value2.M14 && value1.M21 == value2.M21 && value1.M22 == value2.M22 && value1.M23 == value2.M23 && value1.M24 == value2.M24 && value1.M31 == value2.M31 && value1.M32 == value2.M32 && value1.M33 == value2.M33 && value1.M34 == value2.M34 && value1.M41 == value2.M41 && value1.M42 == value2.M42 && value1.M43 == value2.M43)
		{
			return value1.M44 != value2.M44;
		}
		return true;
	}

	public readonly bool Equals(Matrix4x4Double other)
	{
		return this == other;
	}

	public override readonly bool Equals(object obj)
	{
		if (obj is Matrix4x4Double matrix4x4Double)
		{
			return this == matrix4x4Double;
		}
		return false;
	}

	public static bool Invert(Matrix4x4Double matrix, out Matrix4x4Double result)
	{
		double m = matrix.M11;
		double m2 = matrix.M12;
		double m3 = matrix.M13;
		double m4 = matrix.M14;
		double m5 = matrix.M21;
		double m6 = matrix.M22;
		double m7 = matrix.M23;
		double m8 = matrix.M24;
		double m9 = matrix.M31;
		double m10 = matrix.M32;
		double m11 = matrix.M33;
		double m12 = matrix.M34;
		double m13 = matrix.M41;
		double m14 = matrix.M42;
		double m15 = matrix.M43;
		double m16 = matrix.M44;
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
			result = new Matrix4x4Double(double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN);
			return false;
		}
		double num12 = 1.0 / num11;
		result.M11 = num7 * num12;
		result.M21 = num8 * num12;
		result.M31 = num9 * num12;
		result.M41 = num10 * num12;
		result.M12 = (0.0 - (m2 * num - m3 * num2 + m4 * num3)) * num12;
		result.M22 = (m * num - m3 * num4 + m4 * num5) * num12;
		result.M32 = (0.0 - (m * num2 - m2 * num4 + m4 * num6)) * num12;
		result.M42 = (m * num3 - m2 * num5 + m3 * num6) * num12;
		double num13 = m7 * m16 - m8 * m15;
		double num14 = m6 * m16 - m8 * m14;
		double num15 = m6 * m15 - m7 * m14;
		double num16 = m5 * m16 - m8 * m13;
		double num17 = m5 * m15 - m7 * m13;
		double num18 = m5 * m14 - m6 * m13;
		result.M13 = (m2 * num13 - m3 * num14 + m4 * num15) * num12;
		result.M23 = (0.0 - (m * num13 - m3 * num16 + m4 * num17)) * num12;
		result.M33 = (m * num14 - m2 * num16 + m4 * num18) * num12;
		result.M43 = (0.0 - (m * num15 - m2 * num17 + m3 * num18)) * num12;
		double num19 = m7 * m12 - m8 * m11;
		double num20 = m6 * m12 - m8 * m10;
		double num21 = m6 * m11 - m7 * m10;
		double num22 = m5 * m12 - m8 * m9;
		double num23 = m5 * m11 - m7 * m9;
		double num24 = m5 * m10 - m6 * m9;
		result.M14 = (0.0 - (m2 * num19 - m3 * num20 + m4 * num21)) * num12;
		result.M24 = (m * num19 - m3 * num22 + m4 * num23) * num12;
		result.M34 = (0.0 - (m * num20 - m2 * num22 + m4 * num24)) * num12;
		result.M44 = (m * num21 - m2 * num23 + m3 * num24) * num12;
		return true;
	}

	public static Matrix4x4Double Multiply(Matrix4x4Double value1, Matrix4x4Double value2)
	{
		return value1 * value2;
	}

	public static Matrix4x4Double operator *(Matrix4x4Double value1, Matrix4x4Double value2)
	{
		Matrix4x4Double result = default(Matrix4x4Double);
		result.M11 = value1.M11 * value2.M11 + value1.M12 * value2.M21 + value1.M13 * value2.M31 + value1.M14 * value2.M41;
		result.M12 = value1.M11 * value2.M12 + value1.M12 * value2.M22 + value1.M13 * value2.M32 + value1.M14 * value2.M42;
		result.M13 = value1.M11 * value2.M13 + value1.M12 * value2.M23 + value1.M13 * value2.M33 + value1.M14 * value2.M43;
		result.M14 = value1.M11 * value2.M14 + value1.M12 * value2.M24 + value1.M13 * value2.M34 + value1.M14 * value2.M44;
		result.M21 = value1.M21 * value2.M11 + value1.M22 * value2.M21 + value1.M23 * value2.M31 + value1.M24 * value2.M41;
		result.M22 = value1.M21 * value2.M12 + value1.M22 * value2.M22 + value1.M23 * value2.M32 + value1.M24 * value2.M42;
		result.M23 = value1.M21 * value2.M13 + value1.M22 * value2.M23 + value1.M23 * value2.M33 + value1.M24 * value2.M43;
		result.M24 = value1.M21 * value2.M14 + value1.M22 * value2.M24 + value1.M23 * value2.M34 + value1.M24 * value2.M44;
		result.M31 = value1.M31 * value2.M11 + value1.M32 * value2.M21 + value1.M33 * value2.M31 + value1.M34 * value2.M41;
		result.M32 = value1.M31 * value2.M12 + value1.M32 * value2.M22 + value1.M33 * value2.M32 + value1.M34 * value2.M42;
		result.M33 = value1.M31 * value2.M13 + value1.M32 * value2.M23 + value1.M33 * value2.M33 + value1.M34 * value2.M43;
		result.M34 = value1.M31 * value2.M14 + value1.M32 * value2.M24 + value1.M33 * value2.M34 + value1.M34 * value2.M44;
		result.M41 = value1.M41 * value2.M11 + value1.M42 * value2.M21 + value1.M43 * value2.M31 + value1.M44 * value2.M41;
		result.M42 = value1.M41 * value2.M12 + value1.M42 * value2.M22 + value1.M43 * value2.M32 + value1.M44 * value2.M42;
		result.M43 = value1.M41 * value2.M13 + value1.M42 * value2.M23 + value1.M43 * value2.M33 + value1.M44 * value2.M43;
		result.M44 = value1.M41 * value2.M14 + value1.M42 * value2.M24 + value1.M43 * value2.M34 + value1.M44 * value2.M44;
		return result;
	}

	static Matrix4x4Double()
	{
		_identity = new Matrix4x4Double(1.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0);
	}
}
