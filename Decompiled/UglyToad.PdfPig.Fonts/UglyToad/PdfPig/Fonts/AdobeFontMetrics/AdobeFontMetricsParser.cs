using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Fonts.AdobeFontMetrics;

public static class AdobeFontMetricsParser
{
	private static readonly object Locker = new object();

	private static readonly Dictionary<string, string> CharacterNames = new Dictionary<string, string>();

	public const string Comment = "Comment";

	public const string StartFontMetrics = "StartFontMetrics";

	public const string EndFontMetrics = "EndFontMetrics";

	public const string FontName = "FontName";

	public const string FullName = "FullName";

	public const string FamilyName = "FamilyName";

	public const string Weight = "Weight";

	public const string FontBbox = "FontBBox";

	public const string Version = "Version";

	public const string Notice = "Notice";

	public const string EncodingScheme = "EncodingScheme";

	public const string MappingScheme = "MappingScheme";

	public const string EscChar = "EscChar";

	public const string CharacterSet = "CharacterSet";

	public const string Characters = "Characters";

	public const string IsBaseFont = "IsBaseFont";

	public const string VVector = "VVector";

	public const string IsFixedV = "IsFixedV";

	public const string CapHeight = "CapHeight";

	public const string XHeight = "XHeight";

	public const string Ascender = "Ascender";

	public const string Descender = "Descender";

	public const string UnderlinePosition = "UnderlinePosition";

	public const string UnderlineThickness = "UnderlineThickness";

	public const string ItalicAngle = "ItalicAngle";

	public const string CharWidth = "CharWidth";

	public const string IsFixedPitch = "IsFixedPitch";

	public const string StartCharMetrics = "StartCharMetrics";

	public const string EndCharMetrics = "EndCharMetrics";

	public const string CharmetricsC = "C";

	public const string CharmetricsCh = "CH";

	public const string CharmetricsWx = "WX";

	public const string CharmetricsW0X = "W0X";

	public const string CharmetricsW1X = "W1X";

	public const string CharmetricsWy = "WY";

	public const string CharmetricsW0Y = "W0Y";

	public const string CharmetricsW1Y = "W1Y";

	public const string CharmetricsW = "W";

	public const string CharmetricsW0 = "W0";

	public const string CharmetricsW1 = "W1";

	public const string CharmetricsVv = "VV";

	public const string CharmetricsN = "N";

	public const string CharmetricsB = "B";

	public const string CharmetricsL = "L";

	public const string StdHw = "StdHW";

	public const string StdVw = "StdVW";

	public const string StartTrackKern = "StartTrackKern";

	public const string EndTrackKern = "EndTrackKern";

	public const string StartKernData = "StartKernData";

	public const string EndKernData = "EndKernData";

	public const string StartKernPairs = "StartKernPairs";

	public const string EndKernPairs = "EndKernPairs";

	public const string StartKernPairs0 = "StartKernPairs0";

	public const string StartKernPairs1 = "StartKernPairs1";

	public const string StartComposites = "StartComposites";

	public const string EndComposites = "EndComposites";

	public const string Cc = "CC";

	public const string Pcc = "PCC";

	public const string KernPairKp = "KP";

	public const string KernPairKph = "KPH";

	public const string KernPairKpx = "KPX";

	public const string KernPairKpy = "KPY";

	private static readonly char[] IndividualCharmetricsSplit = new char[1] { ';' };

	private static readonly char[] CharmetricsKeySplit = new char[1] { ' ' };

