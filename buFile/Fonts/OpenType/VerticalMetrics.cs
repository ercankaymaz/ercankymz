// Decompiled with JetBrains decompiler
// Type: PdfSharp.Fonts.OpenType.VerticalMetrics
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;

#nullable disable
namespace PdfSharp.Fonts.OpenType;

internal class VerticalMetrics : OpenTypeFontTable
{
  public const string Tag = "----";
  public ushort advanceWidth;
  public short lsb;

  public VerticalMetrics(OpenTypeFontface fontData)
    : base(fontData, "----")
  {
    this.Read();
  }

  public void Read()
  {
    try
    {
      this.advanceWidth = this._fontData.ReadUFWord();
      this.lsb = this._fontData.ReadFWord();
    }
    catch (Exception ex)
    {
      throw new InvalidOperationException(PSSR.ErrorReadingFontData, ex);
    }
  }
}
