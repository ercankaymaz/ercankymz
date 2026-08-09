using System;
using System.Collections.Generic;

namespace devDept.Geometry;

public class Matrix
{
	public static double[,] CreateMatrixFromVectors(double[][] vectors, bool asRows)
	{
		if (vectors == null || vectors.Length == 0)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302658277));
		}
		int num = vectors.Length;
		int num2 = vectors[0].Length;
		for (int i = 1; i < num; i++)
		{
			if (vectors[i].Length != num2)
			{
				throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302658233));
			}
		}
		int num3 = (asRows ? num : num2);
		int num4 = (asRows ? num2 : num);
		double[,] array = new double[num3, num4];
		for (int j = 0; j < num; j++)
		{
			for (int k = 0; k < num2; k++)
			{
				if (asRows)
				{
					array[j, k] = vectors[j][k];
				}
				else
				{
					array[k, j] = vectors[j][k];
				}
			}
		}
		return array;
	}

	public static bool IsSymmetric(double[,] matrix, double tolerance)
	{
		int length = matrix.GetLength(0);
		int length2 = matrix.GetLength(1);
		if (length != length2)
		{
			return false;
		}
		for (int i = 0; i < length; i++)
		{
			for (int j = i + 1; j < length2; j++)
			{
				if (Math.Abs(matrix[i, j] - matrix[j, i]) > tolerance)
				{
					return false;
				}
			}
		}
		return true;
	}

	public static double[] Sum(double[] arrayA, double[] arrayB)
	{
		if (arrayA.GetLength(0) != arrayB.GetLength(0))
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302658184));
		}
		double[] array = (double[])arrayA.Clone();
		for (int i = 0; i < arrayB.GetLength(0); i++)
		{
			array[i] += arrayB[i];
		}
		return array;
	}

	public static double[,] Sum(double[,] matrixA, double[,] matrixB)
	{
		if (matrixA.GetLength(0) != matrixB.GetLength(0) || matrixA.GetLength(1) != matrixB.GetLength(1))
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302658906));
		}
		double[,] array = (double[,])matrixA.Clone();
		for (int i = 0; i < matrixB.GetLength(0); i++)
		{
			for (int j = 0; j < matrixB.GetLength(1); j++)
			{
				array[i, j] += matrixB[i, j];
			}
		}
		return array;
	}

	public static bool IsIdentity4(double[,] matrix)
	{
		if (matrix[0, 0] == 1.0 && matrix[0, 1] == 0.0 && matrix[0, 2] == 0.0 && matrix[0, 3] == 0.0 && matrix[1, 0] == 0.0 && matrix[1, 1] == 1.0 && matrix[1, 2] == 0.0 && matrix[1, 3] == 0.0 && matrix[2, 0] == 0.0 && matrix[2, 1] == 0.0 && matrix[2, 2] == 1.0 && matrix[2, 3] == 0.0 && matrix[3, 0] == 0.0 && matrix[3, 1] == 0.0 && matrix[3, 2] == 0.0)
		{
			return matrix[3, 3] == 1.0;
		}
		return false;
	}

	internal static bool _0023_003DzZ6j7EXjFMw6J(float[,] _0023_003DzlTrXFNo_003D)
	{
		if (_0023_003DzlTrXFNo_003D[0, 0] == 1f && _0023_003DzlTrXFNo_003D[0, 1] == 0f && _0023_003DzlTrXFNo_003D[0, 2] == 0f && _0023_003DzlTrXFNo_003D[0, 3] == 0f && _0023_003DzlTrXFNo_003D[1, 0] == 0f && _0023_003DzlTrXFNo_003D[1, 1] == 1f && _0023_003DzlTrXFNo_003D[1, 2] == 0f && _0023_003DzlTrXFNo_003D[1, 3] == 0f && _0023_003DzlTrXFNo_003D[2, 0] == 0f && _0023_003DzlTrXFNo_003D[2, 1] == 0f && _0023_003DzlTrXFNo_003D[2, 2] == 1f && _0023_003DzlTrXFNo_003D[2, 3] == 0f && _0023_003DzlTrXFNo_003D[3, 0] == 0f && _0023_003DzlTrXFNo_003D[3, 1] == 0f && _0023_003DzlTrXFNo_003D[3, 2] == 0f)
		{
			return _0023_003DzlTrXFNo_003D[3, 3] == 1f;
		}
		return false;
	}

	public static void Multiply(double scalar, ref double[,] matrix)
	{
		int length = matrix.GetLength(0);
		int length2 = matrix.GetLength(1);
		for (int i = 0; i < length; i++)
		{
			for (int j = 0; j < length2; j++)
			{
				matrix[i, j] *= scalar;
			}
		}
	}

	internal static void _0023_003DzPOz2LQY_003D(float _0023_003DzunFPxNM_003D, ref float[,] _0023_003DzlTrXFNo_003D)
	{
		int length = _0023_003DzlTrXFNo_003D.GetLength(0);
		int length2 = _0023_003DzlTrXFNo_003D.GetLength(1);
		for (int i = 0; i < length; i++)
		{
			for (int j = 0; j < length2; j++)
			{
				_0023_003DzlTrXFNo_003D[i, j] *= _0023_003DzunFPxNM_003D;
			}
		}
	}

	public static double[] Multiply3x(double[,] a, double[] b)
	{
		double[] array = new double[3];
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				array[i] += a[i, j] * b[j];
			}
		}
		return array;
	}

	public static float[] Multiply3x(float[,] a, float[] b)
	{
		float[] array = new float[3];
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				array[i] += a[i, j] * b[j];
			}
		}
		return array;
	}

	public static double[] Multiply4x(double[,] a, double[] b)
	{
		double[] array = new double[4];
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				array[i] += a[i, j] * b[j];
			}
		}
		return array;
	}

	public static float[] Multiply4x(float[,] a, float[] b)
	{
		float[] array = new float[4];
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				array[i] += a[i, j] * b[j];
			}
		}
		return array;
	}

	public static double[] Multiply(double[,] a, double[] b)
	{
		double[] array = new double[a.GetLength(0)];
		for (int i = 0; i < a.GetLength(0); i++)
		{
			for (int j = 0; j < a.GetLength(1); j++)
			{
				array[i] += a[i, j] * b[j];
			}
		}
		return array;
	}

	public static float[] Multiply(float[,] a, float[] b)
	{
		float[] array = new float[a.GetLength(0)];
		for (int i = 0; i < a.GetLength(0); i++)
		{
			for (int j = 0; j < a.GetLength(1); j++)
			{
				array[i] += a[i, j] * b[j];
			}
		}
		return array;
	}

	public static double[] MultiplyX3(double[] a, double[,] b)
	{
		double[] array = new double[3];
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				array[i] += a[j] * b[j, i];
			}
		}
		return array;
	}

	public static float[] MultiplyX3(float[] a, float[,] b)
	{
		float[] array = new float[3];
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				array[i] += a[j] * b[j, i];
			}
		}
		return array;
	}

	internal static double[] _0023_003Dz2kPlLwy1Ckiw(double[] _0023_003DzjbqS1qE_003D, double[,] _0023_003Dz1v6oPQk_003D)
	{
		double[] array = new double[4];
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				array[i] += _0023_003DzjbqS1qE_003D[j] * _0023_003Dz1v6oPQk_003D[j, i];
			}
		}
		return array;
	}

	internal static float[] _0023_003Dz2kPlLwy1Ckiw(float[] _0023_003DzjbqS1qE_003D, float[,] _0023_003Dz1v6oPQk_003D)
	{
		float[] array = new float[4];
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				array[i] += _0023_003DzjbqS1qE_003D[j] * _0023_003Dz1v6oPQk_003D[j, i];
			}
		}
		return array;
	}

	public static double[,] Multiply4x4(double[,] a, double[,] b)
	{
		double[,] array = new double[4, 4];
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				for (int k = 0; k < 4; k++)
				{
					array[i, j] += a[i, k] * b[k, j];
				}
			}
		}
		return array;
	}

	public static float[,] Multiply4x4(float[,] a, float[,] b)
	{
		float[,] array = new float[4, 4];
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				for (int k = 0; k < 4; k++)
				{
					array[i, j] += a[i, k] * b[k, j];
				}
			}
		}
		return array;
	}

	public static float[] Multiply4x4(float[] a, float[] b)
	{
		if (a.Length != 16 || b.Length != 16)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302658862));
		}
		float[] array = new float[16];
		int num = 0;
		int num2 = 0;
		while (num2 < 16)
		{
			float num3 = a[num2++];
			float num4 = a[num2++];
			float num5 = a[num2++];
			float num6 = a[num2++];
			for (int i = 0; i < 4; i++)
			{
				float num7 = b[i];
				float num8 = b[i + 4];
				float num9 = b[i + 8];
				float num10 = b[i + 12];
				array[num++] = num3 * num7 + num4 * num8 + num5 * num9 + num6 * num10;
			}
		}
		return array;
	}

	[CLSCompliant(false)]
	public static double[,] Multiply(double[,] a, double[,] b)
	{
		int length = a.GetLength(0);
		int length2 = a.GetLength(1);
		int length3 = b.GetLength(1);
		double[,] array = new double[length, length3];
		for (int i = 0; i < length; i++)
		{
			for (int j = 0; j < length3; j++)
			{
				for (int k = 0; k < length2; k++)
				{
					array[i, j] += a[i, k] * b[k, j];
				}
			}
		}
		return array;
	}

	[CLSCompliant(false)]
	public static float[,] Multiply(float[,] a, float[,] b)
	{
		int length = a.GetLength(0);
		int length2 = a.GetLength(1);
		int length3 = b.GetLength(1);
		float[,] array = new float[length, length3];
		for (int i = 0; i < length; i++)
		{
			for (int j = 0; j < length3; j++)
			{
				for (int k = 0; k < length2; k++)
				{
					array[i, j] += a[i, k] * b[k, j];
				}
			}
		}
		return array;
	}

	internal static Equation[] _0023_003DzPOz2LQY_003D(Equation[] _0023_003DzjbqS1qE_003D, Equation[] _0023_003Dz1v6oPQk_003D)
	{
		Equation[] array = new Equation[_0023_003DzjbqS1qE_003D.Length];
		int num = _0023_003DzjbqS1qE_003D.Length;
		for (int i = 0; i < num; i++)
		{
			array[i] = new Equation
			{
				Coefficients = new List<Coefficient>()
			};
			for (int j = 0; j < num; j++)
			{
				for (int k = 0; k < _0023_003DzjbqS1qE_003D[i].Coefficients.Count; k++)
				{
					Coefficient coefficient = _0023_003DzjbqS1qE_003D[i].Coefficients[k];
					Coefficient coefficient2 = _0023_003Dz1v6oPQk_003D[coefficient.Pos][j];
					if (coefficient2.Pos != -1)
					{
						array[i].Add(j, coefficient.Val * coefficient2.Val);
					}
				}
			}
		}
		return array;
	}

	public static double[,] Multiply(Equation[] a, Equation[] b, int nSize)
	{
		int num = nSize / 2;
		double[,] array = new double[a.Length, nSize];
		int num2 = a.Length;
		for (int i = 0; i < num2; i++)
		{
			for (int j = 0; j < num2; j++)
			{
				foreach (Coefficient coefficient2 in a[i].Coefficients)
				{
					Coefficient coefficient = b[coefficient2.Pos][j];
					if (coefficient.Pos != -1)
					{
						array[i, j - i + num] += coefficient2.Val * coefficient.Val;
					}
				}
			}
		}
		return array;
	}

	public static double[,] Multiply3x3(double[,] a, double[,] b)
	{
		double[,] array = new double[3, 3];
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				for (int k = 0; k < 3; k++)
				{
					array[i, j] += a[i, k] * b[k, j];
				}
			}
		}
		return array;
	}

	public static float[,] Multiply3x3(float[,] a, float[,] b)
	{
		float[,] array = new float[3, 3];
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				for (int k = 0; k < 3; k++)
				{
					array[i, j] += a[i, k] * b[k, j];
				}
			}
		}
		return array;
	}

	public static float[] Multiply3x3(float[] a, float[] b)
	{
		if (a.Length != 9 || b.Length != 9)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302659040));
		}
		float[] array = new float[9];
		int num = 0;
		int num2 = 0;
		while (num2 < 9)
		{
			float num3 = a[num2++];
			float num4 = a[num2++];
			float num5 = a[num2++];
			for (int i = 0; i < 3; i++)
			{
				float num6 = b[i];
				float num7 = b[i + 3];
				float num8 = b[i + 6];
				array[num++] = num3 * num6 + num4 * num7 + num5 * num8;
			}
		}
		return array;
	}

	public static T[,] Transpose<T>(T[,] matrix)
	{
		int length = matrix.GetLength(0);
		int length2 = matrix.GetLength(1);
		T[,] array = new T[length2, length];
		for (int i = 0; i < length; i++)
		{
			for (int j = 0; j < length2; j++)
			{
				array[j, i] = matrix[i, j];
			}
		}
		return array;
	}

	public static Equation[] Transpose(int n, int m, Equation[] equations)
	{
		Equation[] array = new Equation[n];
		for (int i = 0; i < n; i++)
		{
			array[i] = new Equation(0);
		}
		for (int j = 0; j < m; j++)
		{
			for (int k = 0; k < equations[j].Coefficients.Count; k++)
			{
				Coefficient coefficient = equations[j].Coefficients[k];
				array[coefficient.Pos].Add(j, coefficient.Val);
			}
		}
		return array;
	}

	public static double Determinant3(double[,] matrix)
	{
		double num = matrix[2, 2];
		double num2 = matrix[1, 1];
		double num3 = matrix[1, 2];
		double num4 = matrix[1, 0];
		double num5 = matrix[2, 0];
		double num6 = matrix[2, 1];
		return matrix[0, 0] * (num2 * num - num6 * num3) - matrix[0, 1] * (num4 * num - num5 * num3) + matrix[0, 2] * (num4 * num6 - num5 * num2);
	}

	public static float Determinant3(float[,] matrix)
	{
		float num = matrix[2, 2];
		float num2 = matrix[1, 1];
		float num3 = matrix[1, 2];
		float num4 = matrix[1, 0];
		float num5 = matrix[2, 0];
		float num6 = matrix[2, 1];
		return matrix[0, 0] * (num2 * num - num6 * num3) - matrix[0, 1] * (num4 * num - num5 * num3) + matrix[0, 2] * (num4 * num6 - num5 * num2);
	}

	public static double Determinant2(double[,] matrix)
	{
		return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
	}

	public static float Determinant2(float[,] matrix)
	{
		return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
	}

	public static bool Inverse3(double[,] matrix, out double[,] inverse)
	{
		inverse = new double[3, 3];
		double num = Determinant3(matrix);
		if (Math.Abs(num) < 1E-12)
		{
			return false;
		}
		inverse[0, 0] = (matrix[1, 1] * matrix[2, 2] - matrix[1, 2] * matrix[2, 1]) / num;
		inverse[0, 1] = (0.0 - (matrix[0, 1] * matrix[2, 2] - matrix[2, 1] * matrix[0, 2])) / num;
		inverse[0, 2] = (matrix[0, 1] * matrix[1, 2] - matrix[1, 1] * matrix[0, 2]) / num;
		inverse[1, 0] = (0.0 - (matrix[1, 0] * matrix[2, 2] - matrix[1, 2] * matrix[2, 0])) / num;
		inverse[1, 1] = (matrix[0, 0] * matrix[2, 2] - matrix[2, 0] * matrix[0, 2]) / num;
		inverse[1, 2] = (0.0 - (matrix[0, 0] * matrix[1, 2] - matrix[1, 0] * matrix[0, 2])) / num;
		inverse[2, 0] = (matrix[1, 0] * matrix[2, 1] - matrix[2, 0] * matrix[1, 1]) / num;
		inverse[2, 1] = (0.0 - (matrix[0, 0] * matrix[2, 1] - matrix[2, 0] * matrix[0, 1])) / num;
		inverse[2, 2] = (matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0]) / num;
		return true;
	}

	public static bool Inverse3(float[,] matrix, out float[,] inverse)
	{
		inverse = new float[3, 3];
		float num = Determinant3(matrix);
		if ((double)Math.Abs(num) < 1E-12)
		{
			return false;
		}
		inverse[0, 0] = (matrix[1, 1] * matrix[2, 2] - matrix[1, 2] * matrix[2, 1]) / num;
		inverse[0, 1] = (0f - (matrix[0, 1] * matrix[2, 2] - matrix[2, 1] * matrix[0, 2])) / num;
		inverse[0, 2] = (matrix[0, 1] * matrix[1, 2] - matrix[1, 1] * matrix[0, 2]) / num;
		inverse[1, 0] = (0f - (matrix[1, 0] * matrix[2, 2] - matrix[1, 2] * matrix[2, 0])) / num;
		inverse[1, 1] = (matrix[0, 0] * matrix[2, 2] - matrix[2, 0] * matrix[0, 2]) / num;
		inverse[1, 2] = (0f - (matrix[0, 0] * matrix[1, 2] - matrix[1, 0] * matrix[0, 2])) / num;
		inverse[2, 0] = (matrix[1, 0] * matrix[2, 1] - matrix[2, 0] * matrix[1, 1]) / num;
		inverse[2, 1] = (0f - (matrix[0, 0] * matrix[2, 1] - matrix[2, 0] * matrix[0, 1])) / num;
		inverse[2, 2] = (matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0]) / num;
		return true;
	}

	private static void _0023_003Dz2VNEtAiv5fWe<T>(T[,] _0023_003DzFAH4xII_003D, ref T[,] _0023_003DzUDlFc7k_003D, int _0023_003Dz437_00244ak_003D, int _0023_003DzTSeNR8Q_003D)
	{
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				int num = i + ((i >= _0023_003Dz437_00244ak_003D) ? 1 : 0);
				int num2 = j + ((j >= _0023_003DzTSeNR8Q_003D) ? 1 : 0);
				_0023_003DzUDlFc7k_003D[i, j] = _0023_003DzFAH4xII_003D[num, num2];
			}
		}
	}

	public static double Determinant4(double[,] matrix)
	{
		double num = 0.0;
		double num2 = 1.0;
		double[,] _0023_003DzUDlFc7k_003D = new double[3, 3];
		int num3 = 0;
		while (num3 < 4)
		{
			_0023_003Dz2VNEtAiv5fWe(matrix, ref _0023_003DzUDlFc7k_003D, 0, num3);
			double num4 = Determinant3(_0023_003DzUDlFc7k_003D);
			num += matrix[0, num3] * num4 * num2;
			num3++;
			num2 *= -1.0;
		}
		return num;
	}

	public static float Determinant4(float[,] matrix)
	{
		float num = 0f;
		float num2 = 1f;
		float[,] _0023_003DzUDlFc7k_003D = new float[3, 3];
		int num3 = 0;
		while (num3 < 4)
		{
			_0023_003Dz2VNEtAiv5fWe(matrix, ref _0023_003DzUDlFc7k_003D, 0, num3);
			float num4 = Determinant3(_0023_003DzUDlFc7k_003D);
			num += matrix[0, num3] * num4 * num2;
			num3++;
			num2 *= -1f;
		}
		return num;
	}

	public static bool Inverse4(double[,] matrix, out double[,] inverse)
	{
		inverse = new double[4, 4];
		double num = Determinant4(matrix);
		double[,] _0023_003DzUDlFc7k_003D = new double[3, 3];
		if (Math.Abs(num) < 1E-12)
		{
			return false;
		}
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				int num2 = 1 - (i + j) % 2 * 2;
				_0023_003Dz2VNEtAiv5fWe(matrix, ref _0023_003DzUDlFc7k_003D, i, j);
				inverse[j, i] = Determinant3(_0023_003DzUDlFc7k_003D) * (double)num2 / num;
			}
		}
		return true;
	}

	public static bool Inverse4(float[,] matrix, out float[,] inverse)
	{
		inverse = new float[4, 4];
		float num = Determinant4(matrix);
		float[,] _0023_003DzUDlFc7k_003D = new float[3, 3];
		if ((double)Math.Abs(num) < 1E-12)
		{
			return false;
		}
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				int num2 = 1 - (i + j) % 2 * 2;
				_0023_003Dz2VNEtAiv5fWe(matrix, ref _0023_003DzUDlFc7k_003D, i, j);
				inverse[j, i] = Determinant3(_0023_003DzUDlFc7k_003D) * (float)num2 / num;
			}
		}
		return true;
	}

	public static double[,] Inverse4(double[,] a)
	{
		double num = a[0, 0] * a[1, 1] - a[1, 0] * a[0, 1];
		double num2 = a[0, 0] * a[1, 2] - a[1, 0] * a[0, 2];
		double num3 = a[0, 0] * a[1, 3] - a[1, 0] * a[0, 3];
		double num4 = a[0, 1] * a[1, 2] - a[1, 1] * a[0, 2];
		double num5 = a[0, 1] * a[1, 3] - a[1, 1] * a[0, 3];
		double num6 = a[0, 2] * a[1, 3] - a[1, 2] * a[0, 3];
		double num7 = a[2, 2] * a[3, 3] - a[3, 2] * a[2, 3];
		double num8 = a[2, 1] * a[3, 3] - a[3, 1] * a[2, 3];
		double num9 = a[2, 1] * a[3, 2] - a[3, 1] * a[2, 2];
		double num10 = a[2, 0] * a[3, 3] - a[3, 0] * a[2, 3];
		double num11 = a[2, 0] * a[3, 2] - a[3, 0] * a[2, 2];
		double num12 = a[2, 0] * a[3, 1] - a[3, 0] * a[2, 1];
		double num13 = 1.0 / (num * num7 - num2 * num8 + num3 * num9 + num4 * num10 - num5 * num11 + num6 * num12);
		return new double[4, 4]
		{
			{
				(a[1, 1] * num7 - a[1, 2] * num8 + a[1, 3] * num9) * num13,
				((0.0 - a[0, 1]) * num7 + a[0, 2] * num8 - a[0, 3] * num9) * num13,
				(a[3, 1] * num6 - a[3, 2] * num5 + a[3, 3] * num4) * num13,
				((0.0 - a[2, 1]) * num6 + a[2, 2] * num5 - a[2, 3] * num4) * num13
			},
			{
				((0.0 - a[1, 0]) * num7 + a[1, 2] * num10 - a[1, 3] * num11) * num13,
				(a[0, 0] * num7 - a[0, 2] * num10 + a[0, 3] * num11) * num13,
				((0.0 - a[3, 0]) * num6 + a[3, 2] * num3 - a[3, 3] * num2) * num13,
				(a[2, 0] * num6 - a[2, 2] * num3 + a[2, 3] * num2) * num13
			},
			{
				(a[1, 0] * num8 - a[1, 1] * num10 + a[1, 3] * num12) * num13,
				((0.0 - a[0, 0]) * num8 + a[0, 1] * num10 - a[0, 3] * num12) * num13,
				(a[3, 0] * num5 - a[3, 1] * num3 + a[3, 3] * num) * num13,
				((0.0 - a[2, 0]) * num5 + a[2, 1] * num3 - a[2, 3] * num) * num13
			},
			{
				((0.0 - a[1, 0]) * num9 + a[1, 1] * num11 - a[1, 2] * num12) * num13,
				(a[0, 0] * num9 - a[0, 1] * num11 + a[0, 2] * num12) * num13,
				((0.0 - a[3, 0]) * num4 + a[3, 1] * num2 - a[3, 2] * num) * num13,
				(a[2, 0] * num4 - a[2, 1] * num2 + a[2, 2] * num) * num13
			}
		};
	}

	public static float[,] Inverse4(float[,] a)
	{
		float num = a[0, 0] * a[1, 1] - a[1, 0] * a[0, 1];
		float num2 = a[0, 0] * a[1, 2] - a[1, 0] * a[0, 2];
		float num3 = a[0, 0] * a[1, 3] - a[1, 0] * a[0, 3];
		float num4 = a[0, 1] * a[1, 2] - a[1, 1] * a[0, 2];
		float num5 = a[0, 1] * a[1, 3] - a[1, 1] * a[0, 3];
		float num6 = a[0, 2] * a[1, 3] - a[1, 2] * a[0, 3];
		float num7 = a[2, 2] * a[3, 3] - a[3, 2] * a[2, 3];
		float num8 = a[2, 1] * a[3, 3] - a[3, 1] * a[2, 3];
		float num9 = a[2, 1] * a[3, 2] - a[3, 1] * a[2, 2];
		float num10 = a[2, 0] * a[3, 3] - a[3, 0] * a[2, 3];
		float num11 = a[2, 0] * a[3, 2] - a[3, 0] * a[2, 2];
		float num12 = a[2, 0] * a[3, 1] - a[3, 0] * a[2, 1];
		float num13 = 1f / (num * num7 - num2 * num8 + num3 * num9 + num4 * num10 - num5 * num11 + num6 * num12);
		return new float[4, 4]
		{
			{
				(a[1, 1] * num7 - a[1, 2] * num8 + a[1, 3] * num9) * num13,
				((0f - a[0, 1]) * num7 + a[0, 2] * num8 - a[0, 3] * num9) * num13,
				(a[3, 1] * num6 - a[3, 2] * num5 + a[3, 3] * num4) * num13,
				((0f - a[2, 1]) * num6 + a[2, 2] * num5 - a[2, 3] * num4) * num13
			},
			{
				((0f - a[1, 0]) * num7 + a[1, 2] * num10 - a[1, 3] * num11) * num13,
				(a[0, 0] * num7 - a[0, 2] * num10 + a[0, 3] * num11) * num13,
				((0f - a[3, 0]) * num6 + a[3, 2] * num3 - a[3, 3] * num2) * num13,
				(a[2, 0] * num6 - a[2, 2] * num3 + a[2, 3] * num2) * num13
			},
			{
				(a[1, 0] * num8 - a[1, 1] * num10 + a[1, 3] * num12) * num13,
				((0f - a[0, 0]) * num8 + a[0, 1] * num10 - a[0, 3] * num12) * num13,
				(a[3, 0] * num5 - a[3, 1] * num3 + a[3, 3] * num) * num13,
				((0f - a[2, 0]) * num5 + a[2, 1] * num3 - a[2, 3] * num) * num13
			},
			{
				((0f - a[1, 0]) * num9 + a[1, 1] * num11 - a[1, 2] * num12) * num13,
				(a[0, 0] * num9 - a[0, 1] * num11 + a[0, 2] * num12) * num13,
				((0f - a[3, 0]) * num4 + a[3, 1] * num2 - a[3, 2] * num) * num13,
				(a[2, 0] * num4 - a[2, 1] * num2 + a[2, 2] * num) * num13
			}
		};
	}

	public static float[] Inverse4(float[] a)
	{
		if (a.Length != 16)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302658862));
		}
		float num = a[0] * a[5] - a[4] * a[1];
		float num2 = a[0] * a[6] - a[4] * a[2];
		float num3 = a[0] * a[7] - a[4] * a[3];
		float num4 = a[1] * a[6] - a[5] * a[2];
		float num5 = a[1] * a[7] - a[5] * a[3];
		float num6 = a[2] * a[7] - a[6] * a[3];
		float num7 = a[10] * a[15] - a[14] * a[11];
		float num8 = a[9] * a[15] - a[13] * a[11];
		float num9 = a[9] * a[14] - a[13] * a[10];
		float num10 = a[8] * a[15] - a[12] * a[11];
		float num11 = a[8] * a[14] - a[12] * a[10];
		float num12 = a[8] * a[13] - a[12] * a[9];
		float num13 = 1f / (num * num7 - num2 * num8 + num3 * num9 + num4 * num10 - num5 * num11 + num6 * num12);
		return new float[16]
		{
			(a[5] * num7 - a[6] * num8 + a[7] * num9) * num13,
			((0f - a[1]) * num7 + a[2] * num8 - a[3] * num9) * num13,
			(a[13] * num6 - a[14] * num5 + a[15] * num4) * num13,
			((0f - a[9]) * num6 + a[10] * num5 - a[11] * num4) * num13,
			((0f - a[4]) * num7 + a[6] * num10 - a[7] * num11) * num13,
			(a[0] * num7 - a[2] * num10 + a[3] * num11) * num13,
			((0f - a[12]) * num6 + a[14] * num3 - a[15] * num2) * num13,
			(a[8] * num6 - a[10] * num3 + a[11] * num2) * num13,
			(a[4] * num8 - a[5] * num10 + a[7] * num12) * num13,
			((0f - a[0]) * num8 + a[1] * num10 - a[3] * num12) * num13,
			(a[12] * num5 - a[13] * num3 + a[15] * num) * num13,
			((0f - a[8]) * num5 + a[9] * num3 - a[11] * num) * num13,
			((0f - a[4]) * num9 + a[5] * num11 - a[6] * num12) * num13,
			(a[0] * num9 - a[1] * num11 + a[2] * num12) * num13,
			((0f - a[12]) * num4 + a[13] * num2 - a[14] * num) * num13,
			(a[8] * num4 - a[9] * num2 + a[10] * num) * num13
		};
	}

	public static float[] MatrixToArray(float[,] mat)
	{
		int length = mat.GetLength(0);
		int length2 = mat.GetLength(1);
		float[] array = new float[length * length2];
		Buffer.BlockCopy(mat, 0, array, 0, mat.Length * 4);
		return array;
	}

	public static T[,] Diagonal<T>(T[,] matrix, int i)
	{
		int length = matrix.GetLength(0);
		if (length != matrix.GetLength(1))
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302658959));
		}
		if (i <= 0)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302658672));
		}
		int num = length * i;
		T[,] array = new T[num, num];
		for (int j = 0; j < i; j++)
		{
			int num2 = j * length;
			int num3 = j * length;
			for (int k = 0; k < length; k++)
			{
				for (int l = 0; l < length; l++)
				{
					array[num2 + k, num3 + l] = matrix[k, l];
				}
			}
		}
		return array;
	}

	public static double[,] CreateBlockDiagonalMatrix(List<double[,]> matrices)
	{
		int num = 0;
		int num2 = 0;
		foreach (double[,] matrix in matrices)
		{
			num += matrix.GetLength(0);
			num2 += matrix.GetLength(1);
		}
		double[,] array = new double[num, num2];
		int num3 = 0;
		int num4 = 0;
		foreach (double[,] matrix2 in matrices)
		{
			int length = matrix2.GetLength(0);
			int length2 = matrix2.GetLength(1);
			for (int i = 0; i < length; i++)
			{
				for (int j = 0; j < length2; j++)
				{
					array[num3 + i, num4 + j] = matrix2[i, j];
				}
			}
			num3 += length;
			num4 += length2;
		}
		return array;
	}
}
