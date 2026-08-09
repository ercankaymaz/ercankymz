using System;
using System.Drawing;

namespace Zen.Barcode;

public abstract class BarcodeDrawBase<TGlyphFactory, TChecksum> : BarcodeDraw where TGlyphFactory : GlyphFactory where TChecksum : Checksum
{
	private TGlyphFactory _factory;

	private TChecksum _checksum;

	private int _encodingBitCount;

	private int _widthBitCount;

	protected TGlyphFactory Factory => _factory;

	protected TChecksum Checksum => _checksum;

	protected int EncodingBitCount => _encodingBitCount;

	protected int WidthBitCount => _widthBitCount;

	protected BarcodeDrawBase(TGlyphFactory factory, int encodingBitCount)
	{
		_factory = factory;
		_encodingBitCount = encodingBitCount;
	}

	protected BarcodeDrawBase(TGlyphFactory factory, int encodingBitCount, int widthBitCount)
	{
		_factory = factory;
		_encodingBitCount = encodingBitCount;
		_widthBitCount = widthBitCount;
	}

	protected BarcodeDrawBase(TGlyphFactory factory, TChecksum checksum, int encodingBitCount)
	{
		_factory = factory;
		_checksum = checksum;
		_encodingBitCount = encodingBitCount;
	}

	protected BarcodeDrawBase(TGlyphFactory factory, TChecksum checksum, int encodingBitCount, int widthBitCount)
	{
		_factory = factory;
		_checksum = checksum;
		_encodingBitCount = encodingBitCount;
		_widthBitCount = widthBitCount;
	}

	public sealed override Image Draw(string text, BarcodeMetrics metrics)
	{
		return Draw1d(text, (BarcodeMetrics1d)metrics);
	}

	protected virtual Image Draw1d(string text, BarcodeMetrics1d metrics)
	{
		Glyph[] fullBarcode = GetFullBarcode(text);
		int num = ((!metrics.InterGlyphSpacing.HasValue) ? GetDefaultInterGlyphSpace(metrics.MinWidth, metrics.MaxWidth) : metrics.InterGlyphSpacing.Value);
		int barcodeLength = GetBarcodeLength(fullBarcode, num * metrics.Scale, metrics.MinWidth * metrics.Scale, metrics.MaxWidth * metrics.Scale);
		Bitmap bitmap = new Bitmap(barcodeLength, metrics.MaxHeight);
		using (Graphics dc = Graphics.FromImage(bitmap))
		{
			Rectangle bounds = new Rectangle(0, 0, barcodeLength, metrics.MaxHeight);
			Render(fullBarcode, dc, bounds, num * metrics.Scale, metrics.MinHeight, metrics.MinWidth * metrics.Scale, metrics.MaxWidth * metrics.Scale);
		}
		if (metrics.RenderVertically)
		{
			bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
		}
		return bitmap;
	}

	protected virtual int GetDefaultInterGlyphSpace(int barMinWidth, int barMaxWidth)
	{
		return 0;
	}

	protected abstract Glyph[] GetFullBarcode(string text);

	protected virtual int GetBarcodeLength(Glyph[] barcode, int interGlyphSpace, int barMinWidth, int barMaxWidth)
	{
		int num = GetBarcodeInterGlyphLength(barcode, interGlyphSpace);
		for (int i = 0; i < barcode.Length; i++)
		{
			BarGlyph barGlyph = (BarGlyph)barcode[i];
			int encodingBitCount = GetEncodingBitCount(barGlyph);
			if (barGlyph is IBinaryPitchGlyph)
			{
				IBinaryPitchGlyph binaryPitchGlyph = (IBinaryPitchGlyph)barGlyph;
				int num2 = WidthBitCount - 1;
				bool flag = false;
				for (int num3 = encodingBitCount - 1; num3 >= 0; num3--)
				{
					int num4 = 1 << num3;
					bool flag2 = false;
					if ((num4 & binaryPitchGlyph.BitEncoding) != 0)
					{
						flag2 = true;
					}
					if (num3 < encodingBitCount - 1 && flag != flag2)
					{
						num2--;
					}
					flag = flag2;
					num4 = 1 << num2;
					num = (((num4 & binaryPitchGlyph.WidthEncoding) == 0) ? (num + barMinWidth) : (num + barMaxWidth));
				}
			}
			else
			{
				num += encodingBitCount * barMinWidth;
			}
		}
		return num;
	}

