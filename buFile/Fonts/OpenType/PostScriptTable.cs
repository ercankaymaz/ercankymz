// Decompiled with JetBrains decompiler
// Type: PdfSharp.Fonts.OpenType.PostScriptTable
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;

#nullable disable
namespace PdfSharp.Fonts.OpenType;

internal class PostScriptTable : OpenTypeFontTable
{
  public const string Tag = "post";
  public int formatType;
  public float italicAngle;
  public short underlinePosition;
  public short underlineThickness;
  public ulong isFixedPitch;
  public ulong minMemType42;
  public ulong maxMemType42;
  public ulong minMemType1;
  public ulong maxMemType1;

  public PostScriptTable(OpenTypeFontface fontData)
    : base(fontData, "post")
  {
    this.Read();
  }

  public void Read()
  {
    try
    {
      this.formatType = this._fontData.ReadFixed();
      this.italicAngle = (float) this._fontData.ReadFixed() / 65536f;
      this.underlinePosition = this._fontData.ReadFWord();
      this.underlineThickness = this._fontData.ReadFWord();
      this.isFixedPitch = (ulong) this._fontData.ReadULong();
      this.minMemType42 = (ulong) this._fontData.ReadULong();
      this.maxMemType42 = (ulong) this._fontData.ReadULong();
      this.minMemType1 = (ulong) this._fontData.ReadULong();
      this.maxMemType1 = (ulong) this._fontData.ReadULong();
    }
    catch (Exception ex)
    {
      throw new InvalidOperationException(PSSR.ErrorReadingFontData, ex);
    }
  }
}
