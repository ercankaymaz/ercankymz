using System;
using System.Collections.Generic;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Fonts.Type1.CharStrings;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Fonts.Type1;

public class Type1Font
{
	public string Name { get; }

	public IReadOnlyDictionary<int, string> Encoding { get; }

	public TransformationMatrix FontMatrix { get; }

	public PdfRectangle BoundingBox { get; }

	public Type1PrivateDictionary PrivateDictionary { get; }

	internal Type1CharStrings CharStrings { get; }

	internal Type1Font(string name, IReadOnlyDictionary<int, string> encoding, ArrayToken fontMatrix, PdfRectangle boundingBox, Type1PrivateDictionary privateDictionary, Type1CharStrings charStrings)
	{
		Name = name;
		Encoding = encoding;
		FontMatrix = GetFontTransformationMatrix(fontMatrix);
		BoundingBox = boundingBox;
		PrivateDictionary = privateDictionary ?? throw new ArgumentNullException("privateDictionary");
		CharStrings = charStrings ?? throw new ArgumentNullException("charStrings");
	}

	public PdfRectangle? GetCharacterBoundingBox(string characterName)
	{
		if (string.Equals(characterName, ".notdef", StringComparison.OrdinalIgnoreCase))
		{
			return null;
		}
		return PdfSubpath.GetBoundingRectangle(GetCharacterPath(characterName));
	}

	public bool ContainsNamedCharacter(string name)
	{
		return CharStrings.CharStrings.ContainsKey(name);
	}

	private static TransformationMatrix GetFontTransformationMatrix(ArrayToken array)
	{
		if (array == null || array.Data.Count != 6)
		{
			return TransformationMatrix.FromValues(0.001, 0.0, 0.0, 0.001, 0.0, 0.0);
		}
		double a = ((NumericToken)array.Data[0]).Double;
		double b = ((NumericToken)array.Data[1]).Double;
		double c = ((NumericToken)array.Data[2]).Double;
		double d = ((NumericToken)array.Data[3]).Double;
		double e = ((NumericToken)array.Data[4]).Double;
		double f = ((NumericToken)array.Data[5]).Double;
		return TransformationMatrix.FromValues(a, b, c, d, e, f);
	}

	public IReadOnlyList<PdfSubpath>? GetCharacterPath(string characterName)
	{
		if (string.Equals(characterName, ".notdef", StringComparison.OrdinalIgnoreCase))
		{
			return null;
		}
		if (!CharStrings.TryGenerate(characterName, out IReadOnlyList<PdfSubpath> path))
		{
			return null;
		}
		return path;
	}
}
