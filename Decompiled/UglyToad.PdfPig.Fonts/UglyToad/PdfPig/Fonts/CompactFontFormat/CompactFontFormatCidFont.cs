using System.Collections.Generic;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Fonts.CompactFontFormat.CharStrings;
using UglyToad.PdfPig.Fonts.CompactFontFormat.Charsets;
using UglyToad.PdfPig.Fonts.CompactFontFormat.Dictionaries;
using UglyToad.PdfPig.Fonts.Type1.CharStrings;

namespace UglyToad.PdfPig.Fonts.CompactFontFormat;

internal sealed class CompactFontFormatCidFont : CompactFontFormatFont
{
	public IReadOnlyList<CompactFontFormatTopLevelDictionary> FontDictionaries { get; }

	public IReadOnlyList<CompactFontFormatPrivateDictionary> PrivateDictionaries { get; }

	public ICompactFontFormatFdSelect FdSelect { get; }

	public CompactFontFormatCidFont(CompactFontFormatTopLevelDictionary topDictionary, CompactFontFormatPrivateDictionary privateDictionary, ICompactFontFormatCharset charset, Union<Type1CharStrings, Type2CharStrings> charStrings, IReadOnlyList<CompactFontFormatTopLevelDictionary> fontDictionaries, IReadOnlyList<CompactFontFormatPrivateDictionary> privateDictionaries, ICompactFontFormatFdSelect fdSelect)
		: base(topDictionary, privateDictionary, charset, charStrings, null)
	{
		FontDictionaries = fontDictionaries;
		PrivateDictionaries = privateDictionaries;
		FdSelect = fdSelect;
	}

	protected override double GetDefaultWidthX(string characterName)
	{
		if (!TryGetPrivateDictionaryForCharacter(characterName, out CompactFontFormatPrivateDictionary dictionary))
		{
			return 1000.0;
		}
		return dictionary.DefaultWidthX;
	}

	protected override double GetNominalWidthX(string characterName)
	{
		if (!TryGetPrivateDictionaryForCharacter(characterName, out CompactFontFormatPrivateDictionary dictionary))
		{
			return 0.0;
		}
		return dictionary.NominalWidthX;
	}

	public override TransformationMatrix? GetFontMatrix(string characterName)
	{
		CompactFontFormatTopLevelDictionary dictionary;
		bool flag = TryGetFontDictionaryForCharacter(characterName, out dictionary);
		if (base.TopDictionary.FontMatrix.HasValue && flag && dictionary.FontMatrix.HasValue)
		{
			return base.TopDictionary.FontMatrix.Value.Multiply(dictionary.FontMatrix.Value);
		}
		if (base.TopDictionary.FontMatrix.HasValue)
		{
			return base.TopDictionary.FontMatrix;
		}
		if (flag && dictionary.FontMatrix.HasValue)
		{
			return dictionary.FontMatrix;
		}
		return null;
	}

	private bool TryGetPrivateDictionaryForCharacter(string characterName, out CompactFontFormatPrivateDictionary dictionary)
	{
		dictionary = null;
		int glyphIdByName = base.Charset.GetGlyphIdByName(characterName);
		int fontDictionaryIndex = FdSelect.GetFontDictionaryIndex(glyphIdByName);
		if (fontDictionaryIndex == -1)
		{
			return false;
		}
		dictionary = PrivateDictionaries[fontDictionaryIndex];
		return true;
	}

	private bool TryGetFontDictionaryForCharacter(string characterName, out CompactFontFormatTopLevelDictionary dictionary)
	{
		dictionary = null;
		int glyphIdByName = base.Charset.GetGlyphIdByName(characterName);
		int fontDictionaryIndex = FdSelect.GetFontDictionaryIndex(glyphIdByName);
		if (fontDictionaryIndex == -1)
		{
			return false;
		}
		dictionary = FontDictionaries[fontDictionaryIndex];
		return true;
	}
}
