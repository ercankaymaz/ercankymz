#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using PdfSharp.Drawing;
using PdfSharp.Fonts.OpenType;
using PdfSharp.Internal;

namespace PdfSharp.Fonts;

internal static class FontFactory
{
	private static readonly Dictionary<string, FontResolverInfo> FontResolverInfosByName = new Dictionary<string, FontResolverInfo>(StringComparer.OrdinalIgnoreCase);

	private static readonly Dictionary<string, XFontSource> FontSourcesByName = new Dictionary<string, XFontSource>(StringComparer.OrdinalIgnoreCase);

	private static readonly Dictionary<ulong, XFontSource> FontSourcesByKey = new Dictionary<ulong, XFontSource>();

	public static bool HasFontSources => FontSourcesByName.Count > 0;

	public static FontResolverInfo ResolveTypeface(string familyName, FontResolvingOptions fontResolvingOptions, string typefaceKey)
	{
		if (string.IsNullOrEmpty(typefaceKey))
		{
			typefaceKey = XGlyphTypeface.ComputeKey(familyName, fontResolvingOptions);
		}
		try
		{
			Lock.EnterFontFactory();
			if (FontResolverInfosByName.TryGetValue(typefaceKey, out var value))
			{
				return value;
			}
			IFontResolver fontResolver = GlobalFontSettings.FontResolver;
			if (fontResolver != null)
			{
				value = fontResolver.ResolveTypeface(familyName, fontResolvingOptions.IsBold, fontResolvingOptions.IsItalic);
				if (value != null && !(value is PlatformFontResolverInfo))
				{
					if (fontResolvingOptions.OverrideStyleSimulations)
					{
						value = new FontResolverInfo(value.FaceName, fontResolvingOptions.MustSimulateBold, fontResolvingOptions.MustSimulateItalic, value.CollectionNumber);
					}
					string key = value.Key;
					if (FontResolverInfosByName.TryGetValue(key, out var value2))
					{
						value = value2;
						FontResolverInfosByName.Add(typefaceKey, value);
						Debug.Assert(FontSourcesByName.ContainsKey(value.FaceName));
					}
					else
					{
						FontResolverInfosByName.Add(typefaceKey, value);
						Debug.Assert(key == value.Key);
						FontResolverInfosByName.Add(key, value);
						if (!FontSourcesByName.TryGetValue(value.FaceName, out var _))
						{
							byte[] font = fontResolver.GetFont(value.FaceName);
							XFontSource orCreateFrom = XFontSource.GetOrCreateFrom(font);
							if (string.Compare(value.FaceName, orCreateFrom.FontName, StringComparison.OrdinalIgnoreCase) != 0)
							{
								FontSourcesByName.Add(value.FaceName, orCreateFrom);
							}
						}
					}
				}
			}
			else
			{
				value = PlatformFontResolver.ResolveTypeface(familyName, fontResolvingOptions, typefaceKey);
			}
			return value;
		}
		finally
		{
			Lock.ExitFontFactory();
		}
	}

	public static XFontSource GetFontSourceByFontName(string fontName)
	{
		if (FontSourcesByName.TryGetValue(fontName, out var value))
		{
			return value;
		}
		Debug.Assert(condition: false, $"An XFontSource with the name '{fontName}' does not exists.");
		return null;
	}

	public static XFontSource GetFontSourceByTypefaceKey(string typefaceKey)
	{
		if (FontSourcesByName.TryGetValue(typefaceKey, out var value))
		{
			return value;
		}
		Debug.Assert(condition: false, $"An XFontSource with the typeface key '{typefaceKey}' does not exists.");
		return null;
	}

	public static bool TryGetFontSourceByKey(ulong key, out XFontSource fontSource)
	{
		return FontSourcesByKey.TryGetValue(key, out fontSource);
	}

	public static bool TryGetFontResolverInfoByTypefaceKey(string typeFaceKey, out FontResolverInfo info)
	{
		return FontResolverInfosByName.TryGetValue(typeFaceKey, out info);
	}

	public static bool TryGetFontSourceByTypefaceKey(string typefaceKey, out XFontSource source)
	{
		return FontSourcesByName.TryGetValue(typefaceKey, out source);
	}

