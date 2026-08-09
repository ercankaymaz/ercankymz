#define DEBUG
using System;
using System.Diagnostics;
using System.Text;
using PdfSharp.Drawing;
using PdfSharp.Pdf.Internal;

namespace PdfSharp.Fonts.OpenType;

internal sealed class OpenTypeDescriptor : FontDescriptor
{
	internal OpenTypeFontface FontFace;

	public int[] Widths;

	public override bool IsBoldFace => FontFace.os2.IsBold;

	public override bool IsItalicFace => FontFace.os2.IsItalic;

	public OpenTypeDescriptor(string fontDescriptorKey, string name, XFontStyle stlye, OpenTypeFontface fontface, XPdfFontOptions options)
		: base(fontDescriptorKey)
	{
		FontFace = fontface;
		base.FontName = name;
		Initialize();
	}

	public OpenTypeDescriptor(string fontDescriptorKey, XFont font)
		: base(fontDescriptorKey)
	{
		try
		{
			FontFace = font.GlyphTypeface.Fontface;
			base.FontName = font.Name;
			Initialize();
		}
		catch
		{
			GetType();
			throw;
		}
	}

	internal OpenTypeDescriptor(string fontDescriptorKey, string idName, byte[] fontData)
		: base(fontDescriptorKey)
	{
		try
		{
			FontFace = new OpenTypeFontface(fontData, idName);
			if (idName.Contains("XPS-Font-") && FontFace.name != null && FontFace.name.Name.Length != 0)
			{
				string text = string.Empty;
				if (idName.IndexOf('+') == 6)
				{
					text = idName.Substring(0, 6);
				}
				idName = text + "+" + FontFace.name.Name;
				if (FontFace.name.Style.Length != 0)
				{
					idName = idName + "," + FontFace.name.Style;
				}
			}
			base.FontName = idName;
			Initialize();
		}
		catch (Exception)
		{
			GetType();
			throw;
		}
	}

	private void Initialize()
	{
		base.ItalicAngle = FontFace.post.italicAngle;
		base.XMin = FontFace.head.xMin;
		base.YMin = FontFace.head.yMin;
		base.XMax = FontFace.head.xMax;
		base.YMax = FontFace.head.yMax;
		base.UnderlinePosition = FontFace.post.underlinePosition;
		base.UnderlineThickness = FontFace.post.underlineThickness;
		Debug.Assert(FontFace.os2 != null, "TrueType font has no OS/2 table.");
		base.StrikeoutPosition = FontFace.os2.yStrikeoutPosition;
		base.StrikeoutSize = FontFace.os2.yStrikeoutSize;
		base.StemV = 0;
		base.UnitsPerEm = FontFace.head.unitsPerEm;
		bool flag = FontFace.os2.sTypoAscender == 0 && FontFace.os2.sTypoDescender == 0 && FontFace.os2.sTypoLineGap == 0;
		bool flag2 = (FontFace.os2.fsSelection & 0x80) != 0;
		if (!flag && flag2)
		{
			int sTypoAscender = FontFace.os2.sTypoAscender;
			int sTypoDescender = FontFace.os2.sTypoDescender;
			int sTypoLineGap = FontFace.os2.sTypoLineGap;
			base.Ascender = sTypoAscender + sTypoLineGap;
			base.Descender = -sTypoDescender;
			base.LineSpacing = sTypoAscender + sTypoLineGap - sTypoDescender;
		}
		else
		{
			int ascender = FontFace.hhea.ascender;
			int num = Math.Abs(FontFace.hhea.descender);
			int num2 = Math.Max((short)0, FontFace.hhea.lineGap);
			if (!flag)
			{
				int usWinAscent = FontFace.os2.usWinAscent;
				int num3 = Math.Abs(FontFace.os2.usWinDescent);
				base.Ascender = usWinAscent;
				base.Descender = num3;
				base.LineSpacing = Math.Max(num2 + ascender + num, usWinAscent + num3);
			}
			else
			{
				base.Ascender = ascender;
				base.Descender = num;
				base.LineSpacing = ascender + num + num2;
			}
		}
		Debug.Assert(base.Descender >= 0);
		int num4 = base.Ascender + base.Descender;
		int num5 = num4 - base.UnitsPerEm;
		int leading = base.LineSpacing - num4;
		base.Leading = leading;
		if (FontFace.os2.version >= 2 && FontFace.os2.sCapHeight != 0)
		{
			base.CapHeight = FontFace.os2.sCapHeight;
		}
		else
		{
			base.CapHeight = base.Ascender;
		}
		if (FontFace.os2.version >= 2 && FontFace.os2.sxHeight != 0)
		{
			base.XHeight = FontFace.os2.sxHeight;
		}
		else
		{
			base.XHeight = (int)(0.66 * (double)base.Ascender);
		}
		Encoding winAnsiEncoding = PdfEncoders.WinAnsiEncoding;
		Encoding unicode = Encoding.Unicode;
		byte[] array = new byte[256];
		bool symbol = FontFace.cmap.symbol;
		Widths = new int[256];
		for (int i = 0; i < 256; i++)
		{
			array[i] = (byte)i;
			char c = (char)i;
			string text = winAnsiEncoding.GetString(array, i, 1);
			if (text.Length != 0 && text[0] != c)
			{
				c = text[0];
			}
			if (symbol)
			{
				c = (char)(c | (FontFace.os2.usFirstCharIndex & 0xFF00));
			}
			int glyphIndex = CharCodeToGlyphIndex(c);
			Widths[i] = GlyphIndexToPdfWidth(glyphIndex);
		}
	}

