using System.Collections.Generic;
using UglyToad.PdfPig.Fonts.TrueType.Tables;
using UglyToad.PdfPig.Fonts.TrueType.Tables.CMapSubTables;

namespace UglyToad.PdfPig.Fonts.TrueType.Parser;

internal class CMapTableParser : ITrueTypeTableParser<CMapTable>
{
	private readonly struct SubTableHeaderEntry
	{
		public TrueTypeCMapPlatform PlatformId { get; }

		public ushort EncodingId { get; }

		public long Offset { get; }

		public SubTableHeaderEntry(TrueTypeCMapPlatform platformId, ushort encodingId, long offset)
		{
			PlatformId = platformId;
			EncodingId = encodingId;
			Offset = offset;
		}
	}

	public CMapTable Parse(TrueTypeHeaderTable header, TrueTypeDataBytes data, TableRegister.Builder register)
	{
		data.Seek(header.Offset);
		ushort version = data.ReadUnsignedShort();
		ushort num = data.ReadUnsignedShort();
		SubTableHeaderEntry[] array = new SubTableHeaderEntry[num];
		for (int i = 0; i < num; i++)
		{
			TrueTypeCMapPlatform platformId = (TrueTypeCMapPlatform)data.ReadUnsignedShort();
			ushort encodingId = data.ReadUnsignedShort();
			uint num2 = data.ReadUnsignedInt();
			array[i] = new SubTableHeaderEntry(platformId, encodingId, num2);
		}
		List<ICMapSubTable> list = new List<ICMapSubTable>(num);
		int numberOfGlyphs = register.MaximumProfileTable.NumberOfGlyphs;
		for (int j = 0; j < array.Length; j++)
		{
			SubTableHeaderEntry subTableHeaderEntry = array[j];
			data.Seek(header.Offset + subTableHeaderEntry.Offset);
			switch (data.ReadUnsignedShort())
			{
			case 0:
			{
				ByteEncodingCMapTable item4 = ByteEncodingCMapTable.Load(data, subTableHeaderEntry.PlatformId, subTableHeaderEntry.EncodingId);
				list.Add(item4);
				break;
			}
			case 2:
			{
				HighByteMappingCMapTable item3 = HighByteMappingCMapTable.Load(data, numberOfGlyphs, subTableHeaderEntry.PlatformId, subTableHeaderEntry.EncodingId);
				list.Add(item3);
				break;
			}
			case 4:
			{
				Format4CMapTable item2 = Format4CMapTable.Load(data, subTableHeaderEntry.PlatformId, subTableHeaderEntry.EncodingId);
				list.Add(item2);
				break;
			}
			case 6:
			{
				TrimmedTableMappingCMapTable item = TrimmedTableMappingCMapTable.Load(data, subTableHeaderEntry.PlatformId, subTableHeaderEntry.EncodingId);
				list.Add(item);
				break;
			}
			}
		}
		return new CMapTable(version, header, list);
	}
}
