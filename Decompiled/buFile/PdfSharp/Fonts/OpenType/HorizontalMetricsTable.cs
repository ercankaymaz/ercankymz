#define DEBUG
using System;
using System.Diagnostics;

namespace PdfSharp.Fonts.OpenType;

internal class HorizontalMetricsTable : OpenTypeFontTable
{
	public const string Tag = "hmtx";

	public HorizontalMetrics[] Metrics;

	public short[] LeftSideBearing;

	public HorizontalMetricsTable(OpenTypeFontface fontData)
		: base(fontData, "hmtx")
	{
		Read();
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
			Metrics = new HorizontalMetrics[numberOfHMetrics];
			for (int i = 0; i < numberOfHMetrics; i++)
			{
				Metrics[i] = new HorizontalMetrics(_fontData);
			}
			if (num > 0)
			{
				LeftSideBearing = new short[num];
				for (int j = 0; j < num; j++)
				{
					LeftSideBearing[j] = _fontData.ReadFWord();
				}
			}
		}
		catch (Exception innerException)
		{
			throw new InvalidOperationException(PSSR.ErrorReadingFontData, innerException);
		}
	}
}
