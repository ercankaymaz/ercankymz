using System;

namespace UglyToad.PdfPig.Fonts.TrueType.Tables;

internal class BasicMaximumProfileTable : ITrueTypeTable
{
	public string Tag => "maxp";

	public TrueTypeHeaderTable DirectoryTable { get; }

	public bool IsCompressedFontFormat => Version == 0.5;

	public double Version { get; }

	public int NumberOfGlyphs { get; }

	public BasicMaximumProfileTable(TrueTypeHeaderTable directoryTable, float version, int numberOfGlyphs)
	{
		DirectoryTable = directoryTable;
		Version = version;
		NumberOfGlyphs = numberOfGlyphs;
	}

	public static BasicMaximumProfileTable Load(TrueTypeDataBytes data, TrueTypeHeaderTable table)
	{
		data.Seek(table.Offset);
		float num = data.Read32Fixed();
		ushort numberOfGlyphs = data.ReadUnsignedShort();
		if (Math.Abs((double)num - 0.5) < 1.401298464324817E-45)
		{
			return new BasicMaximumProfileTable(table, num, numberOfGlyphs);
		}
		ushort maximumPoints = data.ReadUnsignedShort();
		ushort maximumContours = data.ReadUnsignedShort();
		ushort maximumCompositePoints = data.ReadUnsignedShort();
		ushort maximumCompositeContours = data.ReadUnsignedShort();
		ushort maximumZones = data.ReadUnsignedShort();
		ushort maximumTwilightPoints = data.ReadUnsignedShort();
		ushort maximumStorage = data.ReadUnsignedShort();
		ushort maximumFunctionDefinitions = data.ReadUnsignedShort();
		ushort maximumInstructionDefinitions = data.ReadUnsignedShort();
		ushort maximumStackElements = data.ReadUnsignedShort();
		ushort maximumSizeOfInstructions = data.ReadUnsignedShort();
		ushort maximumComponentElements = data.ReadUnsignedShort();
		ushort maximumComponentDepth = data.ReadUnsignedShort();
		return new MaximumProfileTable(table, num, numberOfGlyphs, maximumPoints, maximumContours, maximumCompositePoints, maximumCompositeContours, maximumZones, maximumTwilightPoints, maximumStorage, maximumFunctionDefinitions, maximumInstructionDefinitions, maximumStackElements, maximumSizeOfInstructions, maximumComponentElements, maximumComponentDepth);
	}
}
