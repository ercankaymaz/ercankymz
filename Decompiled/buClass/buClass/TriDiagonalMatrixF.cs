#define DEBUG
using System;
using System.Diagnostics;
using System.Text;

namespace buClass;

public class TriDiagonalMatrixF
{
	public double[] A;

	public double[] B;

	public double[] C;

	public int N => (A != null) ? A.Length : 0;

	public double this[int row, int col]
	{
		get
		{
			switch (row - col)
			{
			case 0:
				return B[row];
			case -1:
				Debug.Assert(row < N - 1);
				return C[row];
			case 1:
				Debug.Assert(row > 0);
				return A[row];
			default:
				return 0.0;
			}
		}
		set
		{
			switch (row - col)
			{
			case 0:
				B[row] = value;
				break;
			case -1:
				Debug.Assert(row < N - 1);
				C[row] = value;
				break;
			case 1:
				Debug.Assert(row > 0);
				A[row] = value;
				break;
			default:
				throw new ArgumentException("Only the main, super, and sub diagonals can be set.");
			}
		}
	}

	public TriDiagonalMatrixF(int n)
	{
		A = new double[n];
		B = new double[n];
		C = new double[n];
	}

	public string ToDisplayString(string fmt = "", string prefix = "")
	{
		if (N > 0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			string format = "{0" + fmt + "}";
			for (int i = 0; i < N; i++)
			{
				stringBuilder.Append(prefix);
				for (int j = 0; j < N; j++)
				{
					stringBuilder.AppendFormat(format, this[i, j]);
					if (j < N - 1)
					{
						stringBuilder.Append(", ");
					}
				}
				stringBuilder.AppendLine();
			}
			return stringBuilder.ToString();
		}
		return prefix + "0x0 Matrix";
	}

	public double[] Solve(double[] d)
	{
		int n = N;
		if (d.Length != n)
		{
			throw new ArgumentException("The input d is not the same size as this matrix.");
		}
		double[] array = new double[n];
		array[0] = C[0] / B[0];
		for (int i = 1; i < n; i++)
		{
			array[i] = C[i] / (B[i] - array[i - 1] * A[i]);
		}
		double[] array2 = new double[n];
		array2[0] = d[0] / B[0];
		for (int j = 1; j < n; j++)
		{
			array2[j] = (d[j] - array2[j - 1] * A[j]) / (B[j] - array[j - 1] * A[j]);
		}
		double[] array3 = new double[n];
		array3[n - 1] = array2[n - 1];
		for (int num = n - 2; num >= 0; num--)
		{
			array3[num] = array2[num] - array[num] * array3[num + 1];
		}
		return array3;
	}
}
