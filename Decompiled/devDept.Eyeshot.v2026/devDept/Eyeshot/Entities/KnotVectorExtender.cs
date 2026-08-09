using System;
using System.Text;
using devDept.Geometry;

namespace devDept.Eyeshot.Entities;

public static class KnotVectorExtender
{
	public static double Left(this double[] U)
	{
		return U[0];
	}

	public static double Right(this double[] U)
	{
		return U[^1];
	}

	private static double _0023_003DzQwYttdw_003D(this double[] _0023_003DziP9fFuA_003D)
	{
		return _0023_003DziP9fFuA_003D[^1] - _0023_003DziP9fFuA_003D[0];
	}

	public static void Offset(this double[] U, double delta)
	{
		for (int i = 0; i < U.Length; i++)
		{
			U[i] += delta;
		}
	}

	public static void Scale(this double[] U, double factor)
	{
		for (int i = 0; i < U.Length; i++)
		{
			U[i] *= factor;
		}
	}

	public static void Normalize(this double[] items)
	{
		if (items.Left() != 0.0)
		{
			items.Offset(0.0 - items.Left());
		}
		items.Scale(1.0 / items._0023_003DzQwYttdw_003D());
	}

	public static void IsClamped(this double[] U, int p, int n, out bool start, out bool end)
	{
		start = true;
		end = true;
		double num = U[0];
		double num2 = U[p + n];
		if (!Utility.AreEqual(num, U[p], U._0023_003DzQwYttdw_003D()))
		{
			start = false;
		}
		if (!Utility.AreEqual(U[n], num2, U._0023_003DzQwYttdw_003D()))
		{
			end = false;
		}
		for (int i = 0; i < p; i++)
		{
			if (start)
			{
				U[i + 1] = num;
			}
			if (end)
			{
				U[n + i] = num2;
			}
		}
	}

	public static bool IsClamped(this double[] U, int p, int n)
	{
		U.IsClamped(p, n, out var start, out var end);
		return start && end;
	}

	public static int SpanCount(this double[] U, int p, int n)
	{
		int num = 0;
		for (int i = p; i < n + 1; i++)
		{
			if (U[i] > U[i - 1])
			{
				num++;
			}
		}
		return num;
	}

	public static int Multiplicity(this double[] U, int knotIndex)
	{
		return U.Multiplicity(ref knotIndex);
	}

	public static int Multiplicity(this double[] U, ref int knotIndex)
	{
		int num = U.Length;
		int num2 = 0;
		if (knotIndex >= 0 && knotIndex < num)
		{
			double num3 = U[knotIndex];
			int num4 = knotIndex - 1;
			while (num4 >= 0 && num3 == U[num4])
			{
				num2++;
				num4--;
			}
			while (knotIndex < num && num3 == U[knotIndex])
			{
				num2++;
				knotIndex++;
			}
			knotIndex--;
		}
		return num2;
	}

