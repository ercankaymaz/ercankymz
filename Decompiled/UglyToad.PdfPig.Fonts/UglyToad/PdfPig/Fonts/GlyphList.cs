using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using UglyToad.PdfPig.Fonts.Encodings;
using UglyToad.PdfPig.Util;

namespace UglyToad.PdfPig.Fonts;

public class GlyphList
{
	public const string NotDefined = ".notdef";

	private readonly IReadOnlyDictionary<string, string> nameToUnicode;

	private readonly IReadOnlyDictionary<string, string> unicodeToName;

	private readonly Dictionary<string, string> oddNameToUnicodeCache = new Dictionary<string, string>();

	private static readonly Lazy<GlyphList> LazyAdobeGlyphList = new Lazy<GlyphList>(() => GlyphListFactory.Get("glyphlist", "additional"));

	private static readonly Lazy<GlyphList> LazyZapfDingbatsGlyphList = new Lazy<GlyphList>(() => GlyphListFactory.Get("zapfdingbats"));

	public static GlyphList AdobeGlyphList => LazyAdobeGlyphList.Value;

	public static GlyphList ZapfDingbats => LazyZapfDingbatsGlyphList.Value;

	internal GlyphList(IReadOnlyDictionary<string, string> namesToUnicode)
	{
		nameToUnicode = namesToUnicode;
		Dictionary<string, string> dictionary = new Dictionary<string, string>(namesToUnicode.Count);
		foreach (KeyValuePair<string, string> item in namesToUnicode)
		{
			bool flag = WinAnsiEncoding.Instance.ContainsName(item.Key) || MacRomanEncoding.Instance.ContainsName(item.Key) || MacExpertEncoding.Instance.ContainsName(item.Key) || SymbolEncoding.Instance.ContainsName(item.Key) || ZapfDingbatsEncoding.Instance.ContainsName(item.Key);
			if (!dictionary.ContainsKey(item.Value) || flag)
			{
				dictionary[item.Value] = item.Key;
			}
		}
		unicodeToName = dictionary;
	}

	public string UnicodeCodePointToName(int unicodeValue)
	{
		string key = char.ConvertFromUtf32(unicodeValue);
		if (unicodeToName.TryGetValue(key, out string value))
		{
			return value;
		}
		return ".notdef";
	}

	public string NameToUnicode(string name)
	{
		if (name == null)
		{
			return null;
		}
		if (nameToUnicode.TryGetValue(name, out string value))
		{
			return value;
		}
		if (oddNameToUnicodeCache.TryGetValue(name, out string value2))
		{
			return value2;
		}
		string text;
		if (name.IndexOf('.') > 0)
		{
			text = NameToUnicode(name.Substring(0, name.IndexOf('.')));
		}
		else if (name.IndexOf('_') > 0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			string[] array = name.Split('_');
			foreach (string name2 in array)
			{
				stringBuilder.Append(NameToUnicode(name2));
			}
			text = stringBuilder.ToString();
		}
		else if (name.StartsWith("uni") && (name.Length - 3) % 4 == 0)
		{
			int length = name.Length;
			StringBuilder stringBuilder2 = new StringBuilder();
			for (int j = 3; j + 4 <= length; j += 4)
			{
				if (!int.TryParse(name.AsSpanOrSubstring(j, 4), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var result))
				{
					return null;
				}
				if (result > 55295 && result < 57344)
				{
					throw new InvalidFontFormatException("Unicode character name with disallowed code area: " + name);
				}
				stringBuilder2.Append((char)result);
			}
			text = stringBuilder2.ToString();
		}
		else if (name.StartsWith("u", StringComparison.Ordinal) && name.Length >= 5 && name.Length <= 7)
		{
			int num = int.Parse(name.AsSpanOrSubstring(1), NumberStyles.HexNumber, CultureInfo.InvariantCulture);
			if (num > 55295 && num < 57344)
			{
				throw new InvalidFontFormatException("Unicode character name with disallowed code area: " + name);
			}
			text = char.ConvertFromUtf32(num);
		}
		else
		{
			if (!name.StartsWith("c", StringComparison.OrdinalIgnoreCase) || name.Length < 3 || name.Length > 4)
			{
				return null;
			}
			text = char.ConvertFromUtf32(int.Parse(name.AsSpanOrSubstring(1), NumberStyles.Integer, CultureInfo.InvariantCulture));
		}
		oddNameToUnicodeCache[name] = text;
		return text;
	}
}
