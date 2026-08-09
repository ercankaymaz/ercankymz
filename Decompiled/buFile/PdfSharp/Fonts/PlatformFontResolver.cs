#define DEBUG
using System.Diagnostics;
using System.Drawing;
using PdfSharp.Drawing;

namespace PdfSharp.Fonts;

public static class PlatformFontResolver
{
	public static FontResolverInfo ResolveTypeface(string familyName, bool isBold, bool isItalic)
	{
		FontResolvingOptions fontResolvingOptions = new FontResolvingOptions(FontHelper.CreateStyle(isBold, isItalic));
		return ResolveTypeface(familyName, fontResolvingOptions, XGlyphTypeface.ComputeKey(familyName, fontResolvingOptions));
	}

	internal static FontResolverInfo ResolveTypeface(string familyName, FontResolvingOptions fontResolvingOptions, string typefaceKey)
	{
		if (string.IsNullOrEmpty(typefaceKey))
		{
			typefaceKey = XGlyphTypeface.ComputeKey(familyName, fontResolvingOptions);
		}
		if (FontFactory.TryGetFontResolverInfoByTypefaceKey(typefaceKey, out var info))
		{
			return info;
		}
		Font font;
		XFontSource xFontSource = CreateFontSource(familyName, fontResolvingOptions, out font, typefaceKey);
		if (xFontSource == null)
		{
			return null;
		}
		if (fontResolvingOptions.OverrideStyleSimulations)
		{
			info = new PlatformFontResolverInfo(typefaceKey, fontResolvingOptions.MustSimulateBold, fontResolvingOptions.MustSimulateItalic, font);
		}
		else
		{
			bool mustSimulateBold = font.Bold && !xFontSource.Fontface.os2.IsBold;
			bool mustSimulateItalic = font.Italic && !xFontSource.Fontface.os2.IsItalic;
			info = new PlatformFontResolverInfo(typefaceKey, mustSimulateBold, mustSimulateItalic, font);
		}
		FontFactory.CacheFontResolverInfo(typefaceKey, info);
		return info;
	}

	internal static XFontSource CreateFontSource(string familyName, FontResolvingOptions fontResolvingOptions, out Font font, string typefaceKey)
	{
		if (string.IsNullOrEmpty(typefaceKey))
		{
			typefaceKey = XGlyphTypeface.ComputeKey(familyName, fontResolvingOptions);
		}
		FontStyle style = (FontStyle)(fontResolvingOptions.FontStyle & XFontStyle.BoldItalic);
		font = FontHelper.CreateFont(familyName, 10.0, style, out var fontSource);
		if (fontSource != null)
		{
			Debug.Assert(font != null);
			Debug.Assert(FontFactory.TryGetFontSourceByTypefaceKey(typefaceKey, out var source) && fontSource == source);
			return fontSource;
		}
		return XFontSource.GetOrCreateFromGdi(typefaceKey, font);
	}
}
