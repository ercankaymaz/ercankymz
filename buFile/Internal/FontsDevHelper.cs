// Decompiled with JetBrains decompiler
// Type: PdfSharp.Internal.FontsDevHelper
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Drawing;
using PdfSharp.Fonts;

#nullable disable
namespace PdfSharp.Internal;

public static class FontsDevHelper
{
  public static XFont CreateSpecialFont(
    string familyName,
    double emSize,
    XFontStyle style,
    XPdfFontOptions pdfOptions,
    XStyleSimulations styleSimulations)
  {
    return new XFont(familyName, emSize, style, pdfOptions, styleSimulations);
  }

  public static string GetFontCachesState() => FontFactory.GetFontCachesState();
}
