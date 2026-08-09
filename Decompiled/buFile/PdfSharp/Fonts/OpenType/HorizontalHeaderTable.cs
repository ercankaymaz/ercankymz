using System;

namespace PdfSharp.Fonts.OpenType;

internal class HorizontalHeaderTable : OpenTypeFontTable
{
	public const string Tag = "hhea";

	public int version;

	public short ascender;

	public short descender;

	public short lineGap;

	public ushort advanceWidthMax;

	public short minLeftSideBearing;

	public short minRightSideBearing;

	public short xMaxExtent;

	public short caretSlopeRise;

	public short caretSlopeRun;

	public short reserved1;

	public short reserved2;

	public short reserved3;

	public short reserved4;

	public short reserved5;

	public short metricDataFormat;

	public ushort numberOfHMetrics;

	public HorizontalHeaderTable(OpenTypeFontface fontData)
		: base(fontData, "hhea")
	{
		Read();
	}

	public void Read()
	{
		try
		{
			version = _fontData.ReadFixed();
			ascender = _fontData.ReadFWord();
			descender = _fontData.ReadFWord();
			lineGap = _fontData.ReadFWord();
			advanceWidthMax = _fontData.ReadUFWord();
			minLeftSideBearing = _fontData.ReadFWord();
			minRightSideBearing = _fontData.ReadFWord();
			xMaxExtent = _fontData.ReadFWord();
			caretSlopeRise = _fontData.ReadShort();
			caretSlopeRun = _fontData.ReadShort();
			reserved1 = _fontData.ReadShort();
			reserved2 = _fontData.ReadShort();
			reserved3 = _fontData.ReadShort();
			reserved4 = _fontData.ReadShort();
			reserved5 = _fontData.ReadShort();
			metricDataFormat = _fontData.ReadShort();
			numberOfHMetrics = _fontData.ReadUShort();
		}
		catch (Exception innerException)
		{
			throw new InvalidOperationException(PSSR.ErrorReadingFontData, innerException);
		}
	}
}
