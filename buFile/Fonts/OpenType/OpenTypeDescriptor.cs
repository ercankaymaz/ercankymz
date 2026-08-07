// Decompiled with JetBrains decompiler
// Type: PdfSharp.Fonts.OpenType.OpenTypeDescriptor
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Drawing;
using PdfSharp.Pdf.Internal;
using System;
using System.Diagnostics;
using System.Text;

#nullable disable
namespace PdfSharp.Fonts.OpenType;

internal sealed class OpenTypeDescriptor : FontDescriptor
{
  internal OpenTypeFontface FontFace;
  public int[] Widths;

  public OpenTypeDescriptor(
    string fontDescriptorKey,
    string name,
    XFontStyle stlye,
    OpenTypeFontface fontface,
    XPdfFontOptions options)
    : base(fontDescriptorKey)
  {
    this.FontFace = fontface;
    this.FontName = name;
    this.Initialize();
  }

  public OpenTypeDescriptor(string fontDescriptorKey, XFont font)
    : base(fontDescriptorKey)
  {
    try
    {
      this.FontFace = font.GlyphTypeface.Fontface;
      this.FontName = font.Name;
      this.Initialize();
    }
    catch
    {
      this.GetType();
      throw;
    }
  }

  internal OpenTypeDescriptor(string fontDescriptorKey, string idName, byte[] fontData)
    : base(fontDescriptorKey)
  {
    try
    {
      this.FontFace = new OpenTypeFontface(fontData, idName);
      if ((!idName.Contains("XPS-Font-") || this.FontFace.name == null ? 0 : (this.FontFace.name.Name.Length != 0 ? 1 : 0)) != 0)
      {
        string str = string.Empty;
        if (idName.IndexOf('+') == 6)
          str = idName.Substring(0, 6);
        idName = $"{str}+{this.FontFace.name.Name}";
        if (this.FontFace.name.Style.Length != 0)
          idName = $"{idName},{this.FontFace.name.Style}";
      }
      this.FontName = idName;
      this.Initialize();
    }
    catch (Exception ex)
    {
      this.GetType();
      throw;
    }
  }

  private void Initialize()
  {
    this.ItalicAngle = this.FontFace.post.italicAngle;
    this.XMin = (int) this.FontFace.head.xMin;
    this.YMin = (int) this.FontFace.head.yMin;
    this.XMax = (int) this.FontFace.head.xMax;
    this.YMax = (int) this.FontFace.head.yMax;
    this.UnderlinePosition = (int) this.FontFace.post.underlinePosition;
    this.UnderlineThickness = (int) this.FontFace.post.underlineThickness;
    Debug.Assert(this.FontFace.os2 != null, "TrueType font has no OS/2 table.");
    this.StrikeoutPosition = (int) this.FontFace.os2.yStrikeoutPosition;
    this.StrikeoutSize = (int) this.FontFace.os2.yStrikeoutSize;
    this.StemV = 0;
    this.UnitsPerEm = (int) this.FontFace.head.unitsPerEm;
    bool flag1 = this.FontFace.os2.sTypoAscender == (short) 0 && this.FontFace.os2.sTypoDescender == (short) 0 && this.FontFace.os2.sTypoLineGap == (short) 0;
    bool flag2 = ((uint) this.FontFace.os2.fsSelection & 128U /*0x80*/) > 0U;
    if (!flag1 & flag2)
    {
      int sTypoAscender = (int) this.FontFace.os2.sTypoAscender;
      int sTypoDescender = (int) this.FontFace.os2.sTypoDescender;
      int sTypoLineGap = (int) this.FontFace.os2.sTypoLineGap;
      this.Ascender = sTypoAscender + sTypoLineGap;
      this.Descender = -sTypoDescender;
      this.LineSpacing = sTypoAscender + sTypoLineGap - sTypoDescender;
    }
    else
    {
      int ascender = (int) this.FontFace.hhea.ascender;
      int num1 = (int) Math.Abs(this.FontFace.hhea.descender);
      int num2 = (int) Math.Max((short) 0, this.FontFace.hhea.lineGap);
      if (!flag1)
      {
        int usWinAscent = (int) this.FontFace.os2.usWinAscent;
        int num3 = Math.Abs((int) this.FontFace.os2.usWinDescent);
        this.Ascender = usWinAscent;
        this.Descender = num3;
        this.LineSpacing = Math.Max(num2 + ascender + num1, usWinAscent + num3);
      }
      else
      {
        this.Ascender = ascender;
        this.Descender = num1;
        this.LineSpacing = ascender + num1 + num2;
      }
    }
    Debug.Assert(this.Descender >= 0);
    int num4 = this.Ascender + this.Descender;
    int num5 = num4 - this.UnitsPerEm;
    this.Leading = this.LineSpacing - num4;
    if ((this.FontFace.os2.version < (ushort) 2 ? 0 : (this.FontFace.os2.sCapHeight != (short) 0 ? 1 : 0)) != 0)
      this.CapHeight = (int) this.FontFace.os2.sCapHeight;
    else
      this.CapHeight = this.Ascender;
    if ((this.FontFace.os2.version < (ushort) 2 ? 0 : (this.FontFace.os2.sxHeight != (short) 0 ? 1 : 0)) != 0)
      this.XHeight = (int) this.FontFace.os2.sxHeight;
    else
      this.XHeight = (int) (0.66 * (double) this.Ascender);
    Encoding winAnsiEncoding = PdfEncoders.WinAnsiEncoding;
    Encoding unicode = Encoding.Unicode;
    byte[] bytes = new byte[256 /*0x0100*/];
    bool symbol = this.FontFace.cmap.symbol;
    this.Widths = new int[256 /*0x0100*/];
    for (int index = 0; index < 256 /*0x0100*/; ++index)
    {
      bytes[index] = (byte) index;
      char ch = (char) index;
      string str = winAnsiEncoding.GetString(bytes, index, 1);
      if (str.Length != 0 && (int) str[0] != (int) ch)
        ch = str[0];
      if (symbol)
        ch |= (char) ((uint) this.FontFace.os2.usFirstCharIndex & 65280U);
      int glyphIndex = this.CharCodeToGlyphIndex(ch);
      this.Widths[index] = this.GlyphIndexToPdfWidth(glyphIndex);
    }
  }

