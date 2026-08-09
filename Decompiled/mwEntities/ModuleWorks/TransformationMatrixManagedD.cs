using System;
using System.Globalization;

namespace ModuleWorks;

public sealed class TransformationMatrixManagedD
{
	public static int IdxTransformX = 3;

	public static int IdxTransformY = 7;

	public static int IdxTransformZ = 11;

	private double _precision = 9.999999747378752E-06;

	private double[] values = new double[16];

	public double this[int row, int col]
	{
		get
		{
			return values[row * 4 + col];
		}
		set
		{
			values[row * 4 + col] = value;
		}
	}

	public double this[int idx]
	{
		get
		{
			return values[idx];
		}
		set
		{
			values[idx] = value;
		}
	}

	public TransformationMatrixManagedD()
		: this(loadIdentity: true)
	{
	}

	public TransformationMatrixManagedD(bool loadIdentity)
	{
		if (loadIdentity)
		{
			values[0] = 1.0;
			values[5] = 1.0;
			values[10] = 1.0;
			values[15] = 1.0;
		}
	}

	public TransformationMatrixManagedD(double v00, double v01, double v02, double v03, double v10, double v11, double v12, double v13, double v20, double v21, double v22, double v23, double v30, double v31, double v32, double v33)
	{
		values[0] = v00;
		values[1] = v01;
		values[2] = v02;
		values[3] = v03;
		values[4] = v10;
		values[5] = v11;
		values[6] = v12;
		values[7] = v13;
		values[8] = v20;
		values[9] = v21;
		values[10] = v22;
		values[11] = v23;
		values[12] = v30;
		values[13] = v31;
		values[14] = v32;
		values[15] = v33;
	}

	public TransformationMatrixManagedD(double[] values)
	{
		if (values.Length != 16)
		{
			throw new Exception("You need an array of 16 elements to create a TransformationMatrix.");
		}
		double[] array = this.values;
		array[0] = values[0];
		array[1] = values[1];
		array[2] = values[2];
		array[3] = values[3];
		array[4] = values[4];
		array[5] = values[5];
		array[6] = values[6];
		array[7] = values[7];
		array[8] = values[8];
		array[9] = values[9];
		array[10] = values[10];
		array[11] = values[11];
		array[12] = values[12];
		array[13] = values[13];
		array[14] = values[14];
		array[15] = values[15];
	}

	public TransformationMatrixManagedD(TransformationMatrixManagedD other)
	{
		double[] array = values;
		double[] array2 = other.values;
		array[0] = array2[0];
		array[1] = array2[1];
		array[2] = array2[2];
		array[3] = array2[3];
		array[4] = array2[4];
		array[5] = array2[5];
		array[6] = array2[6];
		array[7] = array2[7];
		array[8] = array2[8];
		array[9] = array2[9];
		array[10] = array2[10];
		array[11] = array2[11];
		array[12] = array2[12];
		array[13] = array2[13];
		array[14] = array2[14];
		array[15] = array2[15];
	}

	public static TransformationMatrixManagedD Create3dRotation(Vectord axis, double angle, AngleUnit angleType)
	{
		TransformationMatrixManagedD transformationMatrixManagedD = new TransformationMatrixManagedD(loadIdentity: false);
		Create3dRotation(transformationMatrixManagedD, axis, angle, angleType);
		return transformationMatrixManagedD;
	}

