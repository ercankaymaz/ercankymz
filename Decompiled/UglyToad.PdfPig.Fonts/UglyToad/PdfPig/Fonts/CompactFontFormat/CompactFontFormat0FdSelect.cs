using System;
using System.Collections.Generic;
using UglyToad.PdfPig.Fonts.CompactFontFormat.Dictionaries;

namespace UglyToad.PdfPig.Fonts.CompactFontFormat;

internal class CompactFontFormat0FdSelect : ICompactFontFormatFdSelect
{
	public RegistryOrderingSupplement RegistryOrderingSupplement { get; }

	public IReadOnlyList<int> FontDictionaries { get; }

	public CompactFontFormat0FdSelect(RegistryOrderingSupplement registryOrderingSupplement, IReadOnlyList<int> fontDictionaries)
	{
		RegistryOrderingSupplement = registryOrderingSupplement ?? throw new ArgumentNullException("registryOrderingSupplement");
		FontDictionaries = fontDictionaries ?? throw new ArgumentNullException("fontDictionaries");
	}

	public int GetFontDictionaryIndex(int glyphId)
	{
		if (glyphId < FontDictionaries.Count && glyphId >= 0)
		{
			return FontDictionaries[glyphId];
		}
		return 0;
	}
}
