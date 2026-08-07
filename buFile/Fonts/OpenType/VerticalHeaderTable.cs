// Decompiled with JetBrains decompiler
// Type: PdfSharp.Fonts.OpenType.VerticalHeaderTable
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;

#nullable disable
namespace PdfSharp.Fonts.OpenType;

internal class VerticalHeaderTable : OpenTypeFontTable
{
  public const string Tag = "vhea";
  public int Version;
  public short Ascender;
  public short Descender;
  public short LineGap;
  public ushort AdvanceWidthMax;
  public short MinLeftSideBearing;
  public short MinRightSideBearing;
  public short xMaxExtent;
  public short caretSlopeRise;
  public short caretSlopeRun;
  public short reserved1;
  public short reserved2;
  public short reserved3;
  public short reserved4;
  public short reserved5;
  public short metricDataFormat;
  public ushort numberOfHMetrics;

  public VerticalHeaderTable(OpenTypeFontface fontData)
    : base(fontData, "vhea")
  {
    this.Read();
  }

  public void Read()
  {
    try
    {
      this.Version = this._fontData.ReadFixed();
      this.Ascender = this._fontData.ReadFWord();
      this.Descender = this._fontData.ReadFWord();
      this.LineGap = this._fontData.ReadFWord();
      this.AdvanceWidthMax = this._fontData.ReadUFWord();
      this.MinLeftSideBearing = this._fontData.ReadFWord();
      this.MinRightSideBearing = this._fontData.ReadFWord();
      this.xMaxExtent = this._fontData.ReadFWord();
      this.caretSlopeRise = this._fontData.ReadShort();
      this.caretSlopeRun = this._fontData.ReadShort();
      this.reserved1 = this._fontData.ReadShort();
      this.reserved2 = this._fontData.ReadShort();
      this.reserved3 = this._fontData.ReadShort();
      this.reserved4 = this._fontData.ReadShort();
      this.reserved5 = this._fontData.ReadShort();
      this.metricDataFormat = this._fontData.ReadShort();
      this.numberOfHMetrics = this._fontData.ReadUShort();
    }
    catch (Exception ex)
    {
      throw new InvalidOperationException(PSSR.ErrorReadingFontData, ex);
    }
  }
}