	public static void Create3dRotation(TransformationMatrixManagedD matrix, Vectord axis, double angle, AngleUnit angleType)
	{
		double num = angle;
		if (angleType == AngleUnit.Degree)
		{
			num *= Math.PI / 180.0;
		}
		axis.Normalize();
		double num2 = Math.Sin(num);
		double num3 = Math.Cos(num);
		double num4 = 1.0 - num3;
		double[] array = matrix.values;
		array[0] = num3 + axis.X * axis.X * num4;
		array[1] = axis.X * axis.Y * num4 - axis.Z * num2;
		array[2] = axis.X * axis.Z * num4 + axis.Y * num2;
		array[3] = 0.0;
		array[4] = axis.Y * axis.X * num4 + axis.Z * num2;
		array[5] = num3 + axis.Y * axis.Y * num4;
		array[6] = axis.Y * axis.Z * num4 - axis.X * num2;
		array[7] = 0.0;
		array[8] = axis.Z * axis.X * num4 - axis.Y * num2;
		array[9] = axis.Z * axis.Y * num4 + axis.X * num2;
		array[10] = num3 + axis.Z * axis.Z * num4;
		array[11] = 0.0;
		array[12] = 0.0;
		array[13] = 0.0;
		array[14] = 0.0;
		array[15] = 1.0;
	}

	public static TransformationMatrixManagedD Create3dRotation(Vectord axis, Point3d<double> rotationPoint, double angle, AngleUnit angleType)
	{
		TransformationMatrixManagedD result = new TransformationMatrixManagedD();
		Create3dRotation(result, axis, rotationPoint, angle, angleType);
		return result;
	}

	public static void Create3dRotation(TransformationMatrixManagedD result, Vectord axis, Point3d<double> rotationPoint, double angle, AngleUnit angleType)
	{
		double num = angle;
		if (angleType == AngleUnit.Degree)
		{
			num *= Math.PI / 180.0;
		}
		axis.Normalize();
		double num2 = Math.Sin(num);
		double num3 = Math.Cos(num);
		double num4 = 1.0 - num3;
		double num5 = num3 + axis.X * axis.X * num4;
		double num6 = axis.X * axis.Y * num4 - axis.Z * num2;
		double num7 = axis.X * axis.Z * num4 + axis.Y * num2;
		double num8 = axis.Y * axis.X * num4 + axis.Z * num2;
		double num9 = num3 + axis.Y * axis.Y * num4;
		double num10 = axis.Y * axis.Z * num4 - axis.X * num2;
		double num11 = axis.Z * axis.X * num4 - axis.Y * num2;
		double num12 = axis.Z * axis.Y * num4 + axis.X * num2;
		double num13 = num3 + axis.Z * axis.Z * num4;
		double x = rotationPoint.X;
		double y = rotationPoint.Y;
		double z = rotationPoint.Z;
		double num14 = 0.0 - x;
		double num15 = 0.0 - y;
		double num16 = 0.0 - z;
		double num17 = num5 * num14 + num6 * num15 + num7 * num16;
		double num18 = num8 * num14 + num9 * num15 + num10 * num16;
		double num19 = num11 * num14 + num12 * num15 + num13 * num16;
		double[] array = result.values;
		array[0] = num5;
		array[1] = num6;
		array[2] = num7;
		array[3] = num17 + x;
		array[4] = num8;
		array[5] = num9;
		array[6] = num10;
		array[7] = num18 + y;
		array[8] = num11;
		array[9] = num12;
		array[10] = num13;
		array[11] = num19 + z;
		array[12] = 0.0;
		array[13] = 0.0;
		array[14] = 0.0;
		array[15] = 1.0;
	}

	public static TransformationMatrixManagedD Create3dTranslation(Point3d<double> vector)
	{
		TransformationMatrixManagedD transformationMatrixManagedD = new TransformationMatrixManagedD(loadIdentity: false);
		Create3dTranslation(transformationMatrixManagedD, vector);
		return transformationMatrixManagedD;
	}

	public static TransformationMatrixManagedD Create3dTranslation(double x, double y, double z)
	{
		TransformationMatrixManagedD transformationMatrixManagedD = new TransformationMatrixManagedD(loadIdentity: false);
		Create3dTranslation(transformationMatrixManagedD, x, y, z);
		return transformationMatrixManagedD;
	}

