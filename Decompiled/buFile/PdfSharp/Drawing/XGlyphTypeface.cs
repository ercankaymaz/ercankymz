#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using PdfSharp.Fonts;
using PdfSharp.Fonts.OpenType;
using PdfSharp.Internal;

namespace PdfSharp.Drawing;

[DebuggerDisplay("{DebuggerDisplay}")]
internal sealed class XGlyphTypeface
{
	private const string KeyPrefix = "tk:";

	private readonly XFontFamily _fontFamily;

	private readonly OpenTypeFontface _fontface;

	private readonly XFontSource _fontSource;

	private string _faceName;

	private string _familyName;

	private string _styleName;

	private string _displayName;

	private bool _isBold;

	private bool _isItalic;

	private XStyleSimulations _styleSimulations;

	private readonly string _key;

	private readonly Font _gdiFont;

	public XFontFamily FontFamily => _fontFamily;

	internal OpenTypeFontface Fontface => _fontface;

	public XFontSource FontSource => _fontSource;

	internal string FaceName => _faceName;

	public string FamilyName => _familyName;

	public string StyleName => _styleName;

	public string DisplayName => _displayName;

	public bool IsBold => _isBold;

	public bool IsItalic => _isItalic;

	public XStyleSimulations StyleSimulations => _styleSimulations;

	public string Key => _key;

	internal Font GdiFont => _gdiFont;

	internal string DebuggerDisplay => string.Format(CultureInfo.InvariantCulture, "{0} - {1} ({2})", FamilyName, StyleName, FaceName);

	private XGlyphTypeface(string key, XFontFamily fontFamily, XFontSource fontSource, XStyleSimulations styleSimulations, Font gdiFont)
	{
		_key = key;
		_fontFamily = fontFamily;
		_fontSource = fontSource;
		_fontface = OpenTypeFontface.CetOrCreateFrom(fontSource);
		Debug.Assert(_fontSource.Fontface == _fontface);
		_gdiFont = gdiFont;
		_styleSimulations = styleSimulations;
		Initialize();
	}

	public static XGlyphTypeface GetOrCreateFrom(string familyName, FontResolvingOptions fontResolvingOptions)
	{
		string text = ComputeKey(familyName, fontResolvingOptions);
		XGlyphTypeface glyphTypeface;
		try
		{
			Lock.EnterFontFactory();
			if (GlyphTypefaceCache.TryGetGlyphTypeface(text, out glyphTypeface))
			{
				return glyphTypeface;
			}
			FontResolverInfo fontResolverInfo = FontFactory.ResolveTypeface(familyName, fontResolvingOptions, text);
			if (fontResolverInfo == null)
			{
				throw new InvalidOperationException("No appropriate font found.");
			}
			Font font = null;
			XFontFamily fontFamily;
			if (fontResolverInfo is PlatformFontResolverInfo platformFontResolverInfo)
			{
				font = platformFontResolverInfo.GdiFont;
				fontFamily = XFontFamily.GetOrCreateFromGdi(font);
			}
			else
			{
				fontFamily = XFontFamily.GetOrCreateFontFamily(familyName);
			}
			XFontSource fontSourceByFontName = FontFactory.GetFontSourceByFontName(fontResolverInfo.FaceName);
			Debug.Assert(fontSourceByFontName != null);
			glyphTypeface = new XGlyphTypeface(text, fontFamily, fontSourceByFontName, fontResolverInfo.StyleSimulations, font);
			GlyphTypefaceCache.AddGlyphTypeface(glyphTypeface);
		}
		finally
		{
			Lock.ExitFontFactory();
		}
		return glyphTypeface;
	}

