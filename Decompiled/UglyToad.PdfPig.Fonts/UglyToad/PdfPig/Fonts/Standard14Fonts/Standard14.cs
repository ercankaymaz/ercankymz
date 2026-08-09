using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Fonts.AdobeFontMetrics;

namespace UglyToad.PdfPig.Fonts.Standard14Fonts;

public static class Standard14
{
	private static readonly HashSet<string> Standard14Names;

	private static readonly Dictionary<string, string> Standard14Mapping;

	private static readonly Dictionary<Standard14Font, string> BuilderTypesToNames;

	private static readonly Dictionary<string, UglyToad.PdfPig.Fonts.AdobeFontMetrics.AdobeFontMetrics> Standard14Cache;

	static Standard14()
	{
		Standard14Names = new HashSet<string>();
		Standard14Mapping = new Dictionary<string, string>(34);
		BuilderTypesToNames = new Dictionary<Standard14Font, string>(14);
		Standard14Cache = new Dictionary<string, UglyToad.PdfPig.Fonts.AdobeFontMetrics.AdobeFontMetrics>(34);
		AddAdobeFontMetrics("Courier-Bold", Standard14Font.CourierBold);
		AddAdobeFontMetrics("Courier-BoldOblique", Standard14Font.CourierBoldOblique);
		AddAdobeFontMetrics("Courier", Standard14Font.Courier);
		AddAdobeFontMetrics("Courier-Oblique", Standard14Font.CourierOblique);
		AddAdobeFontMetrics("Helvetica", Standard14Font.Helvetica);
		AddAdobeFontMetrics("Helvetica-Bold", Standard14Font.HelveticaBold);
		AddAdobeFontMetrics("Helvetica-BoldOblique", Standard14Font.HelveticaBoldOblique);
		AddAdobeFontMetrics("Helvetica-Oblique", Standard14Font.HelveticaOblique);
		AddAdobeFontMetrics("Symbol", Standard14Font.Symbol);
		AddAdobeFontMetrics("Times-Bold", Standard14Font.TimesBold);
		AddAdobeFontMetrics("Times-BoldItalic", Standard14Font.TimesBoldItalic);
		AddAdobeFontMetrics("Times-Italic", Standard14Font.TimesItalic);
		AddAdobeFontMetrics("Times-Roman", Standard14Font.TimesRoman);
		AddAdobeFontMetrics("ZapfDingbats", Standard14Font.ZapfDingbats);
		AddAdobeFontMetrics("CourierCourierNew", "Courier");
		AddAdobeFontMetrics("CourierNew", "Courier");
		AddAdobeFontMetrics("CourierNew,Italic", "Courier-Oblique");
		AddAdobeFontMetrics("CourierNew,Bold", "Courier-Bold");
		AddAdobeFontMetrics("CourierNew,BoldItalic", "Courier-BoldOblique");
		AddAdobeFontMetrics("Arial", "Helvetica");
		AddAdobeFontMetrics("Arial,Italic", "Helvetica-Oblique");
		AddAdobeFontMetrics("Arial,Bold", "Helvetica-Bold");
		AddAdobeFontMetrics("Arial,BoldItalic", "Helvetica-BoldOblique");
		AddAdobeFontMetrics("TimesNewRoman", "Times-Roman");
		AddAdobeFontMetrics("TimesNewRoman,Italic", "Times-Italic");
		AddAdobeFontMetrics("TimesNewRoman,Bold", "Times-Bold");
		AddAdobeFontMetrics("TimesNewRoman,BoldItalic", "Times-BoldItalic");
		AddAdobeFontMetrics("Symbol,Italic", "Symbol");
		AddAdobeFontMetrics("Symbol,Bold", "Symbol");
		AddAdobeFontMetrics("Symbol,BoldItalic", "Symbol");
		AddAdobeFontMetrics("Times", "Times-Roman");
		AddAdobeFontMetrics("Times,Italic", "Times-Italic");
		AddAdobeFontMetrics("Times,Bold", "Times-Bold");
		AddAdobeFontMetrics("Times,BoldItalic", "Times-BoldItalic");
		AddAdobeFontMetrics("ArialMT", "Helvetica");
		AddAdobeFontMetrics("Arial-ItalicMT", "Helvetica-Oblique");
		AddAdobeFontMetrics("Arial-BoldMT", "Helvetica-Bold");
		AddAdobeFontMetrics("Arial-BoldMT,Bold", "Helvetica-Bold");
		AddAdobeFontMetrics("Arial-BoldItalicMT", "Helvetica-BoldOblique");
	}

	private static void AddAdobeFontMetrics(string fontName, Standard14Font? type = null)
	{
		AddAdobeFontMetrics(fontName, fontName, type);
	}

	private static void AddAdobeFontMetrics(string fontName, string afmName, Standard14Font? type = null)
	{
		Standard14Names.Add(fontName);
		Standard14Mapping.Add(fontName, afmName);
		if (type.HasValue)
		{
			BuilderTypesToNames[type.Value] = afmName;
		}
		if (Standard14Cache.TryGetValue(afmName, out UglyToad.PdfPig.Fonts.AdobeFontMetrics.AdobeFontMetrics value))
		{
			Standard14Cache[fontName] = value;
		}
		try
		{
			Assembly assembly = typeof(Standard14).Assembly;
			string text = "UglyToad.PdfPig.Fonts.Resources.AdobeFontMetrics." + afmName + ".afm";
			IInputBytes bytes;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using Stream stream = assembly.GetManifestResourceStream(text);
				if (stream == null)
				{
					throw new InvalidOperationException("Could not find AFM resource with name: " + text + ".");
				}
				stream.CopyTo(memoryStream);
				bytes = new MemoryInputBytes(memoryStream.ToArray());
			}
			Standard14Cache[fontName] = AdobeFontMetricsParser.Parse(bytes, useReducedDataSet: true);
		}
		catch (Exception innerException)
		{
			throw new InvalidOperationException("Could not load " + fontName + " from the AFM files.", innerException);
		}
	}

	public static UglyToad.PdfPig.Fonts.AdobeFontMetrics.AdobeFontMetrics GetAdobeFontMetrics(string baseName)
	{
		Standard14Cache.TryGetValue(baseName, out UglyToad.PdfPig.Fonts.AdobeFontMetrics.AdobeFontMetrics value);
		return value;
	}

	public static UglyToad.PdfPig.Fonts.AdobeFontMetrics.AdobeFontMetrics GetAdobeFontMetrics(Standard14Font fontType)
	{
		return Standard14Cache[BuilderTypesToNames[fontType]];
	}

	public static bool IsFontInStandard14(string baseName)
	{
		return Standard14Names.Contains(baseName);
	}

	public static HashSet<string> GetNames()
	{
		return new HashSet<string>(Standard14Names);
	}

	public static string GetMappedFontName(string baseName)
	{
		Standard14Mapping.TryGetValue(baseName, out string value);
		return value;
	}
}
