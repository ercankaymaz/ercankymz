using System.Collections.Generic;
using System.Drawing;

namespace Zen.Barcode;

public class Code39BarcodeDraw : BinaryPitchBarcodeDraw<Code39GlyphFactory, Code39Checksum>
{
	public Code39BarcodeDraw(Code39GlyphFactory factory)
		: base(factory, 12, 9)
	{
	}

	public Code39BarcodeDraw(Code39Checksum checksum)
		: base(checksum.Factory, checksum, 12, 9)
	{
	}

	public override BarcodeMetrics GetDefaultMetrics(int maxHeight)
	{
		return new BarcodeMetrics1d(1, 2, maxHeight);
	}

	public override BarcodeMetrics GetPrintMetrics(Size desiredBarcodeDimensions, Size printResolution, int barcodeCharLength)
	{
		int height = desiredBarcodeDimensions.Height * printResolution.Height / 100;
		int num = printResolution.Width * desiredBarcodeDimensions.Width / (100 * (10 + barcodeCharLength * 9));
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
