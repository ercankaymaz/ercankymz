// Decompiled with JetBrains decompiler
// Type: PdfSharp.Drawing.FontHelper
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Fonts;
using PdfSharp.Fonts.OpenType;
using System;
using System.Diagnostics;
using System.Drawing;

#nullable disable
namespace PdfSharp.Drawing;

internal static class FontHelper
{
  public static XSize MeasureString(string text, XFont font, XStringFormat stringFormat_notyetused)
  {
    XSize xsize = new XSize();
    if (FontDescriptorCache.GetOrCreateDescriptorFor(font) is OpenTypeDescriptor descriptorFor)
    {
      xsize.Height = (double) (descriptorFor.Ascender + descriptorFor.Descender) * font.Size / (double) font.UnitsPerEm;
      Debug.Assert(descriptorFor.Ascender > 0);
      bool symbol = descriptorFor.FontFace.cmap.symbol;
      int length = text.Length;
      int num = 0;
      for (int index = 0; index < length; ++index)
      {
        char ch = text[index];
        if (ch >= ' ')
        {
          if (symbol)
            ch |= (char) ((uint) descriptorFor.FontFace.os2.usFirstCharIndex & 65280U);
          int glyphIndex = descriptorFor.CharCodeToGlyphIndex(ch);
          num += descriptorFor.GlyphIndexToWidth(glyphIndex);
        }
      }
      xsize.Width = (double) num * font.Size / (double) descriptorFor.UnitsPerEm;
      if ((font.GlyphTypeface.StyleSimulations & XStyleSimulations.BoldSimulation) == XStyleSimulations.BoldSimulation)
        xsize.Width += (double) length * font.Size * 0.02;
    }
    Debug.Assert(descriptorFor != null, "No OpenTypeDescriptor.");
    return xsize;
  }

  public static Font CreateFont(
    string familyName,
    double emSize,
    FontStyle style,
    out XFontSource fontSource)
  {
    fontSource = (XFontSource) null;
    return new Font(familyName, (float) emSize, style, GraphicsUnit.World);
  }

  public static ulong CalcChecksum(byte[] buffer)
  {
    if (buffer == null)
      throw new ArgumentNullException(nameof (buffer));
    uint num1 = 0;
    uint num2 = 0;
    int length = buffer.Length;
    int num3 = 0;
    while (length > 0)
    {
      int num4 = 3800;
      if (3800 > length)
        num4 = length;
      length -= num4;
      while (--num4 >= 0)
      {
        num1 += (uint) buffer[num3++];
        num2 += num1;
      }
      num1 %= 65521U;
      num2 %= 65521U;
    }
    return ((ulong) num2 << 16 /*0x10*/ | (ulong) num1) << 32 /*0x20*/ | (ulong) buffer.Length;
  }

  public static XFontStyle CreateStyle(bool isBold, bool isItalic)
  {
    return (XFontStyle) ((isBold ? 1 : 0) | (isItalic ? 2 : 0));
  }
}
