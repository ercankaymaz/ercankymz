// Decompiled with JetBrains decompiler
// Type: Poly2Tri.Utility.MathUtil
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace Poly2Tri.Utility;

public class MathUtil
{
  public const double EPSILON = 1E-12;

  public static bool AreValuesEqual(double val1, double val2, double tolerance = 1E-12)
  {
    return (val1 < val2 - tolerance ? 0 : (val1 <= val2 + tolerance ? 1 : 0)) != 0;
  }

  public static bool IsValueBetween(double val, double min, double max, double tolerance)
  {
    if (min > max)
    {
      double num = min;
      min = max;
      max = num;
    }
    return (val + tolerance < min ? 0 : (val - tolerance <= max ? 1 : 0)) != 0;
  }

  public static double RoundWithPrecision(double f, double precision)
  {
    double num1;
    if (precision < 0.0)
    {
      num1 = f;
    }
    else
    {
      double num2 = Math.Pow(10.0, precision);
      num1 = Math.Floor(f * num2) / num2;
    }
    return num1;
  }

  public static double Clamp(double a, double low, double high) => Math.Max(low, Math.Min(a, high));

  public static void Swap<T>(ref T a, ref T b)
  {
    T obj = a;
    a = b;
    b = obj;
  }

  public static uint Jenkins32Hash(IEnumerable<byte> data, uint nInitialValue)
  {
    foreach (byte num in data)
    {
      nInitialValue += (uint) num;
      nInitialValue += nInitialValue << 10;
      nInitialValue += nInitialValue >> 6;
    }
    nInitialValue += nInitialValue << 3;
    nInitialValue ^= nInitialValue >> 11;
    nInitialValue += nInitialValue << 15;
    return nInitialValue;
  }
}
