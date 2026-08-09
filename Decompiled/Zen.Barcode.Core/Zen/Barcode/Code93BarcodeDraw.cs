using System.Collections.Generic;
using System.Drawing;

namespace Zen.Barcode;

public class Code93BarcodeDraw : BarcodeDrawBase<Code93GlyphFactory, Code93Checksum>
{
	public Code93BarcodeDraw(Code93Checksum checksum)
		: base(checksum.Factory, checksum, 9)
	{
	}

	public override BarcodeMetrics GetDefaultMetrics(int maxHeight)
	{
		return new BarcodeMetrics1d(1, 2, maxHeight);
	}

	public override BarcodeMetrics GetPrintMetrics(Size desiredBarcodeDimensions, Size printResolution, int barcodeCharLength)
	{
		int height = desiredBarcodeDimensions.Height * printResolution.Height / 100;
		int num = printResolution.Width * desiredBarcodeDimensions.Width / (100 * (24 + barcodeCharLength * 12));
		return new BarcodeMetrics1d(num, num * 2, height);
	}

	protected override Glyph[] GetFullBarcode(string text)
	{
		List<Glyph> list = new List<Glyph>();
		list.AddRange(base.Factory.GetGlyphs(text));
		if (base.Checksum != null)
		{
			list.AddRange(base.Checksum.GetChecksum(text));
		}
		list.Insert(0, base.Factory.GetRawGlyph('*'));
		list.Add(base.Factory.GetRawGlyph('*'));
		list.Add(base.Factory.GetRawGlyph('|'));
		return list.ToArray();
	}

	protected override int GetBarcodeLength(Glyph[] barcode, int interGlyphSpace, int barMinWidth, int barMaxWidth)
	{
		return base.GetBarcodeLength(barcode, interGlyphSpace, barMinWidth, barMaxWidth) - 8 * barMinWidth;
	}
}
