using System;

namespace PdfSharp.Fonts.OpenType;

internal class GlyphSubstitutionTable : OpenTypeFontTable
{
	public const string Tag = "GSUB";

	public GlyphSubstitutionTable(OpenTypeFontface fontData)
		: base(fontData, "GSUB")
	{
		DirectoryEntry.Tag = "GSUB";
		DirectoryEntry = fontData.TableDictionary["GSUB"];
		Read();
	}

	public void Read()
	{
		try
		{
		}
		catch (Exception innerException)
		{
			throw new InvalidOperationException(PSSR.ErrorReadingFontData, innerException);
		}
	}
}
