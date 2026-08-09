using System;
using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Fonts.TrueType.Tables;

public class HeaderTable : ITrueTypeTable
{
	public enum FontDirection : short
	{
		StronglyRightToLeftWithNeutrals = -2,
		StronglyRightToLeft,
		FullyMixedDirectional,
		StronglyLeftToRight,
		StronglyLeftToRightWithNeutrals
	}

	[Flags]
	public enum HeaderMacStyle : ushort
	{
		None = 0,
		Bold = 1,
		Italic = 2,
		Underline = 4,
		Outline = 8,
		Shadow = 0x10,
		Condensed = 0x20,
		Extended = 0x40
	}

	public string Tag => "head";

	public TrueTypeHeaderTable DirectoryTable { get; }

	public float Version { get; }

	public float Revision { get; }

	public uint CheckSumAdjustment { get; }

	public uint MagicNumber { get; }

	public ushort Flags { get; }

	public ushort UnitsPerEm { get; }

	public DateTime Created { get; }

	public DateTime Modified { get; }

	public PdfRectangle Bounds { get; }

	public HeaderMacStyle MacStyle { get; }

	public ushort LowestRecommendedPpem { get; }

	public FontDirection FontDirectionHint { get; }

	public IndexToLocationTable.EntryFormat IndexToLocFormat { get; }

	public short GlyphDataFormat { get; }

	public HeaderTable(TrueTypeHeaderTable directoryTable, float version, float revision, uint checkSumAdjustment, uint magicNumber, ushort flags, ushort unitsPerEm, DateTime created, DateTime modified, short xMin, short yMin, short xMax, short yMax, ushort macStyle, ushort lowestRecommendedPpem, short fontDirectionHint, IndexToLocationTable.EntryFormat indexToLocFormat, short glyphDataFormat)
	{
		DirectoryTable = directoryTable;
		Version = version;
		Revision = revision;
		CheckSumAdjustment = checkSumAdjustment;
		MagicNumber = magicNumber;
		Flags = flags;
		UnitsPerEm = unitsPerEm;
		Created = created;
		Modified = modified;
		Bounds = new PdfRectangle(xMin, yMin, xMax, yMax);
		MacStyle = (HeaderMacStyle)macStyle;
		LowestRecommendedPpem = lowestRecommendedPpem;
		FontDirectionHint = (FontDirection)fontDirectionHint;
		IndexToLocFormat = indexToLocFormat;
		GlyphDataFormat = glyphDataFormat;
	}

	public static HeaderTable Load(TrueTypeDataBytes data, TrueTypeHeaderTable table)
	{
		data.Seek(table.Offset);
		float version = data.Read32Fixed();
		float revision = data.Read32Fixed();
		uint checkSumAdjustment = data.ReadUnsignedInt();
		uint num = data.ReadUnsignedInt();
		if (num != 1594834165)
		{
			throw new InvalidOperationException("The magic number for this TrueType font was incorrect. Value was: " + num);
		}
		ushort flags = data.ReadUnsignedShort();
		ushort num2 = data.ReadUnsignedShort();
		if (num2 < 16 || num2 > 16384)
		{
			throw new InvalidOperationException($"The units per em for this TrueType font was incorrect, value should be between 16 and 16384 but found {num2} istead.");
		}
		DateTime created;
		try
		{
			created = data.ReadInternationalDate();
		}
		catch (InvalidFontFormatException)
		{
			created = DateTime.MinValue;
		}
		DateTime modified;
		try
		{
			modified = data.ReadInternationalDate();
		}
		catch (InvalidFontFormatException)
		{
			modified = DateTime.MinValue;
		}
		short xMin = data.ReadSignedShort();
		short yMin = data.ReadSignedShort();
		short xMax = data.ReadSignedShort();
		short yMax = data.ReadSignedShort();
		ushort macStyle = data.ReadUnsignedShort();
		ushort lowestRecommendedPpem = data.ReadUnsignedShort();
		short fontDirectionHint = data.ReadSignedShort();
		IndexToLocationTable.EntryFormat indexToLocFormat = (IndexToLocationTable.EntryFormat)data.ReadSignedShort();
		short glyphDataFormat = data.ReadSignedShort();
		return new HeaderTable(table, version, revision, checkSumAdjustment, num, flags, num2, created, modified, xMin, yMin, xMax, yMax, macStyle, lowestRecommendedPpem, fontDirectionHint, indexToLocFormat, glyphDataFormat);
	}
}
