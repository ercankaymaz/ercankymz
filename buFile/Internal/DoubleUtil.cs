// Decompiled with JetBrains decompiler
// Type: PdfSharp.Internal.DoubleUtil
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Drawing;
using System;
using System.Runtime.InteropServices;

#nullable disable
namespace PdfSharp.Internal;

internal static class DoubleUtil
{
  private const double Epsilon = 2.2204460492503131E-16;
  private const double TenTimesEpsilon = 2.2204460492503131E-15;
  private const float FloatMinimum = 1.175494E-38f;
  private static readonly double[] decs = new double[17]
  {
    1.0,
    0.1,
    0.01,
    0.001,
    0.0001,
    1E-05,
    1E-06,
    1E-07,
    1E-08,
    1E-09,
    1E-10,
    1E-11,
    1E-12,
    1E-13,
    1E-14,
    1E-15,
    1E-16
  };

  public static bool AreClose(double value1, double value2)
  {
    bool flag;
    if (value1.Equals(value2))
    {
      flag = true;
    }
    else
    {
      double num1 = (Math.Abs(value1) + Math.Abs(value2) + 10.0) * 2.2204460492503131E-16;
      double num2 = value1 - value2;
      flag = -num1 < num2 && num1 > num2;
    }
    return flag;
  }

  public static bool AreRoughlyEqual(double value1, double value2, int decimalPlace)
  {
    return value1 == value2 || Math.Abs(value1 - value2) < DoubleUtil.decs[decimalPlace];
  }

  public static bool AreClose(XPoint point1, XPoint point2)
  {
    return DoubleUtil.AreClose(point1.X, point2.X) && DoubleUtil.AreClose(point1.Y, point2.Y);
  }

  public static bool AreClose(XRect rect1, XRect rect2)
  {
    return !rect1.IsEmpty ? !rect2.IsEmpty && DoubleUtil.AreClose(rect1.X, rect2.X) && DoubleUtil.AreClose(rect1.Y, rect2.Y) && DoubleUtil.AreClose(rect1.Height, rect2.Height) && DoubleUtil.AreClose(rect1.Width, rect2.Width) : rect2.IsEmpty;
  }

  public static bool AreClose(XSize size1, XSize size2)
  {
    return DoubleUtil.AreClose(size1.Width, size2.Width) && DoubleUtil.AreClose(size1.Height, size2.Height);
  }

  public static bool AreClose(XVector vector1, XVector vector2)
  {
    return DoubleUtil.AreClose(vector1.X, vector2.X) && DoubleUtil.AreClose(vector1.Y, vector2.Y);
  }

  public static bool GreaterThan(double value1, double value2)
  {
    return value1 > value2 && !DoubleUtil.AreClose(value1, value2);
  }

  public static bool GreaterThanOrClose(double value1, double value2)
  {
    return value1 > value2 || DoubleUtil.AreClose(value1, value2);
  }

  public static bool LessThan(double value1, double value2)
  {
    return value1 < value2 && !DoubleUtil.AreClose(value1, value2);
  }

  public static bool LessThanOrClose(double value1, double value2)
  {
    return value1 < value2 || DoubleUtil.AreClose(value1, value2);
  }

  public static bool IsBetweenZeroAndOne(double value)
  {
    return DoubleUtil.GreaterThanOrClose(value, 0.0) && DoubleUtil.LessThanOrClose(value, 1.0);
  }

  public static bool IsNaN(double value)
  {
    DoubleUtil.NanUnion nanUnion = new DoubleUtil.NanUnion();
    nanUnion.DoubleValue = value;
    ulong num1 = nanUnion.UintValue & 18442240474082181120UL /*0xFFF0000000000000*/;
    ulong num2 = nanUnion.UintValue & 4503599627370495UL /*0x0FFFFFFFFFFFFF*/;
    return (num1 == 9218868437227405312UL /*0x7FF0000000000000*/ || num1 == 18442240474082181120UL /*0xFFF0000000000000*/) && num2 > 0UL;
  }

  public static bool RectHasNaN(XRect r)
  {
    return DoubleUtil.IsNaN(r.X) || DoubleUtil.IsNaN(r.Y) || DoubleUtil.IsNaN(r.Height) || DoubleUtil.IsNaN(r.Width);
  }

  public static bool IsOne(double value) => Math.Abs(value - 1.0) < 2.2204460492503131E-15;

  public static bool IsZero(double value) => Math.Abs(value) < 2.2204460492503131E-15;

  public static int DoubleToInt(double value)
  {
    return 0.0 < value ? (int) (value + 0.5) : (int) (value - 0.5);
  }

  [StructLayout(LayoutKind.Explicit)]
  private struct NanUnion
  {
    [FieldOffset(0)]
    internal double DoubleValue;
    [FieldOffset(0)]
    internal readonly ulong UintValue;
  }
}
