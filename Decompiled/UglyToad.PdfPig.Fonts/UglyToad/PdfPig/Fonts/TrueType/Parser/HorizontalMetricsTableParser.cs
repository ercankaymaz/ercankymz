using UglyToad.PdfPig.Fonts.TrueType.Glyphs;
using UglyToad.PdfPig.Fonts.TrueType.Tables;

namespace UglyToad.PdfPig.Fonts.TrueType.Parser;

internal class HorizontalMetricsTableParser : ITrueTypeTableParser<HorizontalMetricsTable>
{
	public HorizontalMetricsTable Parse(TrueTypeHeaderTable header, TrueTypeDataBytes data, TableRegister.Builder register)
	{
		int numberOfGlyphs = register.MaximumProfileTable.NumberOfGlyphs;
		ushort numberOfHeaderMetrics = register.HorizontalHeaderTable.NumberOfHeaderMetrics;
		data.Seek(header.Offset);
		int num = 0;
		HorizontalMetric[] array = new HorizontalMetric[numberOfHeaderMetrics];
		for (int i = 0; i < numberOfHeaderMetrics; i++)
		{
			ushort advanceWidth = data.ReadUnsignedShort();
			short leftSideBearing = data.ReadSignedShort();
			array[i] = new HorizontalMetric(advanceWidth, leftSideBearing);
			num += 4;
		}
		int num2 = numberOfGlyphs - numberOfHeaderMetrics;
		if (num2 < 0)
		{
			num2 = numberOfGlyphs;
		}
		short[] array2 = new short[num2];
		for (int j = 0; j < array2.Length; j++)
		{
			if (num >= header.Length)
			{
				break;
			}
			array2[j] = data.ReadSignedShort();
			num += 2;
		}
		return new HorizontalMetricsTable(header, array, array2);
	}
}
