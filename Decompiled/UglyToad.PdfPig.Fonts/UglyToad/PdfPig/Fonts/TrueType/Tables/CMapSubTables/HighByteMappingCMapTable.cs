using System;
using System.Collections.Generic;

namespace UglyToad.PdfPig.Fonts.TrueType.Tables.CMapSubTables;

internal class HighByteMappingCMapTable : ICMapSubTable
{
	public readonly struct SubHeader
	{
		public int FirstCode { get; }

		public int EntryCount { get; }

		public short IdDelta { get; }

		public int IdRangeOffset { get; }

		public SubHeader(int firstCode, int entryCount, short idDelta, int idRangeOffset)
		{
			FirstCode = firstCode;
			EntryCount = entryCount;
			IdDelta = idDelta;
			IdRangeOffset = idRangeOffset;
		}
	}

	private readonly IReadOnlyDictionary<int, int> characterCodesToGlyphIndices;

	public TrueTypeCMapPlatform PlatformId { get; }

	public ushort EncodingId { get; }

	private HighByteMappingCMapTable(TrueTypeCMapPlatform platformId, ushort encodingId, IReadOnlyDictionary<int, int> characterCodesToGlyphIndices)
	{
		this.characterCodesToGlyphIndices = characterCodesToGlyphIndices ?? throw new ArgumentNullException("characterCodesToGlyphIndices");
		PlatformId = platformId;
		EncodingId = encodingId;
	}

	public int CharacterCodeToGlyphIndex(int characterCode)
	{
		if (!characterCodesToGlyphIndices.TryGetValue(characterCode, out var value))
		{
			return 0;
		}
		return value;
	}

	public static HighByteMappingCMapTable Load(TrueTypeDataBytes data, int numberOfGlyphs, TrueTypeCMapPlatform platformId, ushort encodingId)
	{
		data.ReadUnsignedShort();
		data.ReadUnsignedShort();
		int[] array = new int[256];
		int num = 0;
		for (int i = 0; i < 256; i++)
		{
			ushort num2 = data.ReadUnsignedShort();
			num = Math.Max(num, num2 / 8);
			array[i] = num2;
		}
		int num3 = num + 1;
		SubHeader[] array2 = new SubHeader[num3];
		for (int j = 0; j < num3; j++)
		{
			ushort firstCode = data.ReadUnsignedShort();
			ushort entryCount = data.ReadUnsignedShort();
			short idDelta = data.ReadSignedShort();
			int idRangeOffset = data.ReadUnsignedShort() - (num3 - j - 1) * 8 - 2;
			array2[j] = new SubHeader(firstCode, entryCount, idDelta, idRangeOffset);
		}
		long position = data.Position;
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		for (int k = 0; k < num3; k++)
		{
			SubHeader subHeader = array2[k];
			data.Seek(position + subHeader.IdRangeOffset);
			for (int l = 0; l < subHeader.EntryCount; l++)
			{
				int key = (k << 8) + (subHeader.FirstCode + l);
				int num4 = data.ReadUnsignedShort();
				if (num4 > 0)
				{
					num4 = (num4 + subHeader.IdDelta) % 65536;
				}
				if (num4 < numberOfGlyphs)
				{
					dictionary[key] = num4;
				}
			}
		}
		return new HighByteMappingCMapTable(platformId, encodingId, dictionary);
	}
}
