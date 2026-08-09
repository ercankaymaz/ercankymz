using System;

namespace buClass;

public class CubicSpline
{
	private double[] a;

	private double[] b;

	private double[] xOrig;

	private double[] yOrig;

	private int _lastIndex = 0;

	public CubicSpline()
	{
	}

	public CubicSpline(double[] x, double[] y, double startSlope = double.NaN, double endSlope = double.NaN)
	{
		Fit(x, y, startSlope, endSlope);
	}

	private void CheckAlreadyFitted()
	{
		if (a == null)
		{
			throw new Exception("Fit must be called before you can evaluate.");
		}
	}

	private int GetNextXIndex(double x)
	{
		if (x < xOrig[_lastIndex])
		{
			throw new ArgumentException("The X values to evaluate must be sorted.");
		}
		while (_lastIndex < xOrig.Length - 2 && x > xOrig[_lastIndex + 1])
		{
			_lastIndex++;
		}
		return _lastIndex;
	}

	private double EvalSpline(double x, int j)
	{
		double num = xOrig[j + 1] - xOrig[j];
		double num2 = (x - xOrig[j]) / num;
		return (1.0 - num2) * yOrig[j] + num2 * yOrig[j + 1] + num2 * (1.0 - num2) * (a[j] * (1.0 - num2) + b[j] * num2);
	}

	public double[] FitAndEval(double[] x, double[] y, double[] xs, double startSlope = double.NaN, double endSlope = double.NaN)
	{
		Fit(x, y, startSlope, endSlope);
		return Eval(xs);
	}

	public void Fit(double[] x, double[] y, double startSlope = double.NaN, double endSlope = double.NaN)
	{
		if (double.IsInfinity(startSlope) || double.IsInfinity(endSlope))
		{
			throw new Exception("startSlope and endSlope cannot be infinity.");
		}
		xOrig = x;
		yOrig = y;
		int num = x.Length;
		double[] array = new double[num];
		TriDiagonalMatrixF triDiagonalMatrixF = new TriDiagonalMatrixF(num);
		if (double.IsNaN(startSlope))
		{
			double num2 = x[1] - x[0];
			triDiagonalMatrixF.C[0] = 1.0 / num2;
			triDiagonalMatrixF.B[0] = 2.0 * triDiagonalMatrixF.C[0];
			array[0] = 3.0 * (y[1] - y[0]) / (num2 * num2);
		}
		else
		{
			triDiagonalMatrixF.B[0] = 1.0;
			array[0] = startSlope;
		}
		for (int i = 1; i < num - 1; i++)
		{
			double num2 = x[i] - x[i - 1];
			double num3 = x[i + 1] - x[i];
			triDiagonalMatrixF.A[i] = 1.0 / num2;
			triDiagonalMatrixF.C[i] = 1.0 / num3;
			triDiagonalMatrixF.B[i] = 2.0 * (triDiagonalMatrixF.A[i] + triDiagonalMatrixF.C[i]);
			double num4 = y[i] - y[i - 1];
			double num5 = y[i + 1] - y[i];
			array[i] = 3.0 * (num4 / (num2 * num2) + num5 / (num3 * num3));
		}
		if (double.IsNaN(endSlope))
		{
			double num2 = x[num - 1] - x[num - 2];
			double num4 = y[num - 1] - y[num - 2];
			triDiagonalMatrixF.A[num - 1] = 1.0 / num2;
			triDiagonalMatrixF.B[num - 1] = 2.0 * triDiagonalMatrixF.A[num - 1];
			array[num - 1] = 3.0 * (num4 / (num2 * num2));
		}
		else
		{
			triDiagonalMatrixF.B[num - 1] = 1.0;
			array[num - 1] = endSlope;
		}
		double[] array2 = triDiagonalMatrixF.Solve(array);
		a = new double[num - 1];
		b = new double[num - 1];
		for (int j = 1; j < num; j++)
		{
			double num2 = x[j] - x[j - 1];
			double num4 = y[j] - y[j - 1];
			a[j - 1] = array2[j - 1] * num2 - num4;
			b[j - 1] = (0.0 - array2[j]) * num2 + num4;
		}
	}

	public double[] Eval(double[] x)
	{
		CheckAlreadyFitted();
		int num = x.Length;
		double[] array = new double[num];
		_lastIndex = 0;
		for (int i = 0; i < num; i++)
		{
			int nextXIndex = GetNextXIndex(x[i]);
			array[i] = EvalSpline(x[i], nextXIndex);
		}
		return array;
	}

	public double[] EvalSlope(double[] x)
	{
		CheckAlreadyFitted();
		int num = x.Length;
		double[] array = new double[num];
		_lastIndex = 0;
		for (int i = 0; i < num; i++)
		{
			int nextXIndex = GetNextXIndex(x[i]);
			double num2 = xOrig[nextXIndex + 1] - xOrig[nextXIndex];
			double num3 = yOrig[nextXIndex + 1] - yOrig[nextXIndex];
			double num4 = (x[i] - xOrig[nextXIndex]) / num2;
			array[i] = num3 / num2 + (1.0 - 2.0 * num4) * (a[nextXIndex] * (1.0 - num4) + b[nextXIndex] * num4) / num2 + num4 * (1.0 - num4) * (b[nextXIndex] - a[nextXIndex]) / num2;
		}
		return array;
	}

	public static void Compute(double[] x, double[] y, double[] z, double[] xs, out double[] ys, out double[] zs, double startSlope = double.NaN, double endSlope = double.NaN)
	{
		CubicSpline cubicSpline = new CubicSpline();
		ys = cubicSpline.FitAndEval(x, y, xs, startSlope, endSlope);
		CubicSpline cubicSpline2 = new CubicSpline();
		zs = cubicSpline2.FitAndEval(x, z, xs, startSlope, endSlope);
	}

	public static void FitGeometric(double[] x, double[] y, double[] z, int nOutputPoints, out double[] xs, out double[] ys, out double[] zs)
	{
		int num = x.Length;
		double[] array = new double[num];
		array[0] = 0.0;
		double num2 = 0.0;
		for (int i = 1; i < num; i++)
		{
			double num3 = x[i] - x[i - 1];
			double num4 = y[i] - y[i - 1];
			double num5 = z[i] - z[i - 1];
			double num6 = Math.Sqrt(num3 * num3 + num4 * num4 + num5 * num5);
			num2 = (array[i] = num2 + num6);
		}
		double num7 = num2 / (double)(nOutputPoints - 1);
		double[] array2 = new double[nOutputPoints];
		array2[0] = 0.0;
		for (int j = 1; j < nOutputPoints; j++)
		{
			array2[j] = array2[j - 1] + num7;
		}
		CubicSpline cubicSpline = new CubicSpline();
		xs = cubicSpline.FitAndEval(array, x, array2);
		CubicSpline cubicSpline2 = new CubicSpline();
		ys = cubicSpline2.FitAndEval(array, y, array2);
		CubicSpline cubicSpline3 = new CubicSpline();
		zs = cubicSpline3.FitAndEval(array, z, array2);
	}
}