	public static void Create3dTranslation(TransformationMatrixManagedD matrix, double x, double y, double z)
	{
		matrix.LoadIdentity();
		double[] array = matrix.values;
		array[3] = x;
		array[7] = y;
		array[11] = z;
	}

	public static void Create3dTranslation(TransformationMatrixManagedD matrix, Point3d<double> translation)
	{
		matrix.LoadIdentity();
		double[] array = matrix.values;
		array[3] = translation.X;
		array[7] = translation.Y;
		array[11] = translation.Z;
	}

	public static void Invert(TransformationMatrixManagedD source, TransformationMatrixManagedD dest)
	{
		for (int i = 0; i < 16; i++)
		{
			dest.values[i] = source.values[i];
		}
		dest.Invert();
	}

	public static void InvertAffine(TransformationMatrixManagedD source, TransformationMatrixManagedD dest)
	{
		for (int i = 0; i < 16; i++)
		{
			dest.values[i] = source.values[i];
		}
		dest.InvertAffine();
	}

	public static void MatrixMultiply(TransformationMatrixManagedD result, TransformationMatrixManagedD left, TransformationMatrixManagedD right)
	{
		double[] array = result.values;
		double[] array2 = left.values;
		double[] array3 = right.values;
		if (array2[0] == 1.0 && array2[5] == 1.0 && array2[10] == 1.0 && array3[0] == 1.0 && array3[5] == 1.0 && array3[10] == 1.0)
		{
			array[0] = (array[5] = (array[10] = (array[15] = 1.0)));
			array[1] = (array[2] = 0.0);
			array[4] = (array[6] = 0.0);
			array[8] = (array[9] = 0.0);
			array[12] = (array[13] = (array[14] = 0.0));
			array[3] = array2[3] + array3[3];
			array[7] = array2[7] + array3[7];
			array[11] = array2[11] + array3[11];
			return;
		}
		array[0] = array2[0] * array3[0] + array2[1] * array3[4] + array2[2] * array3[8] + array2[3] * array3[12];
		array[1] = array2[0] * array3[1] + array2[1] * array3[5] + array2[2] * array3[9] + array2[3] * array3[13];
		array[2] = array2[0] * array3[2] + array2[1] * array3[6] + array2[2] * array3[10] + array2[3] * array3[14];
		array[3] = array2[0] * array3[3] + array2[1] * array3[7] + array2[2] * array3[11] + array2[3] * array3[15];
		array[4] = array2[4] * array3[0] + array2[5] * array3[4] + array2[6] * array3[8] + array2[7] * array3[12];
		array[5] = array2[4] * array3[1] + array2[5] * array3[5] + array2[6] * array3[9] + array2[7] * array3[13];
		array[6] = array2[4] * array3[2] + array2[5] * array3[6] + array2[6] * array3[10] + array2[7] * array3[14];
		array[7] = array2[4] * array3[3] + array2[5] * array3[7] + array2[6] * array3[11] + array2[7] * array3[15];
		array[8] = array2[8] * array3[0] + array2[9] * array3[4] + array2[10] * array3[8] + array2[11] * array3[12];
		array[9] = array2[8] * array3[1] + array2[9] * array3[5] + array2[10] * array3[9] + array2[11] * array3[13];
		array[10] = array2[8] * array3[2] + array2[9] * array3[6] + array2[10] * array3[10] + array2[11] * array3[14];
		array[11] = array2[8] * array3[3] + array2[9] * array3[7] + array2[10] * array3[11] + array2[11] * array3[15];
		array[12] = array2[12] * array3[0] + array2[13] * array3[4] + array2[14] * array3[8] + array2[15] * array3[12];
		array[13] = array2[12] * array3[1] + array2[13] * array3[5] + array2[14] * array3[9] + array2[15] * array3[13];
		array[14] = array2[12] * array3[2] + array2[13] * array3[6] + array2[14] * array3[10] + array2[15] * array3[14];
		array[15] = array2[12] * array3[3] + array2[13] * array3[7] + array2[14] * array3[11] + array2[15] * array3[15];
	}

