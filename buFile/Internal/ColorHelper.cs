// Decompiled with JetBrains decompiler
// Type: PdfSharp.Internal.ColorHelper
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;

#nullable disable
namespace PdfSharp.Internal;

internal static class ColorHelper
{
  public static float sRgbToScRgb(byte bval)
  {
    float num = (float) bval / (float) byte.MaxValue;
    return (double) num > 0.0 ? ((double) num > 0.04045 ? ((double) num >= 1.0 ? 1f : (float) Math.Pow(((double) num + 0.055) / 1.055, 2.4)) : num / 12.92f) : 0.0f;
  }

  public static byte ScRgbTosRgb(float val)
  {
    return (double) val > 0.0 ? ((double) val > 0.0031308 ? ((double) val >= 1.0 ? byte.MaxValue : (byte) ((double) byte.MaxValue * (1.0549999475479126 * Math.Pow((double) val, 5.0 / 12.0) - 0.054999999701976776) + 0.5)) : (byte) ((double) byte.MaxValue * (double) val * 12.920000076293945 + 0.5)) : (byte) 0;
  }
}
