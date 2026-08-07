// Decompiled with JetBrains decompiler
// Type: buCore.buMatrix
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using buClass;
using System;
using System.Reflection;

#nullable disable
namespace buCore;

public class buMatrix
{
  private static string string_0 = "fduyfuFDSGERTHSAF-*05435/&%(hgfdhgfHGFHGFHvxcvcvTREQWEFVFDNB gR E%YT%E";
  private static string string_1 = "QWEFGHLJHGFhjklopoıuygtfc-*098h?=)(/TFDERTYUI)OKNBVFDRErd345678uhgfdXCVBHJ/&%RDW^+%&/()=)(/TRFCVBNYTrEDSX";
  private static string string_2 = "";
  private static string string_3 = "";
  private static double double_0 = 0.0;
  private static double double_1 = 0.0;
  private readonly double[,] double_2;

  public buMatrix()
  {
    if (!buVector.smethod_0(nameof (buMatrix)))
      throw new RegisterException(nameof (buMatrix));
  }

  public buMatrix(int dim1, int dim2) => this.double_2 = new double[dim1, dim2];

  public int Height => this.double_2.GetLength(0);

  public int Width => this.double_2.GetLength(1);

  public double this[int x, int y]
  {
    get => this.double_2[x, y];
    set => this.double_2[x, y] = value;
  }

  public static buMatrix CreatMatrix4x4(
    double m11,
    double m12,
    double m13,
    double m14,
    double m21,
    double m22,
    double m23,
    double m24,
    double m31,
    double m32,
    double m33,
    double m34,
    double m41,
    double m42,
    double m43,
    double m44)
  {
    try
    {
      return new buMatrix(4, 4)
      {
        [0, 0] = m11,
        [0, 1] = m12,
        [0, 2] = m13,
        [0, 3] = m14,
        [1, 0] = m21,
        [1, 1] = m22,
        [1, 2] = m23,
        [1, 3] = m24,
        [2, 0] = m31,
        [2, 1] = m32,
        [2, 2] = m33,
        [2, 3] = m34,
        [3, 0] = m41,
        [3, 1] = m42,
        [3, 2] = m43,
        [3, 3] = m44
      };
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      return new buMatrix();
    }
  }

  public static buMatrix CreatMatrix4x1(double m11, double m21, double m31, double m41)
  {
    try
    {
      return new buMatrix(4, 1)
      {
        [0, 0] = m11,
        [1, 0] = m21,
        [2, 0] = m31,
        [3, 0] = m41
      };
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      return new buMatrix();
    }
  }

  public static void Copy(buMatrix refMatrix, ref buMatrix copiedMatrix)
  {
    try
    {
      copiedMatrix = new buMatrix(refMatrix.Width, refMatrix.Height);
      for (int x = 0; x <= refMatrix.Width - 1; ++x)
      {
        for (int y = 0; y <= refMatrix.Width - 1; ++y)
          copiedMatrix[x, y] = refMatrix[x, y];
      }
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static buMatrix Multiply(buMatrix m1, buMatrix m2)
  {
    try
    {
      buMatrix buMatrix = new buMatrix(m1.Height, m2.Width);
      for (int x = 0; x < buMatrix.Height; ++x)
      {
        for (int y = 0; y < buMatrix.Width; ++y)
        {
          buMatrix[x, y] = 0.0;
          for (int index = 0; index < m1.Width; ++index)
            buMatrix[x, y] += m1[x, index] * m2[index, y];
        }
      }
      return buMatrix;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      return new buMatrix();
    }
  }

  public static void SwapRowsColumns(ref buMatrix m1)
  {
    try
    {
      buMatrix refMatrix = new buMatrix(m1.Height, m1.Width);
      for (int index1 = 0; index1 < m1.Width; ++index1)
      {
        for (int index2 = 0; index2 < m1.Height; ++index2)
        {
          double num = m1[index1, index2];
          refMatrix[index2, index1] = num;
        }
      }
      buMatrix.Copy(refMatrix, ref m1);
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public override string ToString() => $"m11{Environment.NewLine}m22";
}