	public static void MultiplyTranslationOnto(TransformationMatrixManagedD destination, double tx, double ty, double tz)
	{
		double[] array = destination.values;
		double num = array[0] * tx + array[1] * ty + array[2] * tz + array[3] * 1.0;
		double num2 = array[4] * tx + array[5] * ty + array[6] * tz + array[7] * 1.0;
		double num3 = array[8] * tx + array[9] * ty + array[10] * tz + array[11] * 1.0;
		array[3] = num;
		array[7] = num2;
		array[11] = num3;
	}

	public static TransformationMatrixManagedD operator -(TransformationMatrixManagedD left, TransformationMatrixManagedD right)
	{
		TransformationMatrixManagedD transformationMatrixManagedD = new TransformationMatrixManagedD(loadIdentity: false);
		double[] array = left.values;
		double[] array2 = right.values;
		transformationMatrixManagedD.values[0] = array[0] - array2[0];
		transformationMatrixManagedD.values[1] = array[1] - array2[1];
		transformationMatrixManagedD.values[2] = array[2] - array2[2];
		transformationMatrixManagedD.values[3] = array[3] - array2[3];
		transformationMatrixManagedD.values[4] = array[4] - array2[4];
		transformationMatrixManagedD.values[5] = array[5] - array2[5];
		transformationMatrixManagedD.values[6] = array[6] - array2[6];
		transformationMatrixManagedD.values[7] = array[7] - array2[7];
		transformationMatrixManagedD.values[8] = array[8] - array2[8];
		transformationMatrixManagedD.values[9] = array[9] - array2[9];
		transformationMatrixManagedD.values[10] = array[10] - array2[10];
		transformationMatrixManagedD.values[11] = array[11] - array2[11];
		transformationMatrixManagedD.values[12] = array[12] - array2[12];
		transformationMatrixManagedD.values[13] = array[13] - array2[13];
		transformationMatrixManagedD.values[14] = array[14] - array2[14];
		transformationMatrixManagedD.values[15] = array[15] - array2[15];
		return transformationMatrixManagedD;
	}

	public static TransformationMatrixManagedD operator *(TransformationMatrixManagedD matrix, double scalar)
	{
		TransformationMatrixManagedD transformationMatrixManagedD = new TransformationMatrixManagedD(loadIdentity: false);
		double[] array = matrix.values;
		transformationMatrixManagedD.values[0] = array[0] * scalar;
		transformationMatrixManagedD.values[1] = array[1] * scalar;
		transformationMatrixManagedD.values[2] = array[2] * scalar;
		transformationMatrixManagedD.values[3] = array[3] * scalar;
		transformationMatrixManagedD.values[4] = array[4] * scalar;
		transformationMatrixManagedD.values[5] = array[5] * scalar;
		transformationMatrixManagedD.values[6] = array[6] * scalar;
		transformationMatrixManagedD.values[7] = array[7] * scalar;
		transformationMatrixManagedD.values[8] = array[8] * scalar;
		transformationMatrixManagedD.values[9] = array[9] * scalar;
		transformationMatrixManagedD.values[10] = array[10] * scalar;
		transformationMatrixManagedD.values[11] = array[11] * scalar;
		transformationMatrixManagedD.values[12] = array[12] * scalar;
		transformationMatrixManagedD.values[13] = array[13] * scalar;
		transformationMatrixManagedD.values[14] = array[14] * scalar;
		transformationMatrixManagedD.values[15] = array[15] * scalar;
		return transformationMatrixManagedD;
	}

	public static TransformationMatrixManagedD operator *(double scalar, TransformationMatrixManagedD matrix)
	{
		return matrix * scalar;
	}

	public static TransformationMatrixManagedD operator *(TransformationMatrixManagedD left, TransformationMatrixManagedD right)
	{
		TransformationMatrixManagedD result = new TransformationMatrixManagedD(loadIdentity: false);
		MatrixMultiply(result, left, right);
		return result;
	}

