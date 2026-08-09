using System.Collections.Generic;
using System.Linq;
using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Fonts.AdobeFontMetrics;

internal class AdobeFontMetricsBuilder
{
	public double AfmVersion { get; }

	public List<string> Comments { get; }

	public List<AdobeFontMetricsIndividualCharacterMetric> CharacterMetrics { get; } = new List<AdobeFontMetricsIndividualCharacterMetric>();

	public string FontName { get; set; }

	public string FullName { get; set; }

	public string FamilyName { get; set; }

	public string Weight { get; set; }

	public double ItalicAngle { get; set; }

	public bool IsFixedPitch { get; set; }

	public PdfRectangle PdfBoundingBox { get; private set; }

	public double UnderlinePosition { get; set; }

	public double UnderlineThickness { get; set; }

	public string Version { get; set; }

	public string Notice { get; set; }

	public string EncodingScheme { get; set; }

	public int MappingScheme { get; set; }

	public string CharacterSet { get; set; }

	public bool IsBaseFont { get; set; } = true;

	public double CapHeight { get; set; }

	public double XHeight { get; set; }

	public double Ascender { get; set; }

	public double Descender { get; set; }

	public double StdHw { get; set; }

	public double StdVw { get; set; }

	public int EscapeCharacter { get; set; }

	public AdobeFontMetricsCharacterSize CharacterWidth { get; private set; }

	public int Characters { get; set; }

	public AdobeFontMetricsVector VVector { get; private set; }

	public bool IsFixedV { get; set; }

	public AdobeFontMetricsBuilder(double afmVersion)
	{
		AfmVersion = afmVersion;
		Comments = new List<string>();
	}

	public void SetBoundingBox(double x1, double y1, double x2, double y2)
	{
		PdfBoundingBox = new PdfRectangle(x1, y1, x2, y2);
	}

	public void SetCharacterWidth(double x, double y)
	{
		CharacterWidth = new AdobeFontMetricsCharacterSize(x, y);
	}

	public void SetVVector(double x, double y)
	{
		VVector = new AdobeFontMetricsVector(x, y);
	}

	public AdobeFontMetrics Build()
	{
		Dictionary<string, AdobeFontMetricsIndividualCharacterMetric> characterMetrics = CharacterMetrics.ToDictionary((AdobeFontMetricsIndividualCharacterMetric x) => x.Name);
		return new AdobeFontMetrics(AfmVersion, Comments, 0, FontName, FullName, FamilyName, Weight, PdfBoundingBox, Version, Notice, EncodingScheme, MappingScheme, EscapeCharacter, CharacterSet, Characters, IsBaseFont, VVector, IsFixedV, CapHeight, XHeight, Ascender, Descender, UnderlinePosition, UnderlineThickness, ItalicAngle, CharacterWidth, StdHw, StdVw, characterMetrics);
	}
}
