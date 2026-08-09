using System.Collections.Generic;
using System.Drawing;

namespace Zen.Barcode;

public class Code128BarcodeDraw : BarcodeDrawBase<Code128GlyphFactory, Code128Checksum>
{
	public Code128BarcodeDraw(Code128Checksum checksum)
		: base(checksum.Factory, checksum, 11)
	{
	}

	public override BarcodeMetrics GetDefaultMetrics(int maxHeight)
	{
		return new BarcodeMetrics1d(1, maxHeight);
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
		list.AddRange(base.Factory.GetGlyphs(text));
		if (base.Checksum != null)
		{
			list.AddRange(base.Checksum.GetChecksum(text));
		}
		list.Add(base.Factory.GetRawGlyph(106));
		list.Add(base.Factory.GetRawGlyph(107));
		return list.ToArray();
	}

	protected override int GetBarcodeLength(Glyph[] barcode, int interGlyphSpace, int barMinWidth, int barMaxWidth)
	{
		return base.GetBarcodeLength(barcode, interGlyphSpace, barMinWidth, barMaxWidth) - 9 * barMinWidth;
	}
}