	public static TransformationMatrixManagedD operator +(TransformationMatrixManagedD left, TransformationMatrixManagedD right)
	{
		TransformationMatrixManagedD transformationMatrixManagedD = new TransformationMatrixManagedD(loadIdentity: false);
		double[] array = left.values;
		double[] array2 = right.values;
		transformationMatrixManagedD.values[0] = array[0] + array2[0];
		transformationMatrixManagedD.values[1] = array[1] + array2[1];
		transformationMatrixManagedD.values[2] = array[2] + array2[2];
		transformationMatrixManagedD.values[3] = array[3] + array2[3];
		transformationMatrixManagedD.values[4] = array[4] + array2[4];
		transformationMatrixManagedD.values[5] = array[5] + array2[5];
		transformationMatrixManagedD.values[6] = array[6] + array2[6];
		transformationMatrixManagedD.values[7] = array[7] + array2[7];
		transformationMatrixManagedD.values[8] = array[8] + array2[8];
		transformationMatrixManagedD.values[9] = array[9] + array2[9];
		transformationMatrixManagedD.values[10] = array[10] + array2[10];
		transformationMatrixManagedD.values[11] = array[11] + array2[11];
		transformationMatrixManagedD.values[12] = array[12] + array2[12];
		transformationMatrixManagedD.values[13] = array[13] + array2[13];
		transformationMatrixManagedD.values[14] = array[14] + array2[14];
		transformationMatrixManagedD.values[15] = array[15] + array2[15];
		return transformationMatrixManagedD;
	}

	public static Vectord TransformPoint(TransformationMatrixManagedD matrix, Vectord point)
	{
		double[] array = matrix.values;
		double x = array[0] * point.X + array[1] * point.Y + array[2] * point.Z + array[3];
		double y = array[4] * point.X + array[5] * point.Y + array[6] * point.Z + array[7];
		double z = array[8] * point.X + array[9] * point.Y + array[10] * point.Z + array[11];
		return new Vectord(x, y, z);
	}

	public static Vectord TransformVector(TransformationMatrixManagedD matrix, Vectord vector)
	{
		double[] array = matrix.values;
		double x = array[0] * vector.X + array[1] * vector.Y + array[2] * vector.Z;
		double y = array[4] * vector.X + array[5] * vector.Y + array[6] * vector.Z;
		double z = array[8] * vector.X + array[9] * vector.Y + array[10] * vector.Z;
		return new Vectord(x, y, z);
	}

	public void CopyFrom(TransformationMatrixManagedD other)
	{
		double[] array = values;
		double[] array2 = other.values;
		array[0] = array2[0];
		array[1] = array2[1];
		array[2] = array2[2];
		array[3] = array2[3];
		array[4] = array2[4];
		array[5] = array2[5];
		array[6] = array2[6];
		array[7] = array2[7];
		array[8] = array2[8];
		array[9] = array2[9];
		array[10] = array2[10];
		array[11] = array2[11];
		array[12] = array2[12];
		array[13] = array2[13];
		array[14] = array2[14];
		array[15] = array2[15];
	}

	public void CopyTo(TransformationMatrixManagedD other)
	{
		double[] array = other.values;
		double[] array2 = values;
		array[0] = array2[0];
		array[1] = array2[1];
		array[2] = array2[2];
		array[3] = array2[3];
		array[4] = array2[4];
		array[5] = array2[5];
		array[6] = array2[6];
		array[7] = array2[7];
		array[8] = array2[8];
		array[9] = array2[9];
		array[10] = array2[10];
		array[11] = array2[11];
		array[12] = array2[12];
		array[13] = array2[13];
		array[14] = array2[14];
		array[15] = array2[15];
	}

	public bool Equals(TransformationMatrixManagedD rhs)
	{
		return Equals(rhs, _precision);
	}

