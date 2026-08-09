using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;

namespace Zen.Barcode;

public class CodeEan13BarcodeDraw : BarcodeDrawBase<CodeEan13GlyphFactory, CodeEan13Checksum>
{
	public CodeEan13BarcodeDraw(CodeEan13Checksum checksum)
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
		Match match = Regex.Match(text, "^\\s*(?<barcode>[0-9]{12})\\s*$");
		if (!match.Success)
		{
			throw new ArgumentException("Invalid barcode.");
		}
		string text2 = match.Groups["barcode"].Value;
		byte[] array = new byte[10] { 0, 11, 13, 14, 19, 25, 29, 21, 22, 26 };
		char c = text2[0];
		byte b = array[c - 48];
		if (base.Checksum != null)
		{
			text2 += base.Checksum.GetChecksumChar(text2);
		}
		text2 = text2.Substring(1);
		List<Glyph> list = new List<Glyph>();
		list.AddRange(base.Factory.GetGlyphs(text2, allowComposite: true));
		int num = 32;
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i] is CompositeGlyph)
			{
				byte b2 = (byte)((i < 6) ? b : 0);
				CompositeGlyph compositeGlyph = (CompositeGlyph)list[i];
				if ((num & b2) == 0)
				{
					list[i] = compositeGlyph.First;
				}
				else
				{
					list[i] = compositeGlyph.Second;
				}
				if (num > 1)
				{
					num /= 2;
				}
			}
		}
		list.Insert(6, base.Factory.GetRawGlyph('|'));
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
