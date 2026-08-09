using System.Collections.Generic;
using System.IO;
using System.Linq;
using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Fonts.TrueType.Tables;

public class Os2Table : ITrueTypeTable, IWriteable
{
	public string Tag => "OS/2";

	public TrueTypeHeaderTable DirectoryTable { get; }

	public ushort Version { get; }

	public short XAverageCharacterWidth { get; }

	public ushort WeightClass { get; }

	public ushort WidthClass { get; }

	public ushort TypeFlags { get; }

	public short YSubscriptXSize { get; }

	public short YSubscriptYSize { get; }

	public short YSubscriptXOffset { get; }

	public short YSubscriptYOffset { get; }

	public short YSuperscriptXSize { get; }

	public short YSuperscriptYSize { get; }

	public short YSuperscriptXOffset { get; }

	public short YSuperscriptYOffset { get; }

	public short YStrikeoutSize { get; }

	public short YStrikeoutPosition { get; }

	public short FamilyClass { get; }

	public IReadOnlyList<byte> Panose { get; }

	public IReadOnlyList<uint> UnicodeRanges { get; }

	public string VendorId { get; }

	public ushort FontSelectionFlags { get; }

	public ushort FirstCharacterIndex { get; }

	public ushort LastCharacterIndex { get; }

	public Os2Table(TrueTypeHeaderTable directoryTable, ushort version, short xAverageCharacterWidth, ushort weightClass, ushort widthClass, ushort typeFlags, short ySubscriptXSize, short ySubscriptYSize, short ySubscriptXOffset, short ySubscriptYOffset, short ySuperscriptXSize, short ySuperscriptYSize, short ySuperscriptXOffset, short ySuperscriptYOffset, short yStrikeoutSize, short yStrikeoutPosition, short familyClass, IReadOnlyList<byte> panose, IReadOnlyList<uint> unicodeRanges, string vendorId, ushort fontSelectionFlags, ushort firstCharacterIndex, ushort lastCharacterIndex)
	{
		DirectoryTable = directoryTable;
		Version = version;
		XAverageCharacterWidth = xAverageCharacterWidth;
		WeightClass = weightClass;
		WidthClass = widthClass;
		TypeFlags = typeFlags;
		YSubscriptXSize = ySubscriptXSize;
		YSubscriptYSize = ySubscriptYSize;
		YSubscriptXOffset = ySubscriptXOffset;
		YSubscriptYOffset = ySubscriptYOffset;
		YSuperscriptXSize = ySuperscriptXSize;
		YSuperscriptYSize = ySuperscriptYSize;
		YSuperscriptXOffset = ySuperscriptXOffset;
		YSuperscriptYOffset = ySuperscriptYOffset;
		YStrikeoutSize = yStrikeoutSize;
		YStrikeoutPosition = yStrikeoutPosition;
		FamilyClass = familyClass;
		Panose = panose;
		UnicodeRanges = unicodeRanges;
		VendorId = vendorId;
		FontSelectionFlags = fontSelectionFlags;
		FirstCharacterIndex = firstCharacterIndex;
		LastCharacterIndex = lastCharacterIndex;
	}

	public virtual void Write(Stream stream)
	{
		stream.WriteUShort(Version);
		stream.WriteShort(XAverageCharacterWidth);
		stream.WriteUShort(WeightClass);
		stream.WriteUShort(WidthClass);
		stream.WriteShort(TypeFlags);
		stream.WriteShort(YSubscriptXSize);
		stream.WriteShort(YSubscriptYSize);
		stream.WriteShort(YSubscriptXOffset);
		stream.WriteShort(YSubscriptYOffset);
		stream.WriteShort(YSuperscriptXSize);
		stream.WriteShort(YSuperscriptYSize);
		stream.WriteShort(YSuperscriptXOffset);
		stream.WriteShort(YSuperscriptYOffset);
		stream.WriteShort(YStrikeoutSize);
		stream.WriteShort(YStrikeoutPosition);
		stream.WriteShort(FamilyClass);
		stream.Write(Panose.ToArray(), 0, Panose.Count);
		for (int i = 0; i < UnicodeRanges.Count; i++)
		{
			stream.WriteUInt(UnicodeRanges[i]);
		}
		for (int j = 0; j < VendorId.Length; j++)
		{
			stream.WriteByte((byte)VendorId[j]);
		}
		stream.WriteUShort(FontSelectionFlags);
		stream.WriteUShort(FirstCharacterIndex);
		stream.WriteUShort(LastCharacterIndex);
	}
}