	public bool Equals(TransformationMatrixManagedD rhs, double prec)
	{
		if (rhs == null)
		{
			return false;
		}
		double[] array = rhs.values;
		bool result = true;
		for (int i = 0; i < 15; i++)
		{
			if (Math.Abs(values[i] - array[i]) > prec)
			{
				result = false;
				break;
			}
		}
		return result;
	}

	public override bool Equals(object obj)
	{
		return Equals(obj as TransformationMatrixManagedD);
	}

	public double[] GetData()
	{
		return values;
	}

	public override int GetHashCode()
	{
		int num = 0;
		for (int i = 0; i < 15; i++)
		{
			num |= values[i].GetHashCode();
		}
		return num;
	}

	public void Invert()
	{
		TransformationMatrixManagedD transformationMatrixManagedD = new TransformationMatrixManagedD(values);
		double num = transformationMatrixManagedD[0] * transformationMatrixManagedD[5] - transformationMatrixManagedD[4] * transformationMatrixManagedD[1];
		double num2 = transformationMatrixManagedD[0] * transformationMatrixManagedD[6] - transformationMatrixManagedD[4] * transformationMatrixManagedD[2];
		double num3 = transformationMatrixManagedD[0] * transformationMatrixManagedD[7] - transformationMatrixManagedD[4] * transformationMatrixManagedD[3];
		double num4 = transformationMatrixManagedD[1] * transformationMatrixManagedD[6] - transformationMatrixManagedD[5] * transformationMatrixManagedD[2];
		double num5 = transformationMatrixManagedD[1] * transformationMatrixManagedD[7] - transformationMatrixManagedD[5] * transformationMatrixManagedD[3];
		double num6 = transformationMatrixManagedD[2] * transformationMatrixManagedD[7] - transformationMatrixManagedD[6] * transformationMatrixManagedD[3];
		double num7 = transformationMatrixManagedD[10] * transformationMatrixManagedD[15] - transformationMatrixManagedD[14] * transformationMatrixManagedD[11];
		double num8 = transformationMatrixManagedD[9] * transformationMatrixManagedD[15] - transformationMatrixManagedD[13] * transformationMatrixManagedD[11];
		double num9 = transformationMatrixManagedD[9] * transformationMatrixManagedD[14] - transformationMatrixManagedD[13] * transformationMatrixManagedD[10];
		double num10 = transformationMatrixManagedD[8] * transformationMatrixManagedD[15] - transformationMatrixManagedD[12] * transformationMatrixManagedD[11];
		double num11 = transformationMatrixManagedD[8] * transformationMatrixManagedD[14] - transformationMatrixManagedD[12] * transformationMatrixManagedD[10];
		double num12 = transformationMatrixManagedD[8] * transformationMatrixManagedD[13] - transformationMatrixManagedD[12] * transformationMatrixManagedD[9];
		double num13 = 1.0 / (num * num7 - num2 * num8 + num3 * num9 + num4 * num10 - num5 * num11 + num6 * num12);
		values[0] = (transformationMatrixManagedD[5] * num7 - transformationMatrixManagedD[6] * num8 + transformationMatrixManagedD[7] * num9) * num13;
		values[1] = ((0.0 - transformationMatrixManagedD[1]) * num7 + transformationMatrixManagedD[2] * num8 - transformationMatrixManagedD[3] * num9) * num13;
		values[2] = (transformationMatrixManagedD[13] * num6 - transformationMatrixManagedD[14] * num5 + transformationMatrixManagedD[15] * num4) * num13;
		values[3] = ((0.0 - transformationMatrixManagedD[9]) * num6 + transformationMatrixManagedD[10] * num5 - transformationMatrixManagedD[11] * num4) * num13;
		values[4] = ((0.0 - transformationMatrixManagedD[4]) * num7 + transformationMatrixManagedD[6] * num10 - transformationMatrixManagedD[7] * num11) * num13;
		values[5] = (transformationMatrixManagedD[0] * num7 - transformationMatrixManagedD[2] * num10 + transformationMatrixManagedD[3] * num11) * num13;
		values[6] = ((0.0 - transformationMatrixManagedD[12]) * num6 + transformationMatrixManagedD[14] * num3 - transformationMatrixManagedD[15] * num2) * num13;
		values[7] = (transformationMatrixManagedD[8] * num6 - transformationMatrixManagedD[10] * num3 + transformationMatrixManagedD[11] * num2) * num13;
		values[8] = (transformationMatrixManagedD[4] * num8 - transformationMatrixManagedD[5] * num10 + transformationMatrixManagedD[7] * num12) * num13;
		values[9] = ((0.0 - transformationMatrixManagedD[0]) * num8 + transformationMatrixManagedD[1] * num10 - transformationMatrixManagedD[3] * num12) * num13;
		values[10] = (transformationMatrixManagedD[12] * num5 - transformationMatrixManagedD[13] * num3 + transformationMatrixManagedD[15] * num) * num13;
		values[11] = ((0.0 - transformationMatrixManagedD[8]) * num5 + transformationMatrixManagedD[9] * num3 - transformationMatrixManagedD[11] * num) * num13;
		values[12] = ((0.0 - transformationMatrixManagedD[4]) * num9 + transformationMatrixManagedD[5] * num11 - transformationMatrixManagedD[6] * num12) * num13;
		values[13] = (transformationMatrixManagedD[0] * num9 - transformationMatrixManagedD[1] * num11 + transformationMatrixManagedD[2] * num12) * num13;
		values[14] = ((0.0 - transformationMatrixManagedD[12]) * num4 + transformationMatrixManagedD[13] * num2 - transformationMatrixManagedD[14] * num) * num13;
		values[15] = (transformationMatrixManagedD[8] * num4 - transformationMatrixManagedD[9] * num2 + transformationMatrixManagedD[10] * num) * num13;
	}

