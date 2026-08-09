using System;

namespace PdfSharp.Fonts.OpenType;

internal class HorizontalMetrics : OpenTypeFontTable
{
	public const string Tag = "----";

	public ushort advanceWidth;

	public short lsb;

	public HorizontalMetrics(OpenTypeFontface fontData)
		: base(fontData, "----")
	{
		Read();
	}

	public void Read()
	{
		try
		{
			advanceWidth = _fontData.ReadUFWord();
			lsb = _fontData.ReadFWord();
		}
		catch (Exception innerException)
		{
			throw new InvalidOperationException(PSSR.ErrorReadingFontData, innerException);
		}
	}
}
