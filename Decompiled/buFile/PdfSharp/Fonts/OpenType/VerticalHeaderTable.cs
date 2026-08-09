using System;

namespace PdfSharp.Fonts.OpenType;

internal class VerticalHeaderTable : OpenTypeFontTable
{
	public const string Tag = "vhea";

	public int Version;

	public short Ascender;

	public short Descender;

	public short LineGap;

	public ushort AdvanceWidthMax;

	public short MinLeftSideBearing;

	public short MinRightSideBearing;

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

	public VerticalHeaderTable(OpenTypeFontface fontData)
		: base(fontData, "vhea")
	{
		Read();
	}

	public void Read()
	{
		try
		{
			Version = _fontData.ReadFixed();
			Ascender = _fontData.ReadFWord();
			Descender = _fontData.ReadFWord();
			LineGap = _fontData.ReadFWord();
			AdvanceWidthMax = _fontData.ReadUFWord();
			MinLeftSideBearing = _fontData.ReadFWord();
			MinRightSideBearing = _fontData.ReadFWord();
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