	internal int DesignUnitsToPdf(double value)
	{
		return (int)Math.Round(value * 1000.0 / (double)(int)FontFace.head.unitsPerEm);
	}

	public int CharCodeToGlyphIndex(char value)
	{
		try
		{
			CMap4 cmap = FontFace.cmap.cmap4;
			int num = cmap.segCountX2 / 2;
			int i;
			for (i = 0; i < num && value > cmap.endCount[i]; i++)
			{
			}
			Debug.Assert(i < num);
			if (value < cmap.startCount[i])
			{
				return 0;
			}
			if (cmap.idRangeOffs[i] == 0)
			{
				return (value + cmap.idDelta[i]) & 0xFFFF;
			}
			int num2 = cmap.idRangeOffs[i] / 2 + (value - cmap.startCount[i]) - (num - i);
			Debug.Assert(num2 >= 0 && num2 < cmap.glyphCount);
			if (cmap.glyphIdArray[num2] == 0)
			{
				return 0;
			}
			return (cmap.glyphIdArray[num2] + cmap.idDelta[i]) & 0xFFFF;
		}
		catch
		{
			GetType();
			throw;
		}
	}

	public int GlyphIndexToPdfWidth(int glyphIndex)
	{
		try
		{
			int numberOfHMetrics = FontFace.hhea.numberOfHMetrics;
			int unitsPerEm = FontFace.head.unitsPerEm;
			if (glyphIndex >= numberOfHMetrics)
			{
				glyphIndex = numberOfHMetrics - 1;
			}
			int advanceWidth = FontFace.hmtx.Metrics[glyphIndex].advanceWidth;
			if (unitsPerEm == 1000)
			{
				return advanceWidth;
			}
			return advanceWidth * 1000 / unitsPerEm;
		}
		catch (Exception)
		{
			GetType();
			throw;
		}
	}

	public int PdfWidthFromCharCode(char ch)
	{
		int glyphIndex = CharCodeToGlyphIndex(ch);
		return GlyphIndexToPdfWidth(glyphIndex);
	}

	public double GlyphIndexToEmfWidth(int glyphIndex, double emSize)
	{
		try
		{
			int numberOfHMetrics = FontFace.hhea.numberOfHMetrics;
			int unitsPerEm = FontFace.head.unitsPerEm;
			if (glyphIndex >= numberOfHMetrics)
			{
				glyphIndex = numberOfHMetrics - 1;
			}
			int advanceWidth = FontFace.hmtx.Metrics[glyphIndex].advanceWidth;
			return (double)advanceWidth * emSize / (double)unitsPerEm;
		}
		catch (Exception)
		{
			GetType();
			throw;
		}
	}

	public int GlyphIndexToWidth(int glyphIndex)
	{
		try
		{
			int numberOfHMetrics = FontFace.hhea.numberOfHMetrics;
			if (glyphIndex >= numberOfHMetrics)
			{
				glyphIndex = numberOfHMetrics - 1;
			}
			return FontFace.hmtx.Metrics[glyphIndex].advanceWidth;
		}
		catch (Exception)
		{
			GetType();
			throw;
		}
	}
}
