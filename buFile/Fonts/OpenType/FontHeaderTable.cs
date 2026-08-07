// Decompiled with JetBrains decompiler
// Type: PdfSharp.Fonts.OpenType.FontHeaderTable
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;

#nullable disable
namespace PdfSharp.Fonts.OpenType;

internal class FontHeaderTable : OpenTypeFontTable
{
  public const string Tag = "head";
  public int version;
  public int fontRevision;
  public uint checkSumAdjustment;
  public uint magicNumber;
  public ushort flags;
  public ushort unitsPerEm;
  public long created;
  public long modified;
  public short xMin;
  public short yMin;
  public short xMax;
  public short yMax;
  public ushort macStyle;
  public ushort lowestRecPPEM;
  public short fontDirectionHint;
  public short indexToLocFormat;
  public short glyphDataFormat;

  public FontHeaderTable(OpenTypeFontface fontData)
    : base(fontData, "head")
  {
    this.Read();
  }

  public void Read()
  {
    try
    {
      this.version = this._fontData.ReadFixed();
      this.fontRevision = this._fontData.ReadFixed();
      this.checkSumAdjustment = this._fontData.ReadULong();
      this.magicNumber = this._fontData.ReadULong();
      this.flags = this._fontData.ReadUShort();
      this.unitsPerEm = this._fontData.ReadUShort();
      this.created = this._fontData.ReadLongDate();
      this.modified = this._fontData.ReadLongDate();
      this.xMin = this._fontData.ReadShort();
      this.yMin = this._fontData.ReadShort();
      this.xMax = this._fontData.ReadShort();
      this.yMax = this._fontData.ReadShort();
      this.macStyle = this._fontData.ReadUShort();
      this.lowestRecPPEM = this._fontData.ReadUShort();
      this.fontDirectionHint = this._fontData.ReadShort();
      this.indexToLocFormat = this._fontData.ReadShort();
      this.glyphDataFormat = this._fontData.ReadShort();
    }
    catch (Exception ex)
    {
      throw new InvalidOperationException(PSSR.ErrorReadingFontData, ex);
    }
  }
}
