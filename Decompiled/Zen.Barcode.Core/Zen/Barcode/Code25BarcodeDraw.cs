using System.Collections.Generic;
using System.Drawing;

namespace Zen.Barcode;

public class Code25BarcodeDraw : BarcodeDrawBase<Code25GlyphFactory, Code25Checksum>
{
	public Code25BarcodeDraw(Code25GlyphFactory factory)
		: base(factory, 0)
	{
	}

	public Code25BarcodeDraw(Code25Checksum checksum)
		: base(checksum.Factory, checksum, 0)
	{
	}

	public override BarcodeMetrics GetDefaultMetrics(int maxHeight)
	{
		return new BarcodeMetrics1d(1, 1, maxHeight);
	}

	public override BarcodeMetrics GetPrintMetrics(Size desiredBarcodeDimensions, Size printResolution, int barcodeCharLength)
	{
		int height = desiredBarcodeDimensions.Height * printResolution.Height / 100;
		int width = printResolution.Width * desiredBarcodeDimensions.Width / (100 * (24 + barcodeCharLength * 11));
		return new BarcodeMetrics1d(width, height);
	}

	protected override Glyph[] GetFullBarcode(string text)
	{
		List<Glyph> list = new List<Glyph>();
		if (base.Factory is Code25InterleavedGlyphFactory)
		{
			bool flag = false;
			if (text.Length % 2 == 1)
			{
				flag = true;
			}
			if (flag)
			{
				text = "0" + text;
			}
		}
		list.AddRange(base.Factory.GetGlyphs(text));
		if (base.Checksum != null)
		{
			list.AddRange(base.Checksum.GetChecksum(text));
		}
		list.Insert(0, base.Factory.GetRawGlyph('-'));
		list.Add(base.Factory.GetRawGlyph('*'));
		return list.ToArray();
	}

	protected override int GetDefaultInterGlyphSpace(int barMinWidth, int barMaxWidth)
	{
		if (base.Factory is Code25StandardGlyphFactory)
		{
			return barMinWidth;
		}
		return 0;
	}

	protected override int GetBarcodeLength(Glyph[] barcode, int interGlyphSpace, int barMinWidth, int barMaxWidth)
	{
		if (!(base.Factory is Code25InterleavedGlyphFactory))
		{
			return base.GetBarcodeLength(barcode, interGlyphSpace, barMinWidth, barMaxWidth);
		}
		return ((barcode.Length - 2) * 7 + 8) * barMinWidth;
	}

	protected override void RenderBars(Glyph[] barcode, Graphics dc, Rectangle bounds, int interGlyphSpace, int barMinHeight, int barMinWidth, int barMaxWidth)
	{
		if (!(base.Factory is Code25InterleavedGlyphFactory))
		{
			base.RenderBars(barcode, dc, bounds, interGlyphSpace, barMinHeight, barMinWidth, barMaxWidth);
			return;
		}
		int barOffset = 0;
		int num = 0;
		while (num < barcode.Length)
		{
			BarGlyph glyph = (BarGlyph)barcode[num];
			int glyphHeight = GetGlyphHeight(glyph, barMinHeight, bounds.Height);
			if (num == 0 || num == barcode.Length - 1)
			{
				RenderBar(num, glyph, dc, bounds, ref barOffset, barMinHeight, barMinWidth, barMaxWidth);
				num++;
			}
			else
			{
				int num2 = 5;
				BarGlyph barGlyph = (BarGlyph)barcode[num];
				BarGlyph barGlyph2 = (BarGlyph)barcode[num + 1];
				for (int num3 = num2 - 1; num3 >= 0; num3--)
				{
					int num4 = 1 << num3;
					if ((barGlyph.BitEncoding & num4) != 0)
					{
						dc.FillRectangle(Brushes.Black, barOffset, bounds.Top, barMinWidth * 2, glyphHeight);
						barOffset += barMinWidth * 2;
					}
					else
					{
						dc.FillRectangle(Brushes.Black, barOffset, bounds.Top, barMinWidth, glyphHeight);
						barOffset += barMinWidth;
					}
					barOffset = (((barGlyph2.BitEncoding & num4) == 0) ? (barOffset + barMinWidth) : (barOffset + barMinWidth * 2));
				}
				num += 2;
			}
			barOffset += interGlyphSpace;
		}
	}
}