	public void InvertAffine()
	{
		double num = values[3];
		double num2 = values[7];
		double num3 = values[11];
		values[3] = 0.0;
		values[7] = 0.0;
		values[11] = 0.0;
		double num4 = values[4];
		values[4] = values[1];
		values[1] = num4;
		num4 = values[8];
		values[8] = values[2];
		values[2] = num4;
		num4 = values[12];
		values[12] = values[3];
		values[3] = num4;
		num4 = values[9];
		values[9] = values[6];
		values[6] = num4;
		num4 = values[13];
		values[13] = values[7];
		values[7] = num4;
		num4 = values[14];
		values[14] = values[11];
		values[11] = num4;
		values[3] = (0.0 - values[0]) * num + (0.0 - values[1]) * num2 + (0.0 - values[2]) * num3;
		values[7] = (0.0 - values[4]) * num + (0.0 - values[5]) * num2 + (0.0 - values[6]) * num3;
		values[11] = (0.0 - values[8]) * num + (0.0 - values[9]) * num2 + (0.0 - values[10]) * num3;
	}

	public TransformationMatrixManagedD Inverted()
	{
		TransformationMatrixManagedD transformationMatrixManagedD = new TransformationMatrixManagedD(this);
		transformationMatrixManagedD.Invert();
		return transformationMatrixManagedD;
	}

	public TransformationMatrixManagedD InvertedAffine()
	{
		TransformationMatrixManagedD transformationMatrixManagedD = new TransformationMatrixManagedD(this);
		transformationMatrixManagedD.InvertAffine();
		return transformationMatrixManagedD;
	}

	public bool IsIdentity()
	{
		return IsIdentity(_precision);
	}

