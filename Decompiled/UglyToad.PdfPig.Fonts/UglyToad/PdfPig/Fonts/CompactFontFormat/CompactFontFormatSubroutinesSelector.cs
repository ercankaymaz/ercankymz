using System.Collections.Generic;

namespace UglyToad.PdfPig.Fonts.CompactFontFormat;

internal class CompactFontFormatSubroutinesSelector
{
	private readonly CompactFontFormatIndex global;

	private readonly CompactFontFormatIndex local;

	private readonly bool isCid;

	private readonly ICompactFontFormatFdSelect fdSelect;

	private readonly IReadOnlyList<CompactFontFormatIndex> perFontLocalSubroutines;

	public CompactFontFormatSubroutinesSelector(CompactFontFormatIndex global, CompactFontFormatIndex local)
	{
		this.global = global;
		this.local = local;
	}

	public CompactFontFormatSubroutinesSelector(CompactFontFormatIndex global, CompactFontFormatIndex local, ICompactFontFormatFdSelect fdSelect, IReadOnlyList<CompactFontFormatIndex> perFontLocalSubroutines)
	{
		this.global = global;
		this.local = local;
		this.fdSelect = fdSelect;
		this.perFontLocalSubroutines = perFontLocalSubroutines;
		isCid = true;
	}

	public (CompactFontFormatIndex global, CompactFontFormatIndex local) GetSubroutines(int glyphId)
	{
		if (!isCid)
		{
			return (global: global, local: local);
		}
		int fontDictionaryIndex = fdSelect.GetFontDictionaryIndex(glyphId);
		if (fontDictionaryIndex < 0 || fontDictionaryIndex >= perFontLocalSubroutines.Count)
		{
			return (global: global, local: local);
		}
		CompactFontFormatIndex compactFontFormatIndex = perFontLocalSubroutines[fontDictionaryIndex];
		return (global: global, local: compactFontFormatIndex ?? local);
	}
}
