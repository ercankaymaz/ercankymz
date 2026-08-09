using System.Collections.Generic;
using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Fonts.AdobeFontMetrics;

public class AdobeFontMetrics
{
	public double AfmVersion { get; }

	public IReadOnlyList<string> Comments { get; }

	public AdobeFontMetricsWritingDirections MetricSets { get; }

	public string FontName { get; }

	public string FullName { get; }

	public string FamilyName { get; }

	public string Weight { get; }

	public PdfRectangle BoundingBox { get; }

	public string Version { get; }

	public string Notice { get; }

	public string EncodingScheme { get; }

	public int MappingScheme { get; }

	public int EscapeCharacter { get; }

	public string CharacterSet { get; }

	public int Characters { get; }

	public bool IsBaseFont { get; }

	public AdobeFontMetricsVector VVector { get; }

	public bool IsFixedV { get; }

	public double CapHeight { get; }

	public double XHeight { get; }

	public double Ascender { get; }

	public double Descender { get; }

	public double UnderlinePosition { get; }

	public double UnderlineThickness { get; }

	public double ItalicAngle { get; }

	public AdobeFontMetricsCharacterSize CharacterWidth { get; }

	public double HorizontalStemWidth { get; }

	public double VerticalStemWidth { get; }

	public IReadOnlyDictionary<string, AdobeFontMetricsIndividualCharacterMetric> CharacterMetrics { get; }

	public AdobeFontMetrics(double afmVersion, IReadOnlyList<string> comments, int metricSets, string fontName, string fullName, string familyName, string weight, PdfRectangle boundingBox, string version, string notice, string encodingScheme, int mappingScheme, int escapeCharacter, string characterSet, int characters, bool isBaseFont, AdobeFontMetricsVector vVector, bool isFixedV, double capHeight, double xHeight, double ascender, double descender, double underlinePosition, double underlineThickness, double italicAngle, AdobeFontMetricsCharacterSize characterWidth, double horizontalStemWidth, double verticalStemWidth, IReadOnlyDictionary<string, AdobeFontMetricsIndividualCharacterMetric> characterMetrics)
	{
		AfmVersion = afmVersion;
		Comments = comments;
		MetricSets = (AdobeFontMetricsWritingDirections)metricSets;
		FontName = fontName;
		FullName = fullName;
		FamilyName = familyName;
		Weight = weight;
		BoundingBox = boundingBox;
		Version = version;
		Notice = notice;
		EncodingScheme = encodingScheme;
		MappingScheme = mappingScheme;
		EscapeCharacter = escapeCharacter;
		CharacterSet = characterSet;
		Characters = characters;
		IsBaseFont = isBaseFont;
		VVector = vVector;
		IsFixedV = isFixedV;
		CapHeight = capHeight;
		XHeight = xHeight;
		Ascender = ascender;
		Descender = descender;
		UnderlinePosition = underlinePosition;
		UnderlineThickness = underlineThickness;
		ItalicAngle = italicAngle;
		CharacterWidth = characterWidth;
		HorizontalStemWidth = horizontalStemWidth;
		VerticalStemWidth = verticalStemWidth;
		CharacterMetrics = characterMetrics;
	}

	public override string ToString()
	{
		return $"AFM Font {FontName ?? FullName} with {Characters} characters.";
	}
}