	public static bool IsValid(this double[] U, int p, int n, StringBuilder log = null)
	{
		int num = p + 1;
		double num2 = U[0];
		double num3 = U[n];
		for (int i = 1; i < num; i++)
		{
			if (U[i] != num2 || U[i + n] != num3)
			{
				log?.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302971297));
				return false;
			}
		}
		if (U[num] == num2 || U[n - 1] == num3)
		{
			log?.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302971279));
			return false;
		}
		return U.IsValid(p, log);
	}

	public static bool IsValid(this double[] U, int p, StringBuilder log = null)
	{
		if (p == 0 && U[0] == U[1])
		{
			log?.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302970902));
			return false;
		}
		int num = 1;
		for (int i = 0; i < U.Length - 1; i++)
		{
			if (U[i] > U[i + 1])
			{
				log?.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302971135));
				return false;
			}
			if (i > 0 && i < U.Length - 2)
			{
				num = ((U[i] != U[i + 1]) ? 1 : (num + 1));
				if (num > p)
				{
					log?.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302971059));
					return false;
				}
			}
		}
		return true;
	}

	public static int FindSpan(this double[] U, int n, int p, double u)
	{
		if (u <= U[p])
		{
			return p;
		}
		if (u >= U[n + 1])
		{
			return n;
		}
		int num = p;
		int num2 = n + 1;
		int num3 = (num + num2) / 2;
		while (u < U[num3] || u >= U[num3 + 1])
		{
			if (u < U[num3])
			{
				num2 = num3;
			}
			else
			{
				num = num3;
			}
			num3 = (num + num2) / 2;
		}
		return num3;
	}

	public static void FindSpanMult(this double[] U, double u, int p, out int k, out int s)
	{
		int num = U.Length;
		if (u < U.Left() || u > U.Right())
		{
			throw new ArgumentOutOfRangeException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302971766), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302971775));
		}
		s = 0;
		int i;
		for (i = 0; i < num; i++)
		{
			if (s > p)
			{
				break;
			}
			if (U[i] == u)
			{
				s++;
			}
			else if (U[i] > u)
			{
				break;
			}
		}
		k = i - 1;
	}

	public static void FindSpanMult(this double[] U, ref double u, int p, double minKnotDist, out int k, out int s)
	{
		foreach (double num in U)
		{
			if (Math.Abs(num - u) < minKnotDist)
			{
				u = num;
				break;
			}
		}
		U.FindSpanMult(u, p, out k, out s);
	}

	public static bool FindMultipleKnots(this double[] knots, int degree, int minMultiplicity, out int j, out int m)
	{
		int num = degree + 1;
		int num2 = knots.Length - degree - 1;
		if (minMultiplicity == 1 && num < num2)
		{
			j = num;
			m = 1;
			return true;
		}
		m = 1;
		bool flag = false;
		double num3 = knots[num++];
		while (num < num2)
		{
			double num4 = knots[num];
			if (num3 == num4)
			{
				flag = ++m >= minMultiplicity;
			}
			else
			{
				if (flag)
				{
					break;
				}
				m = 1;
			}
			num++;
			num3 = num4;
		}
		j = num - 1;
		return flag;
	}

	public static bool GetFirstSimilarKnotIndex(this double[] U, int p, double minDist, out int index, out int mult)
	{
		index = -1;
		mult = -1;
		for (int i = p; i < U.Length - p - 1; i++)
		{
			if (U[i] != U[i + 1] && U[i + 1] - U[i] < minDist)
			{
				U.FindSpanMult(U[i], p, out var k, out var s);
				U.FindSpanMult(U[i + 1], p, out var k2, out var s2);
				index = ((s < s2) ? k : k2);
				mult = ((s < s2) ? s : s2);
				return true;
			}
		}
		return false;
	}

	public static double MinAcceptableKnotDistance(this double[] U, int p)
	{
		int num = 0;
		for (int i = p; i < U.Length - p - 1; i++)
		{
			if (U[i + 1] != U[i])
			{
				num++;
			}
		}
		return 1E-08 * U._0023_003DzQwYttdw_003D() / (double)num;
	}

	public static void Reverse(this double[] U)
	{
		U.Reverse(0.0);
	}

	public static void Reverse(this double[] U, double offset)
	{
		double[] array = (double[])U.Clone();
		int num = U.Length - 1;
		for (int i = 0; i < U.Length; i++)
		{
			U[i] = offset - array[num];
			num--;
		}
	}

	public static knotVectorType GetStyle(this double[] U, int p, int n)
	{
		if (U.IsClamped(p, n))
		{
			int i;
			for (i = p + 1; i < n - 1 && U[i] == U[i + p - 1]; i += p)
			{
			}
			if (i >= n)
			{
				return knotVectorType.PiecewiseBezier;
			}
			double num = U[p + 1] - U[p];
			for (int j = p + 1; j < U.Length - 1 - p; j++)
			{
				if (Math.Abs(U[j + 1] - U[j] - num) > 1E-12)
				{
					return knotVectorType.ClampedNonUniform;
				}
			}
			return knotVectorType.ClampedUniform;
		}
		double num2 = U[1] - U[0];
		for (int k = 0; k < U.Length - 1; k++)
		{
			if (Math.Abs(U[k + 1] - U[k] - num2) > 1E-12)
			{
				return knotVectorType.UnClampedNonUniform;
			}
		}
		return knotVectorType.UnClampedUniform;
	}

	public static int Split(this double[] U, int m, int k, out int splitPt, out double midVal)
	{
		int num = m + k + 1;
		int i = num / 2;
		midVal = U[i];
		int num2 = i + 1;
		int num3 = 1;
		while (num2 < num && U[num2] == midVal)
		{
			num2++;
			num3++;
		}
		num2 = i - 1;
		while (num2 > 0 && U[num2] == midVal)
		{
			num2--;
			i--;
			num3++;
		}
		if (num2 <= 0)
		{
			midVal = (U[0] + U[num]) / 2.0;
			for (i = num / 2; U[i + 1] < midVal; i++)
			{
			}
			num3 = 0;
		}
		int num4 = k - num3;
		splitPt = ((num4 < k) ? (i - 1) : i);
		return num4;
	}

	public static int Split(this double[] U, double u, int middex, int m, int k, out int splitPt)
	{
		int num = m + k + 1;
		double num2 = U[middex];
		if (!Utility.AreEqual(num2, u, U[num] - U[0]))
		{
			while (U[middex + 1] < num2)
			{
				middex++;
			}
			splitPt = middex;
			return k;
		}
		int num3 = middex + 1;
		int num4 = 1;
		while (num3 < num && U[num3] == num2)
		{
			num3++;
			num4++;
		}
		num3 = middex - 1;
		while (num3 > 0 && U[num3] == num2)
		{
			num3--;
			middex--;
			num4++;
		}
		int num5 = k - num4;
		splitPt = ((num5 < k) ? (middex - 1) : middex);
		return num5;
	}

	public static double[] BasisFuns(this double[] U, int i, double u, int p)
	{
		double[] array = new double[p + 1];
		double[] array2 = new double[p + 1];
		double[] array3 = new double[p + 1];
		array[0] = 1.0;
		for (int j = 1; j <= p; j++)
		{
			array2[j] = u - U[i + 1 - j];
			array3[j] = U[i + j] - u;
			double num = 0.0;
			for (int k = 0; k < j; k++)
			{
				double num2 = array[k] / (array3[k + 1] + array2[j - k]);
				array[k] = num + array3[k + 1] * num2;
				num = array2[j - k] * num2;
			}
			array[j] = num;
		}
		return array;
	}

	public static double OneBasisFun(this double[] U, int i, double u, int p)
	{
		int num = U.Length - 1;
		if ((i == 0 && u == U[0]) || (i == num - p - 1 && u == U[num]))
		{
			return 1.0;
		}
		if (u < U[i] || u >= U[i + p + 1])
		{
			return 0.0;
		}
		double[] array = new double[p + 1];
		for (int j = 0; j <= p; j++)
		{
			if (u >= U[i + j] && u < U[i + j + 1])
			{
				array[j] = 1.0;
			}
			else
			{
				array[j] = 0.0;
			}
		}
		for (int k = 1; k <= p; k++)
		{
			double num2 = ((array[0] != 0.0) ? ((u - U[i]) * array[0] / (U[i + k] - U[i])) : 0.0);
			for (int l = 0; l < p - k + 1; l++)
			{
				double num3 = U[i + l + 1];
				double num4 = U[i + l + k + 1];
				if (array[l + 1] == 0.0)
				{
					array[l] = num2;
					num2 = 0.0;
				}
				else
				{
					double num5 = array[l + 1] / (num4 - num3);
					array[l] = num2 + (num4 - u) * num5;
					num2 = (u - num3) * num5;
				}
			}
		}
		return array[0];
	}

	public static double[,] DersBasisFuns(this double[] U, int i, double u, int p, int n)
	{
		double[] array = new double[p + 1];
		double[] array2 = new double[p + 1];
		double[,] array3 = new double[p + 1, p + 1];
		double[,] array4 = new double[2, p + 1];
		array3[0, 0] = 1.0;
		int k;
		for (int j = 1; j <= p; j++)
		{
			array[j] = u - U[i + 1 - j];
			array2[j] = U[i + j] - u;
			double num = 0.0;
			for (k = 0; k < j; k++)
			{
				double num2 = array2[k + 1];
				double num3 = array[j - k];
				double num4 = (array3[j, k] = num2 + num3);
				double num5 = array3[k, j - 1] / num4;
				array3[k, j] = num + num2 * num5;
				num = num3 * num5;
			}
			array3[j, j] = num;
		}
		double[,] array5 = new double[n + 1, p + 1];
		for (int j = 0; j <= p; j++)
		{
			array5[0, j] = array3[j, p];
		}
		for (k = 0; k <= p; k++)
		{
			int num6 = 0;
			int num7 = 1;
			array4[0, 0] = 1.0;
			for (int l = 1; l <= n; l++)
			{
				double num8 = 0.0;
				int num9 = k - l;
				int num10 = p - l;
				if (k >= l)
				{
					num8 = (array4[num7, 0] = array4[num6, 0] / array3[num10 + 1, num9]) * array3[num9, num10];
				}
				int num11 = ((num9 >= -1) ? 1 : (-num9));
				int num12 = ((k - 1 > num10) ? (p - k) : (l - 1));
				int j;
				for (j = num11; j <= num12; j++)
				{
					num8 += (array4[num7, j] = (array4[num6, j] - array4[num6, j - 1]) / array3[num10 + 1, num9 + j]) * array3[num9 + j, num10];
				}
				if (k <= num10)
				{
					num8 += (array4[num7, l] = (0.0 - array4[num6, l - 1]) / array3[num10 + 1, k]) * array3[k, num10];
				}
				array5[l, k] = num8;
				j = num6;
				num6 = num7;
				num7 = j;
			}
		}
		k = p;
		for (int m = 1; m <= n; m++)
		{
			for (int j = 0; j <= p; j++)
			{
				array5[m, j] *= k;
			}
			k *= p - m;
		}
		return array5;
	}

	public static Point4D Get(this Point4D[,] pw, int u, int v, bool dir = true)
	{
		if (!dir)
		{
			return pw[v, u];
		}
		return pw[u, v];
	}

	public static int Num(this Point4D[,] pw, bool dir = true)
	{
		if (!dir)
		{
			return pw.GetLength(1);
		}
		return pw.GetLength(0);
	}
}
