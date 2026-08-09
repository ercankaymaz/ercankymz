using System;
using System.IO;
using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Fonts.TrueType.Tables.CMapSubTables;

internal class ByteEncodingCMapTable : ICMapSubTable, IWriteable
{
	private const ushort Format = 0;

	private const ushort DefaultLanguageId = 0;

	private const int SizeOfShort = 2;

	private const int GlyphMappingLength = 256;

	private readonly byte[] glyphMapping;

	public TrueTypeCMapPlatform PlatformId { get; }

	public ushort EncodingId { get; }

	public ushort LanguageId { get; }

	public ByteEncodingCMapTable(TrueTypeCMapPlatform platformId, ushort encodingId, ushort languageId, byte[] glyphMapping)
	{
		this.glyphMapping = glyphMapping;
		PlatformId = platformId;
		EncodingId = encodingId;
		LanguageId = languageId;
	}

	public static ByteEncodingCMapTable Load(TrueTypeDataBytes data, TrueTypeCMapPlatform platformId, ushort encodingId)
	{
		ushort num = data.ReadUnsignedShort();
		ushort languageId = data.ReadUnsignedShort();
		if (num == 0)
		{
			return new ByteEncodingCMapTable(platformId, encodingId, languageId, Array.Empty<byte>());
		}
		byte[] array = data.ReadByteArray(num - 6);
		return new ByteEncodingCMapTable(platformId, encodingId, languageId, array);
	}

	public int CharacterCodeToGlyphIndex(int characterCode)
	{
		if (characterCode < 0 || characterCode >= glyphMapping.Length)
		{
			return 0;
		}
		return glyphMapping[characterCode];
	}

	public void Write(Stream stream)
	{
		stream.WriteUShort((ushort)0);
		stream.WriteUShort(262);
		stream.WriteUShort((ushort)0);
		for (int i = 0; i < glyphMapping.Length; i++)
		{
			stream.WriteByte(glyphMapping[i]);
		}
	}
}
