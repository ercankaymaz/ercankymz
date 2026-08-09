using System.Collections.Generic;
using System.IO;
using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Fonts.TrueType.Tables;

public class Os2RevisedVersion0Table : Os2Table
{
	public short TypographicAscender { get; }

	public short TypographicDescender { get; }

	public short TypographicLineGap { get; }

	public ushort WindowsAscent { get; }

	public ushort WindowsDescent { get; }

	public Os2RevisedVersion0Table(TrueTypeHeaderTable directoryTable, ushort version, short xAverageCharacterWidth, ushort weightClass, ushort widthClass, ushort typeFlags, short ySubscriptXSize, short ySubscriptYSize, short ySubscriptXOffset, short ySubscriptYOffset, short ySuperscriptXSize, short ySuperscriptYSize, short ySuperscriptXOffset, short ySuperscriptYOffset, short yStrikeoutSize, short yStrikeoutPosition, short familyClass, IReadOnlyList<byte> panose, IReadOnlyList<uint> unicodeRanges, string vendorId, ushort fontSelectionFlags, ushort firstCharacterIndex, ushort lastCharacterIndex, short typographicAscender, short typographicDescender, short typographicLineGap, ushort windowsAscent, ushort windowsDescent)
		: base(directoryTable, version, xAverageCharacterWidth, weightClass, widthClass, typeFlags, ySubscriptXSize, ySubscriptYSize, ySubscriptXOffset, ySubscriptYOffset, ySuperscriptXSize, ySuperscriptYSize, ySuperscriptXOffset, ySuperscriptYOffset, yStrikeoutSize, yStrikeoutPosition, familyClass, panose, unicodeRanges, vendorId, fontSelectionFlags, firstCharacterIndex, lastCharacterIndex)
	{
		TypographicAscender = typographicAscender;
		TypographicDescender = typographicDescender;
		TypographicLineGap = typographicLineGap;
		WindowsAscent = windowsAscent;
		WindowsDescent = windowsDescent;
	}

	public override void Write(Stream stream)
	{
		base.Write(stream);
		stream.WriteShort(TypographicAscender);
		stream.WriteShort(TypographicDescender);
		stream.WriteShort(TypographicLineGap);
		stream.WriteUShort(WindowsAscent);
		stream.WriteUShort(WindowsDescent);
	}
}