  public override bool IsBoldFace => this.FontFace.os2.IsBold;

  public override bool IsItalicFace => this.FontFace.os2.IsItalic;

  internal int DesignUnitsToPdf(double value)
  {
    return (int) Math.Round(value * 1000.0 / (double) this.FontFace.head.unitsPerEm);
  }

  public int CharCodeToGlyphIndex(char value)
  {
    try
    {
      CMap4 cmap4 = this.FontFace.cmap.cmap4;
      int num = (int) cmap4.segCountX2 / 2;
      int index1 = 0;
      while (index1 < num && (int) value > (int) cmap4.endCount[index1])
        ++index1;
      Debug.Assert(index1 < num);
      if ((int) value < (int) cmap4.startCount[index1])
        return 0;
      if (cmap4.idRangeOffs[index1] == (ushort) 0)
        return (int) value + (int) cmap4.idDelta[index1] & (int) ushort.MaxValue;
      int index2 = (int) cmap4.idRangeOffs[index1] / 2 + ((int) value - (int) cmap4.startCount[index1]) - (num - index1);
      Debug.Assert(index2 >= 0 && index2 < cmap4.glyphCount);
      return cmap4.glyphIdArray[index2] == (ushort) 0 ? 0 : (int) cmap4.glyphIdArray[index2] + (int) cmap4.idDelta[index1] & (int) ushort.MaxValue;
    }
    catch
    {
      this.GetType();
      throw;
    }
  }

  public int GlyphIndexToPdfWidth(int glyphIndex)
  {
    try
    {
      int numberOfHmetrics = (int) this.FontFace.hhea.numberOfHMetrics;
      int unitsPerEm = (int) this.FontFace.head.unitsPerEm;
      if (glyphIndex >= numberOfHmetrics)
        glyphIndex = numberOfHmetrics - 1;
      int advanceWidth = (int) this.FontFace.hmtx.Metrics[glyphIndex].advanceWidth;
      return unitsPerEm == 1000 ? advanceWidth : advanceWidth * 1000 / unitsPerEm;
    }
    catch (Exception ex)
    {
      this.GetType();
      throw;
    }
  }

  public int PdfWidthFromCharCode(char ch)
  {
    return this.GlyphIndexToPdfWidth(this.CharCodeToGlyphIndex(ch));
  }

  public double GlyphIndexToEmfWidth(int glyphIndex, double emSize)
  {
    try
    {
      int numberOfHmetrics = (int) this.FontFace.hhea.numberOfHMetrics;
      int unitsPerEm = (int) this.FontFace.head.unitsPerEm;
      if (glyphIndex >= numberOfHmetrics)
        glyphIndex = numberOfHmetrics - 1;
      return (double) this.FontFace.hmtx.Metrics[glyphIndex].advanceWidth * emSize / (double) unitsPerEm;
    }
    catch (Exception ex)
    {
      this.GetType();
      throw;
    }
  }

  public int GlyphIndexToWidth(int glyphIndex)
  {
    try
    {
      int numberOfHmetrics = (int) this.FontFace.hhea.numberOfHMetrics;
      if (glyphIndex >= numberOfHmetrics)
        glyphIndex = numberOfHmetrics - 1;
      return (int) this.FontFace.hmtx.Metrics[glyphIndex].advanceWidth;
    }
    catch (Exception ex)
    {
      this.GetType();
      throw;
    }
  }
}