	internal static void CacheFontResolverInfo(string typefaceKey, FontResolverInfo fontResolverInfo)
	{
		if (FontResolverInfosByName.TryGetValue(typefaceKey, out var value))
		{
			throw new InvalidOperationException($"A font file with different content already exists with the specified face name '{typefaceKey}'.");
		}
		if (FontResolverInfosByName.TryGetValue(fontResolverInfo.Key, out value))
		{
			throw new InvalidOperationException($"A font resolver already exists with the specified key '{fontResolverInfo.Key}'.");
		}
		FontResolverInfosByName.Add(typefaceKey, fontResolverInfo);
		FontResolverInfosByName.Add(fontResolverInfo.Key, fontResolverInfo);
	}

	public static XFontSource CacheFontSource(XFontSource fontSource)
	{
		try
		{
			Lock.EnterFontFactory();
			if (FontSourcesByKey.TryGetValue(fontSource.Key, out var value))
			{
				int num = fontSource.Bytes.Length;
				for (int i = 0; i < num && value.Bytes[i] == fontSource.Bytes[i]; i++)
				{
				}
				Debug.Assert(value.Fontface != null);
				return value;
			}
			OpenTypeFontface fontface = fontSource.Fontface;
			if (fontface == null)
			{
				fontSource.Fontface = new OpenTypeFontface(fontSource);
			}
			FontSourcesByKey.Add(fontSource.Key, fontSource);
			FontSourcesByName.Add(fontSource.FontName, fontSource);
			return fontSource;
		}
		finally
		{
			Lock.ExitFontFactory();
		}
	}

	public static XFontSource CacheNewFontSource(string typefaceKey, XFontSource fontSource)
	{
		if (FontSourcesByKey.TryGetValue(fontSource.Key, out var value))
		{
			return value;
		}
		OpenTypeFontface fontface = fontSource.Fontface;
		if (fontface == null)
		{
			fontface = new OpenTypeFontface(fontSource);
			fontSource.Fontface = fontface;
		}
		FontSourcesByName.Add(typefaceKey, fontSource);
		FontSourcesByName.Add(fontSource.FontName, fontSource);
		FontSourcesByKey.Add(fontSource.Key, fontSource);
		return fontSource;
	}

	public static void CacheExistingFontSourceWithNewTypefaceKey(string typefaceKey, XFontSource fontSource)
	{
		try
		{
			Lock.EnterFontFactory();
			FontSourcesByName.Add(typefaceKey, fontSource);
		}
		finally
		{
			Lock.ExitFontFactory();
		}
	}

	internal static string GetFontCachesState()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("====================\n");
		stringBuilder.Append("Font resolver info by name\n");
		Dictionary<string, FontResolverInfo>.KeyCollection keys = FontResolverInfosByName.Keys;
		int count = keys.Count;
		string[] array = new string[count];
		keys.CopyTo(array, 0);
		Array.Sort(array, StringComparer.OrdinalIgnoreCase);
		string[] array2 = array;
		foreach (string text in array2)
		{
			stringBuilder.AppendFormat("  {0}: {1}\n", text, FontResolverInfosByName[text].DebuggerDisplay);
		}
		stringBuilder.Append("\n");
		stringBuilder.Append("Font source by key and name\n");
		Dictionary<ulong, XFontSource>.KeyCollection keys2 = FontSourcesByKey.Keys;
		count = keys2.Count;
		ulong[] array3 = new ulong[count];
		keys2.CopyTo(array3, 0);
		Array.Sort(array3, (ulong x, ulong y) => (x != y) ? ((x > y) ? 1 : (-1)) : 0);
		ulong[] array4 = array3;
		foreach (ulong num2 in array4)
		{
			stringBuilder.AppendFormat("  {0}: {1}\n", num2, FontSourcesByKey[num2].DebuggerDisplay);
		}
		Dictionary<string, XFontSource>.KeyCollection keys3 = FontSourcesByName.Keys;
		count = keys3.Count;
		array = new string[count];
		keys3.CopyTo(array, 0);
		Array.Sort(array, StringComparer.OrdinalIgnoreCase);
		string[] array5 = array;
		foreach (string text2 in array5)
		{
			stringBuilder.AppendFormat("  {0}: {1}\n", text2, FontSourcesByName[text2].DebuggerDisplay);
		}
		stringBuilder.Append("--------------------\n\n");
		stringBuilder.Append(FontFamilyCache.GetCacheState());
		stringBuilder.Append(GlyphTypefaceCache.GetCacheState());
		stringBuilder.Append(OpenTypeFontfaceCache.GetCacheState());
		return stringBuilder.ToString();
	}
}
