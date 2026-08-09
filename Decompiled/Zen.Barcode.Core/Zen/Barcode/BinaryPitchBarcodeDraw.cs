using System;
using System.Drawing;

namespace Zen.Barcode;

public abstract class BinaryPitchBarcodeDraw<TGlyphFactory, TChecksum> : BarcodeDrawBase<TGlyphFactory, TChecksum> where TGlyphFactory : GlyphFactory where TChecksum : Checksum
{
	protected BinaryPitchBarcodeDraw(TGlyphFactory factory, int encodingBitCount)
		: base(factory, encodingBitCount)
	{
	}

	protected BinaryPitchBarcodeDraw(TGlyphFactory factory, int encodingBitCount, int widthBitCount)
		: base(factory, encodingBitCount, widthBitCount)
	{
	}

	protected BinaryPitchBarcodeDraw(TGlyphFactory factory, TChecksum checksum, int encodingBitCount)
		: base(factory, checksum, encodingBitCount)
	{
	}

	protected BinaryPitchBarcodeDraw(TGlyphFactory factory, TChecksum checksum, int encodingBitCount, int widthBitCount)
		: base(factory, checksum, encodingBitCount, widthBitCount)
	{
	}

	protected override int GetBarcodeLength(Glyph[] barcode, int interGlyphSpace, int barMinWidth, int barMaxWidth)
	{
		if (barMinWidth == barMaxWidth)
		{
			throw new InvalidOperationException("Only variable pitch drawing supported.");
		}
		int num = GetBarcodeInterGlyphLength(barcode, interGlyphSpace);
		for (int i = 0; i < barcode.Length; i++)
		{
			BinaryPitchGlyph binaryPitchGlyph = (BinaryPitchGlyph)barcode[i];
			int glyphEncodingBitCount = GetGlyphEncodingBitCount(binaryPitchGlyph);
			int num2 = base.WidthBitCount - 1;
			bool flag = false;
			for (int num3 = glyphEncodingBitCount - 1; num3 >= 0; num3--)
			{
				int num4 = 1 << num3;
				bool flag2 = false;
				if ((num4 & binaryPitchGlyph.BitEncoding) != 0)
				{
					flag2 = true;
				}
				if (num3 < glyphEncodingBitCount - 1 && flag != flag2)
				{
					num2--;
				}
				flag = flag2;
				num4 = 1 << num2;
				num = (((num4 & binaryPitchGlyph.WidthEncoding) == 0) ? (num + barMinWidth) : (num + barMaxWidth));
			}
		}
		return num;
	}

	protected virtual int GetGlyphEncodingBitCount(Glyph glyph)
	{
		return base.EncodingBitCount;
	}

	protected override void RenderBar(int glyphIndex, BarGlyph glyph, Graphics dc, Rectangle bounds, ref int barOffset, int barMinHeight, int barMinWidth, int barMaxWidth)
	{
		if (!(glyph is BinaryPitchGlyph binaryPitchGlyph))
		{
			throw new InvalidOperationException("Glyph must be derived from BinaryPitchGlyph.");
		}
		if (barMinWidth == barMaxWidth)
		{
			throw new InvalidOperationException("Only variable-pitch drawing supported.");
		}
		if (base.WidthBitCount == 0)
		{
			throw new InvalidOperationException("Must have width bit information.");
		}
		int glyphEncodingBitCount = GetGlyphEncodingBitCount(glyph);
		int num = base.WidthBitCount - 1;
		bool flag = false;
		for (int num2 = glyphEncodingBitCount - 1; num2 >= 0; num2--)
		{
			int num3 = 1 << num2;
			int num4 = barMinWidth;
			bool flag2 = false;
			if ((num3 & binaryPitchGlyph.BitEncoding) != 0)
			{
				flag2 = true;
			}
			if (num2 < glyphEncodingBitCount - 1 && flag != flag2)
			{
				num--;
			}
			flag = flag2;
			int num5 = 1 << num;
			if ((num5 & binaryPitchGlyph.WidthEncoding) != 0)
			{
				num4 = barMaxWidth;
			}
			if ((binaryPitchGlyph.BitEncoding & num3) != 0)
			{
				dc.FillRectangle(Brushes.Black, barOffset, bounds.Top, num4, bounds.Height);
			}
			barOffset += num4;
		}
	}
}
