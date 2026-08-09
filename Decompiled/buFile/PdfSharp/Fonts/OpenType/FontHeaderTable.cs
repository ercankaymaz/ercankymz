using System;

namespace PdfSharp.Fonts.OpenType;

internal class FontHeaderTable : OpenTypeFontTable
{
	public const string Tag = "head";

	public int version;

	public int fontRevision;

	public uint checkSumAdjustment;

	public uint magicNumber;

	public ushort flags;

	public ushort unitsPerEm;

	public long created;

	public long modified;

	public short xMin;

	public short yMin;

	public short xMax;

	public short yMax;

	public ushort macStyle;

	public ushort lowestRecPPEM;

	public short fontDirectionHint;

	public short indexToLocFormat;

	public short glyphDataFormat;

	public FontHeaderTable(OpenTypeFontface fontData)
		: base(fontData, "head")
	{
		Read();
	}

	public void Read()
	{
		try
		{
			version = _fontData.ReadFixed();
			fontRevision = _fontData.ReadFixed();
			checkSumAdjustment = _fontData.ReadULong();
			magicNumber = _fontData.ReadULong();
			flags = _fontData.ReadUShort();
			unitsPerEm = _fontData.ReadUShort();
			created = _fontData.ReadLongDate();
			modified = _fontData.ReadLongDate();
			xMin = _fontData.ReadShort();
			yMin = _fontData.ReadShort();
			xMax = _fontData.ReadShort();
			yMax = _fontData.ReadShort();
			macStyle = _fontData.ReadUShort();
			lowestRecPPEM = _fontData.ReadUShort();
			fontDirectionHint = _fontData.ReadShort();
			indexToLocFormat = _fontData.ReadShort();
			glyphDataFormat = _fontData.ReadShort();
		}
		catch (Exception innerException)
		{
			throw new InvalidOperationException(PSSR.ErrorReadingFontData, innerException);
		}
	}
}
