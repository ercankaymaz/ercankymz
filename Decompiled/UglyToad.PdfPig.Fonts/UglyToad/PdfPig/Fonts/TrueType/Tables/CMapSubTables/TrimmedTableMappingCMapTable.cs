using System;
using System.IO;
using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Fonts.TrueType.Tables.CMapSubTables;

internal class TrimmedTableMappingCMapTable : ICMapSubTable, IWriteable
{
	private const ushort Format = 6;

	private const ushort DefaultLanguageId = 0;

	private readonly int entryCount;

	private readonly ushort[] glyphIndices;

	public TrueTypeCMapPlatform PlatformId { get; }

	public ushort EncodingId { get; }

	public int FirstCharacterCode { get; }

	public int LastCharacterCode { get; }

	public TrimmedTableMappingCMapTable(TrueTypeCMapPlatform platformId, ushort encodingId, int firstCharacterCode, int entryCount, ushort[] glyphIndices)
	{
		FirstCharacterCode = firstCharacterCode;
		this.entryCount = entryCount;
		this.glyphIndices = glyphIndices ?? throw new ArgumentNullException("glyphIndices");
		LastCharacterCode = firstCharacterCode + entryCount - 1;
		PlatformId = platformId;
		EncodingId = encodingId;
	}

	public int CharacterCodeToGlyphIndex(int characterCode)
	{
		if (characterCode < FirstCharacterCode || characterCode > FirstCharacterCode + entryCount)
		{
			return 0;
		}
		int num = characterCode - FirstCharacterCode;
		if (num < 0 || num >= glyphIndices.Length)
		{
			return 0;
		}
		return glyphIndices[num];
	}

	public static TrimmedTableMappingCMapTable Load(TrueTypeDataBytes data, TrueTypeCMapPlatform platformId, ushort encodingId)
	{
		data.ReadUnsignedShort();
		data.ReadUnsignedShort();
		ushort firstCharacterCode = data.ReadUnsignedShort();
		ushort length = data.ReadUnsignedShort();
		ushort[] array = data.ReadUnsignedShortArray(length);
		return new TrimmedTableMappingCMapTable(platformId, encodingId, firstCharacterCode, length, array);
	}

	public void Write(Stream stream)
	{
		stream.WriteUShort((ushort)6);
		ushort value = (ushort)(10 + 2 * glyphIndices.Length);
		stream.WriteUShort(value);
		stream.WriteUShort((ushort)0);
		stream.WriteUShort(FirstCharacterCode);
		stream.WriteUShort(glyphIndices.Length);
		for (int i = 0; i < glyphIndices.Length; i++)
		{
			stream.WriteUShort(glyphIndices[i]);
		}
	}
}
