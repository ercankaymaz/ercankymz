// Decompiled with JetBrains decompiler
// Type: buClass.CubicSpline
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;

#nullable disable
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
    this.Fit(x, y, startSlope, endSlope);
  }

  private void CheckAlreadyFitted()
  {
    if (this.a == null)
      throw new Exception("Fit must be called before you can evaluate.");
  }

  private int GetNextXIndex(double x)
  {
    if (x < this.xOrig[this._lastIndex])
      throw new ArgumentException("The X values to evaluate must be sorted.");
    while (this._lastIndex < this.xOrig.Length - 2 && x > this.xOrig[this._lastIndex + 1])
      ++this._lastIndex;
    return this._lastIndex;
  }

  private double EvalSpline(double x, int j)
  {
    double num1 = this.xOrig[j + 1] - this.xOrig[j];
    double num2 = (x - this.xOrig[j]) / num1;
    return (1.0 - num2) * this.yOrig[j] + num2 * this.yOrig[j + 1] + num2 * (1.0 - num2) * (this.a[j] * (1.0 - num2) + this.b[j] * num2);
  }

  public double[] FitAndEval(
    double[] x,
    double[] y,
    double[] xs,
    double startSlope = double.NaN,
    double endSlope = double.NaN)
  {
    this.Fit(x, y, startSlope, endSlope);
    return this.Eval(xs);
  }

  public void Fit(double[] x, double[] y, double startSlope = double.NaN, double endSlope = double.NaN)
  {
    if (double.IsInfinity(startSlope) || double.IsInfinity(endSlope))
      throw new Exception("startSlope and endSlope cannot be infinity.");
    this.xOrig = x;
    this.yOrig = y;
    int length = x.Length;
    double[] d = new double[length];
    TriDiagonalMatrixF triDiagonalMatrixF = new TriDiagonalMatrixF(length);
    if (double.IsNaN(startSlope))
    {
      double num = x[1] - x[0];
      triDiagonalMatrixF.C[0] = 1.0 / num;
      triDiagonalMatrixF.B[0] = 2.0 * triDiagonalMatrixF.C[0];
      d[0] = 3.0 * (y[1] - y[0]) / (num * num);
    }
    else
    {
      triDiagonalMatrixF.B[0] = 1.0;
      d[0] = startSlope;
    }
    for (int index = 1; index < length - 1; ++index)
    {
      double num1 = x[index] - x[index - 1];
      double num2 = x[index + 1] - x[index];
      triDiagonalMatrixF.A[index] = 1.0 / num1;
      triDiagonalMatrixF.C[index] = 1.0 / num2;
      triDiagonalMatrixF.B[index] = 2.0 * (triDiagonalMatrixF.A[index] + triDiagonalMatrixF.C[index]);
      double num3 = y[index] - y[index - 1];
      double num4 = y[index + 1] - y[index];
      d[index] = 3.0 * (num3 / (num1 * num1) + num4 / (num2 * num2));
    }
    if (double.IsNaN(endSlope))
    {
      double num5 = x[length - 1] - x[length - 2];
      double num6 = y[length - 1] - y[length - 2];
      triDiagonalMatrixF.A[length - 1] = 1.0 / num5;
      triDiagonalMatrixF.B[length - 1] = 2.0 * triDiagonalMatrixF.A[length - 1];
      d[length - 1] = 3.0 * (num6 / (num5 * num5));
    }
    else
    {
      triDiagonalMatrixF.B[length - 1] = 1.0;
      d[length - 1] = endSlope;
    }
    double[] numArray = triDiagonalMatrixF.Solve(d);
    this.a = new double[length - 1];
    this.b = new double[length - 1];
    for (int index = 1; index < length; ++index)
    {
      double num7 = x[index] - x[index - 1];
      double num8 = y[index] - y[index - 1];
      this.a[index - 1] = numArray[index - 1] * num7 - num8;
      this.b[index - 1] = -numArray[index] * num7 + num8;
    }
  }

  public double[] Eval(double[] x)
  {
    this.CheckAlreadyFitted();
    int length = x.Length;
    double[] numArray = new double[length];
    this._lastIndex = 0;
    for (int index = 0; index < length; ++index)
    {
      int nextXindex = this.GetNextXIndex(x[index]);
      numArray[index] = this.EvalSpline(x[index], nextXindex);
    }
    return numArray;
  }

  public double[] EvalSlope(double[] x)
  {
    this.CheckAlreadyFitted();
    int length = x.Length;
    double[] numArray = new double[length];
    this._lastIndex = 0;
    for (int index = 0; index < length; ++index)
    {
      int nextXindex = this.GetNextXIndex(x[index]);
      double num1 = this.xOrig[nextXindex + 1] - this.xOrig[nextXindex];
      double num2 = this.yOrig[nextXindex + 1] - this.yOrig[nextXindex];
      double num3 = (x[index] - this.xOrig[nextXindex]) / num1;
      numArray[index] = num2 / num1 + (1.0 - 2.0 * num3) * (this.a[nextXindex] * (1.0 - num3) + this.b[nextXindex] * num3) / num1 + num3 * (1.0 - num3) * (this.b[nextXindex] - this.a[nextXindex]) / num1;
    }
    return numArray;
  }

  public static void Compute(
    double[] x,
    double[] y,
    double[] z,
    double[] xs,
    out double[] ys,
    out double[] zs,
    double startSlope = double.NaN,
    double endSlope = double.NaN)
  {
    CubicSpline cubicSpline1 = new CubicSpline();
    ys = cubicSpline1.FitAndEval(x, y, xs, startSlope, endSlope);
    CubicSpline cubicSpline2 = new CubicSpline();
    zs = cubicSpline1.FitAndEval(x, z, xs, startSlope, endSlope);
  }

  public static void FitGeometric(
    double[] x,
    double[] y,
    double[] z,
    int nOutputPoints,
    out double[] xs,
    out double[] ys,
    out double[] zs)
  {
    int length = x.Length;
    double[] x1 = new double[length];
    x1[0] = 0.0;
    double num1 = 0.0;
    for (int index = 1; index < length; ++index)
    {
      double num2 = x[index] - x[index - 1];
      double num3 = y[index] - y[index - 1];
      double num4 = z[index] - z[index - 1];
      double num5 = Math.Sqrt(num2 * num2 + num3 * num3 + num4 * num4);
      num1 += num5;
      x1[index] = num1;
    }
    double num6 = num1 / (double) (nOutputPoints - 1);
    double[] xs1 = new double[nOutputPoints];
    xs1[0] = 0.0;
    for (int index = 1; index < nOutputPoints; ++index)
      xs1[index] = xs1[index - 1] + num6;
    CubicSpline cubicSpline1 = new CubicSpline();
    xs = cubicSpline1.FitAndEval(x1, x, xs1);
    CubicSpline cubicSpline2 = new CubicSpline();
    ys = cubicSpline2.FitAndEval(x1, y, xs1);
    CubicSpline cubicSpline3 = new CubicSpline();
    zs = cubicSpline3.FitAndEval(x1, z, xs1);
  }
}
