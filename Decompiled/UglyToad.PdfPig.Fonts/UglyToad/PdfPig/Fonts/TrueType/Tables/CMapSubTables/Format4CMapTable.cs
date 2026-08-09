using System;
using System.Collections.Generic;

namespace UglyToad.PdfPig.Fonts.TrueType.Tables.CMapSubTables;

internal class Format4CMapTable : ICMapSubTable
{
	public readonly struct Segment
	{
		public int StartCode { get; }

		public int EndCode { get; }

		public int IdDelta { get; }

		public int IdRangeOffset { get; }

		public Segment(int startCode, int endCode, int idDelta, int idRangeOffset)
		{
			StartCode = startCode;
			EndCode = endCode;
			IdDelta = idDelta;
			IdRangeOffset = idRangeOffset;
		}

		public override string ToString()
		{
			return $"Start: {StartCode}, End: {EndCode}, Delta: {IdDelta}, Offset: {IdRangeOffset}";
		}
	}

	public TrueTypeCMapPlatform PlatformId { get; }

	public ushort EncodingId { get; }

	public ushort Language { get; }

	public IReadOnlyList<Segment> Segments { get; }

	public IReadOnlyList<ushort> GlyphIds { get; }

	public Format4CMapTable(TrueTypeCMapPlatform platformId, ushort encodingId, ushort language, IReadOnlyList<Segment> segments, IReadOnlyList<ushort> glyphIds)
	{
		PlatformId = platformId;
		EncodingId = encodingId;
		Language = language;
		Segments = segments ?? throw new ArgumentNullException("segments");
		GlyphIds = glyphIds ?? throw new ArgumentNullException("glyphIds");
	}

	public int CharacterCodeToGlyphIndex(int characterCode)
	{
		for (int i = 0; i < Segments.Count; i++)
		{
			Segment segment = Segments[i];
			if (segment.EndCode >= characterCode && segment.StartCode <= characterCode)
			{
				if (segment.IdRangeOffset == 0)
				{
					return (characterCode + segment.IdDelta) & 0xFFFF;
				}
				int num = segment.IdRangeOffset / 2 + (characterCode - segment.StartCode);
				return GlyphIds[num - Segments.Count + i];
			}
		}
		return 0;
	}

	public static Format4CMapTable Load(TrueTypeDataBytes data, TrueTypeCMapPlatform platformId, ushort encodingId)
	{
		ushort num = data.ReadUnsignedShort();
		ushort language = data.ReadUnsignedShort();
		int num2 = data.ReadUnsignedShort() / 2;
		data.ReadUnsignedShort();
		data.ReadUnsignedShort();
		data.ReadUnsignedShort();
		ushort[] array = data.ReadUnsignedShortArray(num2);
		data.ReadUnsignedShort();
		ushort[] array2 = data.ReadUnsignedShortArray(num2);
		short[] array3 = data.ReadShortArray(num2);
		ushort[] array4 = data.ReadUnsignedShortArray(num2);
		int length = (num - (16 + 8 * num2)) / 2;
		ushort[] glyphIds = data.ReadUnsignedShortArray(length);
		Segment[] array5 = new Segment[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			ushort startCode = array2[i];
			ushort endCode = array[i];
			short idDelta = array3[i];
			ushort idRangeOffset = array4[i];
			array5[i] = new Segment(startCode, endCode, idDelta, idRangeOffset);
		}
		return new Format4CMapTable(platformId, encodingId, language, array5, glyphIds);
	}
}
