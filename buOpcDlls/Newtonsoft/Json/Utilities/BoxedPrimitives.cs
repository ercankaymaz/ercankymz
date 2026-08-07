// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Utilities.BoxedPrimitives
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.CompilerServices.Newtonsoft.Json;

#nullable disable
namespace Newtonsoft.Json.Utilities;

[NullableContext(1)]
[Nullable(0)]
internal static class BoxedPrimitives
{
  internal static readonly object BooleanTrue = (object) true;
  internal static readonly object BooleanFalse = (object) false;
  internal static readonly object Int32_M1 = (object) -1;
  internal static readonly object Int32_0 = (object) 0;
  internal static readonly object Int32_1 = (object) 1;
  internal static readonly object Int32_2 = (object) 2;
  internal static readonly object Int32_3 = (object) 3;
  internal static readonly object Int32_4 = (object) 4;
  internal static readonly object Int32_5 = (object) 5;
  internal static readonly object Int32_6 = (object) 6;
  internal static readonly object Int32_7 = (object) 7;
  internal static readonly object Int32_8 = (object) 8;
  internal static readonly object Int64_M1 = (object) -1L;
  internal static readonly object Int64_0 = (object) 0L;
  internal static readonly object Int64_1 = (object) 1L;
  internal static readonly object Int64_2 = (object) 2L;
  internal static readonly object Int64_3 = (object) 3L;
  internal static readonly object Int64_4 = (object) 4L;
  internal static readonly object Int64_5 = (object) 5L;
  internal static readonly object Int64_6 = (object) 6L;
  internal static readonly object Int64_7 = (object) 7L;
  internal static readonly object Int64_8 = (object) 8L;
  internal static readonly object DoubleNaN = (object) double.NaN;
  internal static readonly object DoublePositiveInfinity = (object) double.PositiveInfinity;
  internal static readonly object DoubleNegativeInfinity = (object) double.NegativeInfinity;
  internal static readonly object DoubleZero = (object) 0.0;
  internal static readonly object DoubleNegativeZero = (object) -0.0;

  internal static object Get(bool value)
  {
    return !value ? BoxedPrimitives.BooleanFalse : BoxedPrimitives.BooleanTrue;
  }

  internal static object Get(int value)
  {
    object obj;
    switch (value)
    {
      case -1:
        obj = BoxedPrimitives.Int32_M1;
        break;
      case 0:
        obj = BoxedPrimitives.Int32_0;
        break;
      case 1:
        obj = BoxedPrimitives.Int32_1;
        break;
      case 2:
        obj = BoxedPrimitives.Int32_2;
        break;
      case 3:
        obj = BoxedPrimitives.Int32_3;
        break;
      case 4:
        obj = BoxedPrimitives.Int32_4;
        break;
      case 5:
        obj = BoxedPrimitives.Int32_5;
        break;
      case 6:
        obj = BoxedPrimitives.Int32_6;
        break;
      case 7:
        obj = BoxedPrimitives.Int32_7;
        break;
      case 8:
        obj = BoxedPrimitives.Int32_8;
        break;
      default:
        obj = (object) value;
        break;
    }
    return obj;
  }

  internal static object Get(long value)
  {
    object obj;
    switch (value - -1L)
    {
      case 0:
        obj = BoxedPrimitives.Int64_M1;
        break;
      case 1:
        obj = BoxedPrimitives.Int64_0;
        break;
      case 2:
        obj = BoxedPrimitives.Int64_1;
        break;
      case 3:
        obj = BoxedPrimitives.Int64_2;
        break;
      case 4:
        obj = BoxedPrimitives.Int64_3;
        break;
      case 5:
        obj = BoxedPrimitives.Int64_4;
        break;
      case 6:
        obj = BoxedPrimitives.Int64_5;
        break;
      case 7:
        obj = BoxedPrimitives.Int64_6;
        break;
      case 8:
        obj = BoxedPrimitives.Int64_7;
        break;
      case 9:
        obj = BoxedPrimitives.Int64_8;
        break;
      default:
        obj = (object) value;
        break;
    }
    return obj;
  }

  internal static object Get(Decimal value) => (object) value;

  internal static object Get(double value)
  {
    return value == 0.0 ? (!double.IsNegativeInfinity(1.0 / value) ? BoxedPrimitives.DoubleZero : BoxedPrimitives.DoubleNegativeZero) : (double.IsInfinity(value) ? (!double.IsPositiveInfinity(value) ? BoxedPrimitives.DoubleNegativeInfinity : BoxedPrimitives.DoublePositiveInfinity) : (double.IsNaN(value) ? BoxedPrimitives.DoubleNaN : (object) value));
  }
}
