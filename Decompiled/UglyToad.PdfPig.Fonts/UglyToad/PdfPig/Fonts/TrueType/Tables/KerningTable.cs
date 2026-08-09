using System.Collections.Generic;
using UglyToad.PdfPig.Fonts.TrueType.Tables.Kerning;

namespace UglyToad.PdfPig.Fonts.TrueType.Tables;

internal class KerningTable
{
	public IReadOnlyList<KerningSubTable> KerningTables { get; }

	public KerningTable(IReadOnlyList<KerningSubTable> kerningTables)
	{
		List<KerningSubTable> list = new List<KerningSubTable>();
		foreach (KerningSubTable kerningTable in kerningTables)
		{
			if (kerningTable != null)
			{
				list.Add(kerningTable);
			}
		}
		KerningTables = list;
	}

	public static KerningTable Load(TrueTypeDataBytes data, TrueTypeHeaderTable headerTable)
	{
		data.Seek(headerTable.Offset);
		data.ReadUnsignedShort();
		ushort num = data.ReadUnsignedShort();
		KerningSubTable[] array = new KerningSubTable[num];
		for (int i = 0; i < num; i++)
		{
			long position = data.Position;
			ushort version = data.ReadUnsignedShort();
			data.ReadUnsignedShort();
			KernCoverage coverage;
			switch ((int)((coverage = (KernCoverage)data.ReadUnsignedShort()) & (KernCoverage)255) >> 8)
			{
			case 0:
				array[i] = ReadFormat0Table(version, data, coverage);
				break;
			case 2:
				array[i] = ReadFormat2Table(version, data, coverage, position);
				break;
			}
		}
		return new KerningTable(array);
	}

	private static KerningSubTable ReadFormat0Table(int version, TrueTypeDataBytes data, KernCoverage coverage)
	{
		ushort num = data.ReadUnsignedShort();
		data.ReadUnsignedShort();
		data.ReadUnsignedShort();
		data.ReadUnsignedShort();
		KernPair[] array = new KernPair[num];
		for (int i = 0; i < num; i++)
		{
			ushort leftGlyphIndex = data.ReadUnsignedShort();
			ushort rightGlyphIndex = data.ReadUnsignedShort();
			short value = data.ReadSignedShort();
			array[i] = new KernPair(leftGlyphIndex, rightGlyphIndex, value);
		}
		return new KerningSubTable(version, coverage, array);
	}

	private static KerningSubTable ReadFormat2Table(int version, TrueTypeDataBytes data, KernCoverage coverage, long tableStartOffset)
	{
		return null;
	}
}
