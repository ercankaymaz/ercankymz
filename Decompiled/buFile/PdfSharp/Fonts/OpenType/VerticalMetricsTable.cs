#define DEBUG
using System;
using System.Diagnostics;

namespace PdfSharp.Fonts.OpenType;

internal class VerticalMetricsTable : OpenTypeFontTable
{
	public const string Tag = "vmtx";

	public HorizontalMetrics[] metrics;

	public short[] leftSideBearing;

	public VerticalMetricsTable(OpenTypeFontface fontData)
		: base(fontData, "vmtx")
	{
		Read();
		throw new NotImplementedException("VerticalMetricsTable");
	}

	public void Read()
	{
		try
		{
			HorizontalHeaderTable hhea = _fontData.hhea;
			MaximumProfileTable maxp = _fontData.maxp;
			if (hhea == null || maxp == null)
			{
				return;
			}
			int numberOfHMetrics = hhea.numberOfHMetrics;
			int num = maxp.numGlyphs - numberOfHMetrics;
			Debug.Assert(numberOfHMetrics != 0);
			Debug.Assert(num >= 0);
			metrics = new HorizontalMetrics[numberOfHMetrics];
			for (int i = 0; i < numberOfHMetrics; i++)
			{
				metrics[i] = new HorizontalMetrics(_fontData);
			}
			if (num > 0)
			{
				leftSideBearing = new short[num];
				for (int j = 0; j < num; j++)
				{
					leftSideBearing[j] = _fontData.ReadFWord();
				}
			}
		}
		catch (Exception innerException)
		{
			throw new InvalidOperationException(PSSR.ErrorReadingFontData, innerException);
		}
	}
}