	public bool IsIdentity(double prec)
	{
		if (Math.Abs(values[0] - 1.0) < prec && Math.Abs(values[1] - 0.0) < prec && Math.Abs(values[2] - 0.0) < prec && Math.Abs(values[3] - 0.0) < prec && Math.Abs(values[4] - 0.0) < prec && Math.Abs(values[5] - 1.0) < prec && Math.Abs(values[6] - 0.0) < prec && Math.Abs(values[7] - 0.0) < prec && Math.Abs(values[8] - 0.0) < prec && Math.Abs(values[9] - 0.0) < prec && Math.Abs(values[10] - 1.0) < prec && Math.Abs(values[11] - 0.0) < prec && Math.Abs(values[12] - 0.0) < prec && Math.Abs(values[13] - 0.0) < prec && Math.Abs(values[14] - 0.0) < prec)
		{
			return Math.Abs(values[15] - 1.0) < prec;
		}
		return false;
	}

	public void LoadIdentity()
	{
		values[0] = 1.0;
		values[1] = 0.0;
		values[2] = 0.0;
		values[3] = 0.0;
		values[4] = 0.0;
		values[5] = 1.0;
		values[6] = 0.0;
		values[7] = 0.0;
		values[8] = 0.0;
		values[9] = 0.0;
		values[10] = 1.0;
		values[11] = 0.0;
		values[12] = 0.0;
		values[13] = 0.0;
		values[14] = 0.0;
		values[15] = 1.0;
	}

	public override string ToString()
	{
		return ToString(CultureInfo.InvariantCulture);
	}

	public string ToString(CultureInfo culture)
	{
		return string.Format(culture, "{0:0.000}; {1:0.000}; {2:0.000}; {3:0.000}; {4:0.000}; {5:0.000}; {6:0.000}; {7:0.000}; {8:0.000}; {9:0.000}; {10:0.000}; {11:0.000}; {12:0.000}; {13:0.000}; {14:0.000}; {15:0.000}; ", values[0], values[1], values[2], values[3], values[4], values[5], values[6], values[7], values[8], values[9], values[10], values[11], values[12], values[13], values[14], values[15]);
	}

	public void Transpose()
	{
		double num = values[4];
		values[4] = values[1];
		values[1] = num;
		num = values[8];
		values[8] = values[2];
		values[2] = num;
		num = values[12];
		values[12] = values[3];
		values[3] = num;
		num = values[9];
		values[9] = values[6];
		values[6] = num;
		num = values[13];
		values[13] = values[7];
		values[7] = num;
		num = values[14];
		values[14] = values[11];
		values[11] = num;
	}

	public TransformationMatrixManagedD Transposed()
	{
		TransformationMatrixManagedD transformationMatrixManagedD = new TransformationMatrixManagedD(loadIdentity: false);
		transformationMatrixManagedD.values[0] = values[0];
		transformationMatrixManagedD.values[4] = values[1];
		transformationMatrixManagedD.values[8] = values[2];
		transformationMatrixManagedD.values[12] = values[3];
		transformationMatrixManagedD.values[1] = values[4];
		transformationMatrixManagedD.values[5] = values[5];
		transformationMatrixManagedD.values[9] = values[6];
		transformationMatrixManagedD.values[13] = values[7];
		transformationMatrixManagedD.values[2] = values[8];
		transformationMatrixManagedD.values[6] = values[9];
		transformationMatrixManagedD.values[10] = values[10];
		transformationMatrixManagedD.values[14] = values[11];
		transformationMatrixManagedD.values[3] = values[12];
		transformationMatrixManagedD.values[7] = values[13];
		transformationMatrixManagedD.values[11] = values[14];
		transformationMatrixManagedD.values[15] = values[15];
		return transformationMatrixManagedD;
	}

	private static void MultiplyTranslationOnto(TransformationMatrixManagedD destination, TransformationMatrixManagedD source)
	{
		double[] array = source.values;
		double tx = array[3];
		double ty = array[7];
		double tz = array[11];
		MultiplyTranslationOnto(destination, tx, ty, tz);
	}
}
