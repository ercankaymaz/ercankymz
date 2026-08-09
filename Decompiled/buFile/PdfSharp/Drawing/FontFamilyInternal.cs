using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using PdfSharp.Internal;

namespace PdfSharp.Drawing;

[DebuggerDisplay("{DebuggerDisplay}")]
internal class FontFamilyInternal
{
	private readonly string _sourceName;

	private readonly string _name;

	private readonly FontFamily _gdiFontFamily;

	public string SourceName => _sourceName;

	public string Name => _name;

	public FontFamily GdiFamily => _gdiFontFamily;

	internal string DebuggerDisplay => string.Format(CultureInfo.InvariantCulture, "FontFamily: '{0}'", Name);

	private FontFamilyInternal(string familyName, bool createPlatformObjects)
	{
		_sourceName = (_name = familyName);
		if (createPlatformObjects)
		{
			_gdiFontFamily = new FontFamily(familyName);
			_name = _gdiFontFamily.Name;
		}
	}

	private FontFamilyInternal(FontFamily gdiFontFamily)
	{
		_sourceName = (_name = gdiFontFamily.Name);
		_gdiFontFamily = gdiFontFamily;
	}

	internal static FontFamilyInternal GetOrCreateFromName(string familyName, bool createPlatformObject)
	{
		try
		{
			Lock.EnterFontFactory();
			FontFamilyInternal fontFamilyInternal = FontFamilyCache.GetFamilyByName(familyName);
			if (fontFamilyInternal == null)
			{
				fontFamilyInternal = new FontFamilyInternal(familyName, createPlatformObject);
				fontFamilyInternal = FontFamilyCache.CacheOrGetFontFamily(fontFamilyInternal);
			}
			return fontFamilyInternal;
		}
		finally
		{
			Lock.ExitFontFactory();
		}
	}

	internal static FontFamilyInternal GetOrCreateFromGdi(FontFamily gdiFontFamily)
	{
		try
		{
			Lock.EnterFontFactory();
			FontFamilyInternal fontFamily = new FontFamilyInternal(gdiFontFamily);
			return FontFamilyCache.CacheOrGetFontFamily(fontFamily);
		}
		finally
		{
			Lock.ExitFontFactory();
		}
	}
}