	public static XGlyphTypeface GetOrCreateFromGdi(Font gdiFont)
	{
		string text = ComputeKey(gdiFont);
		if (GlyphTypefaceCache.TryGetGlyphTypeface(text, out var glyphTypeface))
		{
			return glyphTypeface;
		}
		XFontFamily orCreateFromGdi = XFontFamily.GetOrCreateFromGdi(gdiFont);
		XFontSource orCreateFromGdi2 = XFontSource.GetOrCreateFromGdi(text, gdiFont);
		XStyleSimulations xStyleSimulations = XStyleSimulations.None;
		if (gdiFont.Bold && !orCreateFromGdi2.Fontface.os2.IsBold)
		{
			xStyleSimulations |= XStyleSimulations.BoldSimulation;
		}
		if (gdiFont.Italic && !orCreateFromGdi2.Fontface.os2.IsItalic)
		{
			xStyleSimulations |= XStyleSimulations.ItalicSimulation;
		}
		glyphTypeface = new XGlyphTypeface(text, orCreateFromGdi, orCreateFromGdi2, xStyleSimulations, gdiFont);
		GlyphTypefaceCache.AddGlyphTypeface(glyphTypeface);
		return glyphTypeface;
	}

	private void Initialize()
	{
		_familyName = _fontface.name.Name;
		if (string.IsNullOrEmpty(_faceName) || _faceName.StartsWith("?"))
		{
			_faceName = _familyName;
		}
		_styleName = _fontface.name.Style;
		_displayName = _fontface.name.FullFontName;
		if (string.IsNullOrEmpty(_displayName))
		{
			_displayName = _familyName;
			if (string.IsNullOrEmpty(_styleName))
			{
				_displayName = _displayName + " (" + _styleName + ")";
			}
		}
		_isBold = _fontface.os2.IsBold;
		_isItalic = _fontface.os2.IsItalic;
	}

	private string GetFaceNameSuffix()
	{
		if (IsBold)
		{
			return IsItalic ? ",BoldItalic" : ",Bold";
		}
		return IsItalic ? ",Italic" : "";
	}

	internal string GetBaseName()
	{
		string text = DisplayName;
		int num = text.IndexOf("bold", StringComparison.OrdinalIgnoreCase);
		if (num > 0)
		{
			text = text.Substring(0, num) + text.Substring(num + 4, text.Length - num - 4);
		}
		num = text.IndexOf("italic", StringComparison.OrdinalIgnoreCase);
		if (num > 0)
		{
			text = text.Substring(0, num) + text.Substring(num + 6, text.Length - num - 6);
		}
		text = text.Trim();
		return text + GetFaceNameSuffix();
	}

	internal static string ComputeKey(string familyName, FontResolvingOptions fontResolvingOptions)
	{
		string text = "";
		if (fontResolvingOptions.OverrideStyleSimulations)
		{
			switch (fontResolvingOptions.StyleSimulations)
			{
			case XStyleSimulations.BoldSimulation:
				text = "|b+/i-";
				break;
			case XStyleSimulations.ItalicSimulation:
				text = "|b-/i+";
				break;
			case XStyleSimulations.BoldItalicSimulation:
				text = "|b+/i+";
				break;
			default:
				throw new ArgumentOutOfRangeException("fontResolvingOptions");
			case XStyleSimulations.None:
				break;
			}
		}
		return "tk:" + familyName.ToLowerInvariant() + (fontResolvingOptions.IsItalic ? "/i" : "/n") + (fontResolvingOptions.IsBold ? "/700" : "/400") + "/5" + text;
	}

	internal static string ComputeKey(string familyName, bool isBold, bool isItalic)
	{
		return ComputeKey(familyName, new FontResolvingOptions(FontHelper.CreateStyle(isBold, isItalic)));
	}

	internal static string ComputeKey(Font gdiFont)
	{
		string name = gdiFont.Name;
		string originalFontName = gdiFont.OriginalFontName;
		string systemFontName = gdiFont.SystemFontName;
		string text = name;
		FontStyle style = gdiFont.Style;
		return "tk:" + text.ToLowerInvariant() + (((style & FontStyle.Italic) == FontStyle.Italic) ? "/i" : "/n") + (((style & FontStyle.Bold) == FontStyle.Bold) ? "/700" : "/400") + "/5";
	}
}
