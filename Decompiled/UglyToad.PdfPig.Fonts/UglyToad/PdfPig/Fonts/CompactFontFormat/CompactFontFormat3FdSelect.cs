using System;
using System.Collections.Generic;
using UglyToad.PdfPig.Fonts.CompactFontFormat.Dictionaries;

namespace UglyToad.PdfPig.Fonts.CompactFontFormat;

internal class CompactFontFormat3FdSelect : ICompactFontFormatFdSelect
{
	internal readonly struct Range3
	{
		public int First { get; }

		public int FontDictionary { get; }

		public Range3(int first, int fontDictionary)
		{
			First = first;
			FontDictionary = fontDictionary;
		}

		public override string ToString()
		{
			return $"First {First}, Dictionary {FontDictionary}.";
		}
	}

	public RegistryOrderingSupplement RegistryOrderingSupplement { get; }

	public IReadOnlyList<Range3> Ranges { get; }

	public int Sentinel { get; }

	public CompactFontFormat3FdSelect(RegistryOrderingSupplement registryOrderingSupplement, IReadOnlyList<Range3> ranges, int sentinel)
	{
		RegistryOrderingSupplement = registryOrderingSupplement ?? throw new ArgumentNullException("registryOrderingSupplement");
		Ranges = ranges ?? throw new ArgumentNullException("ranges");
		Sentinel = sentinel;
	}

	public int GetFontDictionaryIndex(int glyphId)
	{
		for (int i = 0; i < Ranges.Count; i++)
		{
			if (Ranges[i].First > glyphId)
			{
				continue;
			}
			if (i + 1 < Ranges.Count)
			{
				if (Ranges[i + 1].First > glyphId)
				{
					return Ranges[i].FontDictionary;
				}
				continue;
			}
			if (Sentinel > glyphId)
			{
				return Ranges[i].FontDictionary;
			}
			return -1;
		}
		return 0;
	}
}
