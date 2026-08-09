namespace UglyToad.PdfPig.Fonts.TrueType.Tables;

internal class MaximumProfileTable : BasicMaximumProfileTable
{
	public int MaximumPoints { get; }

	public int MaximumContours { get; }

	public int MaximumCompositePoints { get; }

	public int MaximumCompositeContours { get; }

	public int MaximumZones { get; }

	public int MaximumTwilightPoints { get; }

	public int MaximumStorage { get; }

	public int MaximumFunctionDefinitions { get; }

	public int MaximumInstructionDefinitions { get; }

	public int MaximumStackElements { get; }

	public int MaximumSizeOfInstructions { get; }

	public int MaximumComponentElements { get; }

	public int MaximumComponentDepth { get; }

	public MaximumProfileTable(TrueTypeHeaderTable directoryTable, float version, int numberOfGlyphs, int maximumPoints, int maximumContours, int maximumCompositePoints, int maximumCompositeContours, int maximumZones, int maximumTwilightPoints, int maximumStorage, int maximumFunctionDefinitions, int maximumInstructionDefinitions, int maximumStackElements, int maximumSizeOfInstructions, int maximumComponentElements, int maximumComponentDepth)
		: base(directoryTable, version, numberOfGlyphs)
	{
		MaximumPoints = maximumPoints;
		MaximumContours = maximumContours;
		MaximumCompositePoints = maximumCompositePoints;
		MaximumCompositeContours = maximumCompositeContours;
		MaximumZones = maximumZones;
		MaximumTwilightPoints = maximumTwilightPoints;
		MaximumStorage = maximumStorage;
		MaximumFunctionDefinitions = maximumFunctionDefinitions;
		MaximumInstructionDefinitions = maximumInstructionDefinitions;
		MaximumStackElements = maximumStackElements;
		MaximumSizeOfInstructions = maximumSizeOfInstructions;
		MaximumComponentElements = maximumComponentElements;
		MaximumComponentDepth = maximumComponentDepth;
	}
}
