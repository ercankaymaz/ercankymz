// Decompiled with JetBrains decompiler
// Type: PdfSharp.Fonts.OpenType.OS2Table
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;

#nullable disable
namespace PdfSharp.Fonts.OpenType;

internal class OS2Table : OpenTypeFontTable
{
  public const string Tag = "OS/2";
  public ushort version;
  public short xAvgCharWidth;
  public ushort usWeightClass;
  public ushort usWidthClass;
  public ushort fsType;
  public short ySubscriptXSize;
  public short ySubscriptYSize;
  public short ySubscriptXOffset;
  public short ySubscriptYOffset;
  public short ySuperscriptXSize;
  public short ySuperscriptYSize;
  public short ySuperscriptXOffset;
  public short ySuperscriptYOffset;
  public short yStrikeoutSize;
  public short yStrikeoutPosition;
  public short sFamilyClass;
  public byte[] panose;
  public uint ulUnicodeRange1;
  public uint ulUnicodeRange2;
  public uint ulUnicodeRange3;
  public uint ulUnicodeRange4;
  public string achVendID;
  public ushort fsSelection;
  public ushort usFirstCharIndex;
  public ushort usLastCharIndex;
  public short sTypoAscender;
  public short sTypoDescender;
  public short sTypoLineGap;
  public ushort usWinAscent;
  public ushort usWinDescent;
  public uint ulCodePageRange1;
  public uint ulCodePageRange2;
  public short sxHeight;
  public short sCapHeight;
  public ushort usDefaultChar;
  public ushort usBreakChar;
  public ushort usMaxContext;

  public OS2Table(OpenTypeFontface fontData)
    : base(fontData, "OS/2")
  {
    this.Read();
  }

  public void Read()
  {
    try
    {
      this.version = this._fontData.ReadUShort();
      this.xAvgCharWidth = this._fontData.ReadShort();
      this.usWeightClass = this._fontData.ReadUShort();
      this.usWidthClass = this._fontData.ReadUShort();
      this.fsType = this._fontData.ReadUShort();
      this.ySubscriptXSize = this._fontData.ReadShort();
      this.ySubscriptYSize = this._fontData.ReadShort();
      this.ySubscriptXOffset = this._fontData.ReadShort();
      this.ySubscriptYOffset = this._fontData.ReadShort();
      this.ySuperscriptXSize = this._fontData.ReadShort();
      this.ySuperscriptYSize = this._fontData.ReadShort();
      this.ySuperscriptXOffset = this._fontData.ReadShort();
      this.ySuperscriptYOffset = this._fontData.ReadShort();
      this.yStrikeoutSize = this._fontData.ReadShort();
      this.yStrikeoutPosition = this._fontData.ReadShort();
      this.sFamilyClass = this._fontData.ReadShort();
      this.panose = this._fontData.ReadBytes(10);
      this.ulUnicodeRange1 = this._fontData.ReadULong();
      this.ulUnicodeRange2 = this._fontData.ReadULong();
      this.ulUnicodeRange3 = this._fontData.ReadULong();
      this.ulUnicodeRange4 = this._fontData.ReadULong();
      this.achVendID = this._fontData.ReadString(4);
      this.fsSelection = this._fontData.ReadUShort();
      this.usFirstCharIndex = this._fontData.ReadUShort();
      this.usLastCharIndex = this._fontData.ReadUShort();
      this.sTypoAscender = this._fontData.ReadShort();
      this.sTypoDescender = this._fontData.ReadShort();
      this.sTypoLineGap = this._fontData.ReadShort();
      this.usWinAscent = this._fontData.ReadUShort();
      this.usWinDescent = this._fontData.ReadUShort();
      if (this.version < (ushort) 1)
        return;
      this.ulCodePageRange1 = this._fontData.ReadULong();
      this.ulCodePageRange2 = this._fontData.ReadULong();
      if (this.version < (ushort) 2)
        return;
      this.sxHeight = this._fontData.ReadShort();
      this.sCapHeight = this._fontData.ReadShort();
      this.usDefaultChar = this._fontData.ReadUShort();
      this.usBreakChar = this._fontData.ReadUShort();
      this.usMaxContext = this._fontData.ReadUShort();
    }
    catch (Exception ex)
    {
      throw new InvalidOperationException(PSSR.ErrorReadingFontData, ex);
    }
  }

  public bool IsBold => ((uint) this.fsSelection & 32U /*0x20*/) > 0U;

  public bool IsItalic => ((uint) this.fsSelection & 1U) > 0U;

  [Flags]
  public enum FontSelectionFlags : ushort
  {
    Italic = 1,
    Bold = 32, // 0x0020
    Regular = 64, // 0x0040
  }
}