	public static AdobeFontMetrics Parse(IInputBytes bytes, bool useReducedDataSet)
	{
		StringBuilder stringBuilder = new StringBuilder();
		string b = ReadString(bytes, stringBuilder);
		if (!string.Equals("StartFontMetrics", b, StringComparison.OrdinalIgnoreCase))
		{
			throw new InvalidFontFormatException("The AFM file was not valid, it did not start with StartFontMetrics.");
		}
		AdobeFontMetricsBuilder adobeFontMetricsBuilder = new AdobeFontMetricsBuilder(ReadDouble(bytes, stringBuilder));
		while ((b = ReadString(bytes, stringBuilder)) != "EndFontMetrics")
		{
			switch (b)
			{
			case "Comment":
				adobeFontMetricsBuilder.Comments.Add(ReadLine(bytes, stringBuilder));
				break;
			case "FontName":
				adobeFontMetricsBuilder.FontName = ReadLine(bytes, stringBuilder);
				break;
			case "FullName":
				adobeFontMetricsBuilder.FullName = ReadLine(bytes, stringBuilder);
				break;
			case "FamilyName":
				adobeFontMetricsBuilder.FamilyName = ReadLine(bytes, stringBuilder);
				break;
			case "Weight":
				adobeFontMetricsBuilder.Weight = ReadLine(bytes, stringBuilder);
				break;
			case "ItalicAngle":
				adobeFontMetricsBuilder.ItalicAngle = ReadDouble(bytes, stringBuilder);
				break;
			case "IsFixedPitch":
				adobeFontMetricsBuilder.IsFixedPitch = ReadBool(bytes, stringBuilder);
				break;
			case "FontBBox":
				adobeFontMetricsBuilder.SetBoundingBox(ReadDouble(bytes, stringBuilder), ReadDouble(bytes, stringBuilder), ReadDouble(bytes, stringBuilder), ReadDouble(bytes, stringBuilder));
				break;
			case "UnderlinePosition":
				adobeFontMetricsBuilder.UnderlinePosition = ReadDouble(bytes, stringBuilder);
				break;
			case "UnderlineThickness":
				adobeFontMetricsBuilder.UnderlineThickness = ReadDouble(bytes, stringBuilder);
				break;
			case "Version":
				adobeFontMetricsBuilder.Version = ReadLine(bytes, stringBuilder);
				break;
			case "Notice":
				adobeFontMetricsBuilder.Notice = ReadLine(bytes, stringBuilder);
				break;
			case "EncodingScheme":
				adobeFontMetricsBuilder.EncodingScheme = ReadLine(bytes, stringBuilder);
				break;
			case "MappingScheme":
				adobeFontMetricsBuilder.MappingScheme = (int)ReadDouble(bytes, stringBuilder);
				break;
			case "CharacterSet":
				adobeFontMetricsBuilder.CharacterSet = ReadLine(bytes, stringBuilder);
				break;
			case "EscChar":
				adobeFontMetricsBuilder.EscapeCharacter = (int)ReadDouble(bytes, stringBuilder);
				break;
			case "Characters":
				adobeFontMetricsBuilder.Characters = (int)ReadDouble(bytes, stringBuilder);
				break;
			case "IsBaseFont":
				adobeFontMetricsBuilder.IsBaseFont = ReadBool(bytes, stringBuilder);
				break;
			case "CapHeight":
				adobeFontMetricsBuilder.CapHeight = ReadDouble(bytes, stringBuilder);
				break;
			case "XHeight":
				adobeFontMetricsBuilder.XHeight = ReadDouble(bytes, stringBuilder);
				break;
			case "Ascender":
				adobeFontMetricsBuilder.Ascender = ReadDouble(bytes, stringBuilder);
				break;
			case "Descender":
				adobeFontMetricsBuilder.Descender = ReadDouble(bytes, stringBuilder);
				break;
			case "StdHW":
				adobeFontMetricsBuilder.StdHw = ReadDouble(bytes, stringBuilder);
				break;
			case "StdVW":
				adobeFontMetricsBuilder.StdVw = ReadDouble(bytes, stringBuilder);
				break;
			case "CharWidth":
				adobeFontMetricsBuilder.SetCharacterWidth(ReadDouble(bytes, stringBuilder), ReadDouble(bytes, stringBuilder));
				break;
			case "VVector":
				adobeFontMetricsBuilder.SetVVector(ReadDouble(bytes, stringBuilder), ReadDouble(bytes, stringBuilder));
				break;
			case "IsFixedV":
				adobeFontMetricsBuilder.IsFixedV = ReadBool(bytes, stringBuilder);
				break;
			case "StartCharMetrics":
			{
				int num = (int)ReadDouble(bytes, stringBuilder);
				for (int i = 0; i < num; i++)
				{
					AdobeFontMetricsIndividualCharacterMetric item = ReadCharacterMetric(bytes, stringBuilder);
					adobeFontMetricsBuilder.CharacterMetrics.Add(item);
				}
				string text = ReadString(bytes, stringBuilder);
				if (text != "EndCharMetrics")
				{
					throw new InvalidFontFormatException("The character metrics section did not end with EndCharMetrics instead it was " + text + ".");
				}
				break;
			}
			}
		}
		return adobeFontMetricsBuilder.Build();
	}

	private static double ReadDouble(IInputBytes input, StringBuilder stringBuilder)
	{
		return double.Parse(ReadString(input, stringBuilder), CultureInfo.InvariantCulture);
	}

	private static bool ReadBool(IInputBytes input, StringBuilder stringBuilder)
	{
		string text = ReadString(input, stringBuilder);
		if (!(text == "true"))
		{
			if (text == "false")
			{
				return false;
			}
			throw new InvalidFontFormatException("The AFM should have contained a boolean but instead contained: " + text + ".");
		}
		return true;
	}

	private static string ReadString(IInputBytes input, StringBuilder stringBuilder)
	{
		stringBuilder.Clear();
		if (input.IsAtEnd())
		{
			return "EndFontMetrics";
		}
		while (ReadHelper.IsWhitespace(input.CurrentByte) && input.MoveNext())
		{
		}
		stringBuilder.Append((char)input.CurrentByte);
		while (input.MoveNext() && !ReadHelper.IsWhitespace(input.CurrentByte))
		{
			stringBuilder.Append((char)input.CurrentByte);
		}
		return stringBuilder.ToString();
	}

