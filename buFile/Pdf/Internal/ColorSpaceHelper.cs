// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Internal.ColorSpaceHelper
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Drawing;
using System;

#nullable disable
namespace PdfSharp.Pdf.Internal;

internal static class ColorSpaceHelper
{
  public static XColor EnsureColorMode(PdfColorMode colorMode, XColor color)
  {
    return (colorMode != PdfColorMode.Rgb ? 0 : (color.ColorSpace != 0 ? 1 : 0)) == 0 ? ((colorMode != PdfColorMode.Cmyk ? 0 : (color.ColorSpace != XColorSpace.Cmyk ? 1 : 0)) == 0 ? color : XColor.FromCmyk(color.A, color.C, color.M, color.Y, color.K)) : XColor.FromArgb((int) (color.A * (double) byte.MaxValue), (int) color.R, (int) color.G, (int) color.B);
  }

  public static XColor EnsureColorMode(PdfDocument document, XColor color)
  {
    if (document == null)
      throw new ArgumentNullException(nameof (document));
    return ColorSpaceHelper.EnsureColorMode(document.Options.ColorMode, color);
  }

  public static bool IsEqualCmyk(XColor x, XColor y)
  {
    return (x.ColorSpace != XColorSpace.Cmyk ? 1 : (y.ColorSpace != XColorSpace.Cmyk ? 1 : 0)) == 0 && x.C == y.C && x.M == y.M && x.Y == y.Y && x.K == y.K;
  }
}
