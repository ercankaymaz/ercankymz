using System.Text;
using UglyToad.PdfPig.Fonts.TrueType.Tables;

namespace UglyToad.PdfPig.Fonts.TrueType.Parser;

internal class Os2TableParser : ITrueTypeTableParser<Os2Table>
{
	public Os2Table Parse(TrueTypeHeaderTable header, TrueTypeDataBytes data, TableRegister.Builder register)
	{
		data.Seek(header.Offset);
		ushort num = data.ReadUnsignedShort();
		short xAverageCharacterWidth = data.ReadSignedShort();
		ushort weightClass = data.ReadUnsignedShort();
		ushort widthClass = data.ReadUnsignedShort();
		ushort typeFlags = data.ReadUnsignedShort();
		short ySubscriptXSize = data.ReadSignedShort();
		short ySubscriptYSize = data.ReadSignedShort();
		short ySubscriptXOffset = data.ReadSignedShort();
		short ySubscriptYOffset = data.ReadSignedShort();
		short ySuperscriptXSize = data.ReadSignedShort();
		short ySuperscriptYSize = data.ReadSignedShort();
		short ySuperscriptXOffset = data.ReadSignedShort();
		short ySuperscriptYOffset = data.ReadSignedShort();
		short yStrikeoutSize = data.ReadSignedShort();
		short yStrikeoutPosition = data.ReadSignedShort();
		short familyClass = data.ReadSignedShort();
		byte[] panose = data.ReadByteArray(10);
		uint num2 = data.ReadUnsignedInt();
		uint num3 = data.ReadUnsignedInt();
		uint num4 = data.ReadUnsignedInt();
		uint num5 = data.ReadUnsignedInt();
		byte[] bytes = data.ReadByteArray(4);
		ushort fontSelectionFlags = data.ReadUnsignedShort();
		ushort firstCharacterIndex = data.ReadUnsignedShort();
		ushort lastCharacterIndex = data.ReadUnsignedShort();
		uint[] unicodeRanges = new uint[4] { num2, num3, num4, num5 };
		string vendorId = Encoding.ASCII.GetString(bytes);
		if (num == 0 && header.Length == 68)
		{
			return new Os2Table(header, num, xAverageCharacterWidth, weightClass, widthClass, typeFlags, ySubscriptXSize, ySubscriptYSize, ySubscriptXOffset, ySubscriptYOffset, ySuperscriptXSize, ySuperscriptYSize, ySuperscriptXOffset, ySuperscriptYOffset, yStrikeoutSize, yStrikeoutPosition, familyClass, panose, unicodeRanges, vendorId, fontSelectionFlags, firstCharacterIndex, lastCharacterIndex);
		}
		short typographicAscender;
		short typographicDescender;
		short typographicLineGap;
		ushort windowsAscent;
		ushort windowsDescent;
		try
		{
			typographicAscender = data.ReadSignedShort();
			typographicDescender = data.ReadSignedShort();
			typographicLineGap = data.ReadSignedShort();
			windowsAscent = data.ReadUnsignedShort();
			windowsDescent = data.ReadUnsignedShort();
		}
		catch
		{
			return new Os2Table(header, num, xAverageCharacterWidth, weightClass, widthClass, typeFlags, ySubscriptXSize, ySubscriptYSize, ySubscriptXOffset, ySubscriptYOffset, ySuperscriptXSize, ySuperscriptYSize, ySuperscriptXOffset, ySuperscriptYOffset, yStrikeoutSize, yStrikeoutPosition, familyClass, panose, unicodeRanges, vendorId, fontSelectionFlags, firstCharacterIndex, lastCharacterIndex);
		}
		if (num == 0)
		{
			return new Os2RevisedVersion0Table(header, num, xAverageCharacterWidth, weightClass, widthClass, typeFlags, ySubscriptXSize, ySubscriptYSize, ySubscriptXOffset, ySubscriptYOffset, ySuperscriptXSize, ySuperscriptYSize, ySuperscriptXOffset, ySuperscriptYOffset, yStrikeoutSize, yStrikeoutPosition, familyClass, panose, unicodeRanges, vendorId, fontSelectionFlags, firstCharacterIndex, lastCharacterIndex, typographicAscender, typographicDescender, typographicLineGap, windowsAscent, windowsDescent);
		}
		uint codePage = data.ReadUnsignedInt();
		uint codePage2 = data.ReadUnsignedInt();
		if (num == 1)
		{
			return new Os2Version1Table(header, num, xAverageCharacterWidth, weightClass, widthClass, typeFlags, ySubscriptXSize, ySubscriptYSize, ySubscriptXOffset, ySubscriptYOffset, ySuperscriptXSize, ySuperscriptYSize, ySuperscriptXOffset, ySuperscriptYOffset, yStrikeoutSize, yStrikeoutPosition, familyClass, panose, unicodeRanges, vendorId, fontSelectionFlags, firstCharacterIndex, lastCharacterIndex, typographicAscender, typographicDescender, typographicLineGap, windowsAscent, windowsDescent, codePage, codePage2);
		}
		short xHeight = data.ReadSignedShort();
		short capHeight = data.ReadSignedShort();
		ushort defaultCharacter = data.ReadUnsignedShort();
		ushort breakCharacter = data.ReadUnsignedShort();
		ushort maximumContext = data.ReadUnsignedShort();
		if (num < 5)
		{
			return new Os2Version2To4OpenTypeTable(header, num, xAverageCharacterWidth, weightClass, widthClass, typeFlags, ySubscriptXSize, ySubscriptYSize, ySubscriptXOffset, ySubscriptYOffset, ySuperscriptXSize, ySuperscriptYSize, ySuperscriptXOffset, ySuperscriptYOffset, yStrikeoutSize, yStrikeoutPosition, familyClass, panose, unicodeRanges, vendorId, fontSelectionFlags, firstCharacterIndex, lastCharacterIndex, typographicAscender, typographicDescender, typographicLineGap, windowsAscent, windowsDescent, codePage, codePage2, xHeight, capHeight, defaultCharacter, breakCharacter, maximumContext);
		}
		ushort lowerOpticalPointSize = data.ReadUnsignedShort();
		ushort upperOpticalPointSize = data.ReadUnsignedShort();
		return new Os2Version5OpenTypeTable(header, num, xAverageCharacterWidth, weightClass, widthClass, typeFlags, ySubscriptXSize, ySubscriptYSize, ySubscriptXOffset, ySubscriptYOffset, ySuperscriptXSize, ySuperscriptYSize, ySuperscriptXOffset, ySuperscriptYOffset, yStrikeoutSize, yStrikeoutPosition, familyClass, panose, unicodeRanges, vendorId, fontSelectionFlags, firstCharacterIndex, lastCharacterIndex, typographicAscender, typographicDescender, typographicLineGap, windowsAscent, windowsDescent, codePage, codePage2, xHeight, capHeight, defaultCharacter, breakCharacter, maximumContext, lowerOpticalPointSize, upperOpticalPointSize);
	}
}