	protected virtual int GetEncodingBitCount(Glyph glyph)
	{
		int result = EncodingBitCount;
		if (glyph is IVaryLengthGlyph)
		{
			IVaryLengthGlyph varyLengthGlyph = (IVaryLengthGlyph)glyph;
			result = varyLengthGlyph.BitEncodingWidth;
		}
		return result;
	}

	protected virtual int GetWidthBitCount(Glyph glyph)
	{
		return WidthBitCount;
	}

	protected int GetBarcodeInterGlyphLength(Glyph[] barcode, int interGlyphSpace)
	{
		return (barcode.Length - 1) * interGlyphSpace;
	}

	protected virtual void Render(Glyph[] barcode, Graphics dc, Rectangle bounds, int interGlyphSpace, int barMinHeight, int barMinWidth, int barMaxWidth)
	{
		dc.FillRectangle(Brushes.White, bounds);
		RenderBars(barcode, dc, bounds, interGlyphSpace, barMinHeight, barMinWidth, barMaxWidth);
	}

	protected virtual void RenderBars(Glyph[] barcode, Graphics dc, Rectangle bounds, int interGlyphSpace, int barMinHeight, int barMinWidth, int barMaxWidth)
	{
		int barOffset = 0;
		for (int i = 0; i < barcode.Length; i++)
		{
			BarGlyph glyph = (BarGlyph)barcode[i];
			RenderBar(i, glyph, dc, bounds, ref barOffset, barMinHeight, barMinWidth, barMaxWidth);
			barOffset += interGlyphSpace;
		}
	}

	protected virtual void RenderBar(int glyphIndex, BarGlyph glyph, Graphics dc, Rectangle bounds, ref int barOffset, int barMinHeight, int barMinWidth, int barMaxWidth)
	{
		int encodingBitCount = GetEncodingBitCount(glyph);
		if (encodingBitCount == 0)
		{
			throw new InvalidOperationException("Encoding bit width must be greater than zero.");
		}
		int glyphEncoding = GetGlyphEncoding(glyphIndex, glyph);
		int glyphHeight = GetGlyphHeight(glyph, barMinHeight, bounds.Height);
		if (glyph is IBinaryPitchGlyph)
		{
			IBinaryPitchGlyph binaryPitchGlyph = (IBinaryPitchGlyph)glyph;
			int num = WidthBitCount - 1;
			bool flag = false;
			for (int num2 = encodingBitCount - 1; num2 >= 0; num2--)
			{
				int num3 = 1 << num2;
				int num4 = barMinWidth;
				bool flag2 = false;
				if ((num3 & glyphEncoding) != 0)
				{
					flag2 = true;
				}
				if (num2 < encodingBitCount - 1 && flag != flag2)
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
					dc.FillRectangle(Brushes.Black, barOffset, bounds.Top, num4, glyphHeight);
				}
				barOffset += num4;
			}
			return;
		}
		for (int num6 = encodingBitCount - 1; num6 >= 0; num6--)
		{
			int num7 = 1 << num6;
			if ((glyphEncoding & num7) != 0)
			{
				dc.FillRectangle(Brushes.Black, barOffset, bounds.Top, barMinWidth, glyphHeight);
			}
			barOffset += barMinWidth;
		}
	}

	protected virtual int GetGlyphEncoding(int glyphIndex, BarGlyph glyph)
	{
		return glyph.BitEncoding;
	}

	protected virtual int GetGlyphHeight(Glyph glyph, int barMinHeight, int barMaxHeight)
	{
		return barMaxHeight;
	}
}
