using System;
using System.Collections.Generic;
using System.Linq;

namespace UglyToad.PdfPig.Fonts.CompactFontFormat.Charsets;

internal abstract class CompactFontFormatCharset : ICompactFontFormatCharset
{
	protected readonly IReadOnlyDictionary<int, (int stringId, string name)> GlyphIdToStringIdAndName;

	public bool IsCidCharset { get; }

	protected CompactFontFormatCharset(ReadOnlySpan<(int glyphId, int stringId, string name)> data)
	{
		Dictionary<int, (int, string)> dictionary = new Dictionary<int, (int, string)> { 
		{
			0,
			(0, ".notdef")
		} };
		ReadOnlySpan<(int, int, string)> readOnlySpan = data;
		for (int i = 0; i < readOnlySpan.Length; i++)
		{
			(int, int, string) tuple = readOnlySpan[i];
			dictionary[tuple.Item1] = (tuple.Item2, tuple.Item3);
		}
		GlyphIdToStringIdAndName = dictionary;
	}

	public virtual string GetNameByGlyphId(int glyphId)
	{
		return GlyphIdToStringIdAndName[glyphId].name;
	}

	public virtual string GetNameByStringId(int stringId)
	{
		return GlyphIdToStringIdAndName.FirstOrDefault<KeyValuePair<int, (int, string)>>((KeyValuePair<int, (int stringId, string name)> x) => x.Value.stringId == stringId).Value.Item2;
	}

	public virtual int GetStringIdByGlyphId(int glyphId)
	{
		if (GlyphIdToStringIdAndName.TryGetValue(glyphId, out (int, string) value))
		{
			return value.Item1;
		}
		return 0;
	}

	public int GetGlyphIdByName(string characterName)
	{
		foreach (KeyValuePair<int, (int, string)> item in GlyphIdToStringIdAndName)
		{
			if (string.Equals(item.Value.Item2, characterName, StringComparison.Ordinal))
			{
				return item.Key;
			}
		}
		return 0;
	}
}
