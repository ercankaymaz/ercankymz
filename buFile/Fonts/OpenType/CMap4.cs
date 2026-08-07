// Decompiled with JetBrains decompiler
// Type: PdfSharp.Fonts.OpenType.CMap4
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;
using System.Diagnostics;

#nullable disable
namespace PdfSharp.Fonts.OpenType;

internal class CMap4 : OpenTypeFontTable
{
  public WinEncodingId encodingId;
  public ushort format;
  public ushort length;
  public ushort language;
  public ushort segCountX2;
  public ushort searchRange;
  public ushort entrySelector;
  public ushort rangeShift;
  public ushort[] endCount;
  public ushort[] startCount;
  public short[] idDelta;
  public ushort[] idRangeOffs;
  public int glyphCount;
  public ushort[] glyphIdArray;

  public CMap4(OpenTypeFontface fontData, WinEncodingId encodingId)
    : base(fontData, "----")
  {
    this.encodingId = encodingId;
    this.Read();
  }

  internal void Read()
  {
    try
    {
      this.format = this._fontData.ReadUShort();
      Debug.Assert(this.format == (ushort) 4, "Only format 4 expected.");
      this.length = this._fontData.ReadUShort();
      this.language = this._fontData.ReadUShort();
      this.segCountX2 = this._fontData.ReadUShort();
      this.searchRange = this._fontData.ReadUShort();
      this.entrySelector = this._fontData.ReadUShort();
      this.rangeShift = this._fontData.ReadUShort();
      int length = (int) this.segCountX2 / 2;
      this.glyphCount = ((int) this.length - (16 /*0x10*/ + 8 * length)) / 2;
      this.endCount = new ushort[length];
      this.startCount = new ushort[length];
      this.idDelta = new short[length];
      this.idRangeOffs = new ushort[length];
      this.glyphIdArray = new ushort[this.glyphCount];
      for (int index = 0; index < length; ++index)
        this.endCount[index] = this._fontData.ReadUShort();
      int num = (int) this._fontData.ReadUShort();
      for (int index = 0; index < length; ++index)
        this.startCount[index] = this._fontData.ReadUShort();
      for (int index = 0; index < length; ++index)
        this.idDelta[index] = this._fontData.ReadShort();
      for (int index = 0; index < length; ++index)
        this.idRangeOffs[index] = this._fontData.ReadUShort();
      for (int index = 0; index < this.glyphCount; ++index)
        this.glyphIdArray[index] = this._fontData.ReadUShort();
    }
    catch (Exception ex)
    {
      throw new InvalidOperationException(PSSR.ErrorReadingFontData, ex);
    }
  }
}
