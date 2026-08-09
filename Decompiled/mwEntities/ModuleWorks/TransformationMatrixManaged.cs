using System;
using System.Globalization;

namespace ModuleWorks;

public sealed class TransformationMatrixManaged
{
	public static int IdxTransformX = 3;

	public static int IdxTransformY = 7;

	public static int IdxTransformZ = 11;

	private float _precision = 1E-05f;

	private float[] values = new float[16];

	public float this[int row, int col]
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

	public float this[int idx]
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

	public TransformationMatrixManaged()
		: this(loadIdentity: true)
	{
	}

	public TransformationMatrixManaged(bool loadIdentity)
	{
		if (loadIdentity)
		{
			values[0] = 1f;
			values[5] = 1f;
			values[10] = 1f;
			values[15] = 1f;
		}
	}

	public TransformationMatrixManaged(float v00, float v01, float v02, float v03, float v10, float v11, float v12, float v13, float v20, float v21, float v22, float v23, float v30, float v31, float v32, float v33)
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

	public TransformationMatrixManaged(float[] values)
	{
		if (values.Length != 16)
		{
			throw new Exception("You need an array of 16 elements to create a TransformationMatrix.");
		}
		float[] array = this.values;
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

	public TransformationMatrixManaged(TransformationMatrixManaged other)
	{
		float[] array = values;
		float[] array2 = other.values;
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

	public static TransformationMatrixManaged Create3dRotation(Vectorf axis, float angle, AngleUnit angleType)
	{
		TransformationMatrixManaged transformationMatrixManaged = new TransformationMatrixManaged(loadIdentity: false);
		Create3dRotation(transformationMatrixManaged, axis, angle, angleType);
		return transformationMatrixManaged;
	}

	public static void Create3dRotation(TransformationMatrixManaged matrix, Vectorf axis, float angle, AngleUnit angleType)
	{
		float num = angle;
		if (angleType == AngleUnit.Degree)
		{
			num *= (float)Math.PI / 180f;
		}
		axis.Normalize();
		float num2 = (float)Math.Sin(num);
		float num3 = (float)Math.Cos(num);
		float num4 = 1f - num3;
		float[] array = matrix.values;
		array[0] = num3 + axis.X * axis.X * num4;
		array[1] = axis.X * axis.Y * num4 - axis.Z * num2;
		array[2] = axis.X * axis.Z * num4 + axis.Y * num2;
		array[3] = 0f;
		array[4] = axis.Y * axis.X * num4 + axis.Z * num2;
		array[5] = num3 + axis.Y * axis.Y * num4;
		array[6] = axis.Y * axis.Z * num4 - axis.X * num2;
		array[7] = 0f;
		array[8] = axis.Z * axis.X * num4 - axis.Y * num2;
		array[9] = axis.Z * axis.Y * num4 + axis.X * num2;
		array[10] = num3 + axis.Z * axis.Z * num4;
		array[11] = 0f;
		array[12] = 0f;
		array[13] = 0f;
		array[14] = 0f;
		array[15] = 1f;
	}

	public static TransformationMatrixManaged Create3dRotation(Vectorf axis, Point3d<float> rotationPoint, float angle, AngleUnit angleType)
	{
		TransformationMatrixManaged result = new TransformationMatrixManaged();
		Create3dRotation(result, axis, rotationPoint, angle, angleType);
		return result;
	}

	public static void Create3dRotation(TransformationMatrixManaged result, Vectorf axis, Point3d<float> rotationPoint, float angle, AngleUnit angleType)
	{
		float num = angle;
		if (angleType == AngleUnit.Degree)
		{
			num *= (float)Math.PI / 180f;
		}
		axis.Normalize();
		float num2 = (float)Math.Sin(num);
		float num3 = (float)Math.Cos(num);
		float num4 = 1f - num3;
		float num5 = num3 + axis.X * axis.X * num4;
		float num6 = axis.X * axis.Y * num4 - axis.Z * num2;
		float num7 = axis.X * axis.Z * num4 + axis.Y * num2;
		float num8 = axis.Y * axis.X * num4 + axis.Z * num2;
		float num9 = num3 + axis.Y * axis.Y * num4;
		float num10 = axis.Y * axis.Z * num4 - axis.X * num2;
		float num11 = axis.Z * axis.X * num4 - axis.Y * num2;
		float num12 = axis.Z * axis.Y * num4 + axis.X * num2;
		float num13 = num3 + axis.Z * axis.Z * num4;
		float x = rotationPoint.X;
		float y = rotationPoint.Y;
		float z = rotationPoint.Z;
		float num14 = 0f - x;
		float num15 = 0f - y;
		float num16 = 0f - z;
		float num17 = num5 * num14 + num6 * num15 + num7 * num16;
		float num18 = num8 * num14 + num9 * num15 + num10 * num16;
		float num19 = num11 * num14 + num12 * num15 + num13 * num16;
		float[] array = result.values;
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
		array[12] = 0f;
		array[13] = 0f;
		array[14] = 0f;
		array[15] = 1f;
	}

	public static TransformationMatrixManaged Create3dTranslation(Point3d<float> vector)
	{
		TransformationMatrixManaged transformationMatrixManaged = new TransformationMatrixManaged(loadIdentity: false);
		Create3dTranslation(transformationMatrixManaged, vector);
		return transformationMatrixManaged;
	}

	public static TransformationMatrixManaged Create3dTranslation(float x, float y, float z)
	{
		TransformationMatrixManaged transformationMatrixManaged = new TransformationMatrixManaged(loadIdentity: false);
		Create3dTranslation(transformationMatrixManaged, x, y, z);
		return transformationMatrixManaged;
	}

	public static void Create3dTranslation(TransformationMatrixManaged matrix, float x, float y, float z)
	{
		matrix.LoadIdentity();
		float[] array = matrix.values;
		array[3] = x;
		array[7] = y;
		array[11] = z;
	}

	public static void Create3dTranslation(TransformationMatrixManaged matrix, Point3d<float> translation)
	{
		matrix.LoadIdentity();
		float[] array = matrix.values;
		array[3] = translation.X;
		array[7] = translation.Y;
		array[11] = translation.Z;
	}

	public static void Invert(TransformationMatrixManaged source, TransformationMatrixManaged dest)
	{
		for (int i = 0; i < 16; i++)
		{
			dest.values[i] = source.values[i];
		}
		dest.Invert();
	}

	public static void InvertAffine(TransformationMatrixManaged source, TransformationMatrixManaged dest)
	{
		for (int i = 0; i < 16; i++)
		{
			dest.values[i] = source.values[i];
		}
		dest.InvertAffine();
	}

	public static void MatrixMultiply(TransformationMatrixManaged result, TransformationMatrixManaged left, TransformationMatrixManaged right)
	{
		float[] array = result.values;
		float[] array2 = left.values;
		float[] array3 = right.values;
		if (array2[0] == 1f && array2[5] == 1f && array2[10] == 1f && array3[0] == 1f && array3[5] == 1f && array3[10] == 1f)
		{
			array[0] = (array[5] = (array[10] = (array[15] = 1f)));
			array[1] = (array[2] = 0f);
			array[4] = (array[6] = 0f);
			array[8] = (array[9] = 0f);
			array[12] = (array[13] = (array[14] = 0f));
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

	public static void MultiplyTranslationOnto(TransformationMatrixManaged destination, float tx, float ty, float tz)
	{
		float[] array = destination.values;
		float num = array[0] * tx + array[1] * ty + array[2] * tz + array[3] * 1f;
		float num2 = array[4] * tx + array[5] * ty + array[6] * tz + array[7] * 1f;
		float num3 = array[8] * tx + array[9] * ty + array[10] * tz + array[11] * 1f;
		array[3] = num;
		array[7] = num2;
		array[11] = num3;
	}

	public static TransformationMatrixManaged operator -(TransformationMatrixManaged left, TransformationMatrixManaged right)
	{
		TransformationMatrixManaged transformationMatrixManaged = new TransformationMatrixManaged(loadIdentity: false);
		float[] array = left.values;
		float[] array2 = right.values;
		transformationMatrixManaged.values[0] = array[0] - array2[0];
		transformationMatrixManaged.values[1] = array[1] - array2[1];
		transformationMatrixManaged.values[2] = array[2] - array2[2];
		transformationMatrixManaged.values[3] = array[3] - array2[3];
		transformationMatrixManaged.values[4] = array[4] - array2[4];
		transformationMatrixManaged.values[5] = array[5] - array2[5];
		transformationMatrixManaged.values[6] = array[6] - array2[6];
		transformationMatrixManaged.values[7] = array[7] - array2[7];
		transformationMatrixManaged.values[8] = array[8] - array2[8];
		transformationMatrixManaged.values[9] = array[9] - array2[9];
		transformationMatrixManaged.values[10] = array[10] - array2[10];
		transformationMatrixManaged.values[11] = array[11] - array2[11];
		transformationMatrixManaged.values[12] = array[12] - array2[12];
		transformationMatrixManaged.values[13] = array[13] - array2[13];
		transformationMatrixManaged.values[14] = array[14] - array2[14];
		transformationMatrixManaged.values[15] = array[15] - array2[15];
		return transformationMatrixManaged;
	}

	public static TransformationMatrixManaged operator *(TransformationMatrixManaged matrix, float scalar)
	{
		TransformationMatrixManaged transformationMatrixManaged = new TransformationMatrixManaged(loadIdentity: false);
		float[] array = matrix.values;
		transformationMatrixManaged.values[0] = array[0] * scalar;
		transformationMatrixManaged.values[1] = array[1] * scalar;
		transformationMatrixManaged.values[2] = array[2] * scalar;
		transformationMatrixManaged.values[3] = array[3] * scalar;
		transformationMatrixManaged.values[4] = array[4] * scalar;
		transformationMatrixManaged.values[5] = array[5] * scalar;
		transformationMatrixManaged.values[6] = array[6] * scalar;
		transformationMatrixManaged.values[7] = array[7] * scalar;
		transformationMatrixManaged.values[8] = array[8] * scalar;
		transformationMatrixManaged.values[9] = array[9] * scalar;
		transformationMatrixManaged.values[10] = array[10] * scalar;
		transformationMatrixManaged.values[11] = array[11] * scalar;
		transformationMatrixManaged.values[12] = array[12] * scalar;
		transformationMatrixManaged.values[13] = array[13] * scalar;
		transformationMatrixManaged.values[14] = array[14] * scalar;
		transformationMatrixManaged.values[15] = array[15] * scalar;
		return transformationMatrixManaged;
	}

	public static TransformationMatrixManaged operator *(float scalar, TransformationMatrixManaged matrix)
	{
		return matrix * scalar;
	}

	public static TransformationMatrixManaged operator *(TransformationMatrixManaged left, TransformationMatrixManaged right)
	{
		TransformationMatrixManaged result = new TransformationMatrixManaged(loadIdentity: false);
		MatrixMultiply(result, left, right);
		return result;
	}

	public static TransformationMatrixManaged operator +(TransformationMatrixManaged left, TransformationMatrixManaged right)
	{
		TransformationMatrixManaged transformationMatrixManaged = new TransformationMatrixManaged(loadIdentity: false);
		float[] array = left.values;
		float[] array2 = right.values;
		transformationMatrixManaged.values[0] = array[0] + array2[0];
		transformationMatrixManaged.values[1] = array[1] + array2[1];
		transformationMatrixManaged.values[2] = array[2] + array2[2];
		transformationMatrixManaged.values[3] = array[3] + array2[3];
		transformationMatrixManaged.values[4] = array[4] + array2[4];
		transformationMatrixManaged.values[5] = array[5] + array2[5];
		transformationMatrixManaged.values[6] = array[6] + array2[6];
		transformationMatrixManaged.values[7] = array[7] + array2[7];
		transformationMatrixManaged.values[8] = array[8] + array2[8];
		transformationMatrixManaged.values[9] = array[9] + array2[9];
		transformationMatrixManaged.values[10] = array[10] + array2[10];
		transformationMatrixManaged.values[11] = array[11] + array2[11];
		transformationMatrixManaged.values[12] = array[12] + array2[12];
		transformationMatrixManaged.values[13] = array[13] + array2[13];
		transformationMatrixManaged.values[14] = array[14] + array2[14];
		transformationMatrixManaged.values[15] = array[15] + array2[15];
		return transformationMatrixManaged;
	}

	public static Vectorf TransformPoint(TransformationMatrixManaged matrix, Vectorf point)
	{
		float[] array = matrix.values;
		float x = array[0] * point.X + array[1] * point.Y + array[2] * point.Z + array[3];
		float y = array[4] * point.X + array[5] * point.Y + array[6] * point.Z + array[7];
		float z = array[8] * point.X + array[9] * point.Y + array[10] * point.Z + array[11];
		return new Vectorf(x, y, z);
	}

	public static Vectorf TransformVector(TransformationMatrixManaged matrix, Vectorf vector)
	{
		float[] array = matrix.values;
		float x = array[0] * vector.X + array[1] * vector.Y + array[2] * vector.Z;
		float y = array[4] * vector.X + array[5] * vector.Y + array[6] * vector.Z;
		float z = array[8] * vector.X + array[9] * vector.Y + array[10] * vector.Z;
		return new Vectorf(x, y, z);
	}

	public void CopyFrom(TransformationMatrixManaged other)
	{
		float[] array = values;
		float[] array2 = other.values;
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

	public void CopyTo(TransformationMatrixManaged other)
	{
		float[] array = other.values;
		float[] array2 = values;
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

	public bool Equals(TransformationMatrixManaged rhs)
	{
		return Equals(rhs, _precision);
	}

	public bool Equals(TransformationMatrixManaged rhs, float prec)
	{
		if (rhs == null)
		{
			return false;
		}
		float[] array = rhs.values;
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
		return Equals(obj as TransformationMatrixManaged);
	}

	public float[] GetData()
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
		TransformationMatrixManaged transformationMatrixManaged = new TransformationMatrixManaged(values);
		float num = transformationMatrixManaged[0] * transformationMatrixManaged[5] - transformationMatrixManaged[4] * transformationMatrixManaged[1];
		float num2 = transformationMatrixManaged[0] * transformationMatrixManaged[6] - transformationMatrixManaged[4] * transformationMatrixManaged[2];
		float num3 = transformationMatrixManaged[0] * transformationMatrixManaged[7] - transformationMatrixManaged[4] * transformationMatrixManaged[3];
		float num4 = transformationMatrixManaged[1] * transformationMatrixManaged[6] - transformationMatrixManaged[5] * transformationMatrixManaged[2];
		float num5 = transformationMatrixManaged[1] * transformationMatrixManaged[7] - transformationMatrixManaged[5] * transformationMatrixManaged[3];
		float num6 = transformationMatrixManaged[2] * transformationMatrixManaged[7] - transformationMatrixManaged[6] * transformationMatrixManaged[3];
		float num7 = transformationMatrixManaged[10] * transformationMatrixManaged[15] - transformationMatrixManaged[14] * transformationMatrixManaged[11];
		float num8 = transformationMatrixManaged[9] * transformationMatrixManaged[15] - transformationMatrixManaged[13] * transformationMatrixManaged[11];
		float num9 = transformationMatrixManaged[9] * transformationMatrixManaged[14] - transformationMatrixManaged[13] * transformationMatrixManaged[10];
		float num10 = transformationMatrixManaged[8] * transformationMatrixManaged[15] - transformationMatrixManaged[12] * transformationMatrixManaged[11];
		float num11 = transformationMatrixManaged[8] * transformationMatrixManaged[14] - transformationMatrixManaged[12] * transformationMatrixManaged[10];
		float num12 = transformationMatrixManaged[8] * transformationMatrixManaged[13] - transformationMatrixManaged[12] * transformationMatrixManaged[9];
		float num13 = 1f / (num * num7 - num2 * num8 + num3 * num9 + num4 * num10 - num5 * num11 + num6 * num12);
		values[0] = (transformationMatrixManaged[5] * num7 - transformationMatrixManaged[6] * num8 + transformationMatrixManaged[7] * num9) * num13;
		values[1] = ((0f - transformationMatrixManaged[1]) * num7 + transformationMatrixManaged[2] * num8 - transformationMatrixManaged[3] * num9) * num13;
		values[2] = (transformationMatrixManaged[13] * num6 - transformationMatrixManaged[14] * num5 + transformationMatrixManaged[15] * num4) * num13;
		values[3] = ((0f - transformationMatrixManaged[9]) * num6 + transformationMatrixManaged[10] * num5 - transformationMatrixManaged[11] * num4) * num13;
		values[4] = ((0f - transformationMatrixManaged[4]) * num7 + transformationMatrixManaged[6] * num10 - transformationMatrixManaged[7] * num11) * num13;
		values[5] = (transformationMatrixManaged[0] * num7 - transformationMatrixManaged[2] * num10 + transformationMatrixManaged[3] * num11) * num13;
		values[6] = ((0f - transformationMatrixManaged[12]) * num6 + transformationMatrixManaged[14] * num3 - transformationMatrixManaged[15] * num2) * num13;
		values[7] = (transformationMatrixManaged[8] * num6 - transformationMatrixManaged[10] * num3 + transformationMatrixManaged[11] * num2) * num13;
		values[8] = (transformationMatrixManaged[4] * num8 - transformationMatrixManaged[5] * num10 + transformationMatrixManaged[7] * num12) * num13;
		values[9] = ((0f - transformationMatrixManaged[0]) * num8 + transformationMatrixManaged[1] * num10 - transformationMatrixManaged[3] * num12) * num13;
		values[10] = (transformationMatrixManaged[12] * num5 - transformationMatrixManaged[13] * num3 + transformationMatrixManaged[15] * num) * num13;
		values[11] = ((0f - transformationMatrixManaged[8]) * num5 + transformationMatrixManaged[9] * num3 - transformationMatrixManaged[11] * num) * num13;
		values[12] = ((0f - transformationMatrixManaged[4]) * num9 + transformationMatrixManaged[5] * num11 - transformationMatrixManaged[6] * num12) * num13;
		values[13] = (transformationMatrixManaged[0] * num9 - transformationMatrixManaged[1] * num11 + transformationMatrixManaged[2] * num12) * num13;
		values[14] = ((0f - transformationMatrixManaged[12]) * num4 + transformationMatrixManaged[13] * num2 - transformationMatrixManaged[14] * num) * num13;
		values[15] = (transformationMatrixManaged[8] * num4 - transformationMatrixManaged[9] * num2 + transformationMatrixManaged[10] * num) * num13;
	}

	public void InvertAffine()
	{
		float num = values[3];
		float num2 = values[7];
		float num3 = values[11];
		values[3] = 0f;
		values[7] = 0f;
		values[11] = 0f;
		float num4 = values[4];
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
		values[3] = (0f - values[0]) * num + (0f - values[1]) * num2 + (0f - values[2]) * num3;
		values[7] = (0f - values[4]) * num + (0f - values[5]) * num2 + (0f - values[6]) * num3;
		values[11] = (0f - values[8]) * num + (0f - values[9]) * num2 + (0f - values[10]) * num3;
	}

	public TransformationMatrixManaged Inverted()
	{
		TransformationMatrixManaged transformationMatrixManaged = new TransformationMatrixManaged(this);
		transformationMatrixManaged.Invert();
		return transformationMatrixManaged;
	}

	public TransformationMatrixManaged InvertedAffine()
	{
		TransformationMatrixManaged transformationMatrixManaged = new TransformationMatrixManaged(this);
		transformationMatrixManaged.InvertAffine();
		return transformationMatrixManaged;
	}

	public bool IsIdentity()
	{
		return IsIdentity(_precision);
	}

	public bool IsIdentity(float prec)
	{
		if (Math.Abs(values[0] - 1f) < prec && Math.Abs(values[1] - 0f) < prec && Math.Abs(values[2] - 0f) < prec && Math.Abs(values[3] - 0f) < prec && Math.Abs(values[4] - 0f) < prec && Math.Abs(values[5] - 1f) < prec && Math.Abs(values[6] - 0f) < prec && Math.Abs(values[7] - 0f) < prec && Math.Abs(values[8] - 0f) < prec && Math.Abs(values[9] - 0f) < prec && Math.Abs(values[10] - 1f) < prec && Math.Abs(values[11] - 0f) < prec && Math.Abs(values[12] - 0f) < prec && Math.Abs(values[13] - 0f) < prec && Math.Abs(values[14] - 0f) < prec)
		{
			return Math.Abs(values[15] - 1f) < prec;
		}
		return false;
	}

	public void LoadIdentity()
	{
		values[0] = 1f;
		values[1] = 0f;
		values[2] = 0f;
		values[3] = 0f;
		values[4] = 0f;
		values[5] = 1f;
		values[6] = 0f;
		values[7] = 0f;
		values[8] = 0f;
		values[9] = 0f;
		values[10] = 1f;
		values[11] = 0f;
		values[12] = 0f;
		values[13] = 0f;
		values[14] = 0f;
		values[15] = 1f;
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
		float num = values[4];
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

	public TransformationMatrixManaged Transposed()
	{
		TransformationMatrixManaged transformationMatrixManaged = new TransformationMatrixManaged(loadIdentity: false);
		transformationMatrixManaged.values[0] = values[0];
		transformationMatrixManaged.values[4] = values[1];
		transformationMatrixManaged.values[8] = values[2];
		transformationMatrixManaged.values[12] = values[3];
		transformationMatrixManaged.values[1] = values[4];
		transformationMatrixManaged.values[5] = values[5];
		transformationMatrixManaged.values[9] = values[6];
		transformationMatrixManaged.values[13] = values[7];
		transformationMatrixManaged.values[2] = values[8];
		transformationMatrixManaged.values[6] = values[9];
		transformationMatrixManaged.values[10] = values[10];
		transformationMatrixManaged.values[14] = values[11];
		transformationMatrixManaged.values[3] = values[12];
		transformationMatrixManaged.values[7] = values[13];
		transformationMatrixManaged.values[11] = values[14];
		transformationMatrixManaged.values[15] = values[15];
		return transformationMatrixManaged;
	}

	private static void MultiplyTranslationOnto(TransformationMatrixManaged destination, TransformationMatrixManaged source)
	{
		float[] array = source.values;
		float tx = array[3];
		float ty = array[7];
		float tz = array[11];
		MultiplyTranslationOnto(destination, tx, ty, tz);
	}
}
