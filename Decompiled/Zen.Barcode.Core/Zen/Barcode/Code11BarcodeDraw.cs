using System.Collections.Generic;
using System.Drawing;

namespace Zen.Barcode;

public class Code11BarcodeDraw : BinaryPitchVaryLengthBarcodeDraw<Code11GlyphFactory, Code11Checksum>
{
	public Code11BarcodeDraw(Code11GlyphFactory factory)
		: base(factory, 0, 5)
	{
	}

	public Code11BarcodeDraw(Code11Checksum checksum)
		: base(checksum.Factory, checksum, 0, 5)
	{
	}

	public override BarcodeMetrics GetDefaultMetrics(int maxHeight)
	{
		return new BarcodeMetrics1d(1, 3, maxHeight);
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
		return list.ToArray();
	}

	protected override int GetDefaultInterGlyphSpace(int barMinWidth, int barMaxWidth)
	{
		return barMinWidth;
	}
}
