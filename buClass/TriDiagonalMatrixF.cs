// Decompiled with JetBrains decompiler
// Type: buClass.TriDiagonalMatrixF
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Diagnostics;
using System.Text;

#nullable disable
namespace buClass;

public class TriDiagonalMatrixF
{
  public double[] A;
  public double[] B;
  public double[] C;

  public int N => this.A != null ? this.A.Length : 0;

  public double this[int row, int col]
  {
    get
    {
      switch (row - col)
      {
        case -1:
          Debug.Assert(row < this.N - 1);
          return this.C[row];
        case 0:
          return this.B[row];
        case 1:
          Debug.Assert(row > 0);
          return this.A[row];
        default:
          return 0.0;
      }
    }
    set
    {
      switch (row - col)
      {
        case -1:
          Debug.Assert(row < this.N - 1);
          this.C[row] = value;
          break;
        case 0:
          this.B[row] = value;
          break;
        case 1:
          Debug.Assert(row > 0);
          this.A[row] = value;
          break;
        default:
          throw new ArgumentException("Only the main, super, and sub diagonals can be set.");
      }
    }
  }

  public TriDiagonalMatrixF(int n)
  {
    this.A = new double[n];
    this.B = new double[n];
    this.C = new double[n];
  }

  public string ToDisplayString(string fmt = "", string prefix = "")
  {
    if (this.N <= 0)
      return prefix + "0x0 Matrix";
    StringBuilder stringBuilder = new StringBuilder();
    string format = $"{{0{fmt}}}";
    for (int row = 0; row < this.N; ++row)
    {
      stringBuilder.Append(prefix);
      for (int col = 0; col < this.N; ++col)
      {
        stringBuilder.AppendFormat(format, (object) this[row, col]);
        if (col < this.N - 1)
          stringBuilder.Append(", ");
      }
      stringBuilder.AppendLine();
    }
    return stringBuilder.ToString();
  }

  public double[] Solve(double[] d)
  {
    int n = this.N;
    if (d.Length != n)
      throw new ArgumentException("The input d is not the same size as this matrix.");
    double[] numArray1 = new double[n];
    numArray1[0] = this.C[0] / this.B[0];
    for (int index = 1; index < n; ++index)
      numArray1[index] = this.C[index] / (this.B[index] - numArray1[index - 1] * this.A[index]);
    double[] numArray2 = new double[n];
    numArray2[0] = d[0] / this.B[0];
    for (int index = 1; index < n; ++index)
      numArray2[index] = (d[index] - numArray2[index - 1] * this.A[index]) / (this.B[index] - numArray1[index - 1] * this.A[index]);
    double[] numArray3 = new double[n];
    numArray3[n - 1] = numArray2[n - 1];
    for (int index = n - 2; index >= 0; --index)
      numArray3[index] = numArray2[index] - numArray1[index] * numArray3[index + 1];
    return numArray3;
  }
}
