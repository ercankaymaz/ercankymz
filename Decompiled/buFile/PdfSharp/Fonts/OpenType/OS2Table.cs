using System;

namespace PdfSharp.Fonts.OpenType;

internal class OS2Table : OpenTypeFontTable
{
	[Flags]
	public enum FontSelectionFlags : ushort
	{
		Italic = 1,
		Bold = 0x20,
		Regular = 0x40
	}

	public const string Tag = "OS/2";

	public ushort version;

	public short xAvgCharWidth;

	public ushort usWeightClass;

	public ushort usWidthClass;

	public ushort fsType;

	public short ySubscriptXSize;

	public short ySubscriptYSize;

	public short ySubscriptXOffset;

	public short ySubscriptYOffset;

	public short ySuperscriptXSize;

	public short ySuperscriptYSize;

	public short ySuperscriptXOffset;

	public short ySuperscriptYOffset;

	public short yStrikeoutSize;

	public short yStrikeoutPosition;

	public short sFamilyClass;

	public byte[] panose;

	public uint ulUnicodeRange1;

	public uint ulUnicodeRange2;

	public uint ulUnicodeRange3;

	public uint ulUnicodeRange4;

	public string achVendID;

	public ushort fsSelection;

	public ushort usFirstCharIndex;

	public ushort usLastCharIndex;

	public short sTypoAscender;

	public short sTypoDescender;

	public short sTypoLineGap;

	public ushort usWinAscent;

	public ushort usWinDescent;

	public uint ulCodePageRange1;

	public uint ulCodePageRange2;

	public short sxHeight;

	public short sCapHeight;

	public ushort usDefaultChar;

	public ushort usBreakChar;

	public ushort usMaxContext;

	public bool IsBold => (fsSelection & 0x20) != 0;

	public bool IsItalic => (fsSelection & 1) != 0;

	public OS2Table(OpenTypeFontface fontData)
		: base(fontData, "OS/2")
	{
		Read();
	}

	public void Read()
	{
		try
		{
			version = _fontData.ReadUShort();
			xAvgCharWidth = _fontData.ReadShort();
			usWeightClass = _fontData.ReadUShort();
			usWidthClass = _fontData.ReadUShort();
			fsType = _fontData.ReadUShort();
			ySubscriptXSize = _fontData.ReadShort();
			ySubscriptYSize = _fontData.ReadShort();
			ySubscriptXOffset = _fontData.ReadShort();
			ySubscriptYOffset = _fontData.ReadShort();
			ySuperscriptXSize = _fontData.ReadShort();
			ySuperscriptYSize = _fontData.ReadShort();
			ySuperscriptXOffset = _fontData.ReadShort();
			ySuperscriptYOffset = _fontData.ReadShort();
			yStrikeoutSize = _fontData.ReadShort();
			yStrikeoutPosition = _fontData.ReadShort();
			sFamilyClass = _fontData.ReadShort();
			panose = _fontData.ReadBytes(10);
			ulUnicodeRange1 = _fontData.ReadULong();
			ulUnicodeRange2 = _fontData.ReadULong();
			ulUnicodeRange3 = _fontData.ReadULong();
			ulUnicodeRange4 = _fontData.ReadULong();
			achVendID = _fontData.ReadString(4);
			fsSelection = _fontData.ReadUShort();
			usFirstCharIndex = _fontData.ReadUShort();
			usLastCharIndex = _fontData.ReadUShort();
			sTypoAscender = _fontData.ReadShort();
			sTypoDescender = _fontData.ReadShort();
			sTypoLineGap = _fontData.ReadShort();
			usWinAscent = _fontData.ReadUShort();
			usWinDescent = _fontData.ReadUShort();
			if (version >= 1)
			{
				ulCodePageRange1 = _fontData.ReadULong();
				ulCodePageRange2 = _fontData.ReadULong();
				if (version >= 2)
				{
					sxHeight = _fontData.ReadShort();
					sCapHeight = _fontData.ReadShort();
					usDefaultChar = _fontData.ReadUShort();
					usBreakChar = _fontData.ReadUShort();
					usMaxContext = _fontData.ReadUShort();
				}
			}
		}
		catch (Exception innerException)
		{
			throw new InvalidOperationException(PSSR.ErrorReadingFontData, innerException);
		}
	}
}
