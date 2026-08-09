using System;

namespace devDept.Geometry;

public static class GaussianMethod
{
	public const double epsilon = 1E-12;

	public const double rankEpsilon = 1E-08;

	public static string Print<T>(this T[,] A)
	{
		string text = string.Empty;
		for (int i = 0; i < A.GetLength(0); i++)
		{
			for (int j = 0; j < A.GetLength(1); j++)
			{
				text = text + A[i, j].ToString() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382);
			}
			text += _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302915165);
		}
		return text;
	}

	public static string Print<T>(this T[] A)
	{
		string text = string.Empty;
		for (int i = 0; i < A.GetLength(0); i++)
		{
			text = text + A[i].ToString() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302915165);
		}
		return text;
	}

	public static int Rank(double[,] A)
	{
		int length = A.GetLength(0);
		int length2 = A.GetLength(1);
		int num = 0;
		double[] array = new double[length];
		for (int i = 0; i < length; i++)
		{
			for (int j = 0; j < i; j++)
			{
				if (!(array[j] <= 1E-08))
				{
					double num2 = 0.0;
					for (int k = 0; k < length2; k++)
					{
						num2 += A[j, k] * A[i, k];
					}
					for (int l = 0; l < length2; l++)
					{
						A[i, l] -= A[j, l] * num2 / array[j];
					}
				}
			}
			double num3 = 0.0;
			for (int m = 0; m < length2; m++)
			{
				num3 += A[i, m] * A[i, m];
			}
			if (num3 > 1E-08)
			{
				num++;
			}
			array[i] = num3;
		}
		return num;
	}

	public static void Solve(double[,] A, double[] B, ref double[] X)
	{
		int length = A.GetLength(0);
		int length2 = A.GetLength(1);
		double num = 0.0;
		for (int i = 0; i < length; i++)
		{
			int num2 = i;
			double num3 = 0.0;
			for (int j = i; j < length; j++)
			{
				if (!(Math.Abs(A[j, i]) <= num3))
				{
					num3 = Math.Abs(A[j, i]);
					num2 = j;
				}
			}
			if (num3 < 1E-12)
			{
				continue;
			}
			for (int k = 0; k < length2; k++)
			{
				num = A[i, k];
				A[i, k] = A[num2, k];
				A[num2, k] = num;
			}
			num = B[i];
			B[i] = B[num2];
			B[num2] = num;
			for (int l = i + 1; l < length; l++)
			{
				double num4 = A[l, i] / A[i, i];
				for (int m = 0; m < length2; m++)
				{
					A[l, m] -= A[i, m] * num4;
				}
				B[l] -= B[i] * num4;
			}
		}
		for (int num5 = length - 1; num5 >= 0; num5--)
		{
			if (!(Math.Abs(A[num5, num5]) < 1E-12))
			{
				double num6 = B[num5] / A[num5, num5];
				for (int num7 = length - 1; num7 > num5; num7--)
				{
					num6 -= X[num7] * A[num5, num7] / A[num5, num5];
				}
				X[num5] = num6;
			}
		}
	}
}
