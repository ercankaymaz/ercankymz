#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using PdfSharp.Fonts;
using PdfSharp.Fonts.OpenType;

namespace PdfSharp.Drawing;

internal static class FontHelper
{
	public static XSize MeasureString(string text, XFont font, XStringFormat stringFormat_notyetused)
	{
		XSize result = default(XSize);
		OpenTypeDescriptor openTypeDescriptor = FontDescriptorCache.GetOrCreateDescriptorFor(font) as OpenTypeDescriptor;
		if (openTypeDescriptor != null)
		{
			result.Height = (double)(openTypeDescriptor.Ascender + openTypeDescriptor.Descender) * font.Size / (double)font.UnitsPerEm;
			Debug.Assert(openTypeDescriptor.Ascender > 0);
			bool symbol = openTypeDescriptor.FontFace.cmap.symbol;
			int length = text.Length;
			int num = 0;
			for (int i = 0; i < length; i++)
			{
				char c = text[i];
				if (c >= ' ')
				{
					if (symbol)
					{
						c = (char)(c | (openTypeDescriptor.FontFace.os2.usFirstCharIndex & 0xFF00));
					}
					int glyphIndex = openTypeDescriptor.CharCodeToGlyphIndex(c);
					num += openTypeDescriptor.GlyphIndexToWidth(glyphIndex);
				}
			}
			result.Width = (double)num * font.Size / (double)openTypeDescriptor.UnitsPerEm;
			if ((font.GlyphTypeface.StyleSimulations & XStyleSimulations.BoldSimulation) == XStyleSimulations.BoldSimulation)
			{
				result.Width += (double)length * font.Size * 0.02;
			}
		}
		Debug.Assert(openTypeDescriptor != null, "No OpenTypeDescriptor.");
		return result;
	}

	public static Font CreateFont(string familyName, double emSize, FontStyle style, out XFontSource fontSource)
	{
		fontSource = null;
		return new Font(familyName, (float)emSize, style, GraphicsUnit.World);
	}

	public static ulong CalcChecksum(byte[] buffer)
	{
		if (buffer == null)
		{
			throw new ArgumentNullException("buffer");
		}
		uint num = 0u;
		uint num2 = 0u;
		int num3 = buffer.Length;
		int num4 = 0;
		while (num3 > 0)
		{
			int num5 = 3800;
			if (num5 > num3)
			{
				num5 = num3;
			}
			num3 -= num5;
			while (--num5 >= 0)
			{
				num += buffer[num4++];
				num2 += num;
			}
			num %= 65521;
			num2 %= 65521;
		}
		ulong num6 = (ulong)num2 << 16;
		num6 |= num;
		ulong num7 = (ulong)buffer.Length;
		return (num6 << 32) | num7;
	}

	public static XFontStyle CreateStyle(bool isBold, bool isItalic)
	{
		return (XFontStyle)((isBold ? 1 : 0) | (isItalic ? 2 : 0));
	}
}
