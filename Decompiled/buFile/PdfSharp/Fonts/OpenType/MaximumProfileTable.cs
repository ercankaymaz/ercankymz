using System;

namespace PdfSharp.Fonts.OpenType;

internal class MaximumProfileTable : OpenTypeFontTable
{
	public const string Tag = "maxp";

	public int version;

	public ushort numGlyphs;

	public ushort maxPoints;

	public ushort maxContours;

	public ushort maxCompositePoints;

	public ushort maxCompositeContours;

	public ushort maxZones;

	public ushort maxTwilightPoints;

	public ushort maxStorage;

	public ushort maxFunctionDefs;

	public ushort maxInstructionDefs;

	public ushort maxStackElements;

	public ushort maxSizeOfInstructions;

	public ushort maxComponentElements;

	public ushort maxComponentDepth;

	public MaximumProfileTable(OpenTypeFontface fontData)
		: base(fontData, "maxp")
	{
		Read();
	}

	public void Read()
	{
		try
		{
			version = _fontData.ReadFixed();
			numGlyphs = _fontData.ReadUShort();
			maxPoints = _fontData.ReadUShort();
			maxContours = _fontData.ReadUShort();
			maxCompositePoints = _fontData.ReadUShort();
			maxCompositeContours = _fontData.ReadUShort();
			maxZones = _fontData.ReadUShort();
			maxTwilightPoints = _fontData.ReadUShort();
			maxStorage = _fontData.ReadUShort();
			maxFunctionDefs = _fontData.ReadUShort();
			maxInstructionDefs = _fontData.ReadUShort();
			maxStackElements = _fontData.ReadUShort();
			maxSizeOfInstructions = _fontData.ReadUShort();
			maxComponentElements = _fontData.ReadUShort();
			maxComponentDepth = _fontData.ReadUShort();
		}
		catch (Exception innerException)
		{
			throw new InvalidOperationException(PSSR.ErrorReadingFontData, innerException);
		}
	}
}
