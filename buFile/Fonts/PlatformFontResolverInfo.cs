// Decompiled with JetBrains decompiler
// Type: PdfSharp.Fonts.PlatformFontResolverInfo
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System.Drawing;

#nullable disable
namespace PdfSharp.Fonts;

internal class PlatformFontResolverInfo : FontResolverInfo
{
  private readonly Font _gdiFont;

  public PlatformFontResolverInfo(
    string faceName,
    bool mustSimulateBold,
    bool mustSimulateItalic,
    Font gdiFont)
    : base(faceName, mustSimulateBold, mustSimulateItalic)
  {
    this._gdiFont = gdiFont;
  }

  public Font GdiFont => this._gdiFont;
}
