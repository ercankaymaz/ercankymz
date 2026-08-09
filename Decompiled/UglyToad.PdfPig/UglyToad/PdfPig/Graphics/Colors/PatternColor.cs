using System;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Graphics.Colors;

public abstract class PatternColor : IColor
{
	public PatternType PatternType { get; }

	public DictionaryToken PatternDictionary { get; }

	public DictionaryToken ExtGState { get; }

	public TransformationMatrix Matrix { get; }

	public ColorSpace ColorSpace { get; } = ColorSpace.Pattern;

	protected internal PatternColor(PatternType patternType, DictionaryToken patternDictionary, DictionaryToken extGState, TransformationMatrix matrix)
	{
		PatternType = patternType;
		PatternDictionary = patternDictionary;
		ExtGState = extGState;
		Matrix = matrix;
	}

	public (double r, double g, double b) ToRGBValues()
	{
		throw new InvalidOperationException("Cannot call ToRGBValues in a Pattern color.");
	}

	public override string ToString()
	{
		return $"Pattern: ({PatternType})";
	}
}
