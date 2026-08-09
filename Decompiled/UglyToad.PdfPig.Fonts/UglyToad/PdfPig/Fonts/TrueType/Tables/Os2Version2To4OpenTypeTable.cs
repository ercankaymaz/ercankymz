using System.Collections.Generic;
using System.IO;
using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Fonts.TrueType.Tables;

public class Os2Version2To4OpenTypeTable : Os2Version1Table
{
	public short XHeight { get; }

	public short CapHeight { get; }

	public ushort DefaultCharacter { get; }

	public ushort BreakCharacter { get; }

	public ushort MaximumContext { get; }

	public Os2Version2To4OpenTypeTable(TrueTypeHeaderTable directoryTable, ushort version, short xAverageCharacterWidth, ushort weightClass, ushort widthClass, ushort typeFlags, short ySubscriptXSize, short ySubscriptYSize, short ySubscriptXOffset, short ySubscriptYOffset, short ySuperscriptXSize, short ySuperscriptYSize, short ySuperscriptXOffset, short ySuperscriptYOffset, short yStrikeoutSize, short yStrikeoutPosition, short familyClass, IReadOnlyList<byte> panose, IReadOnlyList<uint> unicodeRanges, string vendorId, ushort fontSelectionFlags, ushort firstCharacterIndex, ushort lastCharacterIndex, short typographicAscender, short typographicDescender, short typographicLineGap, ushort windowsAscent, ushort windowsDescent, uint codePage1, uint codePage2, short xHeight, short capHeight, ushort defaultCharacter, ushort breakCharacter, ushort maximumContext)
		: base(directoryTable, version, xAverageCharacterWidth, weightClass, widthClass, typeFlags, ySubscriptXSize, ySubscriptYSize, ySubscriptXOffset, ySubscriptYOffset, ySuperscriptXSize, ySuperscriptYSize, ySuperscriptXOffset, ySuperscriptYOffset, yStrikeoutSize, yStrikeoutPosition, familyClass, panose, unicodeRanges, vendorId, fontSelectionFlags, firstCharacterIndex, lastCharacterIndex, typographicAscender, typographicDescender, typographicLineGap, windowsAscent, windowsDescent, codePage1, codePage2)
	{
		XHeight = xHeight;
		CapHeight = capHeight;
		DefaultCharacter = defaultCharacter;
		BreakCharacter = breakCharacter;
		MaximumContext = maximumContext;
	}

	public override void Write(Stream stream)
	{
		base.Write(stream);
		stream.WriteShort(XHeight);
		stream.WriteShort(CapHeight);
		stream.WriteUShort(DefaultCharacter);
		stream.WriteUShort(BreakCharacter);
		stream.WriteUShort(MaximumContext);
	}
}
