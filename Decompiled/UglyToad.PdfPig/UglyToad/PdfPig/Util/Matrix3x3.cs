using System;
using System.Collections;
using System.Collections.Generic;

namespace UglyToad.PdfPig.Util;

internal sealed class Matrix3x3 : IEnumerable<double>, IEnumerable, IEquatable<Matrix3x3>
{
	public static readonly Matrix3x3 Identity = new Matrix3x3(1.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 1.0);

	private readonly double m11;

	private readonly double m12;

	private readonly double m13;

	private readonly double m21;

	private readonly double m22;

	private readonly double m23;

	private readonly double m31;

	private readonly double m32;

	private readonly double m33;

	public Matrix3x3(double m11, double m12, double m13, double m21, double m22, double m23, double m31, double m32, double m33)
	{
		this.m11 = m11;
		this.m12 = m12;
		this.m13 = m13;
		this.m21 = m21;
		this.m22 = m22;
		this.m23 = m23;
		this.m31 = m31;
		this.m32 = m32;
		this.m33 = m33;
	}

	public IEnumerator<double> GetEnumerator()
	{
		yield return m11;
		yield return m12;
		yield return m13;
		yield return m21;
		yield return m22;
		yield return m23;
		yield return m31;
		yield return m32;
		yield return m33;
	}

	public Matrix3x3 Inverse()
	{
		double determinant = GetDeterminant();
		if (determinant == 0.0)
		{
			throw new InvalidOperationException("May not inverse a matrix with a determinant of 0.");
		}
		Matrix3x3 matrix3x = Transpose();
		double num = matrix3x.m22 * matrix3x.m33 - matrix3x.m23 * matrix3x.m32;
		double num2 = matrix3x.m21 * matrix3x.m33 - matrix3x.m23 * matrix3x.m31;
		double num3 = matrix3x.m21 * matrix3x.m32 - matrix3x.m22 * matrix3x.m31;
		double num4 = matrix3x.m12 * matrix3x.m33 - matrix3x.m13 * matrix3x.m32;
		double num5 = matrix3x.m11 * matrix3x.m33 - matrix3x.m13 * matrix3x.m31;
		double num6 = matrix3x.m11 * matrix3x.m32 - matrix3x.m12 * matrix3x.m31;
		double num7 = matrix3x.m12 * matrix3x.m23 - matrix3x.m13 * matrix3x.m22;
		double num8 = matrix3x.m11 * matrix3x.m23 - matrix3x.m13 * matrix3x.m21;
		double num9 = matrix3x.m11 * matrix3x.m22 - matrix3x.m12 * matrix3x.m21;
		return new Matrix3x3(num, 0.0 - num2, num3, 0.0 - num4, num5, 0.0 - num6, num7, 0.0 - num8, num9).Multiply(1.0 / determinant);
	}

	public Matrix3x3 Multiply(double factor)
	{
		return new Matrix3x3(m11 * factor, m12 * factor, m13 * factor, m21 * factor, m22 * factor, m23 * factor, m31 * factor, m32 * factor, m33 * factor);
	}

	public (double, double, double) Multiply((double, double, double) vector)
	{
		return (m11 * vector.Item1 + m12 * vector.Item2 + m13 * vector.Item3, m21 * vector.Item1 + m22 * vector.Item2 + m23 * vector.Item3, m31 * vector.Item1 + m32 * vector.Item2 + m33 * vector.Item3);
	}

	public Matrix3x3 Multiply(Matrix3x3 matrix)
	{
		return new Matrix3x3(m11 * matrix.m11 + m12 * matrix.m21 + m13 * matrix.m31, m11 * matrix.m12 + m12 * matrix.m22 + m13 * matrix.m32, m11 * matrix.m13 + m12 * matrix.m23 + m13 * matrix.m33, m21 * matrix.m11 + m22 * matrix.m21 + m23 * matrix.m31, m21 * matrix.m12 + m22 * matrix.m22 + m23 * matrix.m32, m21 * matrix.m13 + m22 * matrix.m23 + m23 * matrix.m33, m31 * matrix.m11 + m32 * matrix.m21 + m33 * matrix.m31, m31 * matrix.m12 + m32 * matrix.m22 + m33 * matrix.m32, m31 * matrix.m13 + m32 * matrix.m23 + m33 * matrix.m33);
	}

	public Matrix3x3 Transpose()
	{
		return new Matrix3x3(m11, m21, m31, m12, m22, m32, m13, m23, m33);
	}

	public override bool Equals(object? obj)
	{
		if (obj is Matrix3x3 other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(Matrix3x3? other)
	{
		if (other == null)
		{
			return false;
		}
		if (this == other)
		{
			return true;
		}
		if (m11 == other.m11 && m12 == other.m12 && m13 == other.m13 && m21 == other.m21 && m22 == other.m22 && m23 == other.m23 && m31 == other.m31 && m32 == other.m32)
		{
			return m33 == other.m33;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (m11, m12, m13, m21, m22, m23, m31, m32, m33).GetHashCode();
	}

	private double GetDeterminant()
	{
		double num = m22 * m33 - m23 * m32;
		double num2 = m21 * m33 - m23 * m31;
		double num3 = m21 * m32 - m22 * m31;
		return m11 * num - m12 * num2 + m13 * num3;
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
