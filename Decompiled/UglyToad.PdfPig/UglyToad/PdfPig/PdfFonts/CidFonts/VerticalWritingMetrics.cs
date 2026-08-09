using System.Collections.Generic;
using UglyToad.PdfPig.Geometry;

namespace UglyToad.PdfPig.PdfFonts.CidFonts;

internal class VerticalWritingMetrics
{
	public VerticalVectorComponents DefaultVerticalWritingMetrics { get; }

	public IReadOnlyDictionary<int, double> IndividualVerticalWritingDisplacements { get; }

	public IReadOnlyDictionary<int, PdfVector> IndividualVerticalWritingPositions { get; }

	public VerticalWritingMetrics(VerticalVectorComponents defaultVerticalWritingMetrics, IReadOnlyDictionary<int, double>? individualVerticalWritingDisplacements, IReadOnlyDictionary<int, PdfVector>? individualVerticalWritingPositions)
	{
		DefaultVerticalWritingMetrics = defaultVerticalWritingMetrics;
		IndividualVerticalWritingDisplacements = individualVerticalWritingDisplacements ?? new Dictionary<int, double>(0);
		IndividualVerticalWritingPositions = individualVerticalWritingPositions ?? new Dictionary<int, PdfVector>(0);
	}

	public PdfVector GetPositionVector(int characterIdentifier, double glyphWidth)
	{
		if (IndividualVerticalWritingPositions.TryGetValue(characterIdentifier, out var value))
		{
			return value;
		}
		return DefaultVerticalWritingMetrics.GetPositionVector(glyphWidth);
	}

	public PdfVector GetDisplacementVector(int characterIdentifier)
	{
		if (IndividualVerticalWritingDisplacements.TryGetValue(characterIdentifier, out var value))
		{
			return new PdfVector(0.0, value);
		}
		return DefaultVerticalWritingMetrics.GetDisplacementVector();
	}
}