	private static string ReadLine(IInputBytes input, StringBuilder stringBuilder)
	{
		stringBuilder.Clear();
		while (ReadHelper.IsWhitespace(input.CurrentByte) && input.MoveNext())
		{
		}
		stringBuilder.Append((char)input.CurrentByte);
		while (input.MoveNext() && !ReadHelper.IsEndOfLine(input.CurrentByte))
		{
			stringBuilder.Append((char)input.CurrentByte);
		}
		return stringBuilder.ToString();
	}

	private static AdobeFontMetricsIndividualCharacterMetric ReadCharacterMetric(IInputBytes bytes, StringBuilder stringBuilder)
	{
		string[] array = ReadLine(bytes, stringBuilder).Split(IndividualCharmetricsSplit, StringSplitOptions.RemoveEmptyEntries);
		AdobeFontMetricsIndividualCharacterMetricBuilder adobeFontMetricsIndividualCharacterMetricBuilder = new AdobeFontMetricsIndividualCharacterMetricBuilder();
		string[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			string[] array3 = array2[i].Split(CharmetricsKeySplit, StringSplitOptions.RemoveEmptyEntries);
			switch (array3[0])
			{
			case "C":
			{
				int characterCode2 = int.Parse(array3[1], CultureInfo.InvariantCulture);
				adobeFontMetricsIndividualCharacterMetricBuilder.CharacterCode = characterCode2;
				break;
			}
			case "CH":
			{
				int characterCode = int.Parse(array3[1], NumberStyles.HexNumber, CultureInfo.InvariantCulture);
				adobeFontMetricsIndividualCharacterMetricBuilder.CharacterCode = characterCode;
				break;
			}
			case "WX":
				adobeFontMetricsIndividualCharacterMetricBuilder.WidthX = double.Parse(array3[1], CultureInfo.InvariantCulture);
				break;
			case "W0X":
				adobeFontMetricsIndividualCharacterMetricBuilder.WidthXDirection0 = double.Parse(array3[1], CultureInfo.InvariantCulture);
				break;
			case "W1X":
				adobeFontMetricsIndividualCharacterMetricBuilder.WidthXDirection1 = double.Parse(array3[1], CultureInfo.InvariantCulture);
				break;
			case "WY":
				adobeFontMetricsIndividualCharacterMetricBuilder.WidthY = double.Parse(array3[1], CultureInfo.InvariantCulture);
				break;
			case "W0Y":
				adobeFontMetricsIndividualCharacterMetricBuilder.WidthYDirection0 = double.Parse(array3[1], CultureInfo.InvariantCulture);
				break;
			case "W1Y":
				adobeFontMetricsIndividualCharacterMetricBuilder.WidthYDirection1 = double.Parse(array3[1], CultureInfo.InvariantCulture);
				break;
			case "W":
				adobeFontMetricsIndividualCharacterMetricBuilder.WidthX = double.Parse(array3[1], CultureInfo.InvariantCulture);
				adobeFontMetricsIndividualCharacterMetricBuilder.WidthY = double.Parse(array3[2], CultureInfo.InvariantCulture);
				break;
			case "W0":
				adobeFontMetricsIndividualCharacterMetricBuilder.WidthXDirection0 = double.Parse(array3[1], CultureInfo.InvariantCulture);
				adobeFontMetricsIndividualCharacterMetricBuilder.WidthYDirection0 = double.Parse(array3[2], CultureInfo.InvariantCulture);
				break;
			case "W1":
				adobeFontMetricsIndividualCharacterMetricBuilder.WidthXDirection1 = double.Parse(array3[1], CultureInfo.InvariantCulture);
				adobeFontMetricsIndividualCharacterMetricBuilder.WidthYDirection1 = double.Parse(array3[2], CultureInfo.InvariantCulture);
				break;
			case "VV":
				adobeFontMetricsIndividualCharacterMetricBuilder.VVector = new AdobeFontMetricsVector(double.Parse(array3[1], CultureInfo.InvariantCulture), double.Parse(array3[2], CultureInfo.InvariantCulture));
				break;
			case "N":
				lock (Locker)
				{
					string text = array3[1];
					if (!CharacterNames.TryGetValue(text, out string value))
					{
						value = text;
						CharacterNames[text] = value;
					}
					adobeFontMetricsIndividualCharacterMetricBuilder.Name = value;
				}
				break;
			case "B":
				adobeFontMetricsIndividualCharacterMetricBuilder.BoundingBox = new PdfRectangle(double.Parse(array3[1], CultureInfo.InvariantCulture), double.Parse(array3[2], CultureInfo.InvariantCulture), double.Parse(array3[3], CultureInfo.InvariantCulture), double.Parse(array3[4], CultureInfo.InvariantCulture));
				break;
			case "L":
				adobeFontMetricsIndividualCharacterMetricBuilder.Ligature = new AdobeFontMetricsLigature(array3[1], array3[2]);
				break;
			default:
				throw new InvalidFontFormatException("Unknown CharMetrics command '" + array3[0] + "'.");
			}
		}
		return adobeFontMetricsIndividualCharacterMetricBuilder.Build();
	}
}
