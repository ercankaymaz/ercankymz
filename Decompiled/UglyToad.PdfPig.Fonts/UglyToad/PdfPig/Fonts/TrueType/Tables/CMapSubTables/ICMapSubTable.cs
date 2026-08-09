namespace UglyToad.PdfPig.Fonts.TrueType.Tables.CMapSubTables;

public interface ICMapSubTable
{
	TrueTypeCMapPlatform PlatformId { get; }

	ushort EncodingId { get; }

	int CharacterCodeToGlyphIndex(int characterCode);
}
