using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;

namespace Zen.Barcode;

public class CodeEan8BarcodeDraw : BarcodeDrawBase<CodeEan8GlyphFactory, CodeEan8Checksum>
{
	public CodeEan8BarcodeDraw(CodeEan8Checksum checksum)
		: base(checksum.Factory, checksum, 7)
	{
	}

	public override BarcodeMetrics GetDefaultMetrics(int maxHeight)
	{
		return new BarcodeMetrics1d(1, 1, maxHeight - 5, maxHeight);
	}

	public override BarcodeMetrics GetPrintMetrics(Size desiredBarcodeDimensions, Size printResolution, int barcodeCharLength)
	{
		int num = desiredBarcodeDimensions.Height * printResolution.Height / 100;
		int minHeight = num * 85 / 100;
		int num2 = printResolution.Width * desiredBarcodeDimensions.Width / (100 * (24 + barcodeCharLength * 11));
		return new BarcodeMetrics1d(num2, num2, minHeight, num);
	}

	protected override Glyph[] GetFullBarcode(string text)
	{
		Match match = Regex.Match(text, "^\\s*(?<barcode>[0-9]{7})\\s*$");
		if (!match.Success)
		{
			throw new ArgumentException("Invalid barcode.");
		}
		string text2 = match.Groups["barcode"].Value;
		if (base.Checksum != null)
		{
			text2 += base.Checksum.GetChecksumChar(text2);
		}
		List<Glyph> list = new List<Glyph>();
		list.AddRange(base.Factory.GetGlyphs(text2, allowComposite: true));
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i] is CompositeGlyph)
			{
				CompositeGlyph compositeGlyph = (CompositeGlyph)list[i];
				if (i < 4)
				{
					list[i] = compositeGlyph.First;
				}
				else
				{
					list[i] = compositeGlyph.Second;
				}
			}
		}
		list.Insert(4, base.Factory.GetRawGlyph('|'));
		list.Insert(0, base.Factory.GetRawGlyph('*'));
		list.Add(base.Factory.GetRawGlyph('*'));
		return list.ToArray();
	}

	protected override int GetGlyphHeight(Glyph glyph, int barMinHeight, int barMaxHeight)
	{
		if (glyph.Character == '*' || glyph.Character == '|')
		{
			return barMaxHeight;
		}
		return barMinHeight;
	}

	protected override int GetDefaultInterGlyphSpace(int barMinWidth, int barMaxWidth)
	{
		return 0;
	}
}
