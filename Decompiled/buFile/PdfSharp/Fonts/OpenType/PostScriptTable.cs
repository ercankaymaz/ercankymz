using System;

namespace PdfSharp.Fonts.OpenType;

internal class PostScriptTable : OpenTypeFontTable
{
	public const string Tag = "post";

	public int formatType;

	public float italicAngle;

	public short underlinePosition;

	public short underlineThickness;

	public ulong isFixedPitch;

	public ulong minMemType42;

	public ulong maxMemType42;

	public ulong minMemType1;

	public ulong maxMemType1;

	public PostScriptTable(OpenTypeFontface fontData)
		: base(fontData, "post")
	{
		Read();
	}

	public void Read()
	{
		try
		{
			formatType = _fontData.ReadFixed();
			italicAngle = (float)_fontData.ReadFixed() / 65536f;
			underlinePosition = _fontData.ReadFWord();
			underlineThickness = _fontData.ReadFWord();
			isFixedPitch = _fontData.ReadULong();
			minMemType42 = _fontData.ReadULong();
			maxMemType42 = _fontData.ReadULong();
			minMemType1 = _fontData.ReadULong();
			maxMemType1 = _fontData.ReadULong();
		}
		catch (Exception innerException)
		{
			throw new InvalidOperationException(PSSR.ErrorReadingFontData, innerException);
		}
	}
}
