using System;
using System.Collections.Generic;
using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Fonts.CompactFontFormat;

public class CompactFontFormatFontCollection
{
	public CompactFontFormatHeader Header { get; }

	public IReadOnlyDictionary<string, CompactFontFormatFont> Fonts { get; }

	public CompactFontFormatFont FirstFont { get; }

	public CompactFontFormatFontCollection(CompactFontFormatHeader header, IReadOnlyDictionary<string, CompactFontFormatFont> fontSet)
	{
		Header = header;
		Fonts = fontSet ?? throw new ArgumentNullException("fontSet");
		using IEnumerator<KeyValuePair<string, CompactFontFormatFont>> enumerator = fontSet.GetEnumerator();
		if (enumerator.MoveNext())
		{
			FirstFont = enumerator.Current.Value;
		}
	}

	public TransformationMatrix GetFirstTransformationMatrix()
	{
		using (IEnumerator<KeyValuePair<string, CompactFontFormatFont>> enumerator = Fonts.GetEnumerator())
		{
			if (enumerator.MoveNext())
			{
				return enumerator.Current.Value.FontMatrix;
			}
		}
		return TransformationMatrix.Identity;
	}

	public PdfRectangle? GetCharacterBoundingBox(string characterName)
	{
		return FirstFont.GetCharacterBoundingBox(characterName);
	}

	public string GetCharacterName(int characterCode, bool isCid)
	{
		return FirstFont.GetCharacterName(characterCode, isCid) ?? ".notdef";
	}
}
